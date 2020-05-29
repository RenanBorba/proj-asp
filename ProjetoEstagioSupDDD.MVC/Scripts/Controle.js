$(document).ready(function () {

    $('#ProdutoId').click(function () {
        var url = $('#produtoListaModal').data('url');
        $.get(url, function (data) {
            $('#produtoListaContainer').html(data);
            $('#produtoListaModal').modal('show');
        });
    });

    fControle.SelecionarProduto();

});
    var fControle = {
        SelecionarProduto: function () {
            $(document).on('click', '.selecionar-produto', function () {
                var produtoId = $(this).attr("produto-id");
                var descricaoProduto = $(this).find("td:first").html().trim();
                $('#ProdutoId').val(produtoId);
                $('#produtoListaModal').modal('toggle');
            });
        }
    };


