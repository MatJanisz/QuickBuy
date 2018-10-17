import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-my-product-list',
  templateUrl: './my-product-list.component.html',
  styleUrls: ['./my-product-list.component.css']
})
export class MyProductListComponent implements OnInit {

  products: ProductModel[] = [];
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getAllMyProducts()
    .subscribe(products => (this.products = products), error => console.log(error));
  }

}
