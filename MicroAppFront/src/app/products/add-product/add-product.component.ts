import { TranslatePipe } from '../../shared/translate/translate.pipe';
import { BaseComponent } from '../../core/base-component/base-component';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { ProductCategory } from '../models/productCategory';
import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Guid } from 'guid-typescript';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent extends BaseComponent {

  product: Product = {
    id: Guid.create().toString(),
    name: undefined,
    price: undefined,
    description: undefined,
    categoryId: undefined
  };

  categories: ProductCategory[] = [
    { id: 1, name: 'Category1'},
    { id: 2, name: 'Category2'},
    { id: 3, name: 'Category3'}
  ];

  constructor(private productService: ProductService,
              private translatePipe: TranslatePipe,
              public snackBar: MatSnackBar,
              private router: Router) { super(snackBar); }

  addProduct(product: Product) {
    if (this.validateFields()) {
    this.productService.addProduct(product).subscribe(
      (success) => {
        this.clear();
        this.redirectToUploadDocuments();
        this.openSnackBar(this.translatePipe.transform('ADDED_PRODUCT'), this.COLOR_SNACKBAR_GREEN);
      },
      (error) => {
        console.log(error);
        this.openSnackBar(this.translatePipe.transform('ERROR'), this.COLOR_SNACKBAR_RED);
      });
    } else {
      this.openSnackBar(this.translatePipe.transform('FILL_PRODUCT'), this.COLOR_SNACKBAR_YELLOW);
    }
  }

  private redirectToUploadDocuments() {
    this.router.navigate(['upload-documents/', { id: this.product.id.toString(), redirectTo: 'add-product' }]);
  }

  clear() {
    this.product = { id: Guid.create().toString(), name: undefined, price: undefined, description: undefined, categoryId: undefined };
  }

  private validateFields(): boolean {
    if (!this.validateName()) {
      return false;
    }

    if (!this.validateCategory()) {
      return false;
    }

    if (!this.validatePrice()) {
      return false;
    }

    if (!this.validateDescription()) {
      return false;
    }

    return true;
  }

  private validateName(): boolean {
    if (this.product.name === undefined || this.product.name.length < 3) {
      return false;
    }
    return true;
  }

  private validateCategory(): boolean {
    if (this.product.categoryId === undefined) {
      return false;
    }
    return true;
  }

  private validatePrice(): boolean {
    if (this.product.price === undefined) {
      return false;
    }
    return true;
  }

  private validateDescription(): boolean {
    if (this.product.description === undefined || this.product.description.length < 3) {
      return false;
    }
    return true;
  }
}
