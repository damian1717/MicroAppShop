import { Document } from './../../shared/documents/models/document';
import { ProductCategory } from './productCategory';

export interface Product {
  id: string;
  name: string;
  price: number;
  description: string;
  categoryId: number;
  productCategory?: ProductCategory;
  document?: Document;
  image?: any;
}
