import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { AddProductComponent } from './add-product/add-product.component';
import { AddProductCategoryComponent } from './add-product-category/add-product-category/add-product-category.component';

@NgModule({
  declarations: [AddProductComponent, AddProductCategoryComponent],
  imports: [
    ReactiveFormsModule,
    SharedModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule {}
