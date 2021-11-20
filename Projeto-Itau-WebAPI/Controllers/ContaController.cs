using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Itau_WebAPI.Data;
using Projeto_Itau_WebAPI.Model;

namespace Projeto_Itau_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IRepository _repo;

        public ContaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("TipoConta/{tipo}")]
        public async Task<IActionResult> BuscarTodos(int tipo)
        {
            try
            {
                var resultado = await _repo.BuscarTodasContasAsync(tipo);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{contaId}")]
        public async Task<IActionResult> BuscarContaId(int contaId)
        {
            try
            {
                var resultado = await _repo.BuscarContasAsyncById(contaId);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("TotalContasPagar/{contaPagar}")]
        public async Task<IActionResult> TotalContasPagarAsync(int contaPagar)
        {
            try
            {
                var resultado = await _repo.TotalContasPagarAsync(contaPagar);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("TotalContasReceber/{contaReceber}")]
        public async Task<IActionResult> TotalContasReceberAsync(int contaReceber)
        {
            try
            {
                var resultado = await _repo.TotalContasReceberAsync(contaReceber);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Conta conta)
        {
            try
            {
                _repo.Adicionar(conta);

                if (await _repo.SaveChangesAsync())
                    return Ok(conta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{contaId}")]
        public async Task<IActionResult> Atualizar(int contaId, Conta model)
        {
            try
            {
                var conta = await _repo.BuscarContasAsyncById(contaId);
                if (conta == null)
                    return NotFound();

                _repo.Atualizar(model);

                if (await _repo.SaveChangesAsync())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}
