export class Supplier{
    public Id: number;
    public Name: string;
    public Address: string;
    public Phone: string;
    public Email: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class SupplierCondition {
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