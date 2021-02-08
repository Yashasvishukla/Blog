import { Injectable } from "@angular/core";
import { Resolve, Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Blog } from "../_models/Blog";
import { AlertifyService } from "../_services/alertify.service";
import { UserService } from "../_services/user.service";

@Injectable()
export class BlogListResolver implements Resolve<Blog[]>{

    constructor(private userService: UserService, private alertify: AlertifyService, private router: Router){}

    resolve(): Observable<Blog[]>{
        return this.userService.getBlogs().pipe(
            catchError (error => {
                this.alertify.error('Error occured while fetching the Blog list');
                this.router.navigate(['']);
                return of(null);
            })
        );
    }
}