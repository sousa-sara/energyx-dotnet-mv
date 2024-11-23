using EnergyX.DTOs;
using EnergyX.Services;
using Microsoft.AspNetCore.Mvc;
using OdontoFast.Exceptions;
using System.Threading.Tasks;

namespace EnergyX.Controllers
{
  public class OperadoresController : Controller
  {
    private readonly IOperadoresService _operadoresService;

    public OperadoresController(IOperadoresService operadoresService)
    {
      _operadoresService = operadoresService;
    }

    // Ação para realizar o login do operador
    [HttpPost]
    public async Task<IActionResult> Login(OperadorLoginDto loginDto)
    {
      try
      {
        var operador = await _operadoresService.LoginAsync(loginDto);
        HttpContext.Session.SetInt32("OperadorId", (int)operador.OperadorId); // Armazena o ID do dentista na sessão

        return RedirectToAction("Index", "Home"); // Redireciona para a página principal ou outra ação
      }
      catch (BusinessException ex)
      {
        // Define a mensagem de erro
        TempData["ErrorMessage"] = ex.Message;
        return RedirectToAction("Index", "Login"); // Retorna para a página de login em caso de erro
      }
    }

    // Método para criar um novo dentista
    [HttpPost("create-operadores")]
    public async Task<IActionResult> Create(CreateOperadoresDto dto)
    {
      try
      {
        // Chama o serviço para criar um dentista com os dados do DTO
        var createdDentista = await _operadoresService.CreateOperadoresAsync(dto);

        TempData["msgRegistro"] = "Cadastro Realizado! Agora você já pode acessar a EnergyX utilizando sua LOR e Senha";
        return RedirectToAction("Index", "Login");
      }
      catch (BusinessException ex)
      {
        // Define a mensagem de erro
        TempData["ErrorMessage"] = ex.Message;
        return RedirectToAction("Index", "Login"); // Retorna para a página de login em caso de erro
      }
    }

    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return Redirect("/Login");
    }

    // Método para atualizar as informações do dentista
    // [HttpPost]
    // public async Task<IActionResult> Update(UpdateDentistaDto dto)
    // {
    //     int dentistaId = (int)HttpContext.Session.GetInt32("DentistaId");
    //     try
    //     {
    //         TempData["okMsg"] = "Seus dados foram atualizados!";
    //         var updatedDentista = await _operadoresService.UpdateDentistaAsync(dentistaId, dto);
    //         return RedirectToAction("Perfil"); // Redireciona para o perfil atualizado
    //     }
    //     catch (BusinessException ex)
    //     {
    //         ModelState.AddModelError(string.Empty, ex.Message);
    //         return View("DentistaPerfil", dto); // Retorna à View com a mensagem de erro
    //     }
    // }
  }
}
