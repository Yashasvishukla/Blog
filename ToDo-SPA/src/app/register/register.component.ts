import { Output } from '@angular/core';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegisterMode = new EventEmitter();
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(
      () => {
        this.alertify.success('register successfully');
      },
      error => {
        this.alertify.error(error);
      });
  }

  cancel(){
    this.cancelRegisterMode.emit(false);
  }

}
