using Selia.Integrador.Utils.AutenticacaoRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Adapter.AbstractFactory
{
    public static class AutenticacaoRestAbstractFactory
    {
        //Não foi usado um IOC aqui, pela arquitetura do projeto
        //Quando houver mais tipo de autenticações criar regra
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoAutenticacao"></param>
        /// <returns></returns>
        public static IAutenticacaoRest ObterInstancia(Model.Interface.Rest.TipoAutenticacao tipoAutenticacao)
        {
            IAutenticacaoRest ret = null;

            if (tipoAutenticacao == Model.Interface.Rest.TipoAutenticacao.Basic)
            {
                ret = new AutenticacaoRestBasic();
            }

            return ret; 
        }
    }
}

