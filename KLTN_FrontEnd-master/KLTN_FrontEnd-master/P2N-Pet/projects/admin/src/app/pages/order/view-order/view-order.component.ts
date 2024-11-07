import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal, StatusPaymentNormal } from '../../../models/status';
import { OrderService } from '../../../services/order.service';

@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.scss']
})
export class ViewOrderComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  statusPaymentChecked = 10;

  orderItems: any;

  orderStatusText = StatusNormal;
  orderStatusOptions = [];

  statusPaymentText = StatusPaymentNormal;
  statusPaymentOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService,
    private modalService: NgbModal) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.orderService.GetOrderDetail(this.id).subscribe((res: any) => {
      var orderDetail = res.content.OrderDetail;

      this.f.Id.setValue(this.id);
      this.f.CustomerName.setValue(orderDetail.CustomerName);
      this.f.CustomerPhone.setValue(orderDetail.CustomerPhone);
      this.f.CustomerEmail.setValue(orderDetail.CustomerEmail);
      this.f.CustomerAddress.setValue(orderDetail.CustomerAddress);
      this.f.TotalMoney.setValue(orderDetail.TotalMoney);
      this.f.TypePaymentName.setValue(orderDetail.TypePaymentName);
      this.f.StatusPaymentName.setValue(orderDetail.StatusPaymentName);
      this.f.Note.setValue(orderDetail.Note);
      this.orderItems = orderDetail.OrderItems;

      
      this.statusPaymentChecked = orderDetail.StatusPaymentId;
    });

    this.form = this.formBuilder.group({
      Id: [0],
      CustomerName: ['', Validators.required],
      CustomerPhone: ['', Validators.required],
      CustomerEmail: ['', Validators.required],
      CustomerAddress: ['', Validators.required],
      TotalMoney: [0, Validators.required],
      TypePaymentName: ['', Validators.required],
      StatusPaymentName: ['', Validators.required],
      Note: ['', Validators.required]
    });

    this.form.disable();
  }

  get f() { return this.form.controls; }

  ngAfterViewInit() {

  }

  buildSelection() {
    ChangeEnumToList(this.orderStatusText, this.orderStatusOptions);
    ChangeEnumToList(this.statusPaymentText, this.statusPaymentOptions);
  }

  tabchange: string[] = ['Thông tin đơn hàng','Các sản phẩm'];
  selectedwallet = this.tabchange[0];

  UpdateStatusPaymentId(value){
    if(value == "Đã thanh toán"){
      this.statusPaymentChecked = 20;
    }
    else if(value == "Chưa thanh toán"){
      this.statusPaymentChecked = 10;
    } 
  }

  UpdateStatusPayment(){
    this.orderService.UpdateStatusPayment(this.id, this.statusPaymentChecked).subscribe((res: any) => {
      this.router.navigate(["admin/list-order"]);
    });
  }
}
