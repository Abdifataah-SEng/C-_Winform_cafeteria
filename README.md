# Cafeteria Management System

This repository contains a Windows Forms cafeteria management application written in C# for .NET Framework 4.7.2. The project name is `SS_Assment_Cafateria_C#`, and the application is designed for an administrator/operator who manages cafeteria employees, orders, payments, salaries, reports, and database backup/restore.

The application uses SQL Server LocalDB through `System.Data.SqlClient`. The configured database is:

```text
(localdb)\ProjectModels
Cafeteria_management_C_DB
```

## What The App Does

The app provides these main workflows:

- Splash/loading screen before login.
- Login using records from the `userlogin` table.
- Forgot-password screen that verifies a user and attempts to update the stored password.
- Admin dashboard with totals for orders, salary records, employees, and payments.
- Order management with create, update, delete, search, category filtering, and report viewing.
- Payment management with create, update, delete, search, method filtering, and report viewing.
- Employee management with create, update, delete, search, and report viewing.
- Salary management with create, update, delete, search, and report viewing.
- Database backup and restore using SQL Server `BACKUP DATABASE` and `RESTORE DATABASE`.

## Main Screens

| Screen/File | Purpose |
| --- | --- |
| `Form1` | Splash/loading form. After the progress bar reaches 100, opens `login`. |
| `login` | Authenticates against `userlogin.username` and `userlogin.password_hash`. |
| `forgot_pass` | Verifies username/email/full name, then attempts password reset. |
| `Dashbourd` | Main admin shell with side navigation. |
| `ui_Dashbourd` | Dashboard totals and charts. |
| `UC_employee` | Employee list, search, refresh, open editor, open report. |
| `employee` | Employee create/update/delete/search form. |
| `UC_order` | Order list, search, refresh, category filter, open editor, open report. |
| `order_bn` | Order create/update/delete/search form. |
| `UC_payment` | Payment list, search, refresh, payment-method filter, open editor, open report. |
| `payment` | Payment create/update/delete/search form. |
| `UC_salary` | Salary list, search, refresh, open editor, open report. |
| `Salary` | Salary create/update/delete/search form. |
| `BackUp` | Backup and restore database `.bak` files. |

## Technology Stack

- C# Windows Forms
- .NET Framework 4.7.2
- SQL Server LocalDB
- `System.Data.SqlClient`
- Crystal Reports for report viewers
- Bunifu UI WinForms controls
- Guna.UI2 WinForms controls
- Windows Forms chart controls

## Project Structure

```text
SS_Assment_Cafateria_C#.sln
SS_Assment_Cafateria_C#/
  App.config
  Program.cs
  Form1.cs
  login.cs
  forgot_pass.cs
  Dashbourd.cs
  ui_Dashbourd.cs
  UC_employee.cs
  employee.cs
  UC_order.cs
  order_bn.cs
  UC_payment.cs
  payment.cs
  UC_salary.cs
  Salary.cs
  BackUp.cs
  Cafeteria_management_C_DBDataSet.xsd
  *.rpt
  Resources/
```

## How The App Starts

1. `Program.Main()` runs `Application.Run(new Form1())`.
2. `Form1` enables a timer and updates a Bunifu progress bar.
3. When the progress value reaches 100, `Form1` opens `login` and hides itself.
4. A successful login opens `Dashbourd`.
5. The dashboard side menu loads user controls into the main panel:
   - Dashboard
   - Order
   - Payment
   - Employees
   - Salary
   - BackUp

## Database Dependency

The app requires a SQL Server database named `Cafeteria_management_C_DB`. The schema is documented in [Database.md](Database.md).

Required tables:

- `userlogin`
- `employees`
- `Orderall`
- `payment`
- `salary`

Required dashboard object:

- `AbouvTotal`

`AbouvTotal` is used by the dashboard totals screen, but it is not included in the typed dataset. It should be created as a SQL view or table-valued summary that returns totals in this order: orders, salary, employees, payments.

## Reports

The app includes Crystal Report classes and `.rpt` files:

- `EmployeeRP.rpt` with `EmployeeVRPcs`
- `OrderRT.rpt` with `OrderVRP`
- `pymentRP.rpt` with `pymentVRP`
- `SalaryRP.rpt` with `SlaryVRP`

There are also embedded `Report1.rdlc` and `Report2.rdlc` files, but the current source opens Crystal Report viewers for the visible report buttons.

## Build And Run

1. Install Visual Studio with .NET Framework desktop development.
2. Install .NET Framework 4.7.2 targeting pack if it is not already installed.
3. Install SQL Server LocalDB.
4. Install Crystal Reports runtime/developer components for .NET Framework.
5. Make sure Bunifu UI and Guna.UI2 assemblies are available. The project currently references local absolute paths in the `.csproj`, and the checked-in `bin/Debug` folder also contains DLL copies.
6. Create the `Cafeteria_management_C_DB` database using the schema in [Database.md](Database.md).
7. Add at least one `userlogin` row so the login screen can authenticate.
8. Open `SS_Assment_Cafateria_C#.sln` in Visual Studio.
9. Build and run the project.

## Important Notes From Code Reading

- Passwords are compared directly against `userlogin.password_hash`; the current code does not hash the login input before comparison.
- The password reset form uses `fullname` in one query, while the typed dataset defines `full_name`. It also has an update statement that references `Users`. If password reset does not work, check those database column/table names.
- Several filter text boxes build SQL using string concatenation. This works for local input but is not safe for untrusted input.
- `salary.salary_month` is defined as text in the typed dataset, but the form uses a date picker and converts the stored value back to `DateTime`.
- `Orderall.subtotal` is read-only in the typed dataset and is not inserted by the order form. A computed column is the easiest way to support it.

## Extra Documentation

- [Database.md](Database.md) - database schema, relationships, and setup SQL.
- [DATA_FLOW.md](DATA_FLOW.md) - application and data flow.
- [USE_CASES.md](USE_CASES.md) - use cases by actor/workflow.
- [SYSTEM_USAGE.md](SYSTEM_USAGE.md) - how an operator uses the system.
