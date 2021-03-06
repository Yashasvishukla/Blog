import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PostsComponent } from './posts/posts.component';
import { NewPostComponent } from './new-post/new-post.component';
import { RouterModule } from '@angular/router';
import { appRouter } from './router';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { BlogDetailResolver } from './_resolvers/blog-detail.resolver';
import { BlogListResolver } from './_resolvers/blog-list.resolver';

@NgModule({
  declarations: [						
    AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PostsComponent,
      NewPostComponent,
      BlogDetailComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRouter),
    CarouselModule.forRoot()
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    BlogListResolver,
    BlogDetailResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
