function Login() {
    let Email = $("#txtEmail").val();
    let Pass = $("#txtpass").val();
    let DataObject =
    {
        Email: Email,
        Password: Pass
    };
    $.ajax({
        async: false,
        type: "POST",
        url: '/MasterReg/Login',
        data: JSON.stringify(DataObject),
        accepts: "application/json",
        contentType: "application/json",
       
        success: function (data) {
            if (data.error === false) {
                open("/MasterReg/RegisterPage/RegisterAccount", "_self");
            }
            else {
                console.log(data);
                alert(data.message);
            }
        },
        error: function (data) {
            console.log(data);
            alert(data.responseJSON.message);
        }
       
    });
}