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

function Register() {
    let Email = $("#txtEmail").val();
    let Pass = $("#txtpass").val();
    let Name = $("#txtFullName").val();
    let NumberPhone = $("#txtNumberPhone").val();
    let RePass = $("#txtRepass").val();
    let dpNation = $("#dpNationality").val();
    let txtNation = $("#txtNationality").val();

   

    let DataObject =
    {
        Email: Email,
        Password: Pass,
        RePassword: RePass,
        dpNationality: dpNation,
        txtNationality: txtNation,
        NumberPhone:NumberPhone
    };
    $.ajax({
        async: false,
        type: "POST",
        url: '/MasterReg/RegisterAccount',
        data: JSON.stringify(DataObject),
        accepts: "application/json",
        contentType: "application/json",

        success: function (data) {
            if (data.error === false) {
                alert(data.message);
                open("/MasterReg/LoginPage/LoginPage", "_self");
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
function CekDPNationality() {
    let Nation = $("#dpNationality").val();
  // let Nation $("#txtAcct").val($(this).find("option:selected").attr("value"));

    var Nationality = document.getElementById('txtNationality');

    if (Nation === "Other") {
        Nationality.style.display = 'block';

    }
    else {
        Nationality.style.display = 'none';

    }
}