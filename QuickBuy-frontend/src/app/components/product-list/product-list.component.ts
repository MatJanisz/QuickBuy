import { ProductModel } from './../../shared/models/product.model';
import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  // products: ProductModel[] = [new ProductModel('id', 'banana', 'anna@gmail.com', 5, 40, 'others',
  // 'https://upload.wikimedia.org/wikipedia/commons/6/69/Banana_%28white_background%29.jpg', 'desc'),
  // new ProductModel('id', 'apple', 'john@gmail.com', 2, 90, 'others',
  // 'https://pl.wikipedia.org/wiki/ThinkPad#/media/File:Lenovo_ThinkPad_X1_Ultrabook.jpg', 'desc')];
  products: ProductModel[] = [];
  constructor(private searchService: SearchService) { }

  ngOnInit() {
    this.searchService
      .getAll()
      .subscribe(products => (this.products = products), error => console.log(error));
  }

}
