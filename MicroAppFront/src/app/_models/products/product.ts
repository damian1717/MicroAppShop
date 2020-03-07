import { Document } from './../documents/document';
import { ProductCategory } from './ProductCategory';

export interface Product {
  name: string;
  price: number;
  description: string;
  categoryId: number;
  productCategory?: ProductCategory;
  document?: Document;
}
