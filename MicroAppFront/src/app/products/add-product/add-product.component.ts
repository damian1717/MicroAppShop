import { TranslatePipe } from '../../core/translate/translate.pipe';
import { BaseComponent } from '../../core/base-component/base-component';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { ProductCategory } from '../models/productCategory';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
export interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent extends BaseComponent implements OnInit {

  product: Product = {
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
  uploadImage = false;
  constructor(private productService: ProductService,
              private translatePipe: TranslatePipe,
              public snackBar: MatSnackBar) { super(snackBar); }

  ngOnInit() {
  }

  addProduct(product: Product) {
    this.productService.addProduct(product).subscribe(
      (success) => {
        this.clear();
        this.openSnackBar(this.translatePipe.transform('ADDED_PRODUCT'), this.COLOR_SNACKBAR_GREEN);
      },
      (error) => {
        console.log(error);
        this.openSnackBar(this.translatePipe.transform('ERROR'), this.COLOR_SNACKBAR_RED);
      });
  }

  clear() {
    this.product = { name: undefined, price: undefined, description: undefined, categoryId: undefined };
  }

  showUploadImage() {
    this.uploadImage = !this.uploadImage;
  }
}
