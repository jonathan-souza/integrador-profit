var Content = "";
var TemplatePrincipal;

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/^\s+/, "");
}
String.prototype.rtrim = function () {
    return this.replace(/\s+$/, "");
}

$(document).ready(function () {
    PreInit();
});
function PreInit() {
    if ($(".UltimaAtualizacao").html().trim() == "") {
        $(".Loader").show();
    }
    else {
        $(".LoadUltimaAtualizacao").show();
    }
    var now = new Date();
    SeliaMonitor.ConsultarIntegracao(
    {
        "Parametro": "",
        onCallback: function (json) {
            $("#loopConteudo").html("");

            $.each(json, function (index, value) {
                if (value.Consumidor != true && value.DestinoID != 0) {
                    Content = "";

                    TemplatePrincipal = $("#TemplateBase").clone();

                    MontaTemplate(value);

                    TemplatePrincipal.find(".Integracao").html(Content);

                    if (value.Status == 0) {
                        TemplatePrincipal.find(".DescricaoIntegrador").addClass("Offline");
                    }

                    $("#loopConteudo").append(TemplatePrincipal.html());                    
                }
            });
            Init();
            $(".Loader").hide();
            $(".LoadUltimaAtualizacao").hide();

            if ($(".UltimaAtualizacao").html().trim() == "") {
                window.setInterval(PreInit, 100000);
            }
            $(".UltimaAtualizacao").html("Ultima Atualizacao: " + GetDate(now));
        }
    });
}

function Init() {
    $.each($(".r-mainPad"), function (key, value) {
        $(value).find(".r-minus")[0].click();
    });
    $(".Status").click(function (e, s) {
        if ($(this.parentElement.parentElement).find(".ConteudoErro").is(":visible")) {
            $(this.parentElement.parentElement).find(".ConteudoErro").hide();
            $($(this.parentElement.parentElement).find(".Status")).find("img").attr('src', 'images/plus.png');
        }
        else {
            var control = this;

            if ($(control.parentNode.parentNode).find(".ConteudoErro").attr('isPostBack') == null) {
                $($(this.parentElement.parentElement).find(".Status")).find("img").attr('src', 'images/Loader.gif');
                SeliaMonitor.ConsultarLogFila({
                    "Parametro": "{IntegracaoID:" + $(this).attr("ID") + "}",
                    onCallback: function (json) {
                        $(control.parentNode.parentNode).find(".ConteudoErro").attr('isPostBack', true);
                        $.each(json, function (index, value) {
                            MontarTemplateLogFila(value);
                            $(control.parentElement.parentElement).find(".ConteudoErro").show();
                            $($(control.parentElement.parentElement).find(".Status")).find("img").attr('src', 'images/minus.png');
                            $(control.parentNode.parentNode).find(".ConteudoErro").html(divConteudo);
                        });
                        $('.Reprocessar').click(function () {
                            $(this.parentNode).find(".Reprocessar").hide();
                            $(this.parentNode).find(".Deletar").hide();
                            $(this.parentNode).find(".loaderbgwhite").show();
                            var controle = this;

                            SeliaMonitor.AtualizarStatusFilaSucesso(
                            {
                                "Parametro": "{FilaID:" + $(this).attr("ID") + "}",
                                onCallback: function (json) {
                                    if (json == true) {
                                        $(controle.parentNode.parentNode).hide();
                                        PreInit();
                                    }
                                    $(controle.parentNode).find(".Reprocessar").show();
                                    $(controle.parentNode).find(".Deletar").show();
                                    $(controle.parentNode).find(".loaderbgwhite").hide();
                                }
                            });
                        });

                        $('.Deletar').click(function () {
                            $(this.parentNode).find(".Reprocessar").hide();
                            $(this.parentNode).find(".Deletar").hide();
                            $(this.parentNode).find(".loaderbgwhite").show();
                            var controle = this;
                            SeliaMonitor.DeletarFila(
                            {
                                "Parametro": "{FilaID:" + $(this).attr("ID") + "}",
                                onCallback: function (json) {
                                    if (json == true) {
                                        $(controle.parentNode.parentNode).hide();
                                        PreInit();
                                    }
                                    $(controle.parentNode).find(".Reprocessar").show();
                                    $(controle.parentNode).find(".Deletar").show();
                                    $(controle.parentNode).find(".loaderbgwhite").hide();
                                }
                            });
                        });

                    }
                });
            }
            else {
                $(control.parentElement.parentElement).find(".ConteudoErro").show();
                $($(control.parentElement.parentElement).find(".Status")).find("img").attr('src', 'images/minus.png');
                $(control.parentNode.parentNode).find(".ConteudoErro").html(divConteudo);
            }
        }
    });
    $(".MaxminIntegracao").click(function () {
        if ($(this.parentElement.parentElement).find(".Integracao").is(":visible")) {
            $(this.parentElement.parentElement).find(".Integracao").hide();
            $(this).attr('src', 'images/maximize.png');
            $(this.parentElement.parentElement).find(".DescricaoIntegrador").css('border-radius', '5px');
        }
        else {

            $(this.parentElement.parentElement).find(".Integracao").show();
            $(this).attr('src', 'images/minimize.png');
            $(this.parentElement.parentElement).find(".DescricaoIntegrador").css('border-radius', '5px 5px 0px 0px');
        }
    });
}
function MontaTemplate(value) {
    var Base = $("#TemplateBase").find(".Painel").clone();
    /*Base = $(Base[0].outerHTML);*/
    Base.find(".TopoPainelTitulo").html(value.Nome);
    
    if (TemplatePrincipal.find(".DescricaoIntegradorTitulo").html() == "" || eval("new " + TemplatePrincipal.find(".DescricaoIntegradorTitulo").attr('Data').replace('/', '').replace('/', '')) > eval("new " + value.DataHoraUltimaExecucao.replace('/', '').replace('/', ''))) {
        TemplatePrincipal.find(".DescricaoIntegradorTitulo").html(value.Nome.split(':')[0] + " (" + GetDate(value.DataHoraUltimaExecucao) + ")");
        TemplatePrincipal.find(".DescricaoIntegradorTitulo").attr('Data', value.DataHoraUltimaExecucao);
    }

    Base.find(".DataPainelTopo").html(GetDate(value.DataHoraUltimaExecucao));

    $.each(value.LogIntegracao, function (logIndex, logValue) {
        if (logValue.Status == 0) {
            alert(logValue.Status);
            if (logValue.Conteudo.indexOf('<') != 0) {
                var Conteudo = logValue.Conteudo;
                var data = GetDate(logValue.DataCriacao);
                Base.find(".Conteudo").html("<div class=\"ConteudoItem\">" + Conteudo + "<span>" + data + "</span></div>");
                Base.find(".Qtd").html("1");
            }
        }
        return false;
    });

    Base.find(".imgShowLogFila").hide();
    var qtd = parseInt(Base.find(".Qtd").html().trim() == "" ? "0" : Base.find(".Qtd").html(), 10) + value.QtdErros;
    if (qtd > 0) {
        Base.find(".Qtd").html(qtd + " erro(s) encontrado(s)");
        Base.find(".imgShowLogFila").show();
        Base.find(".ImgPainelTopo").attr("src", "images/erro.png");
        Base.find(".Status").attr("ID", value.PaiID);
        TemplatePrincipal.find(".SuccessoIntegrador").attr("src", "images/error.png");
    }

    Content += Base[0].outerHTML + "<div style=\"clear:both\"></div>";
    if (value.DestinoID != 0) {
        Content += $(".Etapa")[0].outerHTML + "<div style=\"clear:both\"></div>";
        MontaTemplate(value.Destino);
    }




}
var divConteudo = "";
function MontarTemplateLogFila(value) {
    if (value != "") {
        var BaseItemErro = $(".Item").clone();

        BaseItemErro.find(".CFilaPrincipal").html(htmlEncode(value.ConteudoFila));
        BaseItemErro.find(".CFila").html(htmlEncode(value.Conteudo));
        BaseItemErro.find(".CRetorno").html(value.ConteudoRetorno);
        BaseItemErro.find('.Deletar').attr("ID", value.FilaID);
        BaseItemErro.find('.Reprocessar').attr("ID", value.FilaID);
        divConteudo += BaseItemErro[0].outerHTML;
    }
}
function htmlEncode(value) {
    return $('<div/>').text(value).html();
}

function GetDate(data) {
    var d = data;
    if (data.toString().indexOf('Date') > 0) {
        var d = eval(data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    }
    try {
        return ("00" + (d.getDate())).slice(-2) + "/" +
    ("00" + (d.getMonth() + 1)).slice(-2) + "/" +
    d.getFullYear() + " " +
    ("00" + d.getHours()).slice(-2) + ":" +
    ("00" + d.getMinutes()).slice(-2) + ":" +
    ("00" + d.getSeconds()).slice(-2);
    }
    catch (err) {
        return "";
    }

}
function StringtoXML(text) {
    if (window.ActiveXObject) {
        var doc = new ActiveXObject('Microsoft.XMLDOM');
        doc.async = 'false';
        doc.loadXML(text);
    } else {
        var parser = new DOMParser();
        var doc = parser.parseFromString(text, 'text/xml');
    }
    return doc;
}
