$(document).ready(function () {

    $(".details").click(function () {        
        var integrante = $(this).attr("data-integrante");
        var calendario = $(this).attr("data-calendario");
        $("#baixarMensalidades").load("/Mensalidades/BaixarMensalidades?integrante=" + integrante + "&calendario=" + calendario, function () {
            $("#baixarMensalidades").modal();
        })
    });
});