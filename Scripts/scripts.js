/* scripts css Login */

const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('containerLogin');

if (signUpButton && container) {
    signUpButton.addEventListener('click', () => {
        container.classList.add("right-panel-active");
    });
}
if (signInButton && container) {
    signInButton.addEventListener('click', () => {
        container.classList.remove("right-panel-active");
    });
}


const loginBtn = document.getElementById('login');
const signupBtn = document.getElementById('signup');

if (loginBtn) {
    loginBtn.addEventListener('click', (e) => {
        let parent = e.target.parentNode.parentNode;
        Array.from(e.target.parentNode.parentNode.classList).find((element) => {
            if (element !== "slide-up") {
                parent.classList.add('slide-up')
            } else {
                signupBtn.parentNode.classList.add('slide-up')
                parent.classList.remove('slide-up')
            }
        });
    });
}

if (signupBtn) {
    signupBtn.addEventListener('click', (e) => {
        let parent = e.target.parentNode;
        Array.from(e.target.parentNode.classList).find((element) => {
            if (element !== "slide-up") {
                parent.classList.add('slide-up')
            } else {
                loginBtn.parentNode.parentNode.classList.add('slide-up')
                parent.classList.remove('slide-up')
            }
        });
    });
}



/* Scripts btn IntroPersonaggi */

function redirectToPage(pageUrl) {
    window.location.href = pageUrl;
}

/* Scripts per collegamenti */

if (window.location.hash === "#inizio") {
    const section = document.getElementById('inizio');
    section.scrollIntoView();
}

function redirectToRazzePage() {
    window.location.href = "Razze#razza";
}
function redirectToCaratteristichePage() {
    window.location.href = "Caratteristiche#caratteristica";
}
function redirectToClassiPage() {
    window.location.href = "Classi#classe";
}
if (window.location.hash === "#razza") {
    const section = document.getElementById('razza');
    section.scrollIntoView();
}
if (window.location.hash === "#caratteristica") {
    const section = document.getElementById('caratteristica');
    section.scrollIntoView();
}
if (window.location.hash === "#classe") {
    const section = document.getElementById('classe');
    section.scrollIntoView();
}

function redirectToFor() {
    window.location.href = "Caratteristiche#for";
}
if (window.location.hash === "for") {
    const section = document.getElementById('for');
    section.scrollIntoView();
}

function redirectToDes() {
    window.location.href = "Caratteristiche#des";
}
if (window.location.hash === "des") {
    const section = document.getElementById('des');
    section.scrollIntoView();
}

function redirectToCos() {
    window.location.href = "Caratteristiche#cos";
}
if (window.location.hash === "cos") {
    const section = document.getElementById('cos');
    section.scrollIntoView();
}

function redirectToInt() {
    window.location.href = "Caratteristiche#int";
}
if (window.location.hash === "int") {
    const section = document.getElementById('int');
    section.scrollIntoView();
}

function redirectToSag() {
    window.location.href = "Caratteristiche#sag";
}
if (window.location.hash === "sag") {
    const section = document.getElementById('sag');
    section.scrollIntoView();
}

function redirectToCar() {
    window.location.href = "Caratteristiche#car";
}
if (window.location.hash === "car") {
    const section = document.getElementById('car');
    section.scrollIntoView();
}

function redirectToElfi() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#elfi";
}
if (window.location.hash === "elfi") {
    const section = document.getElementById('elfi');
    section.scrollIntoView();
}

function redirectToGnomi() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#gnomi";
}
if (window.location.hash === "gnomi") {
    const section = document.getElementById('gnomi');
    section.scrollIntoView();
}

function redirectToHalfling() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#halfling";
}
if (window.location.hash === "halfling") {
    const section = document.getElementById('halfling');
    section.scrollIntoView();
}

function redirectToMezzelfi() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#mezzelfi";
}
if (window.location.hash === "Mezzelfi") {
    const section = document.getElementById('Mezzelfi');
    section.scrollIntoView();
}

function redirectToMezzorchi() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#mezzorchi";
}
if (window.location.hash === "mezzorchi") {
    const section = document.getElementById('mezzorchi');
    section.scrollIntoView();
}

function redirectToNani() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#nani";
}
if (window.location.hash === "nani") {
    const section = document.getElementById('nani');
    section.scrollIntoView();
}

function redirectToUmani() {
    var baseUrl = window.location.origin;
    window.location.href = baseUrl + "/Guida/Razze#umani";
}
if (window.location.hash === "umani") {
    const section = document.getElementById('umani');
    section.scrollIntoView();
}