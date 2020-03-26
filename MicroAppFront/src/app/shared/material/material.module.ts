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
  MatPaginatorModule,
  MatMenuModule
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
  MatPaginatorModule,
  MatMenuModule
];

@NgModule({
  imports: [materialComponents],
  exports: [materialComponents]
})
export class MaterialModule { }
