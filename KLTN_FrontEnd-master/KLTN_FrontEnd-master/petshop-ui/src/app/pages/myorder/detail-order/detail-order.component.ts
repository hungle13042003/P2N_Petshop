import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-detail-order',
  templateUrl: './detail-order.component.html',
  styleUrls: ['./detail-order.component.scss']
})
export class DetailOrderComponent implements OnInit {

  orders: any;
  id: number;
  loading = false;
  constructor(private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService) { }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };
    
    this.id = this.route.snapshot.params['id'];

    this.getDetailOrder();

    let target = document.getElementById('target');
    this.scroll(target);
  }

  getDetailOrder(){
    this.loading = true;

    this.orderService.GetOrderDetail(this.id).subscribe((res: any) =>{
      if(res.result == 0){
        this.loading = false;
      }
      else{
        this.orders = res.content.OrderDetail;
        this.loading = false;
      }
    })
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

}
