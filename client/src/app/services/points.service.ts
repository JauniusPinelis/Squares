import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Point from 'src/models/point.model';

@Injectable({
  providedIn: 'root'
})
export class PointsService {

  constructor(private httpClient: HttpClient) { }

  public getAll() : Observable<Point[]> {
    return this.httpClient.get<Point[]>('https://localhost:44338/point');
  }
}
