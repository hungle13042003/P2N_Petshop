export class CategoryCondition{
    Name: string;
    CategoryRootId: number;
    Status : number;
    TypeProductId: number;

    constructor(){
        this.Name = "";
        this.CategoryRootId = 0;
        this.TypeProductId = 0;
        this.Status = 0;
    }
}

export class TypeProductSelection{
    TypeProductId: number;
    TypeProductName: string;
}

export class CategoryRootSelection{
    Id: number;
    Title: string;
    TypeProductId: number;
}



export class Category{
    public Id: number;
    public Name: string;
    public CategoryIdName: string;
    public StatusText: string;
    public CreateUserName: string;
    public CreateDate: string;
    public UpdateUserName: string;
    public UpdateDate: string;
    public TypeProductId: number;
    public TypeProductName: string;
}