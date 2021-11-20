import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Conta } from 'src/app/models/Conta';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContaReceberService {

  constructor(private http: HttpClient) { }

  baseUrl = `${environment.Url}api/conta`;
  
  BuscarTodasContas(tipoConta: number): Observable<Conta[]>{
    return this.http.get<Conta[]>(`${this.baseUrl}/TipoConta/${tipoConta}`);
  }

  BuscarContaReceberId(id: number): Observable<Conta> {
    return this.http.get<Conta>(`${this.baseUrl}/${id}`);
  }

  Adicionar(conta: Conta) {
    return this.http.post<Conta[]>(`${this.baseUrl}`, conta);
  }

  Atualizar(conta: Conta) {
    return this.http.put<Conta[]>(`${this.baseUrl}/${conta.id}`, conta);
  }
}
