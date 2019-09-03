
API was checked via Postman

GET:		http://localhost:41877/api/product - show all products
GET:		http://localhost:41877/api/product/id(GUID) - show product with specified id(guid)
POST:		http://localhost:41877/api/product - create product
					sample body:
					{
					"price": 15,
					"name" : "Hat"
					}
PUT:		http://localhost:41877/api/product/id(GUID) - update product specified by id(guid)
DELETE :	http://localhost:41877/api/product/id(GUID) - delete product specified by id(guid)