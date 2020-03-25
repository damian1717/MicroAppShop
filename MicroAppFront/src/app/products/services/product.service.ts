import { Product } from '../models/product';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ProductCategory } from '../models/productCategory';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';

  constructor(private http: HttpClient) { }

  productCategories$ = this.http.get<ProductCategory[]>(`${this.baseUrl}/GetAllProductCategories`)
    .pipe(
      catchError(err => {
        console.error(err);
        return throwError(err);
      })
    );

  addProduct(product?: Product) {
    return this.http.post(`${this.baseUrl}/AddProduct`, product);
  }

  addProductCategory(productCategory?: ProductCategory) {
    return this.http.post(`${this.baseUrl}/AddProductCategory`, productCategory);
  }
}
