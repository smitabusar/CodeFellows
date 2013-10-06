$(document).ready(function () {
    //alert("DOM Ready");
    var sideBarButton = $('#listRegion li');
    //Click Event handler for each of list item in sideBar which highlights the given element
    //$('#listRegion li').on('click', function () {
    //    var elementName = $(this).html();
    //    var myDOMObject = document.getElementsByTagName(elementName);
    //    $(myDOMObject).css('border', '5px solid red');
    //});

    //Bubble up the events to the list and toggles the highlighted element
    //$('#listRegion').on('click','li', function (e) {
    //    var elementName = $(this).html();
    //    var myDOMObject = document.getElementsByTagName(elementName);
    //    if($(myDOMObject).hasClass('HighlightElement')){
    //        $(myDOMObject).removeClass('HighlightElement')
    //    }else{
    //        $(myDOMObject).addClass('HighlightElement');
    //    }
    //});

    //Hover event that uses a class to highlight the item on list
    $('#listRegion li').hover(function() {
        var elementName = $(this).html();
        var myDOMObject = document.getElementsByTagName(elementName);
        $(myDOMObject).toggleClass('HighlightElement');
    });
});

