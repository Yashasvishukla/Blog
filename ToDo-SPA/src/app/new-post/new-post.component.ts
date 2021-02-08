import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.scss']
})
export class NewPostComponent implements OnInit {

  blog: any = {};
  constructor(private userService: UserService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  newPost(){
    this.userService.addBlog(this.blog).subscribe(
      blogData => {
        this.alertify.success('Blog Successfully Posted');
        this.router.navigate(['/posts']);
      },
      error => {
        this.alertify.error('Something went wrong!!');
      },
      
    );
  }

}
