using Data.Interface;
using Data.Types;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class AuthService : IAutheService
    {
        private readonly ECV1DevContext _context;
        private readonly ITokenService _tokenService;
        public AuthService(ECV1DevContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task ChangePasswod(int id, ChangePassword req)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Tài khoản không tồn tại");
            }
            if (req.NewPassword != req.ConfirmPassword)
            {
                throw new System.InvalidOperationException($"Confirm Password không đúng!!!");
            }
            if ((!string.IsNullOrEmpty(req.NewPassword) || !string.IsNullOrWhiteSpace(req.NewPassword)) &&
                        (!string.IsNullOrEmpty(req.OldPassword) || !string.IsNullOrWhiteSpace(req.OldPassword)))
            {
                var currPass = req.OldPassword;

                if (currPass != user.Password)
                {
                    throw new System.InvalidOperationException($"Nhập sai mật khẩu cũ");
                }

                var newPass = req.NewPassword;

                user.Password = newPass;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetMe(int id)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                switch(user.Role)
                {
                    case Defined.Enum.RoleEnum.Admin:
                        return $"Quản trị viên";
                    case Defined.Enum.RoleEnum.Manager:
                        try
                        {
                            var manager = _context.Managers.Where(e => e.IdAccountNavigation.Id == user.Id).FirstOrDefault();
                            if(manager != null)
                            {
                                return $"{manager.Name}";
                            }    
                            else
                            {
                                throw new Exception("Manager is Null");
                            }    
                        }catch
                        {
                            throw new Exception("Lỗi đăng nhập quản lý viên");
                        }
                    case Defined.Enum.RoleEnum.Teacher:
                        try
                        {
                            var teacher = _context.Teachers.Where(e => e.IdAccountNavigation.Id == user.Id).FirstOrDefault();
                            if (teacher != null)
                            {
                                return $"{teacher.Name}";
                            }
                            else
                            {
                                throw new Exception("Teacher is Null");
                            }
                        }
                        catch
                        {
                            throw new Exception("Lỗi đăng nhập Giáo viên");
                        }
                    case Defined.Enum.RoleEnum.Student:
                        try
                        {
                            var student = _context.Students.Where(e => e.IdAccountNavigation.Id == user.Id).FirstOrDefault();
                            if (student != null)
                            {
                                return $"{student.Name}";
                            }
                            else
                            {
                                throw new Exception("Student is Null");
                            }
                        }
                        catch
                        {
                            throw new Exception("Lỗi đăng nhập học viên");
                        }
                }    
            }

            throw new NotImplementedException();
        }

        public Task<AuthTypeResult> Login(AuthTypeInput input)
        {
            var acc = _context.Accounts.FirstOrDefault(x => x.Uid == input.Username);
            if (acc == null)
            {
                throw new Exception("Người dùng không tồn tại");
            }
            if(acc.Password.Replace(" ", "") != input.Password)
            {
                throw new Exception("Mật khẩu không đúng");
            }
            var token = _tokenService.GenerateToken(new GenerateRefreshTokenInput()
            {
                Username = input.Username,
                IpAddress = input.IpAddress,
                UserId = acc.Uid.ToString(),

            });
            return token;
        }
    }
}
