import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Cadastro } from 'src/app/models/cadastro';
import { Cadastro_pessoa } from 'src/app/models/cadastro-pessoa';
import { CadastroService } from 'src/app/services/cadastro.service';
import { DatePipe } from '@angular/common';
import { Cadastro_telefone } from 'src/app/models/cadastro-telefone';

@Component({
  selector: 'app-form-telefone',
  templateUrl: './form-telefone.component.html',
  styleUrls: ['./form-telefone.component.css']
})
export class FormTelefoneComponent {

    @Input() telefone? : Cadastro_telefone;
    @Output() telefonesUpdated = new EventEmitter<Cadastro[]>();

    constructor(private CadastrosService : CadastroService){}

    ngOnInit() : void{
    }

   /* EditCadastro(cadastro : Cadastro_pessoa){
      this.CadastrosService.EditCadastro(cadastro).subscribe((cadastro : Cadastro[]) => this.cadastrosUpdated.emit(cadastro))
    }

    DeleteCadastro(cadastro : Cadastro_pessoa){
      this.CadastrosService.DeleteCadastro(cadastro).subscribe((cadastro : Cadastro[]) => this.cadastrosUpdated.emit(cadastro))
    } */

    AddCadastro(telefone : Cadastro_telefone){
      var tel = new Cadastro_telefone(); //transformando em string para jogar para API
      tel.cadastroID = telefone.cadastroID;
      tel.telefone = telefone.telefone.toString();

      this.CadastrosService.AddTelefone(tel).subscribe((tel : Cadastro[]) => this.telefonesUpdated.emit(tel))
    }
}
