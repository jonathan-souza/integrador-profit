using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Adapter
    {
        public enum TipoAdapter
        {
            DB=2, ArquivoTexto=3, WebService=1, Rest=4
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public TipoAdapter Tipo
        {
            get
            {
                if ((int)Model.Adapter.TipoAdapter.DB == ID)
                {
                    return TipoAdapter.DB;
                }
                else if ((int)Model.Adapter.TipoAdapter.ArquivoTexto == ID)
                {
                    return TipoAdapter.ArquivoTexto;
                }
                else if ((int)Model.Adapter.TipoAdapter.Rest == ID)
                {
                    return TipoAdapter.Rest;
                }
                return TipoAdapter.WebService;
            }
        }

    }
}
