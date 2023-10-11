export interface UserRegister {
  username: string;
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface UserLogin {
  username: string;
  password: string;
}

export interface CurrentUser {
  username: string;
  token: string;
  email: string;
}
