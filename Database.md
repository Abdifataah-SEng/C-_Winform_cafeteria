# Database Documentation

The application expects a SQL Server LocalDB database named `Cafeteria_management_C_DB`.

Configured connection string:

```text
Data Source=(localdb)\ProjectModels;Initial Catalog=Cafeteria_management_C_DB;Integrated Security=True;TrustServerCertificate=True
```

The database schema below is based on the source code and the typed dataset file `SS_Assment_Cafateria_C#\Cafeteria_management_C_DBDataSet.xsd`.

## Required Database Objects

Required tables:

- `dbo.userlogin`
- `dbo.employees`
- `dbo.Orderall`
- `dbo.payment`
- `dbo.salary`

Required dashboard summary object:

- `dbo.AbouvTotal`

`AbouvTotal` is used by `ui_Dashbourd.cs` with `SELECT * from AbouvTotal`. The code reads columns by index:

| Index | Dashboard label |
| --- | --- |
| `0` | Order total |
| `1` | Salary total |
| `2` | Employee total |
| `3` | Payment total |

## Tables

### `dbo.userlogin`

Stores application login users.

| Column | Type | Null | Notes |
| --- | --- | --- | --- |
| `user_id` | `int identity` | No | Primary key. |
| `username` | `nvarchar(50)` | No | Used by login. |
| `password_hash` | `nvarchar(256)` | No | Current code compares plain text input to this column. |
| `email` | `nvarchar(100)` | No | Used by forgot-password verification. |
| `full_name` | `nvarchar(100)` | No | Typed dataset name. |
| `role` | `nvarchar(20)` | No | Stored role value. Current code does not enforce role permissions. |
| `created_at` | `datetime` | No | User creation timestamp. |

### `dbo.employees`

Stores staff records.

| Column | Type | Null | Notes |
| --- | --- | --- | --- |
| `employee_id` | `int identity` | No | Primary key. |
| `userlogin_id` | `int` | No | Foreign key to `userlogin.user_id`. |
| `first_name` | `nvarchar(50)` | No | Searchable in employee list. |
| `last_name` | `nvarchar(50)` | No | Searchable in employee list. |
| `position` | `nvarchar(50)` | No | UI options: `Staff`, `Empoyee`, `manager`, `Admin`. |
| `hire_date` | `datetime` | No | Employee hire date. |
| `email` | `nvarchar(100)` | Yes | Employee email. |
| `phone` | `nvarchar(20)` | Yes | Employee phone. |
| `hourly_rate` | `decimal(10,2)` | Yes | Hourly rate. |
| `monthly_salary` | `decimal(10,2)` | Yes | Monthly salary. |

### `dbo.Orderall`

Stores cafeteria orders.

| Column | Type | Null | Notes |
| --- | --- | --- | --- |
| `order_id` | `int identity` | No | Primary key. |
| `employee_id` | `int` | No | Foreign key to `employees.employee_id`. |
| `order_date` | `datetime` | No | Order date. |
| `notes` | `nvarchar(500)` | Yes | Free-text notes. |
| `item_name` | `nvarchar(100)` | No | Searchable in order list. |
| `category` | `nvarchar(50)` | No | UI options: `Drink`, `Food`. |
| `item_price` | `decimal(10,2)` | No | Item price entered by user. |
| `quantity` | `int` | No | Quantity entered by user. |
| `unit_price` | `decimal(10,2)` | No | Unit price entered by user. |
| `subtotal` | `decimal(18,2)` computed | Yes | Read-only in dataset. The app does not insert/update it. |
| `total_amount` | `decimal(10,2)` | No | Total entered by user. |

### `dbo.payment`

Stores order payment records.

| Column | Type | Null | Notes |
| --- | --- | --- | --- |
| `payment_id` | `int identity` | No | Primary key. |
| `order_id` | `int` | No | Usually references `Orderall.order_id`. The dataset does not define this FK, but the form requires an order id. |
| `amount` | `decimal(10,2)` | No | Payment amount. |
| `payment_method` | `nvarchar(20)` | No | UI options: `cash`, `card`, `mobile`. |
| `payment_date` | `datetime` | No | Payment date. |
| `status` | `nvarchar(20)` | No | UI options: `pending`, `completed`, `failed`, `refunded`. |

### `dbo.salary`

Stores salary records.

| Column | Type | Null | Notes |
| --- | --- | --- | --- |
| `salary_id` | `int identity` | No | Primary key. |
| `employee_id` | `int` | No | Foreign key to `employees.employee_id`. |
| `salary_month` | `nvarchar(50)` | No | Dataset defines text; form uses a date picker. Use date-like strings. |
| `base_salary` | `decimal(10,2)` | No | Base salary. |
| `bonuses` | `decimal(10,2)` | No | Bonus amount. |
| `deductions` | `decimal(10,2)` | No | Deduction amount. |
| `payment_date` | `date` | Yes | Salary payment date. |
| `notes` | `nvarchar(500)` | Yes | Free-text notes. |

## Relationships

The typed dataset defines these relationships:

| Relationship | Parent | Child |
| --- | --- | --- |
| `FK__employees__userl__6477ECF3` | `userlogin.user_id` | `employees.userlogin_id` |
| `FK_Orderall_employees` | `employees.employee_id` | `Orderall.employee_id` |
| `FK__salary__employee__6B24EA82` | `employees.employee_id` | `salary.employee_id` |

The payment form also uses `payment.order_id`, so a practical database should add:

| Relationship | Parent | Child |
| --- | --- | --- |
| `FK_payment_Orderall` | `Orderall.order_id` | `payment.order_id` |

## Suggested Setup SQL

Use this script to build a compatible database from an empty SQL Server LocalDB instance.

```sql
CREATE DATABASE Cafeteria_management_C_DB;
GO

USE Cafeteria_management_C_DB;
GO

CREATE TABLE dbo.userlogin (
    user_id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_userlogin PRIMARY KEY,
    username nvarchar(50) NOT NULL,
    password_hash nvarchar(256) NOT NULL,
    email nvarchar(100) NOT NULL,
    full_name nvarchar(100) NOT NULL,
    role nvarchar(20) NOT NULL,
    created_at datetime NOT NULL CONSTRAINT DF_userlogin_created_at DEFAULT (GETDATE())
);
GO

CREATE TABLE dbo.employees (
    employee_id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_employees PRIMARY KEY,
    userlogin_id int NOT NULL,
    first_name nvarchar(50) NOT NULL,
    last_name nvarchar(50) NOT NULL,
    position nvarchar(50) NOT NULL,
    hire_date datetime NOT NULL,
    email nvarchar(100) NULL,
    phone nvarchar(20) NULL,
    hourly_rate decimal(10,2) NULL,
    monthly_salary decimal(10,2) NULL,
    CONSTRAINT FK_employees_userlogin
        FOREIGN KEY (userlogin_id) REFERENCES dbo.userlogin(user_id)
);
GO

CREATE TABLE dbo.Orderall (
    order_id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orderall PRIMARY KEY,
    employee_id int NOT NULL,
    order_date datetime NOT NULL,
    notes nvarchar(500) NULL,
    item_name nvarchar(100) NOT NULL,
    category nvarchar(50) NOT NULL,
    item_price decimal(10,2) NOT NULL,
    quantity int NOT NULL,
    unit_price decimal(10,2) NOT NULL,
    subtotal AS (CONVERT(decimal(18,2), quantity) * CONVERT(decimal(18,2), unit_price)) PERSISTED,
    total_amount decimal(10,2) NOT NULL,
    CONSTRAINT FK_Orderall_employees
        FOREIGN KEY (employee_id) REFERENCES dbo.employees(employee_id)
);
GO

CREATE TABLE dbo.payment (
    payment_id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_payment PRIMARY KEY,
    order_id int NOT NULL,
    amount decimal(10,2) NOT NULL,
    payment_method nvarchar(20) NOT NULL,
    payment_date datetime NOT NULL,
    status nvarchar(20) NOT NULL,
    CONSTRAINT FK_payment_Orderall
        FOREIGN KEY (order_id) REFERENCES dbo.Orderall(order_id)
);
GO

CREATE TABLE dbo.salary (
    salary_id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_salary PRIMARY KEY,
    employee_id int NOT NULL,
    salary_month nvarchar(50) NOT NULL,
    base_salary decimal(10,2) NOT NULL,
    bonuses decimal(10,2) NOT NULL,
    deductions decimal(10,2) NOT NULL,
    payment_date date NULL,
    notes nvarchar(500) NULL,
    CONSTRAINT FK_salary_employees
        FOREIGN KEY (employee_id) REFERENCES dbo.employees(employee_id)
);
GO

CREATE VIEW dbo.AbouvTotal
AS
SELECT
    (SELECT COUNT(*) FROM dbo.Orderall) AS TotalOrders,
    (SELECT COUNT(*) FROM dbo.salary) AS TotalSalaryRecords,
    (SELECT COUNT(*) FROM dbo.employees) AS TotalEmployees,
    (SELECT COUNT(*) FROM dbo.payment) AS TotalPayments;
GO
```

## Minimum Seed Data

At least one `userlogin` row is required before anyone can log in.

```sql
USE Cafeteria_management_C_DB;
GO

INSERT INTO dbo.userlogin (username, password_hash, email, full_name, role)
VALUES ('admin', 'admin', 'admin@example.com', 'System Admin', 'Admin');
GO
```

After that, create at least one employee linked to this user before creating orders or salaries:

```sql
INSERT INTO dbo.employees
    (userlogin_id, first_name, last_name, position, hire_date, email, phone, hourly_rate, monthly_salary)
VALUES
    (1, 'System', 'Admin', 'Admin', GETDATE(), 'admin@example.com', '0000000000', 0, 0);
GO
```

## Data Used By Each Screen

| Screen | Reads | Writes |
| --- | --- | --- |
| `login` | `userlogin` | None |
| `forgot_pass` | `userlogin` | `userlogin.password_hash` |
| `ui_Dashbourd` | `AbouvTotal`, `Orderall`, `payment` | None |
| `UC_employee` | `employees` | None |
| `employee` | `employees` | Insert/update/delete `employees` |
| `UC_order` | `Orderall` | None |
| `order_bn` | `Orderall` | Insert/update/delete `Orderall` |
| `UC_payment` | `payment` | None |
| `payment` | `payment` | Insert/update/delete `payment` |
| `UC_salary` | `salary` | None |
| `Salary` | `salary` | Insert/update/delete `salary` |
| `BackUp` | SQL Server database | Creates/restores `.bak` files |

## Notes And Cautions

- The repository does not include an `.mdf`, `.bak`, or SQL seed file containing actual production data.
- I attempted to inspect the configured LocalDB database from this workspace, but the LocalDB instance was not accessible in the current environment. This document therefore describes the required database model from the code and dataset.
- The current password reset SQL appears inconsistent with the dataset: it uses `fullname` instead of `full_name`, and an update statement references `Users`.
- The current code expects `payment_id`, `employee_id`, `order_id`, and `salary_id` to be entered for search/update/delete, but insert operations mostly rely on identity columns.
