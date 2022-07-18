export interface ICourseResult
{
    id : number;
    name : string;
    dayStart : string;
    dayEnd : string;
    price : number;
    level : string;
}
export interface ICourseInput
{
    name : string;
    dayStart : string;
    dayEnd : string;
    price : number;
    level : string;
}