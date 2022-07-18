import axiosClient from "../API/AxiosClient";
import { ILoginInput } from "../Interfaces/IAuthService";

export const LoginAsync = async (data: ILoginInput) => {
    const response = await axiosClient.post('/login', data);
    return response.data;
};
export const GetMeAsync = async () => {
  const response = await axiosClient.get('/user');
  return response.data;
};