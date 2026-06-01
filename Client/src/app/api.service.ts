import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { GetDataInterface } from './interfaces/get-data.interface';
import { FormSubmitInterface } from './interfaces/form-submit.interface';
import { KsiazkaClass } from './classes/ksiazka.class';

interface KsiazkaDTO {
  id: number;
  tytul: string;
  cena: number;
  dataWydania: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService implements GetDataInterface, FormSubmitInterface {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5112/api/GetData';

  Get(): Observable<KsiazkaClass[]> {
    return this.http.get<KsiazkaDTO[]>(this.apiUrl).pipe(
      map(dtos => dtos.map(dto => this.toKsiazkaClass(dto)))
    );
  }

  GetByID(id: number): Observable<KsiazkaClass> {
    return this.http.get<KsiazkaDTO>(`${this.apiUrl}/${id}`).pipe(
      map(dto => this.toKsiazkaClass(dto))
    );
  }

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      tytul: nazwa,
      cena: cena,
      dataWydania: this.formatDate(data)
    };
    return this.http.post<boolean>(this.apiUrl, body);
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      id: id,
      tytul: nazwa,
      cena: cena,
      dataWydania: this.formatDate(data)
    };
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, body);
  }

  private toKsiazkaClass(dto: KsiazkaDTO): KsiazkaClass {
    const [year, month, day] = dto.dataWydania.split('-').map(Number);
    const date = new Date(year, month - 1, day);
    return new KsiazkaClass(dto.id, dto.tytul, dto.cena, date);
  }

  private formatDate(date: Date): string {
    return date.toISOString().split('T')[0];
  }
}