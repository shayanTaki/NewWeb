
/////////////////////////////////////////////////////////////////////////////////////////////


function pauseHover(id) {
    const element1 = document.getElementById(id);
    if (element1) {
        element1.removeAttribute("onmouseover");
        element1.removeAttribute("onmouseout");
    }
}
function resumeHover(ids) {
    ids.forEach(id => {


        if (id == "HomeA") {

            const element2 = document.getElementById(id);
            if (element2) {
                element2.setAttribute("onmouseover", "changeStyleHome()");
                element2.setAttribute("onmouseout", "resetStyleHome()");
                try {
                    resetStyleHome();
                } catch (error) {
                    return;
                }

            } else {
                return;
            }


        }

        else if (id == "AuthHome") {

            const element3 = document.getElementById(id);
            if (element3) {
                element3.setAttribute("onmouseover", "changeStyleAuth1()");
                element3.setAttribute("onmouseout", "resetStyleAuth1()");

                try {
                    resetStyleAuth1();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }
        }

        else if (id == "Auth2") {

            const element4 = document.getElementById(id);
            if (element4) {
                element4.setAttribute("onmouseover", "changeStyleAuth2()");
                element4.setAttribute("onmouseout", "resetStyleAuth2()");

                try {
                    resetStyleAuth2();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }
        }

        else if (id == "Auth3") {

            const element5 = document.getElementById(id);
            if (element5) {
                element5.setAttribute("onmouseover", "changeStyleAuth3()");
                element5.setAttribute("onmouseout", "resetStyleAuth3()");
                try {
                    resetStyleAuth3();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }
        }

        else if (id == "Auth4") {

            const element6 = document.getElementById(id);
            if (element6) {
                element6.setAttribute("onmouseover", "changeStyleAuth4()");
                element6.setAttribute("onmouseout", "resetStyleAuth4()");

                try {
                    resetStyleAuth4();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }
        }

        else if (id == "Auth5") {

            const element7 = document.getElementById(id);
            if (element7) {
                element7.setAttribute("onmouseover", "changeStyleAuth5()");
                element7.setAttribute("onmouseout", "resetStyleAuth5()");

                try {
                    resetStyleAuth5();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }

        }

        else {

            const element8 = document.getElementById(id);
            if (element8) {
                element8.setAttribute("onmouseover", "changeStyleAuth6()");
                element8.setAttribute("onmouseout", "resetStyleAuth6()");

                try {
                    resetStyleAuth6();
                } catch (error) {
                    return;
                }
            } else {
                return;
            }

        }
    });
}



// تابع اعمال تابع resumeHover بر روی آیتم‌های با آیدی‌های داده شده
function IDgir(ids) {

    ids.forEach(id => {
        const element = document.getElementById(id);
        if (element) {
            resumeHover(element);
        }
    });
}



function removeTextFromList(textToRemove) {
    pauseHover(textToRemove);
    const inputList = ["AuthHome", "HomeA", "Auth2", "Auth3", "Auth4", "Auth5", "Auth6"]; // لیست دستی
    const newList = [];

    for (let i = 0; i < inputList.length; i++) {
        if (inputList[i] !== textToRemove) {
            newList.push(inputList[i]);
        }
    }

    resumeHover(newList);
}


// مثال استفاده از تاب

// مثال اجرا




/////////////////////////////////////////////////////////////////////////////////////////////


function changeStyleHome() {
    let element2 = document.querySelector(".flex-row .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleHome() {
    let element2 = document.querySelector(".flex-row .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}




// onDissClickAuth();






// off onclick


// function onClickHomeOff() {

//   let element5 = document.querySelector(".MenuPnl .svg-on-click");
//   element5.classList.remove("svg-on-click");
//   element5.classList.add("svg-on-click-off");

//   let element2 = document.querySelector(".MenuPnl .svg-base-off");
//   element2.classList.remove("svg-base-off");
//   element2.classList.add("svg-base");


//   let element6 = document.querySelector(".MenuPnl .mtn-on-click");
//   element6.classList.remove("mtn-on-click");
//   element6.classList.add("mtn-base");

//   let element4 =  document.querySelector(".MenuPnl");
//   element4.classList.remove("flex-on-click");
//   element4.classList.add("flex-base");

// }



// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

// Auth Function


function changeStyleAuth1() {
    let element2 = document.querySelector(".flex-row-Auth1 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth1 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth1 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth1");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth1() {
    let element2 = document.querySelector(".flex-row-Auth1 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth1 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth1 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth1");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}











// onclick Auth 1






// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Auth2%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



function changeStyleAuth2() {
    let element2 = document.querySelector(".flex-row-Auth2 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth2 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth2 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth2");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth2() {
    let element2 = document.querySelector(".flex-row-Auth2 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth2 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth2 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth2");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Auth3%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



function changeStyleAuth3() {
    let element2 = document.querySelector(".flex-row-Auth3 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth3 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth3 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth3");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth3() {
    let element2 = document.querySelector(".flex-row-Auth3 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth3 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth3 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth3");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Auth4%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



function changeStyleAuth4() {
    let element2 = document.querySelector(".flex-row-Auth4 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth4 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth4 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth4");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth4() {
    let element2 = document.querySelector(".flex-row-Auth4 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth4 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth4 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth4");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Auth5%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



function changeStyleAuth5() {
    let element2 = document.querySelector(".flex-row-Auth5 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth5 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth5 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth5");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth5() {
    let element2 = document.querySelector(".flex-row-Auth5 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth5 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth5 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth5");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Auth6%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


function changeStyleAuth6() {
    let element2 = document.querySelector(".flex-row-Auth6 .svg-base");
    element2.classList.remove("svg-base");
    element2.classList.add("svg-base-off");


    let element = document.querySelector(".flex-row-Auth6 .svg-on-hover-off");
    element.classList.remove("svg-on-hover-off");
    element.classList.add("svg-on-hover");


    let element3 = document.querySelector(".flex-row-Auth6 .mtn-base");
    element3.classList.remove("mtn-base");
    element3.classList.add("mtn-on-hover");


    let element4 = document.querySelector(".flex-row-Auth6");
    element4.classList.remove("flex-base");
    element4.classList.add("flex-on-hover");
}
function resetStyleAuth6() {
    let element2 = document.querySelector(".flex-row-Auth6 .svg-base-off");
    element2.classList.remove("svg-base-off");
    element2.classList.add("svg-base");

    let element = document.querySelector(".flex-row-Auth6 .svg-on-hover");
    element.classList.remove("svg-on-hover");
    element.classList.add("svg-on-hover-off");

    let element3 = document.querySelector(".flex-row-Auth6 .mtn-on-hover");
    element3.classList.remove("mtn-on-hover");
    element3.classList.add("mtn-base");

    let element4 = document.querySelector(".flex-row-Auth6");
    element4.classList.remove("flex-on-hover");
    element4.classList.add("flex-base");
}


// --------------------------------------------------------------- side bar ------------------------------------------------------------
// function resetStyle() {
//   let element = document.querySelector(".svg-Auth-on");
//   element.classList.remove("svg-Auth-on", "svg-base");
//   element.classList.add("svg-Auth-off","svg-base-off");
// }

//Samnejad's Section
function openNav() {
    document.getElementById("mySidebar").style.width = "300px";
    document.getElementById("main").style.marginLeft = "300px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}








// --------------------------------------------------- main section ----------------------------------------------------------------------



// const DataValues = document.querySelectorAll("#Data-Value");
// DataValues.forEach( Data => {

// });


// Get the element by its id, class, tag name or any valid CSS selector
var DataValues = document.querySelector(".Data-Value");

// Set the color property of the element to any valid CSS color value
DataValues.style.color = "blue";

// debugger;
// var DataValue = document.getElementById("Data-Value");
// console.log(DataValue.innerText);
// console.log(DataValue.innerHTML());
// alert(DataValue)
