import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  isActive = false;
  constructor(public authService: AuthService) { }

  ngOnInit() {
  }
  onAdd(input: number) {
      this.authService.addMoney(Math.abs(input));
   }


}
