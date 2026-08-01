# BizTrack

BizTrack is a personal expense tracking web application designed to help users manage their finances by recording income, tracking expenses, setting budgets, and monitoring spending habits. The application provides an intuitive dashboard with financial insights, making it easier to stay organized and make informed financial decisions.


## Live Demo

This project is currently available as source code only.

**GitHub Repository:**
https://github.com/composure21/BizTrack

---

## About the Project

BizTrack was developed as a full-stack web application using ASP.NET Core MVC and PostgreSQL. It follows the MVC architectural pattern to separate application logic, user interface, and data management, resulting in a clean, scalable, and maintainable codebase.

The application enables users to organize their finances by categorizing transactions, setting budgets, and viewing summaries through an interactive dashboard.

---

## Features

* User-friendly dashboard
* Income management
* Expense management
* Budget creation and tracking
* Transaction history
* Financial summaries
* Expense categorization
* Responsive design
* CRUD operations

---

## Built With

### Frontend

* HTML5
* CSS3
* JavaScript
* Bootstrap

### Backend

* C#
* ASP.NET Core MVC
* Entity Framework Core

### Database

* PostgreSQL

### Development Tools

* Visual Studio
* GitHub

---

## Application Structure

```text
BizTrack/
│
├── Controllers/
├── Models/
├── Views/
│   ├── Dashboard/
│   ├── Income/
│   ├── Expenses/
│   ├── Budgets/
│   ├── Categories/
│   └── Shared/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
│
├── Data/
├── Migrations/
├── appsettings.json
├── Program.cs
└── README.md
```

---

## Dashboard

The dashboard provides a quick overview of the user's financial activity, including:

* Total Income
* Total Expenses
* Remaining Budget
* Recent Transactions
* Expense Breakdown
* Budget Overview

---

## Technologies Used

| Technology            | Purpose             |
| --------------------- | ------------------- |
| ASP.NET Core MVC      | Web Framework       |
| C#                    | Backend Development |
| Entity Framework Core | ORM                 |
| PostgreSQL            | Database            |
| HTML5                 | Structure           |
| CSS3                  | Styling             |
| JavaScript            | Interactivity       |
| Bootstrap             | Responsive UI       |

---

## Getting Started

### Clone the repository

```bash
git clone https://github.com/composure21/BizTrack
```

### Navigate to the project

```bash
cd BizTrack
```

### Configure the database

Update the connection string inside **appsettings.json** with your PostgreSQL database credentials.

### Apply migrations

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run
```

Alternatively, open the solution in **Visual Studio** and press **F5** to run the application.

---

## Future Improvements

* User authentication and authorization
* Financial reports
* Interactive charts and graphs
* Export transactions to PDF or Excel
* Recurring income and expenses
* Savings goals
* Monthly and yearly analytics
* Email notifications

---

## Learning Outcomes

This project demonstrates practical experience with:

* ASP.NET Core MVC architecture
* C# application development
* Entity Framework Core
* PostgreSQL database integration
* CRUD operations
* MVC design pattern
* Responsive web design
* Form validation
* Full-stack web development

---

## Author

Developed by Siyabonga Msweli
