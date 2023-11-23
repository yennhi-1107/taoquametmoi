$(Document).ready(function () {
    $('body').on('click', 'addtocart', function (e) {
        e.prevenDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        alert(id + " " + quantity);
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                $('#checkout_items').html(rs.Count);
                alert(rs.msg);
            }
        })
    });
});