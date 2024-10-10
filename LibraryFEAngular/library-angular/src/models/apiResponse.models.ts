import { Book } from './book.models';        

export interface ApiResponse {
    isSuccess: boolean;
    errorMessages: string[];
    result: Book[];
  }