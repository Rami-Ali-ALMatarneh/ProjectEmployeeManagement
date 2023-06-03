let droplist = document.querySelector(".droplist");
let flag = false;
droplist.onclick = function () {
    let s1 = document.querySelector(".s1");
    let s2 = document.querySelector(".s2");
    let s3 = document.querySelector(".s3");

    if (!flag) {
        s1.classList.add("goDown");
        s2.classList.add("hiddenS2");
        s3.classList.add("goUp");
        ///////////////////////////////
        s1.classList.remove("backUp");
        s2.classList.remove("blocks");
        s3.classList.remove("backDown");
        flag = true;
    } else {
        s1.classList.remove("goDown");
        s2.classList.remove("hiddenS2");
        s3.classList.remove("goUp");
        ///////////////////////
        s1.classList.add("backUp");
        s2.classList.add("blocks");
        s3.classList.add("backDown");
        flag = false;
    }
};