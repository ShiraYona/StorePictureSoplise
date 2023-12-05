
const user1 = sessionStorage.getItem("user")
const jsonUser = JSON.parse(user1)

const loadPage = () => {
    if (!user1) {
        window.location.href = "./home.html"
    }
    const userNameUpdate = document.getElementById("userNameUpdate")
    userNameUpdate.value = jsonUser.email
    const passwordUpdate = document.getElementById("passwordUpdate")
    passwordUpdate.value = jsonUser.password
    passwordUpdate.value = jsonUser.password

    const firstNameUpdate = document.getElementById("firstNameUpdate")
    firstNameUpdate.value = jsonUser.firstName


    const lastNameUpdate = document.getElementById("lastNameUpdate")
    lastNameUpdate.value = jsonUser.lastName
}



const update = async () => {
    try {
    var userId = jsonUser.userId
    alert("user  :"+userId+ "  update ssuccses")
        const email = document.getElementById("userNameUpdate").value
        const password = document.getElementById("passwordUpdate").value
        const firstName = document.getElementById("firstNameUpdate").value
        const lastName = document.getElementById("lastNameUpdate").value
    const User = { userId, email, password, firstName, lastName }
    console.log(User)
    var url = 'api/user' + "/" + userId
    const res = await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(User)

    });

    const dataPost = await res.json();
    }

    catch (er) {
        console.log(er)
    }

}