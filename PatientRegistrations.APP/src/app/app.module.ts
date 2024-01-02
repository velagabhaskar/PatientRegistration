import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PatientsModule } from './patients/patients.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { AgeCalculatorDirective } from './age-calculator.directive';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ConfirmationpopupComponent } from './confirmationpopup/confirmationpopup.component';
import { ErrorInterceptorService } from './error-interceptor.service';
import { LoggerService } from './logger-service';


@NgModule({
  declarations: [
    AppComponent,
    
    NavbarComponent,
       
    
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    PatientsModule,
    HttpClientModule,

  ],
  providers: [
    provideClientHydration(),
    LoggerService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
