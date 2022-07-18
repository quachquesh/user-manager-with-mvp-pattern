# User Manager mô hình MVP

## **1. Kích hoạt Bunifu framework**

#### - Tải license link phía dưới và làm theo **hướng dẫn** để kích hoạt.

**_[Download license](https://mega.nz/file/aHxykBoI#P5bcGqUn6WyNmhnJM5Yf6HOIT424PyIagoWXhwu-jjk)_**

## **2. Cài đặt JSON server**

#### - Cài đặt JSON Servert global

```sh
npm install -g json-server
```

#### - Tạo file db.json bất kỳ đâu với nội dung:

```json
{
  "users": []
}
```

#### - Run JSON server: Mở cmd tại thư mục vừa tạo db.json

```sh
json-server --watch db.json
```
