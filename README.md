# User Manager mô hình MVP

##### - Cài đặt JSON Servert global

```sh
npm install -g json-server
```

##### - Tạo file db.json bất kỳ đâu với nội dung:

```json
{
  "users": []
}
```

##### - Run JSON server: Mở cmd tại thư mục vừa tạo db.json

```sh
json-server --watch db.json
```
