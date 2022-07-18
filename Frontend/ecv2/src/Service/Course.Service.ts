import axiosClient from "../API/AxiosClient"
import { ICourseResult,ICourseInput } from "../Interfaces/ICourseService"



export const GetCourseById = async(id : number) =>
{
    return (await axiosClient.get<ICourseResult>(`/Courses${id}`)).data;
}

export const GetAllCourse = async() =>
{
    return (await axiosClient.get<ICourseResult[]>(`/Courses`)).data;
}

export const UpdateCourse = async(id : number,course : ICourseInput) =>
{
    return (await axiosClient.put<ICourseResult>(`/Courses${id}`,course)).data;
}

export const CreateCourse = async(course : ICourseInput)=>
{
    return (await axiosClient.post<ICourseResult>(`/Courses`,course)).data;
}

export const DeleteCourse = async(id : number) =>
{
    return (await axiosClient.delete(`/Courses${id}`)).data;
}