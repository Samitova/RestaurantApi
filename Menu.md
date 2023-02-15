# Restaurant API

Table of Contents
- [Restaurant Api](#restaurant-api)
    - [Menu](#menu)
        - [Create Menu](#create-menu-request)
            - [Create Menu Request](#create-menu-request)
            - [Create Menu Response](#create-menu-response)
        - [Get Menu](#get-menu)
            - [Login Request](#get-menu-request)
            - [Login Response](#get-menu-response) 

## Menu

### Create Menu

```js 
POST /api/hosts/{hostId}/Menus
```

#### Create Menu Request
```json
{
   "title": "title",
	"description": "description",	
	"menuSections":[
		{			
			"title": "title",
			"description": "description",
			"menuitems":[
				{					
					"title": "title",
					"description": "description"					
				}
			]
		}		
	]  
}
```

#### Create Menu Response

```js
201 Created
```

```json
{
   "id":"00000000-000-000-000-000000000000",
	"title": "title",
	"description": "description",
	"avagerRating":null,
	"menuSections":[
		{
			"id":"00000000-000-000-000-000000000000",
			"title": "title",
			"description": "description",
			"menuitems":[
				{
					"id":"00000000-000-000-000-000000000000",
					"title": "title",
					"description": "description"					
				}
			]
		}		
	],	
	"hostId": "00000000-000-000-000-000000000000",
	"dinerIds": [
		"00000000-000-000-000-000000000000"		
	],
	"menuReviewIds": [
		"00000000-000-000-000-000000000000"
	],
	"createdDateDime":"2023-01-01T00:00:00.0000000Z",
	"updatedDateDime":"2023-01-01T00:00:00.0000000Z"
}
```