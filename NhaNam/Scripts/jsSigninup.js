const { data } = require("jquery");

function signup(e) {
    event.preventDefault();
    var email = document.getElementById(ElementId: "email").value;
    var password = document.getElementById(ElementId: "password").value;
    var confirmPassword = document.getElementById(ElementId: "confirm-password").value;
    var displayName = document.getElementById(ElementId: "display-name").value;
    var birthday = document.getElementById(ElementId: "birthday").value;
    var user = {
        email: email,
        password: password,
    }
    var json = JSON.stringify(value: user);
    localStorage.setItem(key: email, value: json);

    if (password !== confirmPassword) {
        alert(message: "Mật khẩu không khớp. Vui lòng nhập lại!");
        return;
    }

    alert("Đăng ký thành công!");
}
function signin(e) {
    event.preventDefault();
    var email = document.getElementById(ElementId: "email").value;
    var password = document.getElementById(ElementId: "password").value;
    var user = localStorage.getItem(key: email);
    if (user == null)
    {
        alert(message: "Hãy nhập Email và Mật khẩu")
    }
    else if (email == data.email && password == data.password) {
        alert(message: "Đăng nhập thành công")
        window.location.href=
    }
    else
        alert(message:"Đăng nhập thất bại")
}