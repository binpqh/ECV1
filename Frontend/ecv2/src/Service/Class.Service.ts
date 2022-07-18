import axiosClient from "../API/AxiosClient";
import {IClassInput, IClassResult} from "../Interfaces/IClassService"



export const GetAllClass = async() =>
{
    return(await axiosClient.get<IClassResult[]>(`/Classes`)).data;
};

export const GetClassById = async(IdClass : number) =>
{
    return(await axiosClient.get<IClassResult>(`/Classes/${IdClass}`)).data;
};

export const CreateClass = async(createclass : IClassInput) =>
{
    return(await axiosClient.post<IClassResult>(`/Classes`,createclass)).data;
};

export const UpdateClass = async(id : number,createclass : IClassInput) =>
{
    return(await axiosClient.put<IClassResult>(`/Classes/${id}`,createclass)).data;
};

export const DeleteClass = async(id : number) =>
{
    return(await axiosClient.delete(`/Classes/${id}`)).data;
};