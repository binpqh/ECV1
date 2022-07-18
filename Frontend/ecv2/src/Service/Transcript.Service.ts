import axiosClient from "../API/AxiosClient"
import { ITranscriptInput, ITranscriptResult } from "../Interfaces/ITranscript"

export const CreateTranscript =async (Transcript:ITranscriptInput) => {
    return ( await axiosClient.post<ITranscriptResult>(`/Transcript`,Transcript)).data;
}
export const UpdateTranscript =async (
    Id : number,
    Transcript:ITranscriptInput) => {
    return ( await axiosClient.post<ITranscriptResult>(`/Transcript${Id}`,Transcript)).data;
}
export const GetTranscript =async (id:number) => {
    return (await axiosClient.get<ITranscriptResult>(`/Transcript${id}`)).data;
}