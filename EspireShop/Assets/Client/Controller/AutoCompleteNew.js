$(function () {
    $("#txtKeyWord").autocomplete({
        minLength: 0,
        source: function (request, response) {
            $.ajax({
                url: '/TinTuc/ListTitleName/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
            });
        },
        focus: function (event, ui) {
            $("#txtKeyWord").val(ui.item.nameTitle);
            return false;
        },
        select: function (event, ui) {
            $("#txtKeyWord").val(ui.item.nameTitle);
            return false;
        }
    })
  .autocomplete("instance")._renderItem = function (ul, item) {
      return $("<li>")
        .append("<div><a href=/chi-tiet-tin-tuc/" + item.metaTitle + "-" + item.newId + ">" + item.nameTitle + "</a></div>")
        .appendTo(ul);
  };
});