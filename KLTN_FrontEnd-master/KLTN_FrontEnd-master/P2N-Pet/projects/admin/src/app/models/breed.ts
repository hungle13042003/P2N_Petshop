export class Breed{
    public Id: number;
    public Name: string;
    public BreedIdName: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
}

export class BreedCondition {
    Name: string;
    BreedId: string;
    Status: string;
  
    constructor() {
      this.Name = '';
      this.BreedId = '0';
      this.Status = '0';
    }
  }

  export class BreedDefaultSelection {
    Id: number;
    Name: string;
  }