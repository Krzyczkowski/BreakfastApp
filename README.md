### Application based on Industry Level REST API guide from YouTube: https://www.youtube.com/watch?v=PmDJIooZjBE

# Breakfast API
- [User Authentication](#user-api)
  - [Register](#register)
     - [Register Request](#register-request)
     - [Register Response](#register-response)
  - [Login](#login)
     - [Login Request](#login-request)
     - [Login Response](#login-response)
- [Breakfast API](#breakfast-api)
  - [Create Breakfast](#create-breakfast)
    - [Create Breakfast Request](#create-breakfast-request)
    - [Create Breakfast Response](#create-breakfast-response)
  - [Get Breakfast](#get-breakfast)
    - [Get Breakfast Request](#get-breakfast-request)
    - [Get Breakfast Response](#get-breakfast-response)
  - [Update Breakfast](#update-breakfast)
    - [Update Breakfast Request](#update-breakfast-request)
    - [Update Breakfast Response](#update-breakfast-response)
  - [Delete Breakfast](#delete-breakfast)
    - [Delete Breakfast Request](#delete-breakfast-request)
    - [Delete Breakfast Response](#delete-breakfast-response)

## User Authentication

### Register

#### Register Request
```js
POST /auth/register
Content-Type: application/json
```
```json
{
    "firstName": "Wiktor",
    "lastName": "Krzyczkowski",
    "email": "test@test.pl",
    "password": "haslo123"
}
```
#### Register Response
```js
201 Created
```
```json
{
  "id": "fd0ee80e-2031-4505-a6ff-71a0207f9040",
  "firstName": "Wiktor",
  "lastName": "Krzyczkowski",
  "email": "test@test.pl",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmZDBlZTgwZS0yMDMxLTQ1MDUtYTZmZi03MWEwMjA3ZjkwNDAiLCJqdGkiOiIwNzE5NDI4MC01MjdjLTRjNTItOTBhYy0zNjNiOWFjZDE5YWMiLCJnaXZlbl9uYW1lIjoiV2lrdG9yIiwiZmFtaWx5X25hbWUiOiJLcnp5Y3prb3dza2kiLCJhdWQiOiJCdWJiZXJCcmVha2Zhc3QiLCJleHAiOjE3MzE4NzM2NzAsImlzcyI6IkJ1YmJlckJyZWFrZmFzdCJ9.-ccl2nU1TO_-NUGd1IQhmqLmKedRh8ybv9ZH5GF8oG0"
}
```

---

### Login

#### Login Request
```js
POST /auth/login
Content-Type: application/json
```
```json
{
    "email": "wiktor@abc.pl",
    "password": "haslo123"
}
```
#### Login Response
```js
200 OK
```
```json
{
  "id": "e14585c9-85ff-4f30-85c0-8d19ced5c18e",
  "firstName": "Wiktor",
  "lastName": "Krzyczkowski",
  "email": "test@test.pl",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlMTQ1ODVjOS04NWZmLTRmMzAtODVjMC04ZDE5Y2VkNWMxOGUiLCJqdGkiOiJmZGRlMTBjNS00Y2NiLTQ1YzAtOWQ0Mi04NWRhYjg1M2FjZTYiLCJnaXZlbl9uYW1lIjoiV2lrdG9yIiwiZmFtaWx5X25hbWUiOiJLcnp5Y3prb3dza2kiLCJhdWQiOiJCdWJiZXJCcmVha2Zhc3QiLCJleHAiOjE3MzE4NzM4NDgsImlzcyI6IkJ1YmJlckJyZWFrZmFzdCJ9.H_Emb5mAMgG_eOy9-67N4ffX_GF5NklUEOesaEGP0v8"
}
```
---

## Authorization

For endpoints requiring authorization, include the following HTTP header in your requests:
Authorization: Bearer <your-token>

Replace <your-token> with the token received from the Login response.

---

## Breakfast Api

## Create Breakfast

### Create Breakfast Request

```js
POST /breakfasts
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Create Breakfast Response

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Breakfast

### Get Breakfast Request

```js
GET /breakfasts/{{id}}
```

### Get Breakfast Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```

