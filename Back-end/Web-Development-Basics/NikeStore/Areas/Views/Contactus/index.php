
<script src="http://code.jquery.com/jquery-2.1.4.min.js"></script>
<p id="msg"></p>
<form  action="/helpdesk/contactus/response" method="post" id="contact">
    <fieldset >
        <legend>Contact us</legend>
        <input type="text" name="name" placeholder="Name">
        <input type="email" name="email" placeholder="Email">
        <textarea name="text" cols="30" rows="10" placeholder="Message" class="textarea"></textarea>
        <input type="submit" value="Send">
    </fieldset>
</form>


<script>
    $('#contact').on('submit', function()
    {
        var postData = $(this).serializeArray();
        var formURL = $(this).attr("action");
        $.ajax(
            {
                url : formURL,
                type: "POST",
                data : postData,
                success:function(data)
                {
                    $('#msg').html(data)
                }
            });
        return false;
    });
</script>

