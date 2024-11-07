import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TypeProductModel } from 'src/app/models/category';
import { PetCondition } from 'src/app/models/pet';
import { CategoryService } from 'src/app/services/category.service';
import { PetService } from 'src/app/services/pet.service';
import { PromotionService } from 'src/app/services/promotion.service';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  urlImage = `${environment.urlImage}`;
  loading = false;
  petCondition: PetCondition = new PetCondition();

  pets : any;
  promotion: any;

  parentBreeds: any;
  typeProducts: TypeProductModel[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private petService: PetService,
    private categoryService : CategoryService,
    private promotionService: PromotionService) {
  }

  ngOnInit(): void {
    this.loadScript();
    this.getPromotion();

    this.petCondition.TopProduct = 3;
    this.getList();

    this.getListBreedParent();
    this.getListTypeProduct();
  }

  getList(){
    this.loading = true;
    this.petService.getListPet({
      ...this.petCondition
    }).subscribe((res: any) => {
        this.pets = res.content.Products;
        this.loading = false;
      });
  }

  getListBreedParent(){
    this.categoryService.getListBreedParent().subscribe((res : any) => {
      this.parentBreeds = res.content.breeds;
    });
  }

  public loadScript() {
    var isFound = false;
    var scripts = document.getElementsByTagName("script")
    for (var i = 0; i < scripts.length; ++i) {
        if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src').includes("loader")) {
            isFound = true;
        }
    }

    if (!isFound) {
      var dynamicScripts = ["../../../assets/js/jquery.flexslider.js"];

      for (var i = 0; i < dynamicScripts.length; i++) {
        let node = document.createElement('script');
        node.src = dynamicScripts [i];
        node.type = 'text/javascript';
        node.async = false;
        node.defer = true;
        node.charset = 'utf-8';
        document.getElementsByTagName('head')[0].appendChild(node);
      }
    }
  }

  getPromotion(){
    this.promotionService.getPromotion().subscribe((res : any) =>{
      this.promotion = res.content.Promotion;
    });
  }

  getListTypeProduct(){
    this.categoryService.getListTypeProduct().subscribe( (res: any) => {
      this.typeProducts = res.content.Selection;
    })
  }
}
