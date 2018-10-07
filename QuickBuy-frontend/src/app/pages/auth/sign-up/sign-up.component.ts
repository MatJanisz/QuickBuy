import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../shared/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(private authService: AuthService) {}

  ngOnInit() {}
  onSignUp(form: NgForm) {
    const email = form.value.email;
    const password = form.value.password;
    this.authService
      .signUpUser(email, password)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
}
