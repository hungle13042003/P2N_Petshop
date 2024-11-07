export class PetDetail{
    Id: number;
    PetName: string;
    SupplierName: string;
    ColorTitle: string;
    SizeTitle: string;
    AgeTitle: string;
    SexTitle: string;
    StatusDetailTitle: string;
    Price: number;
    Discount: number;
    Quantity: number;
    StatusText: string;
    CreateUserName: string;
    CreateDate: string;
    UpdateUserName: string;
    UpdateDate: string;
}

export class PetDetailCondition {
    BreedId: string;
    SupplierId: string;
    ColorId: string;
    SizeId: string;
    AgeId: string;
    SexId: string;
    StatusDetailId: string;
    Status: string;
    CategoryId: number;
    TypeProductId : number;

    constructor() {
      this.BreedId = '0';
      this.SupplierId = '0';
      this.ColorId = '0';
      this.SizeId = '0';
      this.AgeId = '0';
      this.SexId = '0';
      this.StatusDetailId = '0';
      this.Status = '0';
      this.CategoryId = 0;
      this.TypeProductId = 0;
    }
  }

export class AgeSelection{
  Id: number;
  Title: string;
}

export class ColorSelection{
  Id: number;
  Title: string;
}

export class SizeSelection{
  Id: number;
  Title: string;
}

export class SexSelection{
  Id: number;
  Title: string;
}

export class BreedSelection{
  Id: number;
  Name: string;
}

export class SupplierSelection{
  Id: number;
  Name: string;
}

export class StatusDetailSelection{
  Id: number;
  Title: string;
}

export class ImageModel{
  Id:Number;
  Url: string;
}

export class BrandSelection{
  Id: number;
  Address: string;
}

export class productBrands{
  BrandId: number;
  QuantityInBrand : number;

  constructor(){
    this.BrandId = 0;
    this.QuantityInBrand = 0;
  }
}

export class PetDetailOneModel{
  Id: number;
  BreedId: number;
  SupplierId: number;
  ColorId: number;
  SizeId: number;
  AgeId: number;
  SexId: number;
  StatusDetailId: number;
  Price: number;
  Discount: number;
  Quantity: number;
  Status: number;
  CategoryId: number;
  aProductProductImageForModels: productImageFor[];
  brands: brandProductDetail[]
}

export class productImageFor{
  Id: number;
  ProductImageId: number;
  Image: string;

  constructor(){
    this.Id = 0;
    this.ProductImageId = 0;
    this.Image = '';
  }
}

export class brandProductDetail{
  BrandId: number;
  Address: string;
  QuantityInBrand: number;

  constructor(){
    this.BrandId = 0;
    this.Address = '';
    this.QuantityInBrand = 0;
  }
}
