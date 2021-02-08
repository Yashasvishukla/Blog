import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Blog } from '../_models/Blog';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.css']
})
export class BlogDetailComponent implements OnInit {
  @Input() blog: any;
  constructor(private userService: UserService, private router: ActivatedRoute, private alertify: AlertifyService) { }

  blogDetail: Blog;
  ngOnInit() {
    this.router.data.subscribe(
      blogData => {
        this.blogDetail = blogData['blog'];
      }
    );
  }

  // loadBlog(){
  //   this.userService.getBlog(this.router.snapshot.params['id']).subscribe(
  //   (blogData: Blog) =>{
  //     this.blogDetail = blogData;
  //   },
  //   error => {
  //     this.alertify.error('Error in fetching blog data');
  //   });
  // }

}
