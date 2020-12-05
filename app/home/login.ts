export interface ILogin {
  userName: string;
  password: string;
  role: string;
}
export class Login implements ILogin {
  userName: string;
  password: string;
  role: string;
}
