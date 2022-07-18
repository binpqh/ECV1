import axiosClient from "../API/AxiosClient";
import { IStudentInput, IStudentResult } from "../Interfaces/IStudentService";

export const GetStudentById = async(id : number) =>
{
    return (await axiosClient.get<IStudentResult>(`/Student${id}`)).data;
}
export const GetAllStudent = async() =>
{
    return (await axiosClient.get<IStudentResult[]>(`/Student`)).data;
}
export const CreateStudent = async(
    student : IStudentInput
) =>
{
    return (await axiosClient.post<IStudentResult>(`/Student`,student)).data;
}
export const UpdateStudent = async(
    id : number,
    student : IStudentInput,
) =>
{
    return (await axiosClient.put<IStudentResult>(`/Student${id}`,student)).data;
}
export const DeleteStudent = async(
    id : number
) =>
{
    return (await axiosClient.delete(`/Student${id}`)).data;
}