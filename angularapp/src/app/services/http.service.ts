import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private apiUrl = 'https://localhost:7237/api';

  constructor(private http: HttpClient) { }

  get<T>(url: string, options?: {
    headers?: HttpHeaders | { [header: string]: string | string[] };
    params?: HttpParams | { [param: string]: string | string[] };
  }): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${url}`, options);
  }

  post<TResult, TBody>(url: string, body: TBody, options?: {
    headers?: HttpHeaders | { [header: string]: string | string[] };
    params?: HttpParams | { [param: string]: string | string[] };
  }): Observable<TResult> {
    return this.http.post<TResult>(`${this.apiUrl}/${url}`, body, options);
  }
}
