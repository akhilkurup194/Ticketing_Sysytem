function checkfname() {
    var letters = /^[A-Za-z]+$/;
    let fnameinput = document.getElementById("fname");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Please Enter Your First Name");

    }else { 
        if (fnameinput.value.match(letters)) {
            setSuccess(fnameinput)
        } else {
            setError(fnameinput, "Please Enter Alphabet character only");
        }
      setSuccess(fnameinput)

    }
}


function checklname() {
    var letters = /^[A-Za-z]+$/;
    let lnameinput = document.getElementById("lname");
    let lnamevalue = lnameinput.value.trim();
    if (lnamevalue === "") {
        setError(lnameinput, "Please Enter Your Last Name");

    }else {
        if (lnameinput.value.match(letters)) {
            setSuccess(lnameinput)
        } else {
            setError(lnameinput, "Please Enter Alphabet character only");
        }
        setSuccess(lnameinput)

    }
}


function checkdate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("date").setAttribute("max", today);
    setError(numinput, "Please Enter your contact Number");

}

function checknum() {
    var isNumber = /^[0-9]+$/;
    let numinput = document.getElementById("num");
    if (numinput.value.trim() === "") {
        setError(numinput, "Please Enter your contact Number");
    } else if (!isNumber.test(numinput.value.trim())) {
        setError(numinput, 'Check Phonenumber enter digits only..!!');
    } else if (numinput.value.trim().length !== 10) {
        setError(numinput, "Must be 10 Digits");
    } else {
        setSuccess(numinput);
    }
}

function checkaddress() {
    let addressinput = document.getElementById("address");
    let addressvalue = addressinput.value.trim();
    if (addressvalue === "") {
        setError(addressinput, "Please Enter Your Address");

    }
    else {
        setSuccess(addressinput)

    }

}

function checkstate() {
    let stateinput = document.getElementById("state");
    let statevalue = stateinput.value.trim();
    if (statevalue === "") {
        setError(stateinput, "Please Enter Your City");
    }
    else {
        setSuccess(stateinput)

    }

}

function checkname() {
    let nameinput = document.getElementById("name");
    let namevalue = nameinput.value.trim();
    if (namevalue === "") {
        setError(nameinput, "Please Enter Username");
    } else if (namevalue.length <= 4) {
        setError(nameinput, "Username must be atleast 5 Characters");

    } else if (namevalue.length >= 20) {
        setError(nameinput, "Username should not exceeds 20 Characters");

    } else {

        setSuccess(nameinput)

    }
}


function checkpwd() {
    let pwdinput = document.getElementById("pwd");
    let pwdvalue = pwd.value.trim();
    if (pwdvalue === "") {
        setError(pwdinput, "Please Provide a Password");
    } else if (pwdvalue.length <= 4) {
        setError(pwdinput, "Password must be atleast 5 Characters");

    } else if (pwdvalue.length >= 10) {
        setError(pwdinput, "Password should not exceeds 10 Characters");

    } else {
        setSuccess(pwdinput)

    }
}

function checkcpwd() {
    let passwordinputvalue = document.getElementById("pwd").value.trim();
    let confirmpassword = document.getElementById("cpwd");
    let confirmpasswordvalue = confirmpassword.value.trim()
    if (confirmpasswordvalue === "") {
        setError(confirmpassword, "Please Provide a Password");
    } else {
        if (confirmpasswordvalue === passwordinputvalue) {
            setSuccess(confirmpassword);

        } else {
            setError(confirmpassword, "Password doesn't Match");
        }
    }

}

function checkmail() {
    let emailinput = document.getElementById("mail");
    let emailvalue = emailinput.value.trim();
    if (emailvalue === "") {
        setError(emailinput, "Please Enter Email");
    } else {
        var mailformat = /^([a-zA-Z0-9-_\.]+)@([a-zA-Z0-9]+)\.([a-zA-Z]{2,10})(\.[a-zA-Z]{2,8})?$/
        if (emailvalue.match(mailformat)) {
            setSuccess(emailinput);
        } else {
            setError(emailinput, "Invalid Email Format");
        }
    }
}

function checkfullname() {
    var letters = /^[A-Za-z]+$/;
    let fnameinput = document.getElementById("fullname");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Please Enter Your Name");
    } else {
        if (fnameinput.value.match(letters)) {
            setSuccess(fnameinput)
        } else {
            setError(fnameinput, "Please Enter Alphabet character only");
        }
        setSuccess(fnameinput)


    }
}

function checkpfa() {

    let fnameinput = document.getElementById("pfa");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Please Enter Post For Apply");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkqfn() {

    let fnameinput = document.getElementById("qfn");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Please Enter Qualification");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkepn() {

    let fnameinput = document.getElementById("epn");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Please Enter Experience");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkemail() {
    let emailinput = document.getElementById("email");
    let emailvalue = emailinput.value.trim();
    if (emailvalue === "") {
        setError(emailinput, "Please Enter Email");
    } else {
        var mailformat = /^([a-zA-Z0-9-_\.]+)@([a-zA-Z0-9]+)\.([a-zA-Z]{2,10})(\.[a-zA-Z]{2,8})?$/
        if (emailvalue.match(mailformat)) {
            setSuccess(emailinput);
        } else {
            setError(emailinput, "Invalid Email Format");
        }
    }
}

function checknop() {

    let fnameinput = document.getElementById("nop");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Vacant Number Of Posts");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkdcp() {

    let fnameinput = document.getElementById("dcp");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Job Description");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkqln() {

    let fnameinput = document.getElementById("qln");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Qualification Details");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkexn() {

    let fnameinput = document.getElementById("exn");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Experience Year");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checksly() {

    let fnameinput = document.getElementById("sly");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter the Salary Details");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkjtp() {

    let fnameinput = document.getElementById("jtp");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Job Type FULL TIME/PART TIME");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkcn() {

    let fnameinput = document.getElementById("cn");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter Company details");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkctry() {

    let fnameinput = document.getElementById("ctry");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter the Job Country");

    }

    else {
        setSuccess(fnameinput)


    }
}

function checkste() {

    let fnameinput = document.getElementById("ste");
    let fnamevalue = fnameinput.value.trim();
    if (fnamevalue === "") {
        setError(fnameinput, "Enter the Job State");

    }

    else {
        setSuccess(fnameinput)


    }
}

function myFunction() {
    var x = document.getElementById("pwd");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function setError(input, message) {
    let submitbutton = document.getElementById("submit")
    const formcontrol = input.parentElement;
    const small = formcontrol.querySelector('small');
    small.className = "smallshown"
    small.innerHTML = message
    submitbutton.disabled = true
}

function setSuccess(input) {
    let submitbutton = document.getElementById("submit")
    const formcontrol = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallhidden"
    small.innerHTML = " ";
    submitbutton.disabled = false
}

function checkvalidation() {
    checkfname();
    checklname()
    checkdate();
    checknum();
    checkemail();
    checkaddress();
    checkstate();
    checkname();
    checkpwd();
    checkcpwd();
    checkfullname();
    checkpfa();
    checkqfn();
    checkepn();
    checkemail();
    checknop();
    checkdcp();
    checkqln();
    checkexn();
    checksly();
    checkjtp();
    checkcn();
    checkctry();
    checkste();
}
