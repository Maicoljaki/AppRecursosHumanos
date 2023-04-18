import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/LoginRequest';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';
import { RequestResult } from '../models/RequestResult';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _http: HttpService) { }

  login(user: LoginRequest): Observable<RequestResult<boolean>> {
    return this._http.post<RequestResult<boolean>, LoginRequest>("Auth", user);
  }
}
