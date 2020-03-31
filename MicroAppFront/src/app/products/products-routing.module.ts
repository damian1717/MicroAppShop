import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from './components/add-product/add-product.component';
import { AuthGuard } from '../core/auth/guards/auth.guard';
import { AddProductCategoryComponent } from './components/add-product-category/add-product-category.component';

const routes: Routes = [
  { path: 'add-product', component: AddProductComponent, canActivate: [AuthGuard] },
  { path: 'add-product-category', component: AddProductCategoryComponent, canActivate: [AuthGuard] },
  { path: 'products/:category/:id', component: ProductListComponent, canActivate: [AuthGuard] },
  { path: 'product/:id', component: ProductDetailsComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ProductsRoutingModule {}
