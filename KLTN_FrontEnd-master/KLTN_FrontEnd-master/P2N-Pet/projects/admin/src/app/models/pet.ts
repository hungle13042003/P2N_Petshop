export class Pet{
    public Id: number;
    public BreedName: string;
    public SupplierName: string;
    public Content: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class PetCondition {
    BreedId: string;
    SupplierId: string;
    Status: string;
    CategoryId : number;
    TypeProductId : number;
  
    constructor() {
      this.BreedId = '0';
      this.SupplierId = '0';
      this.Status = '0';
      this.CategoryId = 0;
      this.TypeProductId = 0;
    }
  }

export class BreedSelection{
  Id: number;
  Name: string;
}

export class SupplierSelection{
  Id:number;
  Name: string;
}

export class CategorySelection{
  Id: number;
  Title: string;
  TypeProductId: number;

  constructor(){
    this.Id = 0;
    this.Title = '';
    this.TypeProductId;
  }
}