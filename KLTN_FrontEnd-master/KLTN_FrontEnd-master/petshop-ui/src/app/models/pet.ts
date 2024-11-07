
export class Pet{
    PetDetailId: number;
    PetTitle : string;
    PetId: number;
    BreedId: number;
    BreedName: string;
    BreedIdRoot: number;
    BreedRootName: string;
    SupplierId: number;
    SupplierName: string;
    Price: number;
    Discount: number;
    PriceDiscount: number;
    PetImage: string;
    PetQuantity: number;
}

export class PetCondition{
    BreedId: number;
    BreedIdRoot: number;
    SupplierId: number;
    FindString: string;
    TopProduct: number;
    TypeProducuctId: number;
    CategoryId: number;
    CategoryIdRoot: number;

    constructor(){
        this.BreedId = 0;
        this.BreedIdRoot = 0;
        this.SupplierId = 0;
        this.FindString = "";
        this.TopProduct = 0;
        this.TypeProducuctId = 0;
        this.CategoryId = 0;
        this.CategoryIdRoot = 0;
    }
}
