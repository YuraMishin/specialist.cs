import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-button-disabled',
  templateUrl: './button-disabled.component.html',
  styleUrls: ['./button-disabled.component.scss']
})
export class ButtonDisabledComponent implements OnInit {
  allowNewServer: boolean = false;
  serverCreationStatus: string = 'No server was created!';
  serverName: string = 'Server1';

  constructor() {
    setTimeout(() => {
      this.allowNewServer = true;
    }, 2000);
  }

  ngOnInit(): void {
  }

  onClickCreateServer() {
    this.serverCreationStatus = `Server was created! Name is ${this.serverName}`;
  }

  onUpdateServerName(event: Event) {
    this.serverName = (<HTMLInputElement>event.target).value;
  }

}
