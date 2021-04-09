import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router) { }

  formGroup!: FormGroup;

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      title: ['', [Validators.required, Validators.maxLength(50)]],
      body: ['', [Validators.required]],
    });
  }

  save(form: FormGroup) {
    if (form.valid) {

      const post = form.value;
      form.reset(post);

      this.httpClient.post(`${environment.baseUrl}post`, post).pipe(
        tap(_ => {
          this.router.navigate(['/']);
        })
      ).subscribe();
    }
  }
}
