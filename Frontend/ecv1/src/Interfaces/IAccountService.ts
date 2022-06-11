export interface IAccountInput
{
    uid : string;
    password : string;
}
export interface IAccountResult
{
    id : number;
    uid : string;
    password : string;
    role : number;
}