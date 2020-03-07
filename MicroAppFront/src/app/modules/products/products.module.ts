import { AddProductComponent } from './../../components/products/add-product/add-product/add-product.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';

@NgModule({
  declarations: [AddProductComponent],
  imports: [
    ReactiveFormsModule,
    SharedModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule {}
