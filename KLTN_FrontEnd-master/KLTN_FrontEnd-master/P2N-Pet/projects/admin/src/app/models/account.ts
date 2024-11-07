export class User {
    Id: number;
    Name: string;
    Avatar: string;
    Email: string;
    Phone: string;
    Role: number;
    Token: string;
  }

export class Account{
  Id: number;
  Name: string;
  Email: string;
  Phone: string;
//  Password: string;
  Address: string;
  Avatar: string;
  RoleName: string;
  StatusText: string;
  CreateUserName: string;
  CreateDate: string;
  UpdateUserName: string;
  UpdateDate: string;
};

export class AccountCondition {
  Name: string;
  Phone: string;
  Email: string;
  RoleId: number;
  StatusBlock: number;
  Status: number;

  constructor() {
    this.Name = '';
    this.Phone = '';
    this.Email = '';
    this.RoleId = 30;
    this.StatusBlock = 50;
    this.Status = 0;
  }
}

export class RoleSelection{
  RoleId: number;
  RoleName: string;
}
