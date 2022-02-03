using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TesteSenior.Application;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Structure;
using TesteSenior.ViewModels;

namespace TesteSenior.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Instancia objetos da camada de aplicação
            ProdutoAppService produtoService = new ProdutoAppService();
            MovimentoManualAppService movService = new MovimentoManualAppService();

            //Carrega a lista de produtos para preencher dropdownlist do formulário
            ViewBag.ListaProdutos = new SelectList(produtoService.Listar(), "CodProduto", "Descricao");

            //Carrega os movimentos cadastrados
            FormMovimentoViewModel movVM = new FormMovimentoViewModel();
            movVM.Movimentos = Mapper.Map<List<MovimentoManual>, List<MovimentoManualViewModel>>(movService.Listar());
            return View(movVM);
        }

        [HttpPost]
        public ActionResult Index(FormMovimentoViewModel movVM)
        {
            try
            {
                ProdutoAppService produtoService = new ProdutoAppService();
                ViewBag.ListaProdutos = new SelectList(produtoService.Listar(), "CodProduto", "Descricao");
                if (ModelState.IsValid)
                {
                    //Insere o movimento e retorna mensagem ao usuário
                    MovimentoManualAppService movService = new MovimentoManualAppService();
                    MovimentoManual mov = Mapper.Map<FormMovimentoViewModel, MovimentoManual>(movVM);
                    var result = movService.GravarMovimento(mov);
                    TempData["Msg"] = result.Msg;
                    TempData["TipoMsg"] = result.TipoMsg;

                    //Carrega os movimentos cadastrados
                    movVM = new FormMovimentoViewModel();
                    movVM.Movimentos = Mapper.Map<List<MovimentoManual>, List<MovimentoManualViewModel>>(movService.Listar());
                    return View(movVM);
                }
                else
                {
                    TempData["Msg"] = "Não foi possível incluir o registro. Verifique se os campos foram preenchidos corretamente.";
                    TempData["TipoMsg"] = TipoMensagem.Erro;
                }
            }
            catch(Exception)
            {
                TempData["Msg"] = "Ocorreu um erro ao gravar o movimento";
                TempData["TipoMsg"] = TipoMensagem.Erro;
            }
            
            return View(movVM);
        }

        /// <summary>
        /// Método para carregar a lista de produtos cosif a partir do código de produto
        /// É executado via AJAX pela View
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ListarProdutoCosif(string codProduto)
        {
            ProdutoCosifAppService prConsifService = new ProdutoCosifAppService();
            List<ProdutoCosifViewModel> lstConsif = Mapper.Map<List<ProdutoCosif>, List<ProdutoCosifViewModel>>(prConsifService.ListarPorProduto(codProduto));
            return Json(lstConsif, JsonRequestBehavior.AllowGet);
        }
    }
}