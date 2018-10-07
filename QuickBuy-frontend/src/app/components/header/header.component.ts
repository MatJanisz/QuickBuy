import { AuthService } from './../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(public authService: AuthService) {}
  ngOnInit() {
  }
  onLogout() {
    this.authService.logout();
  }

  onTest() {
    console.log('abc');
    console.log(this.authService.email);
    console.log(this.authService.money);
    console.log(this.authService.isAdmin);
  }

}
