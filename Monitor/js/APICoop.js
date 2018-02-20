
var SeliaMonitor = {};
SeliaMonitor = {
    "ConsultarIntegracao": function (Configuracao) {
        SeliaMonitor.Conectar("ConsultarIntegracoes", Configuracao);
    },
    "ConsultarLogFila": function (Configuracao) {
        SeliaMonitor.Conectar("ConsultarLogFila", Configuracao);
    },
    "AtualizarStatusFilaSucesso": function (Configuracao) {
        SeliaMonitor.Conectar("AtualizarStatusParaSucesso", Configuracao);
    },
    "DeletarFila": function (Configuracao) {
        SeliaMonitor.Conectar("DeletaFila", Configuracao);
    },
    "Conectar": function (NomeDoMetodo, Parametros) {
        $.support.cors = true;
        $.ajax({
            type: "POST",
            url: "Integrador.asmx/" + NomeDoMetodo, // url da pagina/nome do metodo 
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: Parametros.Parametro,
            success: function (json) {
                var JsonResultado = json.d.Result;
                if (JsonResultado == null) {
                    JsonResultado = json.d;
                }
                if (Parametros == null || Parametros.onCallback == null) {
                    return;
                }
                Parametros.onCallback(JsonResultado);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (XMLHttpRequest.responseText != "") {
                    $('html').html(XMLHttpRequest.responseText)
                }
            }
        });
    }
}