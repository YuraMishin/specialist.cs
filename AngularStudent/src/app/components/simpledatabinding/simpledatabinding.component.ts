import {Component, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-simpledatabinding',
  templateUrl: './simpledatabinding.component.html',
  styleUrls: ['./simpledatabinding.component.scss'],
  encapsulation: ViewEncapsulation.Emulated
})
export class SimpledatabindingComponent {
  serverElements: { type: string, name: string, content: string }[] = [];

  constructor() {
    this.serverElements.push(
      {
        type: 'server',
        name: 'Testserver',
        content: 'Just a test'
      }
    );
  }

  onServerAdded(serverData: { serverName: string, serverContent: string }) {
    this.serverElements.push({
      type: 'server',
      name: serverData.serverName,
      content: serverData.serverContent
    });
  }

  onBlueprintAdded(serverData: { serverName: string, serverContent: string }) {
    this.serverElements.push({
      type: 'blueprint',
      name: serverData.serverName,
      content: serverData.serverContent
    });
  }
}
