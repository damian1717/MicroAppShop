import { MatSnackBar } from '@angular/material';

export class BaseComponent {
  constructor(
    public snackBar: MatSnackBar
  ) { }

  readonly COLOR_SNACKBAR_RED = 'red';
  readonly COLOR_SNACKBAR_GREEN = 'green';
  readonly COLOR_SNACKBAR_YELLOW = 'yellow';

  openSnackBar(message: string, color: string) {
    this.snackBar.open(message, '', {
      panelClass: [
        'snack-bar-color-' + color,
        'snack-bar'
      ],
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'end'
    });
  }
}