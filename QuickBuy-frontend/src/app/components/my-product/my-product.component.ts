import { Component, OnInit, Input } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';

@Component({
  selector: 'app-my-product',
  templateUrl: './my-product.component.html',
  styleUrls: ['./my-product.component.css']
})
export class MyProductComponent implements OnInit {
  @Input() product: ProductModel;
  constructor() { }

  ngOnInit() {
  }

}
