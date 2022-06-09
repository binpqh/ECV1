import React, { useEffect } from 'react'
import Modal from 'react-bootstrap/esm/Modal';
import { useNavigate } from 'react-router-dom';
import '../App.scss'
import * as yup from 'yup';
import { useForm } from 'react-hook-form';
import { useAppDispatch, useAppSelector } from '../app/hooks';
import { isLogin, login } from '../Freature/authSlide';
import { isLoading } from '../Freature/Loading/loadSlice';
import { toast } from 'react-toastify';
import { yupResolver } from '@hookform/resolvers/yup';
import { ILoginInput } from '../Interfaces';

const schema = yup.object().shape({
  username: yup.string().required('Tài khoản không được để trống'),
  password: yup
    .string()
    .required('Mật khẩu không được để trống')
    .max(24, 'Mật khẩu không được quá 20 ký tự'),
    
});
const Navbar = () => {
  const [isOpenLogin, setIsOpenLogin] = React.useState(false);
  const [isOpenRegister,setIsOpenRegister] = React.useState(false);

  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const loading = useAppSelector(isLoading);
  const isAuth = useAppSelector(isLogin);

  useEffect(() => {
    if (isAuth) {
      navigate('/');
    }
  },[isAuth, navigate]);
  const showModalRegister = () => {
  setIsOpenRegister(true);
};

const hideModalRegister = () => {
  setIsOpenRegister(false);
};

const showModalLogin = () => {
  setIsOpenLogin(true);
};

const hideModalLogin = () => {
  setIsOpenLogin(false);
};
const handleLoginClick = async (data: ILoginInput) =>{  
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
  } = useForm<ILoginInput>({
    resolver: yupResolver(schema),
  });
  return (
<>
<nav className="navbar navbar-expand-lg navbar-dark bg-primary">
  <div className="container-fluid">
    <a className="navbar-brand">Navbar</a>
    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>

    <div className="collapse navbar-collapse" id="navbarColor01">
      <ul className="navbar-nav me-auto">
        <li className="nav-item">
          <a className="nav-link active">Home
            <span className="visually-hidden">(current)</span>
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">Features</a>
        </li>
        <li className="nav-item">
          <a className="nav-link">Pricing</a>
        </li>
        <li className="nav-item">
          <a className="nav-link">About</a>
        </li>
        <li className="nav-item dropdown">
          <a className="nav-link dropdown-toggle" data-bs-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown</a>
          <div className="dropdown-menu">
            <a className="dropdown-item">Action</a>
            <a className="dropdown-item">Another action</a>
            <a className="dropdown-item">Something else here</a>
            <div className="dropdown-divider"></div>
            <a className="dropdown-item">Separated link</a>
          </div>
        </li>
      </ul>
      <div>
        <button onClick={showModalLogin} type="button" className="btn btn-outline-info">Login</button>
        <form onSubmit={handleSubmit(handleLoginClick)}>
            <Modal show={isOpenLogin} onHide={hideModalLogin} >
              <Modal.Header>
                <Modal.Title>Đăng nhập</Modal.Title>
              </Modal.Header>
              <Modal.Body>
              
                  <input {...register('username')} type="text" className="form-control" placeholder='UID' required
                  />
                  <br/>
                  <input {...register('password')}type="password" className="form-control" placeholder='Password' required
                  />
                
              </Modal.Body>
              <Modal.Footer>
                <button type ="button"className="btn btn-secondary" onClick={hideModalLogin}>Huỷ</button>
                <button type="submit" className="btn btn-success">Đăng nhập</button>
              </Modal.Footer>
            </Modal>
        </form>
        
        
      </div>
      <div>
      <button onClick={showModalRegister} type="button" className="btn btn-outline-secondary">Sign up</button>
          <Modal show={isOpenRegister} onHide={hideModalRegister} >
            <Modal.Header>
              <Modal.Title>Đăng kí</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              
            </Modal.Body>
            <Modal.Footer>
              <button type ="button"className="btn btn-secondary" onClick={hideModalRegister}>Huỷ</button>
              <button type="submit" className="btn btn-success">Đăng kí</button>
            </Modal.Footer>
          </Modal>
      </div>
    </div>
  </div>
</nav>
</>
  );
};

export default Navbar