import { Output } from '@angular/core';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegisterMode = new EventEmitter();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(
      () => {
        console.log('register successfully');
      },
      error => {
        console.log(error);
      });
  }

  cancel(){
    this.cancelRegisterMode.emit(false);
  }

}
