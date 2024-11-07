export class Age{
    public Id: number;
    public Title: string;
    public OrderView: number;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class AgeCondition {
    Title: string;
    Status: string;
  
    constructor() {
      this.Title = '';
      this.Status = '0';
    }
  }