using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Selia.Integrador.Utils;

using Selia.Integrador.BS;
using System.Threading.Tasks;
using System.Threading;

namespace BS
{
    public class Interface
    {
        public class ArquivoText
        {
            public void Executar(Model.Integracao ent)
            {
                Selia.Integrador.Adapter.ArquivoTexto.Config objConfig = new Selia.Integrador.Adapter.ArquivoTexto.Config();
                var item = ((Model.Interface.ArquivoTexto)ent.Interface.Item);
                objConfig.FTP = item.FTP;
                objConfig.Login = item.Login;
                objConfig.Senha = item.Senha;
                objConfig.Url = item.Url;
                objConfig.Delimitador = item.Delimitador;
                objConfig.Diretorio = item.Diretorio;
                objConfig.Encoding = item.Encoding;
                objConfig.ElementoSeparador = ent.ElementoRegistro;
                objConfig.AcaoInicial = ent.AcaoInicial;
                objConfig.AcaoFinal = ent.AcaoFinal;
                objConfig.AcaoEnfileiramento = ent.AcaoEnfileiramento;
                objConfig.Mapeamentos = MapearParaAdapter(ent.Mapeamento);
                objConfig.ConnectionString = ent.ConnectionString;

                if (ent.Consumidor)
                {
                    foreach (Model.Fila fila in ent.Fila)
                    {
                        try
                        {
                            Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.ArquivoTexto().Executar(objConfig, fila.Conteudo, ent.ID);

                            Model.LogFila entLogFila = new Model.LogFila();
                            entLogFila.ConteudoFila = fila.Conteudo;
                            entLogFila.ChavePrimaria = fila.ChavePrimaria;
                            entLogFila.ChaveSecundaria = fila.ChaveSecundaria;
                            entLogFila.LogIntegracao.ID = fila.LogIntegracaoID;
                            entLogFila.IntegracaoID = ent.ID;
                            entLogFila.FilaID = fila.ID;

                            if (!string.IsNullOrEmpty(objResult.Mensagem))
                                entLogFila.ConteudoRetorno = objResult.Mensagem;

                            new BS.LogFila().Inserir(entLogFila);

                            if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                            {
                                new BS.Fila().Excluir(fila.ID);

                                if (ent.Destino != null)
                                {
                                    ent.AcaoInicial = ent.Destino.AcaoInicial;
                                    ent.AcaoFinal = ent.Destino.AcaoFinal;
                                    ent.AcaoEnfileiramento = ent.Destino.AcaoEnfileiramento;
                                    ent.ElementoRegistro = ent.Destino.ElementoRegistro;
                                    ent.PKPrimaria = ent.Destino.PKPrimaria;
                                    objResult.ElementoSeparador = ent.Destino.ElementoRegistro;
                                    objConfig.Mapeamentos = MapearParaAdapter(ent.Mapeamento);

                                    new BS.Fila().ProcessarFila(objResult, ent, null);
                                }
                            }
                            else
                            {
                                new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);
                            }
                        }
                        catch (Exception ex)
                        {
                            Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                            entLogIntegracao.Conteudo = ex.Message;
                            entLogIntegracao.Integracao = ent;
                            entLogIntegracao.Status = 1;
                            new BS.LogIntegracao().Inserir(entLogIntegracao);
                            //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    try
                    {
                        Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.ArquivoTexto().Executar(objConfig);
                        if (!string.IsNullOrEmpty(objResult.Mensagem))
                        {
                            if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                            {

                                if (ent.Destino != null)
                                {
                                    ent.AcaoInicial = ent.Destino.AcaoInicial;
                                    ent.AcaoFinal = ent.Destino.AcaoFinal;
                                    ent.AcaoEnfileiramento = ent.Destino.AcaoEnfileiramento;
                                    ent.ElementoRegistro = ent.Destino.ElementoRegistro;
                                    ent.PKPrimaria = ent.Destino.PKPrimaria;
                                    objResult.ElementoSeparador = ent.Destino.ElementoRegistro;
                                    objConfig.Mapeamentos = MapearParaAdapter(ent.Mapeamento);

                                    new BS.Fila().ProcessarFila(objResult, ent, null);
                                }
                            }
                            else
                            {
                                Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                                entLogIntegracao.Conteudo = objResult.Mensagem;
                                entLogIntegracao.Integracao = ent;
                                entLogIntegracao.Status = 1;
                                new BS.LogIntegracao().Inserir(entLogIntegracao);
                                //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1}", ent.Nome, objResult.Mensagem));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                        entLogIntegracao.Conteudo = ex.Message;
                        entLogIntegracao.Integracao = ent;
                        entLogIntegracao.Status = 1;
                        new BS.LogIntegracao().Inserir(entLogIntegracao);
                        //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                    }
                }
            }
            public List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapearParaAdapter(List<Model.Mapeamento> lstMapeamento)
            {
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRootAll = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRoot = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                foreach (Model.Mapeamento Map in lstMapeamento)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade entMap = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    entMap.ID = Map.ID;
                    entMap.De = Map.De;
                    entMap.Para = Map.Para;
                    entMap.Mult = Map.Mult;
                    entMap.PaiID = Map.PaiID;
                    entMap.Valor = Map.Valor;
                    entMap.Configuracao = Map.Configuracao;
                    entMap.TipoValor = Map.TipoValor;
                    entMap.Acao = Map.Acao;
                    foreach (Model.Mapeamento.DePara MapDePara in Map.ValoresDePara)
                    {
                        entMap.ValoresDePara.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade.DePara() { De = MapDePara.De, Para = MapDePara.Para, InfosAdicionais = MapDePara.InfosAdicionais });
                    }
                    lstRootAll.Add(entMap);
                }

                foreach (Selia.Integrador.Adapter.Util.Mapeamento.Entidade Map in lstRootAll)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade Pai = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    if (Map.PaiID != 0)
                    {
                        Pai = lstRootAll.Single(c => c.ID == Map.PaiID);
                        Pai.Filhos.Add(Map);
                    }
                    else
                    {
                        lstRoot.Add(Map);
                    }
                }
                return lstRoot;
            }
        }
        public class DB
        {
            public void Executar(Model.Integracao ent)
            {
                Selia.Integrador.Adapter.DB.Config objConfig = new Selia.Integrador.Adapter.DB.Config();
                var item = ((Model.Interface.DB)ent.Interface.Item);
                objConfig.StoredProcedure = item.StoredProcedure;
                objConfig.ConnectionString = item.ConnectionString;
                objConfig.ElementoSeparador = ent.ElementoRegistro;
                objConfig.ExecucaoFinal = ent.AcaoFinal;
                objConfig.Mapeamentos = MapearParaAdapter(ent.Mapeamento);
                objConfig.ExecucaoInicial = ent.AcaoInicial;
                objConfig.ExecucaoEnfileiramento = ent.AcaoEnfileiramento;
                objConfig.DataBaseNameFactory = item.DataBaseNameFactory;

                if (ent.Consumidor)
                {
                    foreach (Model.Fila fila in ent.Fila)
                    {
                        try
                        {
                            Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.DB().Executar(objConfig, fila.Conteudo, ent.Destino != null);

                            Model.LogFila entLogFila = new Model.LogFila();
                            entLogFila.ConteudoFila = fila.Conteudo;

                            entLogFila.Conteudo = fila.Conteudo;

                            entLogFila.ChavePrimaria = fila.ChavePrimaria;
                            entLogFila.ChaveSecundaria = fila.ChaveSecundaria;
                            entLogFila.LogIntegracao.ID = fila.LogIntegracaoID;
                            entLogFila.FilaID = fila.ID;
                            entLogFila.IntegracaoID = ent.ID;

                            if (!string.IsNullOrEmpty(objResult.Mensagem))
                                entLogFila.ConteudoRetorno = objResult.Mensagem;

                            new BS.LogFila().Inserir(entLogFila);

                            if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                            {
                                if (objResult.RespostaXmlCompleta != null && objResult.RespostaXmlSeparada != null && objResult.RespostaXmlSeparada.Count > 0)
                                {
                                    new BS.Fila().ProcessarFila(objResult, ent, null);
                                }

                                new BS.Fila().Excluir(fila.ID);
                            }
                            else
                            {
                                new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);
                            }
                        }
                        catch (Exception ex)
                        {
                            //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                        }
                    }

                    if (ent.Destino != null)
                    {
                        new BS.Integracao().Executar(ent.Destino.ID);
                    }
                }
                else
                {
                    try
                    {
                        List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> maps = MapearParaAdapter(ent.Mapeamento);

                        foreach (Model.Interface.DB.ParametroDB Param in item.Parametros)
                        {
                            objConfig.Mapeamentos.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade() { Para = Param.De, Valor = Param.Para });
                        }

                        Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.DB().Executar(objConfig);
                        new BS.Fila().ProcessarFila(objResult, ent, maps);
                    }
                    catch (Exception ex)
                    {
                        Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                        entLogIntegracao.Conteudo = ex.Message;
                        entLogIntegracao.Integracao = ent;
                        entLogIntegracao.Status = 1;
                        new BS.LogIntegracao().Inserir(entLogIntegracao);
                        //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                    }
                }

                //if (ent.DestinoID > 0)
                //{
                //    new IntegracaoNova().Executar(ent.DestinoID, true);
                //}
            }

            public List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapearParaAdapter(List<Model.Mapeamento> lstMapeamento)
            {
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRootAll = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRoot = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                foreach (Model.Mapeamento Map in lstMapeamento)
                {
                    lstRootAll.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade() { ID = Map.ID, De = Map.De, Para = Map.Para, Mult = Map.Mult, PaiID = Map.PaiID, Valor = Map.Valor, TipoValor = Map.TipoValor, Acao = Map.Acao });
                }

                foreach (Selia.Integrador.Adapter.Util.Mapeamento.Entidade Map in lstRootAll)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade Pai = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    if (Map.PaiID != 0)
                    {
                        Pai = lstRootAll.Single(c => c.ID == Map.PaiID);
                        Pai.Filhos.Add(Map);
                    }
                    else
                    {
                        lstRoot.Add(Map);
                    }
                }
                return lstRoot;
            }
        }
        public class WebService
        {
            public void Executar(Model.Integracao ent, XmlDocument Fila = null)
            {
                Selia.Integrador.Adapter.WebService.Config objConfig = PreencherEntWebService(ent);

                if (ent.Consumidor)
                {
                    Consumidor(objConfig, ent);
                }
                else
                {
                    Executor(objConfig, ent, Fila);
                }

                if (ent.DestinoID > 0)
                {
                    new Integracao().Executar(ent.DestinoID, true);
                }
            }

            public Selia.Integrador.Adapter.WebService.Config PreencherEntWebService(Model.Integracao ent)
            {
                var item = ((Model.Interface.WebService)ent.Interface.Item);
                Selia.Integrador.Adapter.WebService.Config objConfig = new Selia.Integrador.Adapter.WebService.Config();
                objConfig.Url = item.Url;
                objConfig.Metodo = item.Metodo;
                objConfig.Login = item.Login;
                objConfig.Senha = item.Senha;
                objConfig.ElementoSeparador = ent.ElementoRegistro;
                objConfig.ExecucaoInicial = ent.AcaoInicial;
                objConfig.ExecucaoFinal = ent.AcaoFinal;
                objConfig.Action = item.Action;
                objConfig.ConnectionString = ent.ConnectionString;

                objConfig.Mapeamentos = MapearParaAdapter(ent.Mapeamento);
                return objConfig;
            }
            public void Consumidor(Selia.Integrador.Adapter.WebService.Config objConfig, Model.Integracao ent)
            {
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapeamentoEntrada = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                if (ent.Destino != null)
                {
                    MapearParaAdapter(ent.Destino.Mapeamento);
                }

                int maxDegreeOfParallelism = ent.NivelParalelismo;
                Parallel.ForEach(ent.Fila, new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }, (fila) =>
                {
                    ExecutaItemFila(ent, fila, objConfig, MapeamentoEntrada);
                });
            }

            private void ExecutaItemFila(Model.Integracao ent, Model.Fila fila, Selia.Integrador.Adapter.WebService.Config objConfig, List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapeamentoEntrada)
            {
                try
                {
                    Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.WebService().Executar(objConfig, fila.Conteudo);

                    Model.LogFila entLogFila = new Model.LogFila();

                    if (!string.IsNullOrEmpty(objResult.ParametrosEnvio))
                        entLogFila.Conteudo = objResult.ParametrosEnvio;

                    entLogFila.Conteudo = objResult.ParametrosEnvio;
                    entLogFila.ConteudoFila = fila.Conteudo;
                    entLogFila.ChavePrimaria = fila.ChavePrimaria;
                    entLogFila.ChaveSecundaria = fila.ChaveSecundaria;
                    entLogFila.LogIntegracao.ID = fila.LogIntegracaoID;
                    entLogFila.FilaID = fila.ID;
                    entLogFila.IntegracaoID = ent.ID;

                    if (!string.IsNullOrEmpty(objResult.Mensagem))
                        entLogFila.ConteudoRetorno = objResult.Mensagem;

                    if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                    {
                        new BS.Fila().Excluir(fila.ID);
                        if (ent.Destino != null)
                        {
                            new BS.Fila().ProcessarFila(objResult, ent, MapeamentoEntrada);
                        }
                    }
                    else
                    {
                        new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);

                        if (!string.IsNullOrEmpty(ent.AcaoReturnoErro))
                        {

                        }
                    }

                    new BS.LogFila().Inserir(entLogFila);
                }
                catch (Exception ex)
                {
                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = ex.Message;
                    entLogIntegracao.Integracao = ent;
                    entLogIntegracao.Status = 1;
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                }
            }

            private void Executor(Selia.Integrador.Adapter.WebService.Config objConfig, Model.Integracao ent, XmlDocument Fila = null)
            {
                try
                {
                    var item = ((Model.Interface.WebService)ent.Interface.Item);
                    List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> maps = objConfig.Mapeamentos;
                    objConfig.Mapeamentos = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                    foreach (Model.Interface.WebService.ParametroWS param in item.Parametros)
                    {
                        objConfig.Mapeamentos.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade() { Para = param.De, Valor = param.Para });
                    }
                    objConfig.DataHoraUltimaExecucao = ent.DataHoraUltimaExecucao;
                    Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.WebService().Executar(objConfig, Fila);
                    new BS.Fila().ProcessarFila(objResult, ent, maps);
                }
                catch (Exception ex)
                {
                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = ex.Message;
                    entLogIntegracao.Integracao = ent;
                    entLogIntegracao.Status = 1;
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", ent.Nome, ex.Message, ex.StackTrace));
                }
            }

            public List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapearParaAdapter(List<Model.Mapeamento> lstMapeamento)
            {
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRootAll = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRoot = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                foreach (Model.Mapeamento Map in lstMapeamento)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade newMap = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    newMap.ID = Map.ID;
                    newMap.De = Map.De;
                    newMap.Para = Map.Para;
                    newMap.Mult = Map.Mult;
                    newMap.PaiID = Map.PaiID;
                    newMap.Valor = Map.Valor;
                    newMap.TipoValor = Map.TipoValor;
                    newMap.Acao = Map.Acao;
                    newMap.isXmlEntrada = Map.BitXmlEntrada;
                    newMap.BitExcluirBranco = Map.BitExcluirBranco;
                    foreach (Model.Mapeamento.DePara depara in Map.ValoresDePara)
                    {
                        newMap.ValoresDePara.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade.DePara() { ID = depara.ID, De = depara.De, InfosAdicionais = depara.InfosAdicionais, Para = depara.Para });
                    }
                    lstRootAll.Add(newMap);
                }

                foreach (Selia.Integrador.Adapter.Util.Mapeamento.Entidade Map in lstRootAll)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade Pai = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    if (Map.PaiID != 0)
                    {
                        Pai = lstRootAll.Single(c => c.ID == Map.PaiID);
                        Pai.Filhos.Add(Map);
                    }
                    else
                    {
                        lstRoot.Add(Map);
                    }
                }
                return lstRoot;
            }
        }

        public class Rest
        {

            public void Executar(Model.Integracao integracao)
            {

                var configuracao = integracao.IntegracaoParaRest();

                configuracao.Mapeamentos = MapearParaAdapter(integracao.Mapeamento);
                configuracao.MapeamentosQueryString = MapearParaAdapter(integracao.MapeamentoQueryString);
                configuracao.MapeamentoRetorno = MapearParaAdapter(integracao.MapeamentoRetorno);

                try
                {
                    if (integracao.Consumidor)
                    {
                        Consumidor(integracao, configuracao);
                    }
                    else
                    {
                        Executor(integracao, configuracao);
                    }
                }
                catch (Exception ex)
                {

                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = ex.Message;
                    entLogIntegracao.Integracao = integracao;
                    entLogIntegracao.Status = 2; //1 Sucesso 2 Erro
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", integracao.Nome, ex.Message, ex.ToString()));
                }

                if (integracao.DestinoID > 0)
                {
                    new Integracao().Executar(integracao.DestinoID, true);
                }
            }

            private void Consumidor(Model.Integracao integracao, Selia.Integrador.Adapter.Rest.Config configuracao)
            {
                int maxDegreeOfParallelism = integracao.NivelParalelismo;
                Parallel.ForEach(integracao.Fila, new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }, (fila) =>
                {
                    ExecutaItemFila(integracao, fila, configuracao);
                });
            }

            private void ExecutaItemFila(Model.Integracao integracao, Model.Fila fila, Selia.Integrador.Adapter.Rest.Config configuracao)
            {
                var integracaoID = integracao.ID;
                string conteudoFila = null;
                try
                {
                    var xmlFila = new XmlDocument();
                    xmlFila.LoadXml(fila.Conteudo);
                    conteudoFila = fila.Conteudo;

                    Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.Rest().Executar(configuracao, xmlFila);

                    Model.LogFila logFila = new Model.LogFila();
                    logFila.Conteudo = objResult.ParametrosEnvio;
                    logFila.ConteudoFila = fila.Conteudo;
                    logFila.ChavePrimaria = fila.ChavePrimaria;
                    logFila.ChaveSecundaria = fila.ChaveSecundaria;
                    logFila.LogIntegracao.ID = fila.LogIntegracaoID;
                    logFila.RespostaSemTratamento = objResult.RespostaSemTratamento;
                    logFila.FilaID = fila.ID;
                    logFila.IntegracaoID = integracao.ID;

                    if (objResult.RespostaXmlCompleta != null)
                        logFila.ConteudoRetorno = objResult.RespostaXmlCompleta.InnerXml;

                    if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                    {
                        new BS.Fila().Excluir(fila.ID);
                        if (integracao.Destino != null)
                        {
                            new BS.Fila().ProcessarFila(objResult, integracao, configuracao.Mapeamentos);

                        }
                    }
                    else
                    {
                        new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);
                    }

                    new BS.LogFila().Inserir(logFila);
                }
                catch (Selia.Integrador.Utils.Exceptions.HttpRestRetornoException exIntegradoRetorno)
                {
                    Model.LogFila logFila = new Model.LogFila();
                    logFila.ChavePrimaria = fila.ChavePrimaria;
                    logFila.ChaveSecundaria = fila.ChaveSecundaria;
                    logFila.LogIntegracao.ID = fila.LogIntegracaoID;
                    logFila.FilaID = fila.ID;

                    logFila.ConteudoFila = fila.Conteudo;
                    logFila.Conteudo = exIntegradoRetorno.ParamentroEnvio;
                    logFila.RespostaSemTratamento = "Connection: " + ConnectionMonitor.Monitor.Instance.GetStatus() + "  **  " + exIntegradoRetorno.RetornoNaoTratado;
                    logFila.ConteudoRetorno = exIntegradoRetorno.RetornoTratado;
                    logFila.IntegracaoID = integracao.ID;

                    new BS.LogFila().Inserir(logFila);
                    new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);

                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = string.Format("{0} - Valor de entrada:{1}", exIntegradoRetorno.ToString(), exIntegradoRetorno.InformacaoAdicional);
                    entLogIntegracao.Integracao = integracao;
                    entLogIntegracao.Status = 2; //1 Sucesso 2 Erro
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", integracao.Nome, exIntegradoRetorno.Message, exIntegradoRetorno.ToString()));
                }
                catch (Selia.Integrador.Utils.Exceptions.HttpRestException exIntegrador)
                {
                    new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);

                    Model.LogFila logFila = new Model.LogFila();
                    logFila.ChavePrimaria = fila.ChavePrimaria;
                    logFila.ChaveSecundaria = fila.ChaveSecundaria;
                    logFila.LogIntegracao.ID = fila.LogIntegracaoID;
                    logFila.FilaID = fila.ID;

                    logFila.ConteudoFila = fila.Conteudo;
                    logFila.Conteudo = exIntegrador.ParamentroEnvio;
                    logFila.RespostaSemTratamento = "Connection: " + ConnectionMonitor.Monitor.Instance.GetStatus() + "  **  " + exIntegrador.RetornoNaoTratado;
                    logFila.ConteudoRetorno = exIntegrador.RetornoTratado;
                    logFila.IntegracaoID = integracao.ID;

                    new BS.LogFila().Inserir(logFila);
                    new BS.Fila().AtualizarStatus(Model.Fila.TipoStatus.Erro, fila.ID);

                    if (!string.IsNullOrEmpty(integracao.AcaoReturnoErro))
                    {
                        List<object> parametros = new List<object>();
                        parametros.Add(fila.ID);
                        parametros.Add(fila);
                        parametros.Add(exIntegrador.InformacaoAdicional);

                        new Selia.Integrador.Utils.Generic.Invoke().Exec(integracao.AcaoReturnoErro.Split(';')[0], integracao.AcaoReturnoErro.Split(';')[1], parametros);
                    }
                    else
                    {
                        Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                        entLogIntegracao.Conteudo = exIntegrador.Message;
                        entLogIntegracao.Integracao = integracao;
                        entLogIntegracao.Status = 2; //1 Sucesso 2 Erro
                        new BS.LogIntegracao().Inserir(entLogIntegracao);
                        //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", integracao.Nome, exIntegrador.Message, exIntegrador.ToString()));
                    }
                }
            }


            private void Executor(Model.Integracao integracao, Selia.Integrador.Adapter.Rest.Config configuracao)
            {
                try
                {
                    Selia.Integrador.Adapter.Resultado objResult = new Selia.Integrador.Adapter.Rest().Executar(configuracao);


                    if (objResult.TipoMensagem == Selia.Integrador.Adapter.Resultado.Tipo.Sucesso)
                        new BS.Fila().ProcessarFila(objResult, integracao, configuracao.Mapeamentos);
                    else
                    {
                        Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                        entLogIntegracao.Conteudo = objResult.Mensagem;
                        entLogIntegracao.Integracao = integracao;
                        entLogIntegracao.Status = 1;
                        new BS.LogIntegracao().Inserir(entLogIntegracao);
                        //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1}", integracao.Nome, objResult.Mensagem));
                    }

                }
                catch (Selia.Integrador.Utils.Exceptions.HttpRestRetornoException exIntegradoRetorno)
                {

                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = string.Format("{0} - {1}", exIntegradoRetorno.Message, exIntegradoRetorno.InformacaoAdicional);
                    entLogIntegracao.Integracao = integracao;
                    entLogIntegracao.Status = 2; //1 Sucesso 2 Erro
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", integracao.Nome, exIntegradoRetorno.Message, exIntegradoRetorno.ToString()));

                }
                catch (Exception ex)
                {
                    Model.LogIntegracao entLogIntegracao = new Model.LogIntegracao();
                    entLogIntegracao.Conteudo = ex.Message;
                    entLogIntegracao.Integracao = integracao;
                    entLogIntegracao.Status = 1;
                    new BS.LogIntegracao().Inserir(entLogIntegracao);
                    //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1} - StackTrace: {2}", integracao.Nome, ex.Message, ex.StackTrace));
                }

            }
            public List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> MapearParaAdapter(List<Model.Mapeamento> lstMapeamento)
            {
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRootAll = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade> lstRoot = new List<Selia.Integrador.Adapter.Util.Mapeamento.Entidade>();
                foreach (Model.Mapeamento Map in lstMapeamento)
                {
                    lstRootAll.Add(
                            new Selia.Integrador.Adapter.Util.Mapeamento.Entidade()
                            {
                                ID = Map.ID,
                                De = Map.De,
                                Para = Map.Para,
                                Mult = Map.Mult,
                                PaiID = Map.PaiID,
                                Valor = Map.Valor,
                                TipoValor = Map.TipoValor,
                                Acao = Map.Acao,
                                isXmlEntrada = Map.BitXmlEntrada,
                                BitExcluirBranco = Map.BitExcluirBranco,
                                ValoresDePara = Map.ValoresDePara.Select(x => new Selia.Integrador.Adapter.Util.Mapeamento.Entidade.DePara()
                                {
                                    De = x.De,
                                    Para = x.Para,
                                    ID = x.ID,
                                    InfosAdicionais = x.InfosAdicionais
                                }).ToList(),
                                ElementoMult = Map.ElementoMult
                            });
                }

                foreach (Selia.Integrador.Adapter.Util.Mapeamento.Entidade Map in lstRootAll)
                {
                    Selia.Integrador.Adapter.Util.Mapeamento.Entidade Pai = new Selia.Integrador.Adapter.Util.Mapeamento.Entidade();
                    if (Map.PaiID != 0)
                    {
                        Pai = lstRootAll.FirstOrDefault(c => c.ID == Map.PaiID);
                        if (Pai != null)
                        {
                            Pai.Filhos.Add(Map);
                        }
                    }
                    else
                    {
                        lstRoot.Add(Map);
                    }
                }
                return lstRoot;
            }

        }
    }
}

