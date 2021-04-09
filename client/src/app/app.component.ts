import { Component } from '@angular/core';


export interface Post {
  id: number;
  title: string;
  body: string;
  slug: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';
}
