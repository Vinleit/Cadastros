import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Cadastro } from 'src/app/models/cadastro';
import { Cadastro_pessoa } from 'src/app/models/cadastro-pessoa';
import { CadastroService } from 'src/app/services/cadastro.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-form-cadastro',
  templateUrl: './form-cadastro.component.html',
  styleUrls: ['./form-cadastro.component.css']
})
export class FormCadastroComponent {

    @Input() cadastro? : Cadastro_pessoa;
    @Output() cadastrosUpdated = new EventEmitter<Cadastro[]>();

    constructor(private CadastrosService : CadastroService){}

    ngOnInit() : void{
    }

    EditCadastro(cadastro : Cadastro_pessoa){
      this.CadastrosService.EditCadastro(cadastro).subscribe((cadastro : Cadastro[]) => this.cadastrosUpdated.emit(cadastro))
    }

    DeleteCadastro(cadastro : Cadastro_pessoa){
      this.CadastrosService.DeleteCadastro(cadastro).subscribe((cadastro : Cadastro[]) => this.cadastrosUpdated.emit(cadastro))
    }

    AddCadastro(cadastro : Cadastro_pessoa){
      this.CadastrosService.AddCadastro(cadastro).subscribe((cadastro : Cadastro[]) => this.cadastrosUpdated.emit(cadastro))
    }
}
