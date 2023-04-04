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
## <img src="https://icon-library.com/images/database-icon-png/database-icon-png-13.jpg" width="20" /> Database

_Create a database in SQLServer that contains the table created from the following script:_

```sql
CREATE DATABASE BikeApiDapper
GO

Use BikeApiDapper
GO

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(80) NOT NULL
);
GO

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(80) NOT NULL
);
GO

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(80) NOT NULL,
	ModelYear SMALLINT NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	BrandId INT NOT NULL,
	CategoryId INT NOT NULL,
	
	CONSTRAINT [FK_Products_Category] FOREIGN KEY (CategoryId) 
        REFERENCES Categories(Id),

	CONSTRAINT [FK_Products_Brand]FOREIGN KEY (BrandId) 
        REFERENCES Brands(Id)
);
GO
```

### Relationships
```yaml
+--------------+        +-------------+        +--------------+
|   Categories | 1    * |    Products | *    1 |     Brands   |
+--------------+        +-------------+        +--------------+
|     Id       |<-------|      Id     |------->|      Id      |
|     Name     |        |     Name    |        |     Name     |
|              |        |  ModelYear  |        |              |
|              |        |    Price    |        |              |
+--------------+        |  BrandId    |        +--------------+
                        | CategoryId  |
                        +-------------+
```

#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/BikeApi.git`

`$ cd BikeApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7250/swagger](https://localhost:7250/swagger) or [https://localhost:7250/api/v1/Products](https://localhost:7250/api/v1/Products), [https://localhost:7250/api/v1/Brands](https://localhost:7250/api/v1/Brands) and [https://localhost:7250/api/v1/Categories](https://localhost:7250/api/v1/Categories)**
#

# 📫  Routes for Products

### Return all objects (Bikes)
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
### Return only one object (Bike)

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
### Insert a new object (Bike)

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
### Update an object (Bike)

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
### Delete an object (Bike)
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
#
# 📫  Routes for Categories

### Return all objects (Categories)
```http
  GET https://localhost:7250/api/v1/Categories
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228933233-9e98652a-f666-4f8f-ae7e-bdfedafbb4e4.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933604-425e7c90-6743-4a03-b72e-442e29574394.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228933260-4efd0310-a0ea-4d73-a05e-92f0883270a8.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933891-75b8a903-4cc7-4153-a1b3-79f4e90a3d5e.png" />

#
### Return only one object (Category)

```http
  GET https://localhost:7250/api/v1/Categories/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/228934433-258dc301-d47c-4646-ac69-3abfb38dab8e.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933604-425e7c90-6743-4a03-b72e-442e29574394.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228934462-7b580c53-08d7-4b09-8ca5-ac561a1980d9.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933891-75b8a903-4cc7-4153-a1b3-79f4e90a3d5e.png" />

#
### Return category with products (Bikes)

```http
  GET https://localhost:7250/api/v1/Categories/${id}/multipleresults
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228954289-d55a0fc6-723a-4119-ba2a-ed36b1473616.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228954303-ae799442-df1a-4c5e-a0ed-ca910a7a90ce.png" />
<img src="https://user-images.githubusercontent.com/118696036/228954314-e5bf283d-9aa8-47c5-9bb5-be347fcc6b09.png" />

#
### Return all categories with prodcuts (Bikes)

```http
  GET https://localhost:7250/api/v1/Categories/multiplemapping
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228956622-bc7ab1d3-54de-4e94-9b75-87ef9900b1d3.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228956646-009cb738-69b2-494d-b841-d1ea6b3375d8.png" />

#
### Insert a new object (Category)

```http
  POST https://localhost:7250/api/v1/Categories
```
📨  **body:**
```
{
    "name": "Children Bicycles"
}
```

🧾  **response:**
```
{
    "products": [],
    "id": 9,
    "name": "Children Bicycles"
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228935651-96161236-807b-47d8-b57b-18618183e6c5.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228935703-8b233cdf-549d-46bd-b76e-34fbeb78244f.png" />
<img src="https://user-images.githubusercontent.com/118696036/228935749-9b1d6632-ebfb-4921-a717-d79814c0e8f3.png" />

#
### Update an object (Category)

```http
  PUT https://localhost:7250/api/v1/Categories/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
    "name": "Cyclocross Bicycles"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228937024-c52a3440-3617-4602-9311-af76efb69201.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933604-425e7c90-6743-4a03-b72e-442e29574394.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228936984-f00b1d0c-6e3c-4f0f-8ae6-410bc25c8a55.png" />
<img src="https://user-images.githubusercontent.com/118696036/228937004-95573f1f-a5fa-4135-9738-f277c53d459c.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933891-75b8a903-4cc7-4153-a1b3-79f4e90a3d5e.png" />

#
### Delete an object (Category)
```http
  DELETE https://localhost:7250/api/v1/Categories/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/228937978-949f6b6c-9bc5-4ed2-80e6-b0044ae4e25b.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933604-425e7c90-6743-4a03-b72e-442e29574394.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228939321-fd91248a-8330-41d6-bc82-743f9861b6f9.png" />
<img src="https://user-images.githubusercontent.com/118696036/228933891-75b8a903-4cc7-4153-a1b3-79f4e90a3d5e.png" />


#
#
# 📫  Routes for Brands

### Return all objects (Brands)
```http
  GET https://localhost:7250/api/v1/Brands
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228941961-939c5b97-971c-4255-9af9-5302073d2925.png" />
<img src="https://user-images.githubusercontent.com/118696036/228940873-4425bff8-7dee-45b6-9473-a4c684a88bf9.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228941979-392ca79d-1071-4a0c-adcf-2b111bd267ef.png" />
<img src="https://user-images.githubusercontent.com/118696036/228942175-48b83873-1f7b-414e-9dd5-8d625f019969.png" />

#
### Return only one object (Brand)

```http
  GET https://localhost:7250/api/v1/Brands/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/228942549-4c2dcfe3-58aa-4ca7-bb2c-81b778b77aa1.png" />
<img src="https://user-images.githubusercontent.com/118696036/228940873-4425bff8-7dee-45b6-9473-a4c684a88bf9.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228942577-f8349e31-1b7c-4a70-bd3f-4fefbadc3b02.png" />
<img src="https://user-images.githubusercontent.com/118696036/228942175-48b83873-1f7b-414e-9dd5-8d625f019969.png" />

#
### Return brand with products (Bikes)

```http
  GET https://localhost:7250/api/v1/Brands/${id}/multipleresults
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228958221-6f2711ea-34fc-408c-8b30-c75814210190.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228958238-8a04a53f-66ae-46d1-9ca6-d5f8e8ac55dd.png" />
<img src="https://user-images.githubusercontent.com/118696036/228958243-60605d3e-8d4b-4765-bfbd-78d822887375.png" />

#
### Return all brands with prodcuts (Bikes)

```http
  GET https://localhost:7250/api/v1/Brands/multiplemapping
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228958979-9a2820a4-a91f-4a22-bbc9-91e701265b1c.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228958990-cc374df3-32cd-4e97-9385-463d8e511d38.png" />

#
### Insert a new object (Brand)

```http
  POST https://localhost:7250/api/v1/Brands
```
📨  **body:**
```
{
    "name": "Trek"
}
```

🧾  **response:**
```
{
    "products": [],
    "id": 11,
    "name": "Trek"
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228943484-de47ad09-22ae-42e1-9a2d-9319fef6afe3.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228943509-72175d20-8510-4e5b-92e5-0d12578d3b15.png" />
<img src="https://user-images.githubusercontent.com/118696036/228943524-b7cdb824-0228-4db1-87cf-375a797ecbde.png" />

#
### Update an object (Brand)

```http
  PUT https://localhost:7250/api/v1/Brands/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
    "name": "Sun Bicycles"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/228944129-829e252e-d5f4-453d-ba81-0b6964f57763.png" />
<img src="https://user-images.githubusercontent.com/118696036/228940873-4425bff8-7dee-45b6-9473-a4c684a88bf9.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228944142-0e65ab1d-9ebb-4187-b788-1931525d2b52.png" />
<img src="https://user-images.githubusercontent.com/118696036/228944152-1d6f5b37-fe15-48c9-936c-6c2f7a1a4b31.png" />
<img src="https://user-images.githubusercontent.com/118696036/228942175-48b83873-1f7b-414e-9dd5-8d625f019969.png" />

#
### Delete an object (Brand)
```http
  DELETE https://localhost:7250/api/v1/Brands/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/228944624-1a2e50f2-6301-4195-9506-440ea7b08d87.png" />
<img src="https://user-images.githubusercontent.com/118696036/228940873-4425bff8-7dee-45b6-9473-a4c684a88bf9.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/228944637-c2642e2a-47f9-45be-af25-1af144693e51.png" />
<img src="https://user-images.githubusercontent.com/118696036/228942175-48b83873-1f7b-414e-9dd5-8d625f019969.png" />

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
