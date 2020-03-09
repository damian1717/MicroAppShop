import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { BaseComponent } from 'src/app/core/base-component/base-component';
import { TranslateService } from 'src/app/shared/translate/translate.service';
import { TranslatePipe } from 'src/app/shared/translate/translate.pipe';
import { AuthService } from 'src/app/core/auth/services/auth.service';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss']
})
export class SidenavListComponent extends BaseComponent implements OnInit {

  @Output() closeSidenav = new EventEmitter<void>();
  constructor(
    private authService: AuthService,
    public snackBar: MatSnackBar,
    private router: Router,
    private translate: TranslateService,
    private translatePipe: TranslatePipe, ) { super(snackBar); }

  ngOnInit() {
  }

  onClose() {
    this.closeSidenav.emit();
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
