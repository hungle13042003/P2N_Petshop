export class PetColor{
    ColorId: number;
    ColorName: string;
}

export class PetSize{
    SizeId: number;
    SizeTitle: string;
}

export class PetAge{
    AgeId: number;
    AgeTitle: string;
}

export class PetSex{
    SexId: number;
    SexTitle: string;

    constructor(){
        this.SexId = 0;
        this.SexTitle = "";
    }
}

export class ProductBrand{
    BrandId: number;
    ProductDetailId: number;
    Address: string;
    QuantityInBrand: number;

    constructor(){
        this.BrandId = 0;
        this.ProductDetailId = 0;
        this.Address = '';
        this.QuantityInBrand = 0;
    }
}

export class PetDetail{
    ProductDetailId : number;
    ProductTitle: string;
    ProductId: number;
    Content: string;
    BreedId: number;
    BreedName: string;
    SupplierId: number;
    SupplierName: string;
    Quantity: number;
    Price: number;
    Discount: number;
    PriceDiscount: number;
    productImages: string[];
    SizeId: number;
    SizeTitle: string;
    productSizes : PetSize[];
    AgeId: number;
    AgeTitle: string;
    productAges : PetAge[];
    ColorId : number;
    ColorName: string;
    productColors: PetColor[];
    SexId: number;
    SexTitle: string;
    productSexes : PetSex[];
    productBrands: ProductBrand[];
    CategoryId: number;
    CategoryName: string;
    TypeProductId: number;
    TypeProductName: string;
    BrandId: number;
    Address: string;
    QuantityBrand: number;
    NumBrand: number;
}

export class PetDetailCondition {
    ProductDetailId: number;
    ProductId: number;
    SizeId: number;
    ColorId: number;
    AgeId: number;
    SexId: number;
    BrandId: number;

    constructor(){
        this.ProductDetailId = 0;
        this.ProductId = 0;
        this.SizeId = 0;
        this.ColorId = 0;
        this.AgeId = 0;
        this.SexId = 0;
        this.BrandId = 0;
    }
}
