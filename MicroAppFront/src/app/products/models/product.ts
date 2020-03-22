import { ProductCategory } from './productCategory';

export interface Product {
  id: string;
  name: string;
  price: number;
  description: string;
  categoryId: number;
  productCategory?: ProductCategory;
}
