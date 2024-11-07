import { AccountService } from './account.service';
import { environment } from './../../environments/environment.prod';
import { Injectable } from '@angular/core';
import { Connection, hubConnection } from 'signalr-no-jquery';
import { Observable, Subject, Subscription } from 'rxjs';

const RECONNECT_TIME = 5000;

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubNotiConnection: Connection;
  private hubProxy: any;
  private messageNoti$: Subject<any> = new Subject<any>();

  constructor(private accountService: AccountService) {}

  private connectNotifyHub() {
    const user = this.accountService.userValue;
    const isLoggedIn = user && user.Token;
    const idonesignal = user.Id;

    //console.log(user.token);

    this.hubProxy = this.hubNotiConnection.createHubProxy('SNetHub');

    //console.log('[SNETNOTI][INFO] Connecting!');

    if (isLoggedIn) {
      this.hubNotiConnection
        .start({
          jsonp: true,
          transport: ['webSockets', 'longPolling'],
          xdomain: true,
        })
        .done(() => {
          //console.log('[SNETNOTI][INFO] Connect successfully!');
          this.hubProxy
            .invoke('ConnectAdvice', user.Token)
            .done(() => {
              //console.log('[SNETNOTI] Auth successfully');
              this.hubProxy.invoke(
                'ConnectAdviceOneSignal',
                user.Token,
                idonesignal
              );
            })
            .fail((err: any) => {
              //console.log('[SNETNOTI][ERROR] Auth rejected. MESSAGE: ', err);
            });
        })
        .fail((err) => {
          //console.log('[SNETNOTI][ERROR] Connect failed!, MESSAGE: ', err);
        });
    } else {
      //console.log('[SNETNOTI][ERROR] Unauthentication!');
    }
  }

  public startNotifyConnection = () => {
    //this.hubNotiConnection = hubConnection(url);

    this.connectNotifyHub();

    // this.hubNotiConnection.disconnected(() => {
    //   setInterval(() => {
    //     console.log('[SNETNOTI][INFO] Reconnecting!');
    //     this.connectNotifyHub();
    //   }, RECONNECT_TIME);
    // });
  };

  public addHelloListener() {
    this.hubProxy.on('hello', (message) => {
      this.messageNoti$.next({ subscriptionType: 'HELLO', data: message });
    });
  }

  public addTalkingListener() {
    this.hubProxy.on('talking', (message) => {
      this.messageNoti$.next({ subscriptionType: 'TALKING', data: message });
    });
  }

  public getMessage(): Observable<any> {
    return this.messageNoti$.asObservable();
  }

  public disconnectNotify() {
    this.hubNotiConnection.stop();
    //console.log('[SNETNOTI][INFO] Disconnecting successfully');
  }
}
