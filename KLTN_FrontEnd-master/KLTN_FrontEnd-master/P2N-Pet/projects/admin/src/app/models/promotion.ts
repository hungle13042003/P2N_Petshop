export class Promotion{
    public Id: number;
    public Title: string;
    public Image: string;
    public FromDate: string;
    public ToDate: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class PromotionCondition {
    Title: string;
    Status: string;
  
    constructor() {
      this.Title = '';
      this.Status = '0';
    }
  }