import { AuthService } from './../../shared/services/auth.service';
import { Component, OnInit, Input } from '@angular/core';
import { UserModel } from '../../shared/models/user.model';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {
  @Input() user: UserModel;
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }
  onBlockUser() {
    this.authService.changeIsBlockedStatus(this.user.id)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
    this.user.isBlocked = true;
  }
  onUnblockUser() {
    this.authService.changeIsBlockedStatus(this.user.id)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
    this.user.isBlocked = false;
  }

}
