$(document).ready(function ()
{
    $("input[type ='submit']").click(function ()
    {
        var selectedapply = $document.getElementById("fullname").val();
        let selectedapply = selectedapply.value.trim();
        if (selectedapply === "") {
            document.getElementById("result").innerHTML = 'Oops!!';

        }
        else {
            document.getElementById("result");
        }
    });
});

jQuery('#frm').validate({
    rules: {
        fullname:"required"
    }, message: {

    }
})