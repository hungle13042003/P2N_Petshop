import { NumberValueAccessor } from "@angular/forms";

export class Breed {
    Id: number;
    BreedName: string;

    constructor(){
        this.Id = 0;
        this.BreedName = "";
    }
}

export class Supplier{
    Id: number;
    SupplierName: string;

    constructor(){
        this.Id = 0;
        this.SupplierName = "";
    }
}

export class CategoryModel{
  Id: number;
  CategoryName: string;
  TypeProductId: number;
  TypeProductName: string;
  CategoryChill: CategoryChillModel[];
}

export class CategoryChillModel{
  Id: number;
  CategoryName: string;
  TypeProductId: number;
  TypeProductName: string;

  constructor(){
    this.Id = 0;
    this.CategoryName = '';
    this.TypeProductId = 0;
    this.TypeProductName = '';
  }
}

export class TypeProductModel{
  TypeProductId: Number;
  TypeProductName: string;
}
