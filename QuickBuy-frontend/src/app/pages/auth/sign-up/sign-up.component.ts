import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../shared/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  isPasswordValid = true;
  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.checkUserData();
  }
  onSignUp(form: NgForm) {
    const email = form.value.email;
    const password = form.value.password;
    console.log(password);
    if (password.search('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$') !== -1) {
      this.isPasswordValid = true;
      this.authService
      .signUpUser(email, password)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
    } else {
      this.isPasswordValid = false;
    }
  }
}
