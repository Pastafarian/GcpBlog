import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Post } from '../app.component';

@Component({
  selector: 'app-view-post',
  templateUrl: './view-post.component.html',
  styleUrls: ['./view-post.component.scss']
})
export class ViewPostComponent implements OnInit {

  title!: string;
  slug!: string;
  body!: string;

  constructor(private httpClient: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      switchMap(params => this.httpClient.get<Post>(`${environment.baseUrl}post/${params.get('slug')}`)),
      tap(post => {
        this.body = post.body,
          this.slug = post.slug;
        this.title = post.title;
      })
    ).subscribe();
  }

}
