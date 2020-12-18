import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Passageiro } from '../Models/Passageiro';

@Injectable({
  providedIn: 'root'
})
export class PassageiroService {

constructor(private http: HttpClient) { }

  url = `${environment.urlApi}/api/Passageiros`;

  getAll(): Observable<Passageiro[]> {
    return this.http.get<Passageiro[]>(`${this.url}`);
  }

  getById(id: number): Observable<Passageiro> {
    return this.http.get<Passageiro>(`${this.url}/${id}`);
  }

  post(passageiro: Passageiro) {
    return this.http.post(`${this.url}`, passageiro);
  }

  put(passageiro: Passageiro) {
    return this.http.put(`${this.url}/${passageiro.id}`, passageiro);
  }

  delete(id: number){
    return this.http.delete(`${this.url}/${id}`);
  }
}
