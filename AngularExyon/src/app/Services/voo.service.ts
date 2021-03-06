import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Voo } from '../Models/Voo';

@Injectable({
  providedIn: 'root'
})
export class VooService {

constructor(private http: HttpClient) { }

  url = `${environment.urlApi}/api/Voos`;

  getAll(): Observable<Voo[]> {
    return this.http.get<Voo[]>(`${this.url}`);
  }

  getById(id: number): Observable<Voo> {
    return this.http.get<Voo>(`${this.url}/${id}`);
  }

  getByCiaAereaId(id: number): Observable<Voo> {
    return this.http.get<Voo>(`${this.url}/cia/${id}`);
  }

  getByPassageiroId(id: number): Observable<Voo> {
    return this.http.get<Voo>(`${this.url}/pass/${id}`);
  }

  getByNumdoVoo(id: number): Observable<Voo> {
    return this.http.get<Voo>(`${this.url}/voo/${id}`);
  }

  post(voo: Voo) {
    return this.http.post(`${this.url}`, voo);
  }

  put(id: number, voo: Voo) {
    return this.http.put(`${this.url}/${id}`, voo);
  }

  delete(id: number){
    return this.http.delete(`${this.url}/${id}`);
  }
}
