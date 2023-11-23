function displayTransactionHistory(transactions) {
    var table = document.getElementById("transaction-table");

    // Xóa bảng nếu có dữ liệu cũ
    while (table.rows.length > 1) {
        table.deleteRow(1);
    }

    // Thêm dữ liệu mới vào bảng
    for (var i = 0; i < transactions.length; i++) {
        var transaction = transactions[i];
        var row = table.insertRow(-1);
        row.insertCell(0).innerHTML = i + 1;
        row.insertCell(1).innerHTML = transaction.order_id;
        row.insertCell(2).innerHTML = transaction.buyer_name;
        row.insertCell(3).innerHTML = transaction.address;
        row.insertCell(4).innerHTML = transaction.date;
        row.insertCell(5).innerHTML = transaction.status;
    }
}
function init() {
    // Lấy lịch sử giao dịch từ cơ sở dữ liệu
    sqlConnection.query("SELECT * FROM transactions", function (result) {
        // Hiển thị lịch sử giao dịch lên trang
        displayTransactionHistory(result);
    });
}
document.addEventListener("DOMContentLoaded", init);