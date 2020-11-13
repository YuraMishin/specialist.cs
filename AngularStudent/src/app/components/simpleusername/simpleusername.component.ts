import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-simpleusername',
  templateUrl: './simpleusername.component.html',
  styleUrls: ['./simpleusername.component.scss']
})
export class SimpleusernameComponent implements OnInit {
  username: string = '';

  constructor() {
  }

  ngOnInit(): void {
  }

  onReset(): void {
    this.username = '';
  }
}
