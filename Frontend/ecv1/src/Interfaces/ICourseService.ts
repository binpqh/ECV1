export interface ICourseResult
{
    Id : number;
    Name : string;
    DayStart : string;
    DayEnd : string;
    Price : number;
    Level : string;
}
export interface ICourseInput
{
    Name : string;
    DayStart : string;
    DayEnd : string;
    Price : number;
    Level : string;
}