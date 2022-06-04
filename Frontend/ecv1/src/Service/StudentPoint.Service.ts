import axiosClient from "../API/AxiosClient"
import { IStudentPointInput, IStudentPointResult } from "../Interfaces/IStudentPointService"

export const GetAllPoint =async () => {
    return (await axiosClient.get<IStudentPointResult[]>(`/StudentPoint`)).data;
}
export const AddPointToTranscript =async (
    studentPoint : IStudentPointInput
) => {
    return (await axiosClient.post<IStudentPointResult>(`/StudentPoint`,studentPoint)).data;
}
export const UpdateStudentPoint =async (
    id : number,
    studentPoint : IStudentPointInput
) => {
    return (await axiosClient.put<IStudentPointResult>(`/StudentPoint${id}`,studentPoint)).data;
}
export const DeleteStudentPoint =async (
    id : number
) => {
    return (await axiosClient.delete<IStudentPointResult>(`/StudentPoint${id}`)).data;
}