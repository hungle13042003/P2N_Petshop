import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { SignalRService } from './services/signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'P2NPet';
  private signalRSubscription: Subscription;

  constructor(private signalRService: SignalRService) {}

  ngOnInit(): void {
    this.signalRService.startNotifyConnection();
    this.signalRService.addHelloListener();
    this.signalRService.addTalkingListener();

    this.signalRSubscription = this.signalRService
      .getMessage()
      .subscribe((message) => {
        // console.log(
        //   `[SNETNOTI][LISTENER][${message.subscriptionType}]1`,
        //   message.data
        // );
      });
  }

  ngOnDestroy(): void {
    this.signalRService.disconnectNotify();
    this.signalRSubscription.unsubscribe();
  }
}
