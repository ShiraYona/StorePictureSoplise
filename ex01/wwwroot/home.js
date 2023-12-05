const register = async () => {
    if (!validateUsername() || !validateEmail() ) {
        return;

    }
    const email = document.getElementById("userNameRegister").value
    const password = document.getElementById("passwordRegister").value

    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
    const user = {Email: email ,password,Firstname: firstName,Lastname: lastName }
    try {
        

        const res = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        alert("user create sucsesfully")
       
    }
    catch (er) {
        console.log(er.message)
    } 
}
var users;
const login = async () => {

    try {
        const Email = document.getElementById("userNameLogin").value;
        const Password = document.getElementById("passwordLogin").value
        var userLogin = {
            Email, Password
        }
        const res = await fetch('api/User/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userLogin)

        });




        if (!res.ok) {
            throw new Error("eror!!!")
        }
        else {
            console.log("hellow");
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))
            window.location.href = "./products.html"
         

        }
    }


    catch (er) {
        console.log(er.message)
    }

}


const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    const meter = document.getElementById('password-strength-meter');
    const text = document.getElementById('password-strength-text');
    const Code = document.getElementById("passwordRegister").value;
    try {
        const res = await fetch('api/User/check', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(Code)
        })
        if (!res.ok)
            throw new Error("error in adding your details to our site")
        const data = await res.json();
        if (data <= 2) alert("your password is weak!! try again")
        meter.value = data;
    }
    catch (e) {
        console.log(e)
    }
   

}
function validateUsername() {

    var usernameInput = document.getElementById("firstName");

    var username = usernameInput.value;
    var usernameLabel = document.getElementById("usernameLabel");


    if (username.length >= 10) {
        usernameInput.classList.add("invalid-input");
        usernameLabel.textContent = "user name is so long";
        return false;
    } else {
        usernameLabel.textContent = "";
        return true;
    }
}




function validateEmail() {
    var emailInput = document.getElementById("userNameRegister");
    var emailLabel = document.getElementById("emailLabel");
    var email = emailInput.value;

    var emailRegex = /^[^\s@]+@[^\s@]+\./;

    if (!emailRegex.test(email)) {
        emailInput.classList.add("invalid-input");
        emailLabel.textContent = "email adress is not valid";

        return false;
    } else {
        emailLabel.textContent = "";
        emailInput.classList.remove("invalid-input");
        return true;
    }
}