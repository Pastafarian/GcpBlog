import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../app.component';
import { environment } from '../../environments/environment';
import { switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['title', 'actions'];
  dataSource: Post[] = [];

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.httpClient.get<Post[]>(environment.baseUrl + 'post').pipe(
      tap(posts => {
        this.dataSource = posts;
      })
    ).subscribe();
  }

  delete(slug: string): void {

    this.httpClient.delete(`${environment.baseUrl}post/${slug}`).pipe(
      switchMap(_ => this.httpClient.get<Post[]>(environment.baseUrl + 'posts')),
      tap(posts => {
        this.dataSource = posts;
      })
    ).subscribe();
  }
}
