import axiosClient from "../API/AxiosClient"
import { ITimeTableResult } from "../Interfaces/ITimeTableService";

export const AddClassDayIntoAClass =async (
    id : number,
    weekday : number
) => {
    return (await axiosClient.post(`TimeTable${id}`,weekday)).data;
}
export const GetTimeTableOfClass =async (
    id : number,
) => {
    return (await axiosClient.get<ITimeTableResult[]>(`TimeTable${id}`)).data;
}
export const DeleleAClassDayInAClass =async (
    id : number,
    weekday : number
) => {
    return (await axiosClient.delete(`TimeTable${id}?weekday=${weekday}`)).data;
}