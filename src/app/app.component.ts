import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Cadastro } from './models/cadastro';
import { Cadastro_pessoa } from './models/cadastro-pessoa';
import { Cadastro_telefone } from './models/cadastro-telefone';
import { CadastroService } from './services/cadastro.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'cadastros.UI';

  PESSOAS: Cadastro[] = [];
  CadastroEdit? : Cadastro_pessoa
  TelefoneAdd? : Cadastro_telefone

  constructor(private cadastro_pessoas_SERVICE: CadastroService) {}

  ngOnInit() : void{
    this.cadastro_pessoas_SERVICE.get_cadastros().subscribe((result : Cadastro[]) => (this.PESSOAS = result))
  }


  UpdateCadastroList(){
    this.cadastro_pessoas_SERVICE.get_cadastros().subscribe((result : Cadastro[]) => (this.PESSOAS = result))
  }

  InitNewCadastro(){
    this.CadastroEdit = new Cadastro_pessoa();
  }

  Edit(cadastro : Cadastro_pessoa){
    cadastro.data_nascimento = cadastro.data_nascimento.replace("T00:00:00","");
    this.CadastroEdit = cadastro;
  }

  excluir(cadastro : Cadastro_pessoa){
    cadastro.data_nascimento = cadastro.data_nascimento.replace("T00:00:00","");
    this.CadastroEdit = cadastro;
  }

  AddTelefone(cadastro : Cadastro){
    var tel = new Cadastro_telefone();

    tel.cadastroID = cadastro.cadastro_Id;
    tel.telefone = ""

    this.TelefoneAdd = tel;
  }
}
