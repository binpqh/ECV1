import axiosClient from "../API/AxiosClient";
import { IAccountInput,IAccountResult } from "../Interfaces/IAccountService";
import { IManagerInput } from "../Interfaces/IManagerService";
import { IStudentInput } from "../Interfaces/IStudentService";
import { ITeacherInput } from "../Interfaces/ITeacherService";
export const RegisterManager =
async(
    account : IAccountInput,
    inforManager : IManagerInput
):Promise<IAccountResult> =>
{
    return(await axiosClient.post<IAccountResult>
        (`/RegisterManager?Uid=${account.uid}&&Password=${account.password}`,inforManager)).data;
};
export const RegisterTeacher =
async(
    account : IAccountInput,
    inforTeacher : ITeacherInput
):Promise<IAccountResult> =>
{
    return(await axiosClient.post<IAccountResult>
        (`/RegisterTeacher?Uid=${account.uid}&&Password=${account.password}`,inforTeacher)).data;
};
export const RegisterStudent =
async(
    account : IAccountInput,
    inforManager : IStudentInput
):Promise<IAccountResult> =>
{
    return(await axiosClient.post<IAccountResult>
        (`/RegisterStudent?Uid=${account.uid}&&Password=${account.password}`,inforManager)).data;
};