export interface RequestResult<T> {
    isError: boolean,
    error: string,
    result: T
}