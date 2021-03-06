import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Blog-App';
  constructor(private authService: AuthService){}

  ngOnInit(){
    this.setUsername();
  }

  setUsername(){
    const token = localStorage.getItem('token');
    if(token){
      this.authService.decodedToken = this.authService.jwtHelperService.decodeToken(token);
    }
  }

}
