export class User {
    Id: number;
    Name: string;
    Email: string;
    Phone: string;
    Avatar: string;
    Address: string
    RoleName: string;
    Token: string;

    constructor(){
        this.Id = 0;
        this.Name = "";
        this.Email = "";
        this.Phone = "";
        this.Avatar = "";
        this.Address = "";
        this.RoleName = "";
        this.Token = "";
    }
  }