import { Component, OnInit, Input } from '@angular/core';
import { ProductModel } from 'src/app/shared/models/product.model';

@Component({
  selector: 'app-my-bought-product',
  templateUrl: './my-bought-product.component.html',
  styleUrls: ['./my-bought-product.component.css']
})
export class MyBoughtProductComponent implements OnInit {
  @Input() product: ProductModel;
  constructor() { }
  ngOnInit() {
  }

}
