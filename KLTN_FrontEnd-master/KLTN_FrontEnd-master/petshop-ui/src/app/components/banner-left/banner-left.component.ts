import { CategoryModel, TypeProductModel } from './../../models/category';
import { map } from 'rxjs/operators';
import { CategoryService } from './../../services/category.service';
import { Component,  OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-banner-left',
  templateUrl: './banner-left.component.html',
  styleUrls: ['./banner-left.component.scss']
})
export class BannerLeftComponent implements OnInit {

  public parentBreeds : any;
  public childBreeds : any;
  public suppliers : any;

  public breedAlls : any;

  public categoryAlls : CategoryModel[];

  public phukien: CategoryModel[];
  public thucan: CategoryModel[];
  public typeProducts: TypeProductModel[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private categoryService : CategoryService) {
    }

  ngOnInit(): void {
    this.getListSupplier();
    this.getListBreedAll();
    this.getListCategoryAll();
    this.getListTypeProduct();

    //let abc = this.categoryAlls;

    //console.log('sao kgoong ra nhỉ');
  }

  ngAfterViewInit() : void {
  }



  getListBreedParent(){
      this.categoryService.getListBreedParent().subscribe((res : any) => {
        this.parentBreeds = res.content.breeds;
      })
  }

  getListBreedChild(id: any){
    this.categoryService.getListBreedChild(id).subscribe(( res : any) =>{
      this.childBreeds = res.content.breeds;
    })
  }

  getListSupplier(){
    this.categoryService.getListSupplierChild().subscribe((res: any) =>{
      this.suppliers = res.content.suppliers;
    })
  }

  getListBreedAll(){
    this.categoryService.getListBreedAll().subscribe((res:any)=>{
      this.breedAlls = res.content.breeds;
    })
  }

  getListCategoryAll(){
    this.categoryService.getListCategoryAll().subscribe((res:any)=>{
      this.categoryAlls = res.content.Categories;

      this.phukien = this.categoryAlls.filter(p => p.TypeProductId == 30);
      this.thucan = this.categoryAlls.filter(p => p.TypeProductId == 20);
    })
  }

  getListTypeProduct(){
    this.categoryService.getListTypeProduct().subscribe( (res: any) => {
      this.typeProducts = res.content.Selection;
    })
  }

 /*  reloadRoute() {
    let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate([currentUrl]);
  } */
}

