using Data.Defined.Enum;
using Data.Interface;
using Data.Tables;
using Data.Types;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class ClassService : IClassService
    {
        private readonly ECV1DevContext _context;
        public ClassService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<ClassResult> CreateAsync(ClassInput create)
        {
            var lophoc = new Class
            {
                Classname = create.ClassName,
                StartTime = create.StartTime,
                EndTime = create.EndTime,
                Status = Status.Active,
                LinkGgmeet = create.LinkGGMeet,
                IdCourse = create.IdCourse,
            };
            await _context.Classes.AddAsync(lophoc);
            await _context.SaveChangesAsync();
            var result = await _context.Classes.Where(e => e.IdCourse == lophoc.IdCourse && e.Status ==Status.Active)
                .Include(e => e.IdCourseNavigation)
                .Select(e => new ClassResult
                {
                    Id = e.Id,
                    ClassName = e.Classname,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    LinkGGMeet = e.LinkGgmeet,
                    IdCourse = e.IdCourse,
                    Courses = new Course
                    {
                        Id = e.IdCourseNavigation.Id,
                        Coursename = e.IdCourseNavigation.Coursename,
                        DayStart = e.IdCourseNavigation.DayStart,
                        DayEnd = e.IdCourseNavigation.DayEnd,
                        Level = e.IdCourseNavigation.Level,
                        Price = e.IdCourseNavigation.Price,
                        Status = e.IdCourseNavigation.Status
                    }
                }).FirstAsync();
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var lophoc = await _context.Classes
                .Where(e => e.Id == id && e.Status != Status.Deleted)
                .FirstOrDefaultAsync();
            if(lophoc != null)
            {
                lophoc.Status = Status.Deleted;
            }    
            else
            {
                throw new Exception("Không tìm thấy id");
            }    
        }

        public async Task<List<ClassResult>> GetAllAsync()
        {
            var lophocs = await _context.Classes.Where(e => e.Status == Status.Active)
                .Include(e => e.IdCourseNavigation)
                .Select(e => new ClassResult
                {
                    Id =e.Id,
                    ClassName =e.Classname,
                    StartTime=e.StartTime,
                    EndTime =e.EndTime,
                    LinkGGMeet = e.LinkGgmeet,
                    IdCourse =e.IdCourse,
                    Courses = new Course
                    {
                        Id = e.IdCourseNavigation.Id,
                        Coursename = e.IdCourseNavigation.Coursename,
                        DayStart = e.IdCourseNavigation.DayStart,
                        DayEnd = e.IdCourseNavigation.DayEnd,
                        Level = e.IdCourseNavigation.Level,
                        Price = e.IdCourseNavigation.Price,
                        Status = e.IdCourseNavigation.Status
                    }
                }
                ).ToListAsync();
            return lophocs;
        }

        public async Task<ClassResult> GetAsync(int id)
        {
            var lophoc = await _context.Classes.Where(e => e.Id == id && e.Status == Status.Active)
                .Include(e => e.IdCourseNavigation)
                .Select(e => new ClassResult
                {
                    Id = e.Id,
                    ClassName = e.Classname,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    LinkGGMeet = e.LinkGgmeet,
                    IdCourse = e.IdCourse,
                    Courses = new Course
                    {
                        Id = e.IdCourseNavigation.Id,
                        Coursename = e.IdCourseNavigation.Coursename,
                        DayStart = e.IdCourseNavigation.DayStart,
                        DayEnd = e.IdCourseNavigation.DayEnd,
                        Level = e.IdCourseNavigation.Level,
                        Price = e.IdCourseNavigation.Price,
                        Status = e.IdCourseNavigation.Status
                    }
                }).FirstAsync();
            if(lophoc == null)
            {
                throw new Exception("Không tìm thấy id");
            }
            return lophoc;
        }

        public async Task<ClassResult> UpdateAsync(int id, ClassInput update)
        {
            var lophoc = await _context.Classes.Where(e => e.Id == id && e.Status == Status.Active)
                .FirstOrDefaultAsync();
            if(lophoc !=null)
            {
                lophoc.Classname = update.ClassName ?? lophoc.Classname;
                lophoc.StartTime = update.StartTime ?? lophoc.StartTime;
                lophoc.EndTime = update.EndTime ?? lophoc.EndTime;
                lophoc.LinkGgmeet = update.LinkGGMeet ?? lophoc.LinkGgmeet;
            }else
            {
                throw new Exception("Không tìm thấy id");
            }
            await _context.SaveChangesAsync();
            return new ClassResult
            {
                Id = lophoc.Id,
                ClassName = lophoc.Classname,
                StartTime = lophoc.StartTime,
                EndTime = lophoc.EndTime,
                LinkGGMeet = lophoc.LinkGgmeet,
                IdCourse = lophoc.IdCourse,
                Courses = new Course
                {
                    Id = lophoc.IdCourseNavigation.Id,
                    Coursename = lophoc.IdCourseNavigation.Coursename,
                    DayStart = lophoc.IdCourseNavigation.DayStart,
                    DayEnd = lophoc.IdCourseNavigation.DayEnd,
                    Level = lophoc.IdCourseNavigation.Level,
                    Price = lophoc.IdCourseNavigation.Price,
                    Status = lophoc.IdCourseNavigation.Status
                }
            };
        }
    }
}
