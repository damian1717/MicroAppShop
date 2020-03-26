import { MatSnackBar } from '@angular/material';
import { BaseComponent } from './../../../../core/base-component/base-component';
import { ProductService } from './../../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent extends BaseComponent implements OnInit {

  categoryId: string;
  constructor(private route: ActivatedRoute, private productService: ProductService, public snackBar: MatSnackBar) { super(snackBar); }

  ngOnInit() {
    this.categoryId = this.route.snapshot.paramMap.get('id');
    console.log(this.categoryId);
    this.getAllProducts(this.categoryId);
  }

  private getAllProducts(categoryId: string) {
    this.productService.getAllProductByCategoryId(categoryId).subscribe(
      (data) => {
        console.log(data);
      },
      (error) => console.log(error)
    );
  }

}
