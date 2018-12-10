import { ProductModel } from './../../shared/models/product.model';
import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-product-list-initial',
  templateUrl: './product-list-initial.component.html',
  styleUrls: ['./product-list-initial.component.css']
})
export class ProductListInitialComponent implements OnInit {

  initialProducts: ProductModel[] = [];
  @Input() keyword: string;
  @Input() category: string;
  isLoaded = false;
  constructor(private searchService: SearchService) { }

  ngOnInit() {
    this.searchService
      .getRandomProducts(5)
      .subscribe(initialProducts => (this.initialProducts = initialProducts), error => console.log(error));
  }

}
