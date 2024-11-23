using EnergyX.DTOs;
using EnergyX.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OdontoFast.Exceptions;
using System.Threading.Tasks;

namespace EnergyX.Controllers
{
  public class RelatoriosController : Controller
  {
    private readonly IRelatoriosTurnoService _relatoriosTurnoService;

    public RelatoriosController(IRelatoriosTurnoService relatoriosTurnoService)
    {
      _relatoriosTurnoService = relatoriosTurnoService;
    }

    // Método para criar um novo relatório de turno
    [HttpPost("create-or-update-relatorios")]
    public async Task<IActionResult> Create(CreateRelatoriosTurnoDto dto, UpdateRelatoriosTurnoDto updateDto)
    {
      try
      {
        if (updateDto.RelatorioTurnoId == 0)
        {
          // Chama o serviço para criar um relatório com os dados do DTO
          await _relatoriosTurnoService.CreateRelatorioTurnoAsync(dto);
          TempData["msgSucesso"] = "Relatório cadastrado com sucesso!";
        }
        else
        {
          // Chama o serviço para atualizar um relatório com os dados do DTO
          await _relatoriosTurnoService.UpdateRelatorioTurnoAsync(updateDto.RelatorioTurnoId, updateDto);
          TempData["msgSucesso"] = "Relatório atualizado com sucesso!";
        }
        return RedirectToAction("RelatoriosTurno", "Home"); // Redireciona para a lista de relatórios
      }
      catch (BusinessException ex)
      {
        // Define a mensagem de erro
        TempData["ErrorMessage"] = ex.Message;
        return RedirectToAction("RelatoriosTurno", "Home"); // Retorna para a página de listagem em caso de erro
      }
    }


    // Método para excluir um relatório
    [HttpPost("delete-relatorio")]
    public async Task<IActionResult> Delete(long relatorioTurnoId)
    {
      try
      {
        await _relatoriosTurnoService.DeleteRelatorioTurnoAsync(relatorioTurnoId);
        TempData["msgSucesso"] = "O relatório " + relatorioTurnoId + " foi excluído.";
        return RedirectToAction("RelatoriosTurno", "Home");
      }
      catch (NotFoundException ex)
      {
        ModelState.AddModelError(string.Empty, ex.Message);
        return RedirectToAction("RelatoriosTurno", "Home");
      }
    }

  }
}
