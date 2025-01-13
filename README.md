# GraphQl
The API is configured to run on port 5001 by default just compose up yml file 
thre is automigration and seeding data will be mapped on the sql server database 
- graph url path is : localhost:5001/ui/graphql
- sql server configs:
- username :sa ; password: Aa@123456 ; port : 1432

- ### Get first 10 Products
```localhost:5001/ui/graphql
query  {
  products(first: 10) {
    id
    name
  }
}

```
- ### Get single product by Id
 ```localhost:5001/ui/graphql
query  {
  product(id: 10) {
    id
    creationDate
  }
}

```
