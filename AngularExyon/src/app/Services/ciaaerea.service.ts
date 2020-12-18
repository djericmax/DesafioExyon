import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ciaaerea } from '../Models/Ciaaerea';

@Injectable({
  providedIn: 'root'
})
export class CiaaereaService {

constructor(private http: HttpClient) { }

  url = `${environment.urlApi}/api/CiaAereas`;

  getAll(): Observable<Ciaaerea[]> {
    return this.http.get<Ciaaerea[]>(`${this.url}`);
  }

  getById(id: number): Observable<Ciaaerea> {
    return this.http.get<Ciaaerea>(`${this.url}/${id}`);
  }

  post(ciaaerea: Ciaaerea) {
    return this.http.post(`${this.url}`, ciaaerea);
  }

  put(id: number, ciaaerea: Ciaaerea) {
    return this.http.put(`${this.url}/${id}`, ciaaerea);
  }

  delete(id: number){
    return this.http.delete(`${this.url}/${id}`);
  }


}
