import { ProductCategory } from './../../models/productCategory';
import { BaseComponent } from './../../../core/base-component/base-component';
import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { TranslatePipe } from 'src/app/shared/translate/translate.pipe';
import { MatSnackBar } from '@angular/material';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-product-category',
  templateUrl: './add-product-category.component.html',
  styleUrls: ['./add-product-category.component.scss']
})
export class AddProductCategoryComponent extends BaseComponent {

  productCategory: ProductCategory = { id: undefined, name: undefined };

  constructor(private productService: ProductService,
              private translatePipe: TranslatePipe,
              public snackBar: MatSnackBar) { super(snackBar); }

  addProductCategory(productCategory: ProductCategory) {
    if (!this.validateFields()) {
      this.productService.addProductCategory(productCategory).subscribe(
        (success) => {
          this.clear();
          this.openSnackBar(this.translatePipe.transform('ADDED_PRODUCT_CATEGORY'), this.COLOR_SNACKBAR_GREEN);
        },
        (error) => {
          console.log(error);
          this.openSnackBar(this.translatePipe.transform('ERROR'), this.COLOR_SNACKBAR_RED);
        });
    } else {
      this.openSnackBar(this.translatePipe.transform('VALID_NAME'), this.COLOR_SNACKBAR_YELLOW);
    }
  }

  clear() {
    this.productCategory = { id: undefined, name: undefined };
  }

  private validateFields(): boolean {
    if (this.validateName()) {
      return false;
    }

    return true;
  }

  private validateName(): boolean {
    if (this.productCategory.name === undefined || this.productCategory.name.length <= 3) {
      return false;
    }
    return true;
  }
}
