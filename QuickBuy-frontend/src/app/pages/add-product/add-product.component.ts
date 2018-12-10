import { AuthService } from './../../shared/services/auth.service';
import { AddProductModel } from './../../shared/models/addProduct.model';
import { Category } from './../../shared/enums/category.enum';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/services/product.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  isPhotoChecked = false;
  categories = Category;
  constructor(private productService: ProductService, public authService: AuthService, router: Router) { }

  ngOnInit() {
    this.authService.checkUserData();
  }

  onCreate() {
  }
  onAddProduct(form: NgForm) {
    const product: AddProductModel = new AddProductModel(
      form.value.title,
      form.value.price,
      form.value.quantity,
      form.value.category,
      form.value.path,
      form.value.description
    );
      this.productService.addProduct(product)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }

}
