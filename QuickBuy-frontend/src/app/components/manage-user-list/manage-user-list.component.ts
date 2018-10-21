import { AuthService } from 'src/app/shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../shared/models/user.model';

@Component({
  selector: 'app-manage-user-list',
  templateUrl: './manage-user-list.component.html',
  styleUrls: ['./manage-user-list.component.css']
})
export class ManageUserListComponent implements OnInit {

  users: UserModel[] = [];
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.getAllUsers()
    .subscribe(users => (this.users = users), error => console.log(error));
  }
}
