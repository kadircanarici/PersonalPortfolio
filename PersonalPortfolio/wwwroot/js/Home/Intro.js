$(document).ready(function () {
    WriteIntro();

}
);
function WriteIntro() {
    $.ajax('Home/GetIntros', {
        type: "GET",
        success: function (data) {
            $("#txtTitleStart").html(data[0].titleStart);
            //$(".fst-normal").html(data[0].titleMidLine);
            //$("#txtTitleEnd").html(data[0].titleEnd);
            $("#txtContent").html(data[0].content);

        }
    });
}