export class Cadastro{
    cadastro_Id? : number;
    nome = "";
    data_nascimento = "";
    cpf = "";
    telefones? = [
        {
            telefone_Id: 0,
            telefone: "",
            cadastroID: 0
        }
    ];
}