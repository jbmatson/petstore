import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Pet {
  id: number;
  name: string;
  status: string;
  photoUrls: string[];
}

@Injectable({
  providedIn: 'root'
})
export class PetService {
  private apiUrl = 'https://localhost:7148/api/pet'; 

  constructor(private http: HttpClient) { }

  findByStatus(status: string[]): Observable<Pet[]> {
    const params = { status };
    return this.http.get<Pet[]>(`${this.apiUrl}/findByStatus`, { params });
  }
}
