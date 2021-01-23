import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {
  myInterval: any;
  activeSlideIndex: any;
  slides: any;
  constructor() { }

  ngOnInit() {
    this.myInterval = 1500;
    this.activeSlideIndex = 0;

    this.slides = [
      {image: 'https://cdn.mos.cms.futurecdn.net/SjD29bXoQtK3joTcZUF6nd.jpg'},
      {image: 'https://introvertdear.com/wp-content/uploads/2019/07/why-INFJs-should-start-a-blog-770x470.jpg'},
      {image: 'https://cdn.mos.cms.futurecdn.net/SjD29bXoQtK3joTcZUF6nd.jpg'}
    ];
  }
}
