export interface ILoginInput {
    username: string;
    password: string;
  }
  
  export interface ILoginResponse {
    token: string;
    status: boolean;
  }