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
                open("/MasterReg/DetailPage/DetailPage", "_self");
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

function GetSession()
{
    $.ajax({
        async: false,
        type: "GET",
        url: '/MasterReg/GetSession',
        data:null,
        //accepts: "application/json",
        //contentType: "application/json",

        success: function (data) {
            if (data.error === false) {
                $("#lbEmail").text(data.message);
            }
            else {
                console.log(data);
                alert(data.message);
                open("/MasterReg/LoginPage/LoginPage", "_self");

            }
        },
        error: function (data) {
            console.log(data);
            alert(data.responseJSON.message);
        }

    });
}

function GetGridUser() {
    $.ajax({
        async: false,
        type: "GET",
        url: '/MasterReg/GetGridUser',
        data: null,
      
        success: function (data) {

            if (data.error === false) {
                $('#tbUser').DataTable({
                    "bDestroy": true,
                    "bFilter": false,
                    paging: true,
                    bAutoWidth: false,
                    // scrollCollapse: true,
                    //scrollY: '500em',
                    //ordering: true,
                    searching: true,
                    data: data.data.listUser,
                    columns: [

   
                        {
                           title: 'User Number', data: 'userNumber'
                         
                        },
                        {
                            title: 'Name', data: 'personalName'

                        },
                        {
                            title: 'Email', data: 'emailAddress'
                        },
                        {
                            title: 'Passwords', data: 'passwords'
                        },
                      
                        {
                            title: 'Number Phone', data: 'numberPhone'
                        },
                     
                        {
                            title: 'Nationality', data: 'nationality'
                        },
                  
                        {
                            title: 'Join Date', data: 'joinDated'
                        }
                        

                    ]

                });

            }
            else {
                alert("Service Error " + data.message);
            }
        },
        error: function (e) {
            alert("Service Error : " + e.responseJSON.message);
            console.log(e);
        },
  
    });

}

function LogOut() {
    $.ajax({
        async: false,
        type: "GET",
        url: '/MasterReg/LogOut',
        data: null,
        //accepts: "application/json",
        //contentType: "application/json",

        success: function (data) {
            if (data.error === false) {
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
        EmailAddress: Email,
        FullName:Name,
        Passwords: Pass,
        RePassword: RePass,
        dpNationality: dpNation,
        txtNationality: txtNation,
        NumberPhone:NumberPhone
    };
    $.ajax({
        async: false,
        type: "POST",
        url: '/MasterReg/RegisterAccounts',
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