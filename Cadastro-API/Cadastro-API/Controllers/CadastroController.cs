using Azure.Core;
using Cadastro_API.Data;
using Cadastro_API.DTO;
using Cadastro_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Cadastro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly SistemaCadastrosDBContext _context;

        public CadastroController(SistemaCadastrosDBContext context)
        {
            _context = context;
        }




        //Exibindo Todos os cadastros
        [HttpGet]
        public async Task<ActionResult<List<CadastroModel>>> GetCadastros()
        {
            return await _context.Cadastros.Include(x => x.telefones).ToListAsync();
        }




        //Exibindo UM cadastro(EX: "api/cadastros/3")
        [HttpGet("{id}")]
        public async Task<CadastroModel> GetCadastro(int id)
        {
            return await _context.Cadastros.Include(x => x.telefones).SingleOrDefaultAsync(x => x.cadastro_Id == id);
        }




        //Adicionando o usuario
        [HttpPost("new")]
        public async Task<ActionResult<CadastroModel>> AddCadastro(AddCadastroDTO request)
        {
            var newCadastro = new CadastroModel()
            {
                Nome = request.Nome,
                data_nascimento = DateTime.ParseExact(request.data_nascimento, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CPF = request.CPF,
            };

            if(newCadastro.Nome is null || newCadastro.data_nascimento is null || newCadastro.CPF is null)
            {
                throw new Exception("Há campos que não foram preenchidos");
            }
            else
            {
                int sum = await _context.Cadastros.CountAsync(x => x.CPF == newCadastro.CPF);
                if (sum == 0)
                {
                    await _context.Cadastros.AddAsync(newCadastro);
                    await _context.SaveChangesAsync();

                    return newCadastro;
                }
                else
                {
                    throw new Exception($"O CPF: {newCadastro.CPF} já está cadastrado");
                }
            }
        }





        //Exibindo os telefones do usuario(EX: "api/telefone/3")
        [HttpGet("telefone/{id}")]
        public async Task<ActionResult<List<TelefonesModel>>> GetTelefone(int id)
        {
            return await _context.Telefones.Where(x => x.cadastroID == id).ToListAsync();
        }




        //Adicionando o telefone
        [HttpPost("telefone/new")]
        public async Task<ActionResult<TelefonesModel>> AddTelefone(AddTelefonesDTO request)
        {
            var cadastro = await _context.Cadastros.FindAsync(request.cadastroID);
            if (cadastro == null)
            {
                return NotFound();
            }
            else
            {
                if (request.telefone.All(char.IsDigit))
                {
                    var newTelefone = new TelefonesModel
                    {
                        Telefone = request.telefone,
                        cadastroID = request.cadastroID
                    };

                    await _context.Telefones.AddAsync(newTelefone);
                    await _context.SaveChangesAsync();

                    return Ok(cadastro);
                }
                else
                {
                    throw new Exception($"O telefone: {request.telefone} não contém somente números!");
                }
            }
        }




        //Editando o usuário
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<CadastroModel>> EditCadastro([FromBody] AddCadastroDTO newCadastro, int id)
        {
            CadastroModel cadastro = await GetCadastro(id);
            if (cadastro == null)
            {
                throw new Exception($"Usuário com ID:{id} não encontrado!");
            }

            else if (newCadastro.Nome is null || newCadastro.data_nascimento is null || newCadastro.CPF is null)
            {
                throw new Exception("Há campos que não foram preenchidos");
            }
            else
            {
                int sum = await _context.Cadastros.CountAsync(x => x.CPF == newCadastro.CPF);
                if(cadastro.CPF == newCadastro.CPF)
                {
                    if (sum == 1)
                    {
                        cadastro.Nome = newCadastro.Nome;
                        cadastro.data_nascimento = DateTime.Parse(newCadastro.data_nascimento);
                        cadastro.CPF = newCadastro.CPF;

                        _context.Cadastros.Update(cadastro);
                        await _context.SaveChangesAsync();

                        return cadastro;
                    }
                    else
                    {
                        throw new Exception($"O CPF: {newCadastro.CPF} já está cadastrado");
                    }
                } 
                else if (cadastro.CPF != newCadastro.CPF)
                {
                    if(sum == 0)
                    {
                        cadastro.Nome = newCadastro.Nome;
                        cadastro.data_nascimento = DateTime.Parse(newCadastro.data_nascimento);
                        cadastro.CPF = newCadastro.CPF;

                        _context.Cadastros.Update(cadastro);
                        await _context.SaveChangesAsync();

                        return cadastro;
                    }
                    else
                    {
                        throw new Exception($"O CPF: {newCadastro.CPF} já está cadastrado");
                    }
                }
                else
                {
                    throw new Exception("Erro ao atualizar o cadastro! Por favor contate a equipe de suporte");
                }
            }
        }




        //Removendo o usuario
        [HttpDelete("delete/{id}")]
        public async Task<bool> DeleteCadastro(int id)
        {
            var cadastro = await GetCadastro(id);
            if (cadastro == null)
            {
                throw new Exception($"Usuário com ID:{id} não encontrado!");
            }
            else
            {
                _context.Cadastros.Remove(cadastro);
                await _context.SaveChangesAsync();
                return true;
            }
        }





        //Removendo o telefone
        [HttpDelete("/telefone/delete/{id}")]
        public async Task<bool> DeleteTelefone(int id)
        {
            var telefone = await _context.Telefones.SingleOrDefaultAsync(x => x.telefone_Id == id);

            if (telefone == null)
            {
                throw new Exception($"Usuário com ID:{id} não encontrado!");
            }

                _context.Telefones.Remove(telefone);
                await _context.SaveChangesAsync();
                return true;
        }
    }
}
