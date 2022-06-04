import axiosClient from "../API/AxiosClient"
import { IStudentInput, IStudentResult } from "../Interfaces/IStudentService";
import { ITeacherInput, ITeacherResult } from "../Interfaces/ITeacherService";

export const GetTeacherById = async(id : number) =>
{
    return (await axiosClient.get<ITeacherResult>(`/Teacher${id}`)).data;
}
export const GetAllTeacher = async() =>
{
    return (await axiosClient.get<ITeacherResult[]>(`/Teacher`)).data;
}
export const CreateTeacher = async(
    teacher : ITeacherInput
) =>
{
    return (await axiosClient.post<ITeacherResult>(`/Teacher`,teacher)).data;
}
export const UpdateTeacher = async(
    id : number,
    teacher : ITeacherInput,
) =>
{
    return (await axiosClient.put<ITeacherResult>(`/Teacher${id}`,teacher)).data;
}
export const DeleteTeacher = async(
    id : number
) =>
{
    return (await axiosClient.delete(`/Teacher${id}`)).data;
}