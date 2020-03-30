import { PageRequest } from './../../core/models/page-request';

export interface ProductsByCategoryRequest extends PageRequest {
  categoryId: string;
}

