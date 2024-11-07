import { CommentCondition } from './../../models/comment';
import { User } from 'src/app/models/account';
import { CartItem } from './../../models/cart';
import { AccountService } from './../../services/account.service';
import { PetDetail, PetDetailCondition } from './../../models/petDetail';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PetService } from 'src/app/services/pet.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CartCreateCondition } from 'src/app/models/cart';
import { CartService } from 'src/app/services/cart.service';
import { PetCondition } from 'src/app/models/pet';
import { CartCountService } from 'src/app/services/cartcount.service';
import { Subscription } from 'rxjs';
import { CommentService } from 'src/app/services/comment.service';
import { CommentModel } from 'src/app/models/comment';
import * as moment from 'moment';

@Component({
  selector: 'app-single',
  templateUrl: './single.component.html',
  styleUrls: ['./single.component.scss'],
})
export class SingleComponent implements OnInit {
  petDetailId: any;
  loading = false;

  form: FormGroup;
  submitted = false;
  countSub: Subscription;
  contentComment: '';
  placeHolderComment?: string;
  commentId?: number;

  comment: CommentModel = new CommentModel();
  listComment: any;
  commentDetail: any;
  commentCondition: CommentCondition = new CommentCondition();
  isUpdated: number;

  public petDetail: PetDetail = new PetDetail();

  cartItem: CartItem = new CartItem();
  cartList: Array<CartItem> = [];

  petImageRoot: any;

  cartCondition: CartCreateCondition = new CartCreateCondition();
  petDetailCondition: PetDetailCondition = new PetDetailCondition();

  user: User;
  message: string = '';
  tempQuantity: number;

  petCondition: PetCondition = new PetCondition();
  pets: any;

  quantity: number;

  showBrand: number;

  numBrand: number;
  brandIdPet : number;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private petService: PetService,
    private cartService: CartService,
    private accountService: AccountService,
    private cartCountService: CartCountService,
    private commentService: CommentService) {
      this.tempQuantity = 0;
      this.quantity = 0;
      this.countSub = this.cartCountService.cartCount$.subscribe((count) => {});

      this.isUpdated = 0;
      this.showBrand = 0;
      this.brandIdPet = 0;
  }

  get f() {
    return this.form.controls;
  }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };

    this.form = this.formBuilder.group({
      Quantity: [1, Validators.required],
    });

    this.petDetailId = this.route.snapshot.params['id'];
    this.brandIdPet = this.route.snapshot.params['brandid'] === undefined ? 0 : this.route.snapshot.params['brandid'];
    this.getDetailPet();

    this.petCondition.TopProduct = 6;
    this.getList();

    this.getQuantityByPetDetailId(this.petDetailId);

    this.GetListComment();

    let target = document.getElementById('target');
    this.scroll(target);
  }

  AddToCart(Id: any) {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.tempQuantity = this.tempQuantity + this.f.Quantity.value;

    if (this.tempQuantity > this.petDetail.Quantity) {
      this.message = 'Số lượng bạn đặt đã vượt qua số lượng tối đa.';

      this.tempQuantity = this.tempQuantity - this.f.Quantity.value;

      this.loading = false;
      this.submitted = false;

      return;
    } else {
      this.message = '';
    }

    if (this.accountService.user) {
      this.accountService.user.subscribe((x) => {
        if (x) {
          this.user = x;
        } else {
          this.user = new User();
        }
      });
    }

    if (!(this.user.Id > 0)) {
      this.router.routeReuseStrategy.shouldReuseRoute = () => {
        return false;
      };
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([`/login`]);

      /* sessionStorage.removeItem('cart-pet');

      this.cartItem.PetDetailId = this.petDetail.PetDetailId;
      this.cartItem.Quantity = this.f.Quantity.value;

      this.cartList.push(this.cartItem);
      sessionStorage.setItem('cart-pet', JSON.stringify({...this.cartList}));

      console.log("message : " + this.message);
      console.log("cartList: " + this.cartList);
      console.log("cartItem: " + this.cartItem);

      this.loading = false;
      this.submitted = false; */
    } else {
      this.cartCondition.ProductDetailId = Id;
      this.cartCondition.Quantity = this.f.Quantity.value;
      this.cartCondition.BrandId = this.brandIdPet;


      this.cartService.AddToCart({ ...this.cartCondition }).subscribe(
        (res: any) => {
          if (res.result == 0) {
            this.message = res.message;
          }

          this.cartCountService.getCountQuantity().subscribe((res: any) => {
            var countQuantity = res.content.countQuantity;

            this.cartCountService.setCartCount(countQuantity);
          });

          this.cartService.getQuantityPetDetailIdAndUserId(Id).subscribe(
            (res: any) => {
              this.quantity = res.content.Quantity;

              //this.f.Quantity.setValue(this.quantity);

              //let currentUrl = this.router.url;
              this.router.routeReuseStrategy.shouldReuseRoute = () => false;
              this.router.onSameUrlNavigation = 'reload';
              //this.router.navigate([currentUrl]);
            },
            (error) => {
              this.quantity = 0;
            }
          );

          let target = document.getElementById('headerpet1');
          this.scroll(target);

          this.loading = false;
          this.submitted = false;
        },
        (error) => {
          this.loading = false;
          this.submitted = false;
        }
      );
    }
  }

  getDetailPet() {
    this.loading = true;

    console.log('brandIdPet: ' + this.brandIdPet);

    this.petService.getPetDetail(this.petDetailId, this.brandIdPet).subscribe((res: any) => {
      this.petDetail = res.content.ProductDetail;

      this.petImageRoot = this.petDetail.productImages[0];

      this.petDetailCondition.SizeId = this.petDetail.SizeId;
      this.petDetailCondition.ColorId = this.petDetail.ColorId;
      this.petDetailCondition.AgeId = this.petDetail.AgeId;
      this.petDetailCondition.SexId = this.petDetail.SexId;
      this.petDetailCondition.BrandId = this.petDetail.BrandId;

      this.loading = false;
    });
  }

  onChangePet(check) {
    this.loading = true;

    this.petDetailCondition.ProductId =
      this.petDetail.ProductId == undefined ? 0 : this.petDetail.ProductId;

    if (check == 1) {
      this.petDetailCondition.AgeId = 0;
      this.petDetailCondition.SizeId = 0;
      this.petDetailCondition.SexId = 0;
    } else if (check == 2) {
      this.petDetailCondition.SizeId = 0;
      this.petDetailCondition.SexId = 0;
    } else if (check == 3) {
      this.petDetailCondition.SexId = 0;
    }

    this.brandIdPet = this.petDetailCondition.BrandId;

    this.petService
      .getMultiPetDetail({ ...this.petDetailCondition })
      .subscribe((res: any) => {
        this.petDetail = res.content.ProductDetail;

        this.petImageRoot = this.petDetail.productImages[0];
        if( this.petDetail.BrandId > 0){
          this.showBrand = 1;
        }
        this.loading = false;

        this.router.routeReuseStrategy.shouldReuseRoute = () => {
          return false;
        };

        /* this.router.onSameUrlNavigation = 'reload'; */
        this.router.navigate([`/details/${this.petDetail.ProductDetailId}/${this.petDetail.BrandId}`]);
      });

    let target = document.getElementById('target');
    this.scroll(target);
  }

  refresh() {
    window.location.reload();
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({ behavior: 'smooth' });
  }

  getList() {
    this.loading = true;
    this.petService
      .getListPet({
        ...this.petCondition,
      })
      .subscribe((res: any) => {
        this.pets = res.content.Products;
        this.loading = false;
      });
  }

  getQuantityByPetDetailId(Id) {
    if (this.accountService.user) {
      this.accountService.user.subscribe((x) => {
        if (x) {
          this.user = x;
        } else {
          this.user = new User();
        }
      });
    }

    if (!(this.user.Id > 0)) {
      this.quantity = 0;
    } else {
      this.cartService.getQuantityPetDetailIdAndUserId(Id).subscribe(
        (res: any) => {
          this.quantity = res.content.Quantity;
          //this.f.Quantity.setValue(this.quantity);
          //let currentUrl = this.router.url;
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          //this.router.navigate([currentUrl]);
        },
        (error) => {
          this.quantity = 0;
        }
      );
    }
  }

  changeImage(numImage) {
    this.petImageRoot = this.petDetail.productImages[numImage];
  }

  CreateOrUpdateComment() {
    if (this.isUpdated == 0) {
      this.CreateComment();
    } else {
      //this.contentComment = this.commentDetail.Content;
      this.commentCondition.ProductCommentId = this.commentDetail.CommentId;
      this.commentCondition.Content = this.contentComment;
      this.commentCondition.Rating = 0;

      this.UpdateComment();
    }
  }

  CreateComment() {
    if (this.contentComment != '') {
      this.comment.ProductDetailId = this.petDetailId;
      this.comment.Content = this.contentComment;
      this.comment.CommentRootId = this.commentId;
      if (this.commentId == 0) {
        this.commentService
          .CreateComment(this.comment)
          .subscribe((res: any) => {
            this.contentComment = '';
            this.GetListComment();
          });
      } else {
        this.commentService.ReplyComment(this.comment).subscribe((res: any) => {
          this.contentComment = '';
          console.log("re");
          this.GetListComment();
        });
      }

      this.commentId = 0;
    }
  }

  UpdateComment() {
    this.commentService
      .UpdateComment({ ...this.commentCondition })
      .subscribe((res: any) => {
        this.isUpdated = 0;
        this.contentComment = '';
        this.GetListComment();
      });
  }

  GetDetailComment(commentId, isUpdated) {
    this.isUpdated = isUpdated;
    this.commentService.GetDetailComment(commentId).subscribe((res: any) => {
      if (isUpdated == 0) {
        const text = 'Trả lời bình luận' + res.content.Comment
        this.placeHolderComment = text
        this.contentComment = ''
        this.commentId = res.content.Comment.CommentId;
      } else {
        this.commentDetail = res.content.Comment;
        this.contentComment = this.commentDetail.Content;
      }
      let myTextBox = document.getElementById('contentcomment');
      myTextBox.focus();
    });

    let target = document.getElementById('cmtTarget');
    this.scroll(target);
  }

  GetListComment() {
    this.petService.GetListComment(this.petDetailId).subscribe((res: any) => {
      this.listComment = res.content.Comments;
    });
  }

  DeleteComment(Id: any) {
    this.commentService.DeleteComment(Id).subscribe((res: any) => {
      this.GetListComment();
    });
  }

  formatDateVN(input) {
    return moment(new Date(input)).format('DD-MM-YYYY HH:mm:ss');
  }
}
