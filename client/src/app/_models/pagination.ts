export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
    search: string;
}

export class PaginatedResult<T>{
    result: T;
    pagination: Pagination;
}