export interface IPagedList<T> {
    data: T[];
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    isFirstPage: boolean;
    isLastPage: boolean;
}
