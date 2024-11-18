import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TerritoryService {
  private apiUrl = 'https://localhost:7079/api/territories';  // Az API URL-je

  constructor(private http: HttpClient) { }

  // Az összes territory lekérése
  getTerritories(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Territory frissítése
  updateTerritory(territory: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${territory.territoryid}`, territory);
  }


  createTerritory(territory: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, territory);
  }

}
