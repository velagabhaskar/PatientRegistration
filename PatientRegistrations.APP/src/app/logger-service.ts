import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {

  constructor() { }
  logError(message: string, error: any): void {
    console.error(message, error);
    // You can extend this service to log errors to a server or a third-party service.
  }
}
