import { ProductService } from './../../services/product.service';
import { BaseComponent } from 'src/app/core/base-component/base-component';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { Product } from '../../models/product';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent extends BaseComponent implements OnInit {

  product: Product = { id: undefined, name: undefined, image: undefined, price: undefined, categoryId: undefined, description: undefined };
  id: string;
  constructor(private route: ActivatedRoute,
              public snackBar: MatSnackBar,
              private productService: ProductService,
              private sanitizer: DomSanitizer) { super(snackBar); }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getProductById(this.id);
  }

  private getProductById(id: string) {
    this.productService.getProductById(id).subscribe(product => {
      const objectURL = 'data:image/png;base64,' + product.document.fileArray;
      product.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      this.product = product;
    });
  }
}
