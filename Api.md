# Restaurant API

Table of Contents
- [Restaurant Api](#restaurant-api)
    - [Authentification](#authentification)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response) 

## Authentification

### Register

```js 
POST {{host}}/api/Authentication/Register
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
POST {{host}}/api/Authentication/Login
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