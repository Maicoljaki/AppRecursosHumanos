import { Component } from '@angular/core';
import { EcuasolEmisor } from '../models/EcuasolEmisor';
import { LoginRequest } from '../models/LoginRequest';
import { AuthService } from '../services/auth.service';
import { EmisorService } from '../services/emisor.service';
import { RequestResult } from '../models/RequestResult';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  emisors: EcuasolEmisor[] = [];
  loginRequest: LoginRequest = {
    usuario: "",
    password: "",
    codigoEmisor: 0
  }

  result: RequestResult<boolean> | null = null;

  constructor(private _authService: AuthService, private _router: Router, _emisorService: EmisorService) {
    _emisorService.getAll().subscribe(e => this.emisors = e);
  }

  login() {
    this._authService.login(this.loginRequest).subscribe(r => {
      this.result = r;
      if (!this.result.isError) {
        this._router.navigate(['/home']);
      }
    });
  }
}
