export class Customer{
    public Id: number;
    public UserName: string;
    public Name: string;
    public Birthday: string;
    public Address: string;
    public Phone: string;
    public Email: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class CustomerCondition {
    Name: string;
    Phone: string;
    Email: string;
    Status: string;
  
    constructor() {
      this.Name = '';
      this.Phone = '';
      this.Email = '';
      this.Status = '0';
    }
  }