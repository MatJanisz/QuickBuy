import { ProductModel } from './../models/product.model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SearchService {
  constructor(private _http: HttpClient) {}
  url = 'product/';

  getAll(): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
       this.url
    );
  }
  getProduct(productId: string): Observable<ProductModel> {
    return this._http.get<ProductModel>(
      this.url + 'GetProduct/' + productId
    );
  }
  getProductsByName(name: string): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetProductsByName/' + name
    );
  }
  getProductsByCategory(category: string): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetProductsByCategory/' + category
    );
  }
  getProductsByNameAndCategory(name: string, category: string): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetProductsByNameAndCategory/' + name + '/' + category
    );
  }
  getRandomProducts(howMany: number): Observable<ProductModel[]> {
    return this._http.get<ProductModel[]>(
      this.url + 'GetRandomProducts/' + howMany
    );
  }



}
