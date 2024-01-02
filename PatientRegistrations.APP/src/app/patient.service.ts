import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Patient } from './models/patient';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  apiUrl=environment.config.apiUrl;

  constructor(private _httpClient:HttpClient) { 


  }
  getallpatients():Observable<Patient[]>
  {
    console.log("1");
  return this._httpClient.get<Patient[]>(this.apiUrl)
}
addPatient( patient: Patient ):Observable<Patient>
{
  const headers = { 'content-type': 'application/json'}  
  const body=JSON.stringify(patient);
  console.log(body)
 return this._httpClient.post<Patient>(this.apiUrl+"/AddPatient",patient,{'headers':headers})
}
updatePatient( patient: Patient ):Observable<Patient>
{
  const headers = { 'content-type': 'application/json'}  
  const body=JSON.stringify(patient);
  console.log(body)
 return this._httpClient.put<Patient>(this.apiUrl+"/UpdatePatient",patient,{'headers':headers})
}
DelePatient( patientId: string ):Observable<boolean>
{
  const headers = { 'content-type': 'application/json'}  
  const body=JSON.stringify(patientId);
  console.log(body)
 return this._httpClient.delete<boolean>(this.apiUrl+"/DeletePatient/"+patientId);
}

getPatientbyId(patientId:string)
{

  return this._httpClient.get<boolean>(this.apiUrl+"/"+patientId);
}
}
