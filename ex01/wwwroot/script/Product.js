


async function filterProducts() {
  
    if (sessionStorage.getItem("shopingBag")) {
        cart = JSON.parse(sessionStorage.getItem("shopingBag"))
    }
    try {
        let checkedArr = [];
        var allCategoriesOptions = document.querySelectorAll(".opt");
        for (i = 0; i < allCategoriesOptions.length; i++) {
            if (allCategoriesOptions[i].checked) {
                checkedArr.push(allCategoriesOptions[i].value);
            }
        }
        var range = document.getElementById("myRange");
        var minPrice = 0;
        var maxPrice = (parseInt(range.value));

        minValue.innerHTML = "Min : " + 0 + '$';
        maxValue.innerHTML = "Max : " + (parseInt(range.value)) + '$';
        const name = document.getElementById("nameSearch").value;
        var url = 'api/Product';
        if (name || minPrice || maxPrice || checkedArr) url += `?`;
        if (name) url += `&desc=${name}`;

        if (minPrice) url += `&minPrice=${minPrice}`;

        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (checkedArr) {
            for (let i = 0; i < checkedArr.length; i++) {
                url += `&categoryIds=${checkedArr[i]}`;
            }
        }


        var res = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (!res.ok) {
            window.alert("NotFound")
        }

        const products = await res.json()

        document.getElementById("PoductList").replaceChildren(clonProducts);




        for (let i = 0; i < products.length; i++) {
            var tmp = document.getElementById("temp-card");
            var clonProducts = tmp.content.cloneNode(true);

            clonProducts.querySelector("img").src = "./images/new_born/" + products[i].img;
            clonProducts.querySelector(".description").innerText = products[i].description;
            clonProducts.querySelector(".price").innerText = products[i].price + '$';
            clonProducts.querySelector("h1").innerText = products[i].name;

            clonProducts.querySelector("button").addEventListener('click', () => { addtoshop(products[i]) });

            document.getElementById("PoductList").appendChild(clonProducts);



        }
        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}




async function getAllCategory() {
    count = sessionStorage.getItem("count");


    document.getElementById("ItemsCountText").innerHTML = count;
    
    try {
    const res = await fetch(`api/Category`);
    const catetegoryData = await res.json();
        return catetegoryData;
    }
    catch (ex) {
        console.log(ex);
    }
}
async function drawCategory() {
    const categories = await getAllCategory();

    for (let i = 0; i < categories.length; i++) {
        var tmp = document.getElementById("temp-category");
        var clonCategories = tmp.content.cloneNode(true);
        clonCategories.querySelector("span.OptionName").innerText = categories[i].name;

        clonCategories.querySelector(".opt").value = categories[i].id;
        document.getElementById("categoryList").appendChild(clonCategories);


    }
}
function edit() { 
    window.location.href = "./update.html"
}
var cart = [];
var count=0;


function addtoshop(product) {

    document.getElementById('overlay').style.display = 'flex';
    document.getElementById('continue-buying').addEventListener('click', function () {
        document.getElementById('overlay').style.display = 'none';
    });
    document.getElementById('shopingBag').addEventListener('click', function () {
        window.location.href = "./ShoppingBag.html"

    });
        cart.push(product);

    count++;
    sessionStorage.setItem("count", JSON.stringify(count));
        document.getElementById("ItemsCountText").innerText = count;
        sessionStorage.setItem('shopingBag', JSON.stringify(cart));
        console.log(cart);
    
}

