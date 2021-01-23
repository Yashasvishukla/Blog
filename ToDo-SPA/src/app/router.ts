import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NewPostComponent } from './new-post/new-post.component';
import { PostsComponent } from './posts/posts.component';
import { AuthGuard } from './_services/auth.guard';

export const appRouter: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'posts', component: PostsComponent},
            {path: 'new-post', component: NewPostComponent}
        ]

    },
    {path: '**', redirectTo: '' , pathMatch: 'full'}
];

