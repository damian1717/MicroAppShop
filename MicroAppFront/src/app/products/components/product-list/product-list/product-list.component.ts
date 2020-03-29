import { MatSnackBar } from '@angular/material';
import { BaseComponent } from './../../../../core/base-component/base-component';
import { ProductService } from './../../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  size = 4;
  constructor(private route: ActivatedRoute,
              private sanitizer: DomSanitizer,
              private productService: ProductService,
              public snackBar: MatSnackBar) { super(snackBar); }

  ngOnInit() {
    this.categoryId = this.route.snapshot.paramMap.get('id');
    this.getAllProducts(this.categoryId);


  }

  private getAllProducts(categoryId: string) {
    this.productService.getAllProductByCategoryId(categoryId).subscribe(
      (data) => {
        console.log(data);

        data.forEach(d => {
          const objectURL = 'data:image/png;base64,' + d.document.fileArray;
          d.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
        console.log(data);
        this.data = data;
        // this.getData({pageIndex: this.page, pageSize: this.size}, data);
      },
      (error) => console.log(error)
    );
  }

  getData(obj) {
    let index=0,
        startingIndex=obj.pageIndex * obj.pageSize,
        endingIndex=startingIndex + obj.pageSize;

    this.data = this.data.filter(() => {
      index++;
      return (index > startingIndex && index <= endingIndex) ? true : false;
    });
  }

}
