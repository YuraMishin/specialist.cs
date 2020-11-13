import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-simplefor',
  templateUrl: './simplefor.component.html',
  styleUrls: ['./simplefor.component.scss']
})
export class SimpleforComponent implements OnInit {
  showSecret: boolean = false;
  numbers: Date[] = [];

  constructor() {
  }

  ngOnInit(): void {
  }

  onToggleAddNumber() {
    this.numbers.push(new Date());
  }
}
