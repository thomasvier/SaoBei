$(document).ready(function () {    
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
                    texto.attr('disabled', 'disabled');
                    texto.text('');
                    texto.val('');
                }
        });
    });    
});