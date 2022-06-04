export interface IAccountInput
{
    Uid : string;
    Password : string;
}
export interface IAccountResult
{
    Id : number;
    Uid : string;
    Password : string;
    Role : number;
}