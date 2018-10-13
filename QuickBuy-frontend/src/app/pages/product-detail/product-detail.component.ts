import { AuthService } from './../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../shared/models/product.model';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { SearchService } from '../../shared/services/search.service';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  id: string;
  product: ProductModel = new ProductModel(null, null, null, null, null, null, null, null);
  result: Object;
  resultOfTransaction: any;
  numberOfBoughtProducts = 0;
  constructor(
    private route: ActivatedRoute,
    private searchService: SearchService,
    private router: Router,
    private productService: ProductService,
    public authService: AuthService
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

  test() {
   // console.log('abc');
    /* this.productService
      .testGet()
      .subscribe(result => (this.result = result, error => console.log(error)));
      console.log(this.result); */
      this.productService
      .testPost()
      .subscribe(result => (this.result = result, error => console.log(error)));
  }

  onBuyNow() {
    this.productService
    .buyProduct(this.id, this.numberOfBoughtProducts)
    .subscribe(resultOfTransaction => (this.resultOfTransaction = resultOfTransaction), error => console.log(error));
    if (this.resultOfTransaction === 2) {
      this.product.quantity -= this.numberOfBoughtProducts;
    }
  }

}
