import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPostComponent } from './add-post/add-post.component';
import { HomeComponent } from './home/home.component';
import { ViewPostComponent } from './view-post/view-post.component';

const routes: Routes = [
  { path: 'add-post', component: AddPostComponent },
  { path: 'article/:slug', component: ViewPostComponent },
  { path: '**', component: HomeComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
