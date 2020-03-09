import { Component, OnInit } from '@angular/core';
import { TranslatePipe } from 'src/app/shared/translate/translate.pipe';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { BaseComponent } from 'src/app/core/base-component/base-component';
import { MatSnackBar } from '@angular/material';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthService } from 'src/app/core/auth/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent extends BaseComponent implements OnInit {

  constructor(
    private authService: AuthService,
    public snackBar: MatSnackBar,
    private translatePipe: TranslatePipe,
    private router: Router) { super(snackBar); }

  ngOnInit() {
  }

  register(form: NgForm) {
    this.authService.register(form.value).subscribe(() => {
      this.router.navigate(['/login']);
      this.openSnackBar(this.translatePipe.transform('REGISTERED'), this.COLOR_SNACKBAR_GREEN);
    }, (error: HttpErrorResponse) => {
      console.log(error);
    });
  }
}
