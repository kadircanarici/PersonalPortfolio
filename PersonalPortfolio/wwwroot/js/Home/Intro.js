

    $.ajax('Home/GetIntros', {
        type: "GET",
        success: function (data) {
            $("#txtTitleStart").html(data[0].titleStart);
            $("#txtTitleStart").append(` <em class="p-relative z-index-1 fst-normal">${data[0].titleMidLine} <span class="appear-animation" data-appear-animation="highlightScribble1"><svg class="highlight-scribble-1" viewBox="0 0 760 60" preserveAspectRatio="none"><path d="M19,49C75.19,30.63,152,21,317.26,17.27c55.43-.41,198.33-2.08,407.85,12.53" stroke="#0088cc" pathLength="1" stroke-width="14" fill="none"></path></svg></span></em>`);
            $("#txtTitleStart").append(`<span id="txtTitleEnd">${data[0].titleEnd}</span>`);
            $("#txtContent").html(data[0].content);

        }
    });


