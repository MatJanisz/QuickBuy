import { ProductModel } from 'src/app/shared/models/product.model';
import { ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/services/product.service';
import { SearchService } from '../../shared/services/search.service';
import { NgForm } from '@angular/forms';
import { Category } from '../../shared/enums/category.enum';
import { EditProductModel } from '../../shared/models/editProduct.model';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  isPhotoChecked = false;
  categories = Category;
  id: string;
  productDetails = new ProductModel(null, null, null, null, null, null, null, null);
  constructor(private productService: ProductService, private searchService: SearchService, private route: ActivatedRoute) {
    this.route.params.subscribe((params: Params) => {
      if (params['id'] === undefined) {
        this.id = '';
      } else {
        this.id = '' + params['id'];
      }
    });
    this.searchService
      .getProduct(this.id)
      .subscribe(
        event => this.productDetails = event,
        error => console.log(error)
      );
   }

  ngOnInit() {
  }
  onEditProduct(form: NgForm) {
    const editedProduct = new EditProductModel(
      this.productDetails.id,
      this.productDetails.name,
      this.productDetails.price,
      this.productDetails.quantity,
      this.productDetails.category,
      this.productDetails.imageSource,
      this.productDetails.description
    );
    console.log(editedProduct.id);
    console.log(editedProduct.name);
    console.log(editedProduct.price);
    console.log(editedProduct.quantity);
    console.log(editedProduct.category);
    console.log(editedProduct.imageSource);
    console.log(editedProduct.description);
     this.productService.editProduct(editedProduct)
      .subscribe(response => console.log(response), error => console.log(error));

  }

}
