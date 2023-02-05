# Restaurant API

Table of Contents
- [Restaurant Api](#restaurant-api)
    - [Authentification](#authentification)
        - [Register](#create-breakfast-request)
            - [Register Request](#create-breakfast-response)
            - [Register Response](#create-breakfast-response)
        - [Login](#get-breakfast)
            - [Login Request](#get-breakfast-request)
            - [Login Response](#get-breakfast-response)
   



## Authentification

### Register

```js 
POST {{host}}/Authentication/Register
```

#### Register Request
```json
{
    "firstName": "Vegun",
    "lastName":"Won",
    "email":"Won@cs.com",
    "password":"123ed4"    
}
```

#### Register Response

```js
200 Ok
```

```json
{
    "id":"00000000-000-000-000-000000000000"
    "firstName": "Vegun",
    "lastName":"Won",
    "email":"Won@cs.com",
    "token":"safweU..tgir" 
}

### Login

```js 
POST {{host}}/Authentication/Login
```

#### Login Request
```json
{   
    "email":"Won@cs.com",
    "password":"123ed4"    
}
```

#### Login Response

```js
200 Ok
```

```json
{
    "id":"00000000-000-000-000-000000000000"
    "firstName": "Vegun",
    "lastName":"Won",
    "email":"Won@cs.com",
    "token":"safweU..tgir" 
}