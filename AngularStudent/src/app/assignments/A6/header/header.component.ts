import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
 @Output() featureSelected = new EventEmitter<string>()

  constructor() {
  }

  ngOnInit(): void {
  }

  onSelectHandler(feature: string) {
    this.featureSelected.emit(feature);
  }

}
