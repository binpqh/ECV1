import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

const axiosClient = axios.create({
  baseURL: `https://localhost:5579/api`,
  headers: {
    'Content-type': 'application/json',
  },
  withCredentials: true,
});

axiosClient.interceptors.request.use(
  async (config: AxiosRequestConfig) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers = {
        Authorization: `Bearer ${token}`,
      };
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);
axiosClient.interceptors.response.use(
  (response: AxiosResponse) => {
    return response;
  },
  async (err) => {
    const originalConfig = err.config;
    if (originalConfig.url !== '/auth/login' && err.response) {
      // Access Token was expired
      if (err.response.status === 401 && !originalConfig._retry) {
        originalConfig._retry = true;
        try {
          const localRefreshToken = localStorage.getItem('refreshToken');
          const localToken = localStorage.getItem('token');

          const data = { refreshToken: localRefreshToken, token: localToken };

          const rs = await axiosClient.post('/auth/refresh-token', data);
          const { token, refreshToken, errors } = rs.data;
          if (errors) {
            localStorage.removeItem('token');
            localStorage.removeItem('refreshToken');
            window.location.href = '/login';
          }
          localStorage.setItem('token', token);
          localStorage.setItem('refreshToken', refreshToken);
          return axiosClient(originalConfig);
        } catch (_error) {
          return Promise.reject(_error);
        }
      }
    }
    return Promise.reject(err);
  }
);

export default axiosClient;
