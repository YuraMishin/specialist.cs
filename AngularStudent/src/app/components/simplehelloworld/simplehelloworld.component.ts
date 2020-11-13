import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-simplehelloworld',
  templateUrl: './simplehelloworld.component.html',
  styleUrls: ['./simplehelloworld.component.scss']
})
export class SimplehelloworldComponent implements OnInit {
  currentDate: string;

  constructor() {
    this.currentDate = new Date().toString();
  }

  ngOnInit(): void {
  }

}
