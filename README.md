# BikeApi

<div align="center">

<img src="https://user-images.githubusercontent.com/118696036/228846843-2bdf0502-1ecf-4a1f-8b28-cbbbf123a77f.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/228847253-d9a4a9ec-8eb6-44db-bc38-04ff01d2f11a.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/228848854-45e88dc2-c652-4763-83a5-41ee3bb80e0d.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/228848879-cbf73198-22fc-48a6-9007-bdf870849ba6.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/228848926-557d8dd5-0371-41d3-8fc4-3e9eafbc40f6.png" width="1500px" />

</div>

## 🌐 Status
<p>Finished project ✅</p>

#
## 🧰 Prerequisites

- .NET 6.0 or +

- Connection string to SQLServer in BikeApi/appsettings.json named as Default
#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/BikeApi.git`

`$ cd BikeApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7250/swagger](https://localhost:7250/swagger) or [https://localhost:7250/api/v1/Products](https://localhost:7250/api/v1/Products)**
#

## 📫  Routes for Products

### Return all bikes
```http
  GET https://localhost:7250/api/v1/Products
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228855022-4432ee67-8221-4d09-843b-5783e453b926.png" />
<img src="https://user-images.githubusercontent.com/118696036/228879167-3871386c-1754-40bb-8e83-275ffe68dc4f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228856219-1e0604d4-1556-44f4-8675-080a6434e336.png" />
<img src="https://user-images.githubusercontent.com/118696036/228856261-fb80c482-ed83-4b89-ab7e-319443e0d806.png" />
<img src="https://user-images.githubusercontent.com/118696036/228880252-9fe960a3-4f83-452c-9110-9ae012bae320.png" />

#
### Return only one object

```http
  GET https://localhost:7250/api/v1/Products/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228861170-bd3a7d90-7a3b-4160-abb1-3f902b686a84.png" />
<img src="https://user-images.githubusercontent.com/118696036/228879167-3871386c-1754-40bb-8e83-275ffe68dc4f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228861196-61851674-f377-4abd-8645-1e43da0daef7.png" />
<img src="https://user-images.githubusercontent.com/118696036/228880252-9fe960a3-4f83-452c-9110-9ae012bae320.png" />

#
### Insert a new object

```http
  POST https://localhost:7250/api/v1/Products
```
📨  **body:**
```
{
  "name": "Trek 820",
  "modelYear": 2016,
  "price": 379.99,
  "brandId": 9,
  "categoryId": 6
}
```

🧾  **response:**
```
{
   "modelYear": 2016,
    "price": 379.99,
    "brandId": 9,
    "categoryId": 6,
    "id": 12,
    "name": "Trek 820"
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228864179-5f5d0318-7bd6-426f-ac4c-7dfe94396ca4.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228864213-269d9719-59bc-415e-89dd-631b284817b0.png" />
<img src="https://user-images.githubusercontent.com/118696036/228864238-dd17cedf-d32e-435c-be46-793b65813d9a.png" />



#
### Update an object

```http
  PUT https://localhost:7250/api/v1/Products/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
  "name": "Trek 820",
  "price": 399.50
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228870883-edb09b10-ced6-4644-98da-0ccad859e251.png" />
<img src="https://user-images.githubusercontent.com/118696036/228879167-3871386c-1754-40bb-8e83-275ffe68dc4f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228870910-8571d4ff-b4f2-40b7-a582-c5ac65ad401f.png" />
<img src="https://user-images.githubusercontent.com/118696036/228870929-5fa37378-fb85-4085-a05d-5989305ccee4.png" />
<img src="https://user-images.githubusercontent.com/118696036/228880252-9fe960a3-4f83-452c-9110-9ae012bae320.png" />

#
#### Delete an object
```http
  DELETE https://localhost:7250/api/v1/Products/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228873019-e171dfd7-a505-4b7e-86ea-ce711286f0f4.png" />
<img src="https://user-images.githubusercontent.com/118696036/228879167-3871386c-1754-40bb-8e83-275ffe68dc4f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228873049-1e15c675-69bd-44af-9285-150a03c68cfd.png" />
<img src="https://user-images.githubusercontent.com/118696036/228880252-9fe960a3-4f83-452c-9110-9ae012bae320.png" />

#
## 🔨 Tools used

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=80/>
</div>

# 🖥️ Technologies and practices used
- [x] C# 10
- [x] .NET CORE 6
- [x] SQL SERVER
- [x] Dapper
- [x] Swagger
- [x] DTOs
- [x] Repository Pattern
- [x] Dependency injection
- [x] POO

# 📖 Features
Registration, Listing, Update and Removal

