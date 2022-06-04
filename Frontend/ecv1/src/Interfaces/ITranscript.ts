export interface ITranscriptResult
{
    Id : number;
    IdTeacher : number;
    IdStudent : number;
    IdManager : number;
    IdClass : number;
    IdPoint : number;
    StatusPay : boolean;
}
export interface ITranscriptInput
{
    IdTeacher : number;
    IdStudent : number;
    IdManager : number;
    IdClass : number;
    StatusPay : boolean;
}