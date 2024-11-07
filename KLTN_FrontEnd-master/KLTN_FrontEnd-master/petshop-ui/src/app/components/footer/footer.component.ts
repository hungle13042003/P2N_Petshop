import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TypeProductModel } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  parentBreeds: any;
  typeProducts: TypeProductModel[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private categoryService : CategoryService) { }

  ngOnInit(): void {
    this.getListBreedParent();
    this.getListTypeProduct();
  }

  getListBreedParent(){
    this.categoryService.getListBreedParent().subscribe((res : any) => {
      this.parentBreeds = res.content.breeds;
    });
  }

  getListTypeProduct(){
    this.categoryService.getListTypeProduct().subscribe( (res: any) => {
      this.typeProducts = res.content.Selection;
    })
  }

}
