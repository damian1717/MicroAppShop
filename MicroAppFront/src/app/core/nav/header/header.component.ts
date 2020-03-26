import { ProductService } from './../../../products/services/product.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { TranslatePipe } from 'src/app/shared/translate/translate.pipe';
import { TranslateService } from 'src/app/shared/translate/translate.service';
import { BaseComponent } from 'src/app/core/base-component/base-component';
import { MatSnackBar } from '@angular/material';
import { AuthService } from 'src/app/core/auth/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends BaseComponent implements OnInit {

  @Output() sidenavToggle = new EventEmitter<void>();
  productCategories$ = this.productService.productCategories$;

  constructor(
    private authService: AuthService,
    public snackBar: MatSnackBar,
    private translate: TranslateService,
    private translatePipe: TranslatePipe,
    private router: Router,
    private productService: ProductService) { super(snackBar); }

  ngOnInit() {
  }

  onToggleSidenav() {
    this.sidenavToggle.emit();
  }

  setLang(lang: string) {
    this.translate.use(lang);
  }

  loggedIn() {
     return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/']);
    this.openSnackBar(this.translatePipe.transform('LOGGED_OUT'), this.COLOR_SNACKBAR_GREEN);
  }
}
