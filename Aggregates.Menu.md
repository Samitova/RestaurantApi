# Domain Models

## Menu

```csharp
class Menu
{
	Menu Create();
	void AddDinner(Dinner dinner);
	void removeDinner(Dinner dinner);
	void updateSection(MenuSection section);
}
```

```json
{
	"id":"00000000-000-000-000-000000000000",
	"title": "title",
	"description": "description",
	"avagerRating":"0.0",
	"sections":[
		{
			"id":"00000000-000-000-000-000000000000",
			"title": "title",
			"description": "description",
			"items":[
				{
					"id":"00000000-000-000-000-000000000000",
					"title": "title",
					"description": "description",
					"price":"0.0"
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
