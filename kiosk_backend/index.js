const express = require("express");
const port = 3000;
const app = express();
var price;
app.use(express.json());

app.post("/", (req, res) => {
    price = req.body.price;
    console.log("등록 성공!" + price);
    res.send(price + "원 결제가 성공적으로 완료되었습니다. ");
});
app.get("/message", (req, res) => {
    res.send(price + "원 결제가 성공적으로 완료되었습니다. ");
});

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`);
});