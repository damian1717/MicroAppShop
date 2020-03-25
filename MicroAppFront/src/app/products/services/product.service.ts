import { Product } from '../models/product';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ProductCategory } from '../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';

  constructor(private http: HttpClient) { }

  addProduct(product?: Product) {
    return this.http.post(`${this.baseUrl}/AddProduct`, product);
  }

  addProductCategory(productCategory?: ProductCategory) {
    return this.http.post(`${this.baseUrl}/AddProductCategory`, productCategory);
  }
}
