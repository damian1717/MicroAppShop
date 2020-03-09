import { Component, OnInit } from '@angular/core';
import { TranslatePipe } from 'src/app/core/translate/translate.pipe';
import { Router } from '@angular/router';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { BaseComponent } from 'src/app/core/base-component/base-component';
import { MatSnackBar } from '@angular/material';
import { AuthService } from 'src/app/core/auth/services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent implements OnInit {

  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    public snackBar: MatSnackBar,
    private translatePipe: TranslatePipe,
    private router: Router) { super(snackBar); }

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', {
        validators: [Validators.email, Validators.required]
      }),
      password: new FormControl('', { validators: [Validators.required] })
    });

    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('main');
    }
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(next => {
      this.router.navigate(['/main']);
      this.openSnackBar(this.translatePipe.transform('LOGGED_IN'), this.COLOR_SNACKBAR_GREEN);
    }, (error: HttpErrorResponse) => {
      console.log(error);
    });
  }

}
