import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { AddProductComponent } from './components/add-product/add-product.component';
import { AddProductCategoryComponent } from './components/add-product-category/add-product-category.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

@NgModule({
  declarations: [AddProductComponent, AddProductCategoryComponent, ProductListComponent, ProductDetailsComponent],
  imports: [
    ReactiveFormsModule,
    SharedModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule {}
