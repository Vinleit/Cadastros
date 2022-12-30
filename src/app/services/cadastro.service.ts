import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cadastro } from '../models/cadastro';
import { Info } from 'src/main';
import { Cadastro_pessoa } from '../models/cadastro-pessoa';
import { Cadastro_telefone } from '../models/cadastro-telefone';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {
  private url = "Cadastro" //nome do controlador
  
  constructor(private http : HttpClient) { }

  public get_cadastros() : Observable<Cadastro[]>{
    return this.http.get<Cadastro[]>(`${Info.apiUrl}/${this.url}`);
  }

  public EditCadastro(cadastro : Cadastro_pessoa) : Observable<Cadastro[]>{
    return this.http.put<Cadastro[]>
    (`${Info.apiUrl}/${this.url}/edit/${cadastro.cadastro_Id}`, cadastro);
  }

  public AddCadastro(cadastro : Cadastro_pessoa) : Observable<Cadastro[]>{
    cadastro.data_nascimento.replace("-","/");
    return this.http.post<Cadastro[]>
    (`${Info.apiUrl}/${this.url}/new`, cadastro);
  }

  public DeleteCadastro(cadastro : Cadastro_pessoa) : Observable<Cadastro[]>{
    return this.http.delete<Cadastro[]>
    (`${Info.apiUrl}/${this.url}/delete/${cadastro.cadastro_Id}`);
  }

  public AddTelefone(telefone : Cadastro_telefone) : Observable<Cadastro[]>{
    return this.http.post<Cadastro[]>
    (`${Info.apiUrl}/${this.url}/telefone/new`, telefone);
  }
}
