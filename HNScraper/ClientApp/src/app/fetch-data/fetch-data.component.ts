import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public stories: StoryModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<StoryModel[]>(baseUrl + 'Story').subscribe(result => {
      this.stories = result;
    }, error => console.error(error));
  }
}

interface StoryModel {
  By: string;
  Title: string;
  Url: string;
}
