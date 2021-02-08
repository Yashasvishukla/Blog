import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
baseUrl = 'http://localhost:5000/api/blog/';
constructor(private http: HttpClient) { }

addBlog(blog: any){
  return this.http.post(this.baseUrl, blog);
}

getBlog(id){
  return this.http.get(this.baseUrl + id);
}

getBlogs(){
  return this.http.get(this.baseUrl);
}

}
