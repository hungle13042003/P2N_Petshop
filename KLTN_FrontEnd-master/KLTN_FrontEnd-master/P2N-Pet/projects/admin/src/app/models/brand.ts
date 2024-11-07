export class BrandCondition{
   Email: string;
   Phone: string;
   Address: string;
   Status: number;

   constructor(){
       this.Email = '';
       this.Phone = '';
       this.Address = '';
       this.Status = 0;
   }
}

export class ProductDetailSelection{
    Id: number;
    ProductName: string;

    constructor(){
        this.Id = 0;
        this.ProductName = '';
    }
}

export class brandProducts{
    Id: number;
    ProductDetailId: number;
    QuantityInBrand : number;

    constructor(){
        this.Id = 0;
        this.ProductDetailId = 0;
        this.QuantityInBrand = 0;
    }
}

export class brandModel{
    Id: number;
    Email: string;
    Phone: string;
    Address: string;
    Status: number;
    StatusText: string;
    products : productModel[]

}

export class productModel{
    BrandId: number;
    ProductDetailId: number;
    ProductName: string;
    QuantityInBrand: number;

    constructor(){
        this.BrandId = 0;
        this.ProductDetailId = 0;
        this.ProductName = '';
        this.QuantityInBrand = 0;
    }
}