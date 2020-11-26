import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-a8-app',
  templateUrl: './a8-app.component.html',
  styleUrls: ['./a8-app.component.scss']
})
export class A8AppComponent implements OnInit {
  oddNumbers: number[] = [];
  evenNumbers: number[] = [];

  constructor() {
  }

  ngOnInit(): void {
  }

  onIntervalFiredHandler(firedNumber: number) {
    if (firedNumber % 2 === 0) {
      this.evenNumbers.push(firedNumber);
    } else {
      this.oddNumbers.push(firedNumber);
    }
  }

}
