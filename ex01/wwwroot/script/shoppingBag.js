

let count = sessionStorage.getItem("count");
let user = JSON.parse(sessionStorage.getItem("user"))
let prod = JSON.parse(sessionStorage.getItem("shopingBag"))
var cPrice = 0;
async function drawBag() {
    let prod = JSON.parse(sessionStorage.getItem("shopingBag"))

    cPrice = 0;

    for (let i = 0; i < prod.length; i++) {
        cPrice += prod[i].price
    }
    document.getElementById('totalAmount').innerHTML = cPrice + '$';
    document.getElementById('itemCount').innerHTML = count;
    for (let i = 0; i < prod.length; i++) {
        var tmpCatg = document.getElementById("temp-row");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price + "$";
        cln.querySelector(".image").src = "./images/new_born/" + prod[i].img;;

        cln.querySelector(".descriptionColumn").innerText = prod[i].description
        cln.querySelector(".totalColumn").addEventListener('click', () => { deleteItem(prod[i]) });
        document.getElementById("itemList").appendChild(cln);
    }
}
function pluse() {
    sessionStorage.setItem("count", count++);
    document.getElementById('itemCount').innerHTML = count;

}
function minus() {
    sessionStorage.setItem("count", count--);
    document.getElementById('itemCount').innerHTML = count;
}


function deleteItem(prodact) {

    let prod = JSON.parse(sessionStorage.getItem("shopingBag"));
    let updatedList = prod.filter(p => p.productId !== prodact.productId);
    cPrice -= prodact
    count -= 1
     count = sessionStorage.setItem("count",count);

    sessionStorage.setItem("shopingBag", []);
    document.getElementById("itemList").innerHTML = "";
    sessionStorage.setItem("shopingBag", JSON.stringify(updatedList));
    drawBag();
}


async function placeOrder() {

    if (user) {
        var order = {
            orderDate: new Date(),
            orderSum: cPrice,
            userId: user.userId,
            orderItems: prod
        }
        try {
            const responsePost = await fetch('api/order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });
            console.log(responsePost)
            if (!responsePost.ok) {
                alert(`the order didnt create`)
            }
            else {
                const newOrder = await responsePost.json();
                alert(` order number ${newOrder.orderId} created at  ${newOrder.orderDate}   was recived ?`)
            }
        }
        catch (error) {
            console.log(error)
        }

    }
    else {
        alert("to login")
        window.location.href="./home.html"
    }




















}







