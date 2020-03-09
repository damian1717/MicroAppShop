import { Document } from './document';
import { ProductCategory } from './productCategory';

export interface Product {
  name: string;
  price: number;
  description: string;
  categoryId: number;
  productCategory?: ProductCategory;
  document?: Document;
}
