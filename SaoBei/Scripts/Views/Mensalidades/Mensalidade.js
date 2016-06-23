$(document).ready(function () {

    $(".details").click(function () {        
        var integranteID = $(this).attr("data-integrante");
        var calendarioID = $(this).attr("data-calendario");
        $("#baixarMensalidades").load("/Mensalidades/BaixarMensalidades?integranteID=" + integranteID + "&calendarioID=" + calendarioID, function () {
            $("#baixarMensalidades").modal();
        })
    });
});