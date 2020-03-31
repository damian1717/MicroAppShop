import { ProductsByCategoryRequest } from '../../models/productsByCategoryRequest';
import { MatSnackBar } from '@angular/material';
import { BaseComponent } from '../../../core/base-component/base-component';
import { ProductService } from '../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from 'src/app/products/models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent extends BaseComponent implements OnInit {

  categoryId: string;
  data: Product[] = new Array<Product>();
  page = 0;
  size = 10;
  totalPage: any;
  request: ProductsByCategoryRequest = { categoryId: undefined, page: undefined };
  constructor(private route: ActivatedRoute,
              private sanitizer: DomSanitizer,
              private productService: ProductService,
              private router: Router,
              public snackBar: MatSnackBar) { super(snackBar); }

  ngOnInit() {
    this.request.page = this.page + 1;
    this.request.categoryId = this.route.snapshot.paramMap.get('id');
    this.getAllProducts(this.request);
  }

  private getAllProducts(request: ProductsByCategoryRequest) {
    this.productService.getAllProductByCategoryId(request).subscribe(
      (data) => {
        this.totalPage = data.headers.get('X-Total-Count');
        data.body.forEach(d => {
          const objectURL = 'data:image/png;base64,' + d.document.fileArray;
          d.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
        this.data = data.body;
      },
      (error) => console.log(error)
    );
  }

  getData(event) {
    this.request.page = event.pageIndex + 1;
    this.data = [];
    this.getAllProducts(this.request);
  }

  redirectToProductDetails(product: Product) {
    this.router.navigate(['product/' + product.id]);
  }
}
