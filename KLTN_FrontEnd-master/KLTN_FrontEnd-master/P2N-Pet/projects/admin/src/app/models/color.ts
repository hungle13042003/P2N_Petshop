export class Color{
    public Id: number;
    public Title: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class ColorCondition {
    Title: string;
    Status: string;
  
    constructor() {
      this.Title = '';
      this.Status = '0';
    }
  }