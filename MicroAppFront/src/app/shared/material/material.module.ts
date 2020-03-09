import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatSidenavModule,
  MatToolbarModule,
  MatIconModule,
  MatListModule,
  MatDatepickerModule,
  MatInputModule,
  MatFormFieldModule,
  MatNativeDateModule,
  MatCheckboxModule,
  MatSelectModule,
  MatSnackBarModule,
  MatTabsModule,
  MatTableModule,
  MatSlideToggleModule,
  MatSortModule,
  MatDialogModule,
  MatPaginatorModule
} from '@angular/material';

const materialComponents = [
  MatButtonModule,
  MatSidenavModule,
  MatToolbarModule,
  MatIconModule,
  MatListModule,
  MatDatepickerModule,
  MatInputModule,
  MatFormFieldModule,
  MatNativeDateModule,
  MatCheckboxModule,
  MatSelectModule,
  MatSnackBarModule,
  MatTabsModule,
  MatTableModule,
  MatSlideToggleModule,
  MatSortModule,
  MatDialogModule,
  MatPaginatorModule
];

@NgModule({
  imports: [materialComponents],
  exports: [materialComponents]
})
export class MaterialModule { }
