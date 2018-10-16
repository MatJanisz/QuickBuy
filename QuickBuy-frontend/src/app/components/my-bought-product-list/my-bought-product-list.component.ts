import { Component, OnInit, OnChanges } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-my-bought-product-list',
  templateUrl: './my-bought-product-list.component.html',
  styleUrls: ['./my-bought-product-list.component.css']
})
export class MyBoughtProductListComponent implements OnInit, OnChanges {

  products: ProductModel[] = [];
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getAllMyBoughtProducts()
    .subscribe(products => (this.products = products), error => console.log(error));
  }
  ngOnChanges() {
    // this.productService.getAllMyBoughtProducts()
    //  .subscribe(products => (this.products = products), error => console.log(error));
  }

}
