import { Component, OnInit, Input } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  // product: ProductModel = new ProductModel('id', 'banana', 'anna@gmail.com', 5, 40, 'others',
  // 'https://upload.wikimedia.org/wikipedia/commons/6/69/Banana_%28white_background%29.jpg', 'desc');
  @Input() product: ProductModel;
  constructor() { }
  ngOnInit() {
  }
}

