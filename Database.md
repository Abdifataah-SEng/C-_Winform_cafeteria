# Database Documentation

<style>
.db-wrap{font-family:Segoe UI,Arial,sans-serif}.db-hero{display:grid;grid-template-columns:1.15fr .85fr;gap:24px;align-items:center;margin:24px 0;padding:28px;border-radius:26px;background:linear-gradient(135deg,#082f49,#2563eb 50%,#7c3aed);box-shadow:0 24px 55px rgba(37,99,235,.25);overflow:hidden;animation:dbFade .8s ease both}.db-hero h2{margin:12px 0 10px;color:#fff;font-size:34px;line-height:1.05}.db-hero p{color:#dbeafe;font-size:16px;line-height:1.65}.db-tag{display:inline-block;margin:4px 6px 4px 0;padding:7px 12px;border-radius:999px;background:rgba(255,255,255,.16);color:#fff;border:1px solid rgba(255,255,255,.25);font-size:12px;font-weight:800}.db-hero img{width:100%;height:245px;object-fit:cover;border-radius:20px;box-shadow:0 18px 40px rgba(0,0,0,.28);animation:dbFloat 5s ease-in-out infinite}.db-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(170px,1fr));gap:14px;margin:22px 0}.db-card{padding:18px;border-radius:20px;background:#fff;border:1px solid #dbeafe;box-shadow:0 16px 35px rgba(2,8,23,.09);transition:.25s ease;position:relative;overflow:hidden}.db-card:before{content:"";position:absolute;inset:0 0 auto;height:6px;background:linear-gradient(90deg,#0ea5e9,#8b5cf6)}.db-card:hover{transform:translateY(-6px);box-shadow:0 24px 50px rgba(37,99,235,.18)}.db-card img{width:46px;height:46px;object-fit:contain;margin-top:10px}.db-card h3{margin:8px 0 6px;color:#0f172a}.db-card p{margin:0;color:#475569;line-height:1.45}.db-badge{display:inline-block;margin-top:12px;padding:5px 10px;border-radius:999px;background:#eff6ff;color:#1d4ed8;font-weight:800;font-size:12px}.db-flow{margin:22px 0;padding:18px;border-radius:20px;background:linear-gradient(90deg,#eff6ff,#faf5ff);border:1px solid #dbeafe;box-shadow:0 14px 30px rgba(30,64,175,.1);font-weight:800;color:#1e3a8a;text-align:center;animation:dbPulse 2.5s ease-in-out infinite}.db-mix{display:grid;grid-template-columns:repeat(auto-fit,minmax(210px,1fr));gap:12px;margin:20px 0}.db-mix img{width:100%;height:150px;object-fit:cover;border-radius:18px;box-shadow:0 16px 34px rgba(15,23,42,.16);transition:.25s}.db-mix img:hover{transform:scale(1.04)}@keyframes dbFade{from{opacity:0;transform:translateY(18px)}to{opacity:1;transform:translateY(0)}}@keyframes dbFloat{0%,100%{transform:translateY(0)}50%{transform:translateY(-9px)}}@keyframes dbPulse{0%,100%{transform:scale(1)}50%{transform:scale(1.015)}}@media(max-width:760px){.db-hero{grid-template-columns:1fr;padding:20px}.db-hero h2{font-size:26px}}
</style>
<link rel="stylesheet" href="https://unpkg.com/aos@2.3.1/dist/aos.css">
<script src="https://cdn.tailwindcss.com"></script>
<script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
<script>
document.addEventListener("DOMContentLoaded",function(){document.querySelectorAll(".db-card,.db-flow").forEach(function(el,i){el.setAttribute("data-aos","zoom-in-up");el.style.animationDelay=(i*90)+"ms"});if(window.AOS){AOS.init({duration:850,once:true,easing:"ease-out-cubic"})}});
</script>

<div class="db-wrap">
  <div class="db-hero">
    <div>
      <span class="db-tag">SQL Server LocalDB</span><span class="db-tag">Tables</span><span class="db-tag">Relationships</span>
      <h2>Database Schema Map</h2>
      <p>The app stores authentication, employees, orders, payments, and salary data. The dashboard also expects an <code>AbouvTotal</code> summary object for totals.</p>
    </div>
    <img src="state/ChatGPT%20Image%20May%2028%2C%202026%2C%2012_01_30%20AM.png" alt="Database schema map visual" />
  </div>

  <div class="db-flow">userlogin -> employees -> Orderall -> payment | employees -> salary | AbouvTotal -> dashboard cards</div>

  <div class="db-grid">
    <div class="db-card"><img src="SS_Assment_Cafateria_C%23/Resources/profile.png" alt="User icon" /><h3>userlogin</h3><p>Admin/operator credentials and role data.</p><span class="db-badge">Parent table</span></div>
    <div class="db-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-employee-64.png" alt="Employee icon" /><h3>employees</h3><p>Staff profile data linked to login users.</p><span class="db-badge">Core table</span></div>
    <div class="db-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-order-100.png" alt="Order icon" /><h3>Orderall</h3><p>Food and drink order records linked to employees.</p><span class="db-badge">Order data</span></div>
    <div class="db-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-payment-64.png" alt="Payment icon" /><h3>payment</h3><p>Payment amount, method, date, and status.</p><span class="db-badge">Payment data</span></div>
    <div class="db-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-salary-94.png" alt="Salary icon" /><h3>salary</h3><p>Salary month, base salary, bonuses, and deductions.</p><span class="db-badge">Payroll data</span></div>
  </div>
  <div class="db-mix">
    <img src="state/images%20%281%29.jpeg" alt="Database server visual" />
    <img src="SS_Assment_Cafateria_C%23/Resources/rodeo-project-management-software-PYqzYhTNjho-unsplash.jpg" alt="Project dashboard photo" />
    <img src="state/ChatGPT%20Image%20May%2028%2C%202026%2C%2012_01_30%20AM.png" alt="Schema map visual" />
  </div>
</div>

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
