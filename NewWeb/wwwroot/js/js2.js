const ul = document.querySelector("ul div"),
    inputbox = document.querySelector("input");

const Button = document.querySelector("button");
let tags = [];
var virtualTypesObj = [
    { value: "752N", type: "J4-CVT", name: "jacj4" },
    { value: "742S", type: "S3-CVT", name: "jacs3" },
    { value: "762S", type: "S5 1.5-DCT", name: "jacs5" },
    { value: "811P", type: "T8-MT", name: "kmct8" },
    { value: "822S", type: "K7-DCT", name: "kmck7" },
    { value: "832N", type: "J7-DCT", name: "kmcj7" },
    { value: "842N", type: "A5-AT", name: "kmca5" },
    { value: "852S", type: "X5-AT", name: "kmcx5" },
];
var BodyShopObj = ["metalfinish", "Metalfinish", "METALFINISH", "MetalFinish", "بدنه", "سالنبدنه"];
var PaintShopObj = ["topcoat", "TopCoat", "Topcoat", "رنگ", "رنگشده", "سالنرنگ"];

// var virtualTypesNames = virtualTypesObj.map(elements => {
//     return elements.name
// });

var virtualTypesMap = new Map();
virtualTypesMap.set("752N", "jacj4");
virtualTypesMap.set("742S", "jacs3");
virtualTypesMap.set("762S", "jacs5");
virtualTypesMap.set("811P", "kmct8");
virtualTypesMap.set("822S", "kmck7");
virtualTypesMap.set("832N", "kmcj7");
virtualTypesMap.set("842N", "kmca5");
virtualTypesMap.set("852S", "kmcx5");

var vitualtypeRes;

function createTag() {
    ul.querySelectorAll("li").forEach(li => li.remove(),);
    tags.forEach(tag => {
        let Litag = `<li class="defualt">${tag} <imgsrc="~/images/search.svg" onclick="remove(this, '${tag}')" alt=""></li>`;
        ul.insertAdjacentHTML("afterbegin", Litag);
    });
}

function remove(element, tag) {
    let index = tags.indexOf(tag);
    tags = [...tags.slice(0, index), ...tags.slice(index + 1)];
    element.parentElement.remove();
    // document.getElementsByName("virtualTypeBoxValue")[0].value = "";
    // document.getElementById("virtualTypeBox").checked = false;
    console.log(tags)
}
function addList(e) {
    if (e.key == "Enter") {
        let tag = e.target.value.replace(/\s/g, '');
        if (tag.length > 1 && !tags.includes(tag)) {
            tag.split('-').forEach(tag => {
                tags.push(tag);
                console.log(tags);
                createTag();
            });
            inputbox.addEventListener('Enter', inputbox.value = "");
        }
    }
}
inputbox.addEventListener('keyup', addList);

// recongnizing difrenet values 
const Fields = [];

function findingVIrtualtype() {
    findingMetalFinish();
    findingTopCoat();
    // var res = virtualTypesNames.find(v => v == tags);
    var CheckVirtualtype = tags.filter(el => virtualTypesObj.map(elements => {
        return elements.name
    }).includes(el));
    var indexOf = virtualTypesObj.findIndex(object => {
        return object.name == CheckVirtualtype;
    });
    vitualtypeRes = virtualTypesObj[indexOf].value;

    console.log(CheckVirtualtype ? CheckVirtualtype : "wasn't found");
    console.log(vitualtypeRes);

    if (vitualtypeRes.length > 0) {
        document.getElementsByName("virtualTypeBoxValue")[0].value = "";
        document.getElementsByName("virtualTypeBoxValue")[0].value = vitualtypeRes;
        document.getElementById("virtualTypeBox").checked = true;
    };


}

function findingMetalFinish() {
    var CheckMetalFinish = tags.filter(function (e) {
        return BodyShopObj.includes(e);
    });
    if (CheckMetalFinish.length > 0) {
        // document.getElementsByName("virtualTypeBoxValue")[0].value = "";
        document.getElementsByName("metalFinishDate")[0].value = "1402/03/28";
        document.getElementById("metalFinishBox").checked = true;

    }
}


function findingTopCoat() {
    var CheckTopCoat = tags.filter(function (e) {
        return PaintShopObj.includes(e);
    });
    if (CheckTopCoat.length > 0) {
        // document.getElementsByName("virtualTypeBoxValue")[0].value = "";
        document.getElementsByName("TopcoatDate")[0].value = "1402/03/28";
        document.getElementById("TopcoatBox").checked = true;

    }
}


// function to pass the data to server
function submitForm() {
    var formData = {
        virtualTypeBox: document.getElementById("virtualTypeBox").checked,
        metalFinishBox: document.getElementById("metalFinishBox").checked,
        TopcoatBox: document.getElementById("TopcoatBox").checked,

        virtualTypeBoxValue: document.getElementsByName("virtualTypeBoxValue")[0].value,
        metalFinishDate: document.getElementsByName("metalFinishDate")[0].value,
        TopcoatDate: document.getElementsByName("TopcoatDate")[0].value,
    };




    // ایجاد یک فرم مخفی برای ارسال داده‌ها به سمت سرور
    var hiddenForm = document.createElement("form");
    hiddenForm.method = "post";
    hiddenForm.action = "/NewHome/NewSearchPost"; // مسیر مورد نظر برای درخواست POST

    // ایجاد یک المان input برای هر فیلد داده
    for (var key in formData) {
        var input = document.createElement("input");
        input.type = "hidden"; // نوع المان input
        input.name = key; // نام فیلد داده
        input.value = formData[key]; // مقدار فیلد داده

        // اضافه کردن المان input به فرم مخفی
        hiddenForm.appendChild(input);
    }

    // اضافه کردن فرم مخفی به صفحه
    document.body.appendChild(hiddenForm);

    // ارسال فرم مخفی
    hiddenForm.submit();
}
