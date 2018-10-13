import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthenticationUserModel } from '../models/authenticationUser.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tokenGetter} from './../../app.module';
import { User } from '../models/user.model';

@Injectable()
export class AuthService {
  constructor(private _http: HttpClient, private router: Router,  private jwtHelper: JwtHelperService ) {}
  url = 'User';
  loggedUser = new User(null, null, null);
  email: any;
  isAdmin: any;
  money: number;

   public getToken(): string {
    return localStorage.getItem('token');
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if (token === 'null') {
      return false;
    }
    if (!this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
   // return token != null && !this.jwtHelper.isTokenExpired(token);
   return false;
  }

  signUpUser(email: string, password: string) {
    const user: AuthenticationUserModel = new AuthenticationUserModel(
      email,
      password
    );
    // this.router.navigate(['/']);
    return this._http.post(this.url + '/Register', user);
  }
  signInUser(email: string, password: string) {
    const user: AuthenticationUserModel = new AuthenticationUserModel(
      email,
      password
    );
    return this._http.post(this.url + '/Login', user).subscribe(
      (token: string) => {
        localStorage.setItem('token', token['token']);
        if (token['token'] === 'Your login or password is incorrect') {
          localStorage.clear();
          console.log('Your login or password is incorrect');
        } else {
          this.getEmailOfLoggedUser();
          this.isLoggedUserAdmin();
          this.getMoneyOfLoggedUser();
          this.router.navigate(['/']);
        }
      },
      error => console.log(error)
    );
  }
  getEmailOfLoggedUser() {
    return this._http.get(
      this.url + '/GetEmailOfLoggedUser/', {responseType: 'text'})
       .subscribe(email => this.email = email);
      // .subscribe(email => console.log(email));
  }

  isLoggedUserAdmin() {
    return this._http.get(
      this.url + '/IsLoggedUserAdmin/', {responseType: 'text'})
       .subscribe(isAdmin => this.isAdmin = isAdmin);
  }

  getMoneyOfLoggedUser() {
    return this._http.get(
      this.url + '/GetMoneyOfLoggedUser/', {responseType: 'text'})
       .subscribe(money => this.money = +money); // + operator change string to number
  }

  checkUserData() {
    if (this.getToken() !== null) {
      this.getEmailOfLoggedUser();
      this.isLoggedUserAdmin();
      this.getMoneyOfLoggedUser();
    }
  }
  addMoney(money: number) {
    this.money += money;
    return this._http.post(
      this.url + '/AddMoney/' + money, '')
       .subscribe(log => console.log(log));
      // .subscribe(email => console.log(email));
  }

  test() {
    console.log(this.email);
  }

  testGet() {
    return this._http.post(
      this.url, null);
  }

  logout() {
    localStorage.clear();
    this.email = '';
    this.isAdmin = '';
    this.money = 0;
    this.router.navigate(['/']);
  }
}
