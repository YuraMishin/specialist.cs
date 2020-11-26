import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-a6-app',
  templateUrl: './a6-app.component.html',
  styleUrls: ['./a6-app.component.scss']
})
export class A6AppComponent implements OnInit {
  loadedFeature = 'recipe';

  constructor() { }

  ngOnInit(): void {
  }

  onNavigate(feature: string) {
    this.loadedFeature = feature;
  }

}
