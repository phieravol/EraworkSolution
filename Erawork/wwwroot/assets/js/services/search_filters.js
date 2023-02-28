$(document).ready(function () {
    // Lấy giá trị của RequestVerificationToken
    var token = $('input[name="__RequestVerificationToken"]').val();

    $('input[type="checkbox"], input[type = "number"]').on('change', function () {

        var categoryIds = [];
        var priceIds = [];
        var providerIds = [];
        var searchTerm = $("#SearchTerm").val();

        $('input[name="category"]:checked').each(function () {
            categoryIds.push($(this).val());
            console.log(categoryIds);
            
        });

        $('input[name="priceOption"]:checked').each(function () {
            priceIds.push($(this).val());
            console.log(typeof(priceIds));
        });

        $('input[name="levelOption"]:checked').each(function () {
            providerIds.push($(this).val());
            console.log(providerIds);
        });

        $.ajax({
            type: 'POST',
            url: '/services',
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            data: {
                CategoryIds: categoryIds,
                PriceOptions: priceIds,
                providerLevels: providerIds,
                searchTerm: searchTerm,
            },
            success: function (success) {
                // Xử lý kết quả tìm kiếm ở đây
            },
            error: function (xhr, status, error) {
                // Xử lý lỗi ở đây
                console.log("xhr: " + xhr);
                console.log("status: " + status);
                console.log("status: " + error);

            }
        });
    })
})