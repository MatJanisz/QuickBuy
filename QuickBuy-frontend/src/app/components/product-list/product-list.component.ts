import { ProductModel } from './../../shared/models/product.model';
import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnChanges {

  products: ProductModel[] = [];
  @Input() keyword: string;
  @Input() category: string;
  isLoaded = false;
  constructor(private searchService: SearchService) { }

  ngOnInit() {
  }
  ngOnChanges() {
    if (this.keyword === '' && this.category === '') {
      this.searchService
      .getAll()
      .subscribe(products => (this.products = products), error => console.log(error));
    } else if (this.keyword !== '' && this.category !== '') {
      this.searchService
      .getProductsByNameAndCategory(this.keyword, this.category)
      .subscribe(products => (this.products = products), error => console.log(error));
    } else if (this.keyword !== '') {
      this.searchService
      .getProductsByName(this.keyword)
      .subscribe(products => (this.products = products), error => console.log(error));
    } else {
      this.searchService
      .getProductsByCategory(this.category)
      .subscribe(products => (this.products = products), error => console.log(error));
    }
   }

}
