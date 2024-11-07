export class CartCreateCondition{
    ProductDetailId: number;
    Quantity: number;
    BrandId: number;

    constructor(){
        this.ProductDetailId = 0;
        this.Quantity = 1;
        this.BrandId = 0;
    }
}

export class CartUpdateCondition{
    CartItemId: number;
    ProductDetailId: number;
    Quantity: number;

    constructor(){
        this.CartItemId = 0;
        this.ProductDetailId = 0;
        this.Quantity = 0;
    }
}

export class CartItemList{
    Id: number;
    CartItemId: number;
    CartId: number;
    ProductDetailId: number;
    ProductTitle: string;
    Price: number;
    Discount: number;
    PriceDiscount: number;
    Quantity: number;
    ProductImage: string;
    TotalPriceItem: number;

    QuantityProduct: number;
}

export class CartItem{
    ProductDetailId: number;
    Quantity: number;

    constructor(){
        this.ProductDetailId =0;
        this.Quantity = 0;
    }
}
