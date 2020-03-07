import { Product } from './../../_models/products/product';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';

  constructor(private http: HttpClient) { }

  addProduct(product?: Product) {
    return this.http.post(this.baseUrl, product);
  }
}
