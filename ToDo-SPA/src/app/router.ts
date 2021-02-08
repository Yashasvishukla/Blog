import { Routes } from '@angular/router';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { HomeComponent } from './home/home.component';
import { NewPostComponent } from './new-post/new-post.component';
import { PostsComponent } from './posts/posts.component';
import { BlogDetailResolver } from './_resolvers/blog-detail.resolver';
import { BlogListResolver } from './_resolvers/blog-list.resolver';
import { AuthGuard } from './_services/auth.guard';

export const appRouter: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'posts', component: PostsComponent, resolve: {blogs : BlogListResolver }},
            { path : 'posts/:id' , component: BlogDetailComponent , resolve : {blog :  BlogDetailResolver} },
            {path: 'new-post', component: NewPostComponent}
        ]

    },
    {path: '**', redirectTo: '' , pathMatch: 'full'}
];

