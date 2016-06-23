$(document).ready(function () {
    $("#teste").click(function () {
        alert('sadasd');
    });
    
    var table = $('#mensalidades');

    table.find('tr').each(function () {
            var check = $(this).find('input[type=checkbox]');
            var texto = $(this).find('input[type=text]');
            
            $(check).change(function () {
                if ($(this).is(':checked'))
                {                    
                    texto.removeAttr('disabled');
                }
                else
                {
                    texto.attr('disabled', 'disabled')
                }
        });
    });

    //$('#pago').change(function () {

    //    if ($(this).is(':checked'))
    //    {            
    //        $('#item_DataPagamento').removeAttr('disabled');
    //    }
    //    else
    //    {
    //        $('#item_DataPagamento').attr('disabled', 'disabled')
    //    }
    //});
});