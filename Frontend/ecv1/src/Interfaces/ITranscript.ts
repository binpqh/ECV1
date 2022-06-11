export interface ITranscriptResult
{
    id : number;
    idTeacher : number;
    idStudent : number;
    idManager : number;
    idClass : number;
    idPoint : number;
    statusPay : boolean;
}
export interface ITranscriptInput
{
    idTeacher : number;
    idStudent : number;
    idManager : number;
    idClass : number;
    statusPay : boolean;
}