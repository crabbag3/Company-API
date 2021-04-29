import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { CompanyModel } from '../../shared/models/company.model';
import { CompanyUpdateModel } from '../../shared/models/company-update.model';
 

@Injectable()
export class CompanyDataService {
  private headers: HttpHeaders;
  private apiUrl: string

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.apiUrl = `${environment.apiBaseUrl}Company`;
  }

 
  public getAll() { 
    return this.http.get(this.apiUrl, { headers: this.headers });
  }

  public getById(id: string) {
    return this.http.get(`${this.apiUrl}${id}`, { headers: this.headers });
  }

  public getByIsin(isin: string) {
    return this.http.get(`${this.apiUrl}ISIN/${isin}`, { headers: this.headers });
  }

  public add(newCompany: CompanyModel) {
    return this.http.post(this.apiUrl, newCompany, { headers: this.headers });
  }

   // Not implemented
  public remove(payload) {
    return this.http.delete(this.apiUrl + '/' + payload.id, { headers: this.headers });
  }

  public update(updateCompany: CompanyUpdateModel) {
    return this.http.put(`${this.apiUrl}`, updateCompany, { headers: this.headers });
  }
}
