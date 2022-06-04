import axiosClient from "../API/AxiosClient"
import { IManagerInput, IManagerResult } from "../Interfaces/IManagerService";

export const GetManagerById = async(id : number) =>
{
    return (await axiosClient.get<IManagerResult>(`/Manager${id}`)).data;
}
export const GetAllManager = async() =>
{
    return (await axiosClient.get<IManagerResult[]>(`/Manager`)).data;
}
export const CreateManager = async(
    manager : IManagerInput
) =>
{
    return (await axiosClient.post<IManagerResult>(`/Manager`,manager)).data;
}
export const UpdateManager = async(
    id : number,
    manager : IManagerInput,
) =>
{
    return (await axiosClient.put<IManagerResult>(`/Manager${id}`,manager)).data;
}
export const DeleteManager = async(
    id : number
) =>
{
    return (await axiosClient.delete(`/Manager${id}`)).data;
}