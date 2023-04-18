import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { EcuasolEmisor } from '../models/EcuasolEmisor';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmisorService {

  constructor(private _http: HttpService) { }

  getAll(): Observable<EcuasolEmisor[]> {
    return this._http.get<EcuasolEmisor[]>("Emisor");
  }
}
