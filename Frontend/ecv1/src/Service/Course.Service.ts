import axiosClient from "../API/AxiosClient"
import { ICourseResult,ICourseInput } from "../Interfaces/ICourseService"



export const GetCourseById = async(id : number) =>
{
    return (await axiosClient.get<ICourseResult>(`/Course${id}`)).data;
}

export const GetAllCourse = async() =>
{
    return (await axiosClient.get<ICourseResult[]>(`/Course`)).data;
}

export const UpdateCourse = async(id : number,course : ICourseInput) =>
{
    return (await axiosClient.put<ICourseResult>(`/Course${id}`,course)).data;
}

export const CreateCourse = async(course : ICourseInput)=>
{
    return (await axiosClient.post<ICourseResult>(`/Course`,course)).data;
}

export const DeleteCourse = async(id : number) =>
{
    return (await axiosClient.delete(`/Course${id}`)).data;
}