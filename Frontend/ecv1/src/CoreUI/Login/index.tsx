import './index.scss';
import { isLogin, login } from '../../Freature/authSlide';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { toast } from 'react-toastify';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { isLoading } from '../../Freature/Loading/loadSlice';
import BeatLoader from 'react-spinners/BeatLoader';
import { css } from '@emotion/react';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';

const schema = yup.object().shape({
  username: yup.string().required('Tài khoản không được để trống'),
  password: yup
    .string()
    .required('Mật khẩu không được để trống')
    .max(24, 'Mật khẩu không được quá 20 ký tự'),
});

interface ILoginForm {
  username: string;
  password: string;
  
}

export const Login = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const loading = useAppSelector(isLoading);
  const isAuth = useAppSelector(isLogin);

  useEffect(() => {
    if (isAuth) {
      navigate('/');
    }
  },[]);

  const handleLoginClick = async (data: ILoginForm) => {
    try {
      await dispatch(
        login({
          username: data.username,
          password: data.password,
        })
      ).unwrap();
      toast('Đăng nhập thành công', {
        type: 'success',
      });
    } catch (error: any) {
      toast.error(error.desc);
    }
  };

  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm<ILoginForm>({
    resolver: yupResolver(schema),
  });

  const flex = css`
    display: flex;
    margin: 0 auto;
  `;

  return (
    <div
      className={
        'loginForm min-h-screen bg-right bg-cover bg-no-repeat flex justify-center items-center'
      }
    >
      <form
        onSubmit={handleSubmit(handleLoginClick)}
        className={
          'bg-[#ffffff3b] min-w-[90%] md:min-w-[400px] min-h-[480px] rounded-lg text-white p-5 shadow-lg'
        }
      >
        <h1
          className={
            'text-center font-extrabold text-3xl border-b-2 border-b-white py-3'
          }
        >
          Đăng nhập
        </h1>
        <div className="form-control w-full mt-5 font-medium">
          <label className="label">
            <span className="label-text text-white text-xl font-medium">
              Tên đăng nhập
            </span>
          </label>
          <input
            {...register('username')}
            type="text"
            placeholder="Tên tài khoản"
            className="input input-bordered w-full text-black text-md focus:ring-2 focus:ring-blue-500"
          />
          <span className={'text-red-500 font-medium text-sm mt-2'}>
            {errors.username?.message}
          </span>
        </div>
        <div className="form-control w-full mt-2">
          <label className="label">
            <span className="label-text text-white text-xl font-medium">
              Mật khẩu
            </span>
          </label>
          <input
            {...register('password')}
            type="password"
            placeholder="Mật khẩu"
            className="input input-bordered w-full text-black focus:ring-2 focus:ring-blue-500"
          />
          <span className={'text-red-500 font-medium text-sm mt-2'}>
            {errors.password?.message}
          </span>
        </div>
        <button
          className={
            'bg-gradient-to-r from-cyan-500 to-blue-500 text-white font-bold py-2 px-4 rounded-lg mt-5 text-center w-full flex justify-center items-center'
          }
          type="submit"
          disabled={loading}
        >
          {loading ? (
            <BeatLoader
              color={'#ffffff'}
              loading={loading}
              css={flex}
              size={20}
            />
          ) : (
            <span className="text-white">Đăng nhập</span>
          )}
        </button>
      </form>
    </div>
  );
};
