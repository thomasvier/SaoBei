$(document).ready(function () {
    $("#IntegranteID").change(function () {
        if ($('#CalendarioID').val() != '' && $('#IntegranteID').val() != '') {
            $("#formMensalidades").submit();
        }
    });

    $(".details").click(function () {        
        var mensalidadeIntegranteID = $(this).attr("data-mensalidade");
        $("#baixarMensalidades").load("/Mensalidades/BaixarMensalidades?mensalidadeIntegranteID=" + mensalidadeIntegranteID, function () {
            $("#baixarMensalidades").modal();
        })
    });
});