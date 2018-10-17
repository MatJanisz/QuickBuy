import { ProductModel } from './../models/product.model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AddProductModel } from 'src/app/shared/models/addProduct.model';
import { EditProductModel } from '../models/editProduct.model';

@Injectable()
export class ProductService {
  constructor(private _http: HttpClient, private router: Router,  private jwtHelper: JwtHelperService ) {}
  url = 'product/';
  testGet() {
    return this._http.get(
      this.url + 'testGet');
  }
  testPost() {
    return this._http.post(
      this.url + 'testPost', null);
  }
  buyProduct(id: string, howMany: number) {
    return this._http.post(
      this.url + 'BuyProduct/' + id + '/' + howMany, null);
  }
  addProduct(newProduct: AddProductModel) {
    return this._http.post(
      this.url, newProduct);
  }
  getAllMyBoughtProducts(): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetAllMyBoughtProducts');
  }
  getAllMyProducts(): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetAllMyProducts');
  }
  editProduct(product: EditProductModel) {
    return this._http.put(
      this.url, product);
  }
}
