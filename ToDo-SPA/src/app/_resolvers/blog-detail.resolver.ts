import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Blog } from "../_models/Blog";
import { AlertifyService } from "../_services/alertify.service";
import { UserService } from "../_services/user.service";

@Injectable()

export class BlogDetailResolver implements Resolve<Blog>{

    constructor(private userService: UserService, private alertify: AlertifyService, private router: Router){}

    resolve(route: ActivatedRouteSnapshot): Observable<Blog>{
        return this.userService.getBlog(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['/posts']);
                return of(null);
            })
        );
    }
}