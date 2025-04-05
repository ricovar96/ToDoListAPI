**ToDoList API**

![image](https://github.com/user-attachments/assets/062e759f-a892-4b7c-915c-0b8acd6921ca)

The ToDoList API is a simple RESTful web service that allows users to manage their tasks. Hosted on Microsoft Azure connected to an SQL Azure Database, it provides CRUD operations (Create, Read, Update, Delete) for managing tasks. Each task has properties like name, description, due date, urgency, and importance.

Features:
Create, Read, Update, and Delete tasks.

Accessible via Swagger UI for easy testing.

Can be tested using Postman with various endpoints for managing tasks.

Hosting:
This API is hosted on Azure App Service, making it accessible over the internet.

How to Use:
Access the API through the Swagger UI interface at https://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/swagger/index.html

Test API endpoints via Postman with pre-configured endpoints for each action:

GET ALL => https://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/api/ToDoList

GET ONE ELEMENT => https://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/api/ToDoList/{ID}

POST=> https://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/api/ToDoList 
{
  "taskName": "string",
  "taskDescription": "string",
  "endDate": "2025-04-05T00:24:40.715Z",
  "isUrgent": true,
  "levelImportance": 0
}

PUT=> https://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/api/ToDoList/{ID}
{
  "id": 0,
  "taskName": "string",
  "taskDescription": "string",
  "endDate": "2025-04-05T00:24:40.715Z",
  "isUrgent": true,
  "levelImportance": 0
}

DELETE=> ttps://todolistricovar96-f4duczhpavfwa2bw.canadacentral-01.azurewebsites.net/api/ToDoList/{ID}

Responses:
The app returns standard HTTP responses, such as:

200 OK: For successful operations.

404 Not Found: When the requested resource is not found.

500 Internal Server Error: For unexpected issues.

Performing CRUD Operations:
You can interact with the API by sending HTTP requests with JSON-formatted data. Use Postman or Swagger UI to easily perform these CRUD operations.
