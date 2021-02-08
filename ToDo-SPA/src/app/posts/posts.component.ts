import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Blog } from '../_models/Blog';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {
  myInterval: any;
  activeSlideIndex: any;
  slides: any;

  blogs: any;
  constructor(private userService: UserService, private alertify: AlertifyService, private router: ActivatedRoute) { }

  ngOnInit() {
    this.myInterval = 1500;
    this.activeSlideIndex = 0;

    this.slides = [
      {image: 'https://cdn.mos.cms.futurecdn.net/SjD29bXoQtK3joTcZUF6nd.jpg'},
      {image: 'https://introvertdear.com/wp-content/uploads/2019/07/why-INFJs-should-start-a-blog-770x470.jpg'},
      {image: 'https://cdn.mos.cms.futurecdn.net/SjD29bXoQtK3joTcZUF6nd.jpg'}
    ];

    this.router.data.subscribe(
      (blogsData:Blog[]) => {
        this.blogs = blogsData['blogs'];
      }
    );
  }


  // loadBlogs(){
  //   this.userService.getBlogs().subscribe(
  //     blogs => {
  //       this.blogs = blogs;
  //     },
  //     error => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }
}
