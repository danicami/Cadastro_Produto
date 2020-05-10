using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovimentosDominio.Interfaces;
using MovimentosManuais.Models;
using MovimentosServicos.Validadores;

namespace MovimentosManuais.Controllers
{
    public class MovimentoManualController : Controller
    {
        private IServico<Produto> servicoProduto;
        private IServico<ProdutoCosif> servicoProdutoCosif;
        private IServico<MovimentoManual> servicoMovimentoManual;
        private IServico<MovimentoManualProduto> servicoMovimentoManualProd;

        public MovimentoManualController(IServico<Produto> _servicoProduto,
                                         IServico<ProdutoCosif> _servicoProdutoCosif,
                                         IServico<MovimentoManual> _servicoMovimentoManual,
                                         IServico<MovimentoManualProduto> _servicoMovimentoManualProd)

        {
            servicoProduto = _servicoProduto;
            servicoProdutoCosif = _servicoProdutoCosif;
            servicoMovimentoManual = _servicoMovimentoManual;
            servicoMovimentoManualProd = _servicoMovimentoManualProd;
        }

        public IActionResult Incluir()
        {
            ViewBag.Produtos = ObterProduto(null);

            return View();
        }

        [HttpPost]
        public IActionResult Incluir(MovimentoManual movimentoManual)
        {
            ViewBag.Produtos = ObterProduto(movimentoManual.CodigoProduto);

            ViewBag.Cosif = ObterCosif(movimentoManual.CodigoProduto);

            if (movimentoManual.Acao == "Incluir")
            {
                Inclusao(movimentoManual);
                movimentoManual = LimparCampos(movimentoManual);
            }
            else if (movimentoManual.Acao == "Limpar")
            {
                movimentoManual = LimparCampos(movimentoManual);
            }
            return View(movimentoManual);
        }

        public MovimentoManual LimparCampos(MovimentoManual movimentoManual)
        {
            ViewBag.Produtos = ObterProduto(null);
            ViewBag.Cosif = null;
            movimentoManual = null;
            ModelState.Clear();

            return movimentoManual;
        }


        public SelectList ObterProduto(string codProduto)
        {
            var produtos = new List<Produto>();
            produtos.Add(new Produto());
            produtos.AddRange (servicoProduto.SelecionaTodos());
            return new SelectList(produtos, "CodigoProduto", "DescricaoProduto", produtos.Select(x => codProduto).FirstOrDefault());
        }

        public SelectList ObterCosif(string codProduto)
        {
            var cosif = servicoProdutoCosif.SelecionaTodos().Where(c => c.CodigoProduto == codProduto);
            return new SelectList(cosif, "CodigoCosif", "CodigoClassificacao");
        }

        public MovimentoManual Inclusao(MovimentoManual movimentoManual)
        {
            if (movimentoManual.CodigoProduto != null && movimentoManual.CodigoCosif != null)
            {
                var list = servicoMovimentoManualProd.SelecionaTodos()
                    .Where(m => m.DataMes == movimentoManual.DataMes && m.DataAno == movimentoManual.DataAno);
                if (list.Count() > 0)
                    movimentoManual.NumeroLancamento = list.Max(x => x.NumeroLancamento) + 1;
                else
                    movimentoManual.NumeroLancamento = 1;

                servicoMovimentoManual.Inserir<MovimentoManualValidador>(movimentoManual);
                movimentoManual = null;
            }

            return movimentoManual;
        }


        public IActionResult Listar()
        {
            var movimentoManualList = servicoMovimentoManualProd.SelecionaTodos();
            ViewBag.MovimentoManual = movimentoManualList.ToAsyncEnumerable();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
