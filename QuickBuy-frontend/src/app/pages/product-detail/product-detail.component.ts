import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  id: string;
  product: ProductModel = new ProductModel(null, null, null, null, null, null, null, null);
  constructor(
    private route: ActivatedRoute,
    private searchService: SearchService,
    private router: Router
  ) {
    this.route.params.subscribe((params: Params) => {
      if (params['id'] === undefined) {
        this.id = '';
      } else {
        this.id = '' + params['id'];
      }
    });
  }

  ngOnInit(): void {
    this.searchService
      .getProduct(this.id)
      .subscribe(product => (this.product = product), error => console.log(error));
  }

}
