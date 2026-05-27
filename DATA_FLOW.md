# Data Flow

This document describes how data moves through the Cafeteria Management System.

## Application Startup Flow

```mermaid
flowchart TD
    A["Program.Main"] --> B["Form1 splash screen"]
    B --> C["Timer updates progress bar"]
    C --> D{"Progress = 100?"}
    D -- "No" --> C
    D -- "Yes" --> E["Open login form"]
    E --> F["User enters username and password"]
    F --> G["Query userlogin table"]
    G --> H{"User found?"}
    H -- "No" --> I["Show Incorrect message"]
    H -- "Yes" --> J["Open Dashbourd"]
```

## Main Navigation Flow

```mermaid
flowchart LR
    A["Dashbourd"] --> B["ui_Dashbourd"]
    A --> C["UC_order"]
    A --> D["UC_payment"]
    A --> E["UC_employee"]
    A --> F["UC_salary"]
    A --> G["BackUp"]

    C --> C1["order_bn editor"]
    C --> C2["OrderVRP report"]
    D --> D1["payment editor"]
    D --> D2["pymentVRP report"]
    E --> E1["employee editor"]
    E --> E2["EmployeeVRPcs report"]
    F --> F1["Salary editor"]
    F --> F2["SlaryVRP report"]
```

## Authentication Data Flow

1. User enters `txtname` and `txtpass`.
2. `login.cs` runs:

```sql
Select * from userlogin where username=@user and password_hash=@pass
```

3. If a record exists, the dashboard opens.
4. If no record exists, the app shows `Incorrect`.

Forgot-password flow:

1. User enters username, email, and full name.
2. `forgot_pass.cs` checks the `userlogin` table.
3. If verification succeeds, the new password section is enabled.
4. If both password fields match, the app attempts to update `userlogin.password_hash`.

## Dashboard Data Flow

```mermaid
flowchart TD
    A["ui_Dashbourd loads"] --> B["SELECT * FROM AbouvTotal"]
    B --> C["Set total labels"]
    A --> D["Group Orderall by category"]
    D --> E["Draw order category chart"]
    A --> F["Group payment by payment_method"]
    F --> G["Draw payment method chart"]
```

Dashboard queries:

```sql
SELECT * from AbouvTotal;

select distinct category, COUNT(*) as Totals
from Orderall
group by category;

select distinct payment_method, COUNT(*) as Totals
from payment
group by payment_method;
```

## Employee Data Flow

List and search:

```mermaid
flowchart TD
    A["UC_employee loads"] --> B["SELECT * FROM employees"]
    B --> C["Bind DataTable to DataGridView"]
    D["Search text changes"] --> E["Query employees by first_name or last_name"]
    E --> C
```

Editor operations:

| Operation | SQL target |
| --- | --- |
| Save | `INSERT INTO employees` |
| Update | `UPDATE employees WHERE employee_id=@employee_id` |
| Delete | `DELETE FROM employees WHERE employee_id=@employee_id` |
| Search | `SELECT * FROM employees WHERE employee_id=@employee_id` |

## Order Data Flow

List and filters:

```mermaid
flowchart TD
    A["UC_order loads"] --> B["SELECT * FROM Orderall"]
    B --> C["Bind DataTable to grid"]
    D["Search text changes"] --> E["Filter by order_id, item_name, or quantity"]
    F["Category combo changes"] --> G["Filter by category"]
    E --> C
    G --> C
```

Editor operations:

| Operation | SQL target |
| --- | --- |
| Save | `INSERT INTO Orderall` |
| Update | `UPDATE Orderall WHERE order_id=@order_id` |
| Delete | `DELETE FROM Orderall WHERE order_id=@order_id` |
| Search | `SELECT * FROM Orderall WHERE order_id=@order_id` |

## Payment Data Flow

List and filters:

```mermaid
flowchart TD
    A["UC_payment loads"] --> B["SELECT * FROM payment"]
    B --> C["Bind DataTable to grid"]
    D["Search text changes"] --> E["Filter by payment_id"]
    F["Payment method combo changes"] --> G["Filter by payment_method"]
    E --> C
    G --> C
```

Editor operations:

| Operation | SQL target |
| --- | --- |
| Save | `INSERT INTO payment` |
| Update | `UPDATE payment WHERE payment_id=@payment_id` |
| Delete | `DELETE FROM payment WHERE payment_id=@payment_id` |
| Search | `SELECT * FROM payment WHERE payment_id=@payment_id` |

## Salary Data Flow

List and search:

```mermaid
flowchart TD
    A["UC_salary loads"] --> B["SELECT * FROM salary"]
    B --> C["Bind DataTable to grid"]
    D["Search text changes"] --> E["Filter by salary_id"]
    E --> C
```

Editor operations:

| Operation | SQL target |
| --- | --- |
| Save | `INSERT INTO Salary` |
| Update | `UPDATE Salary WHERE salary_id=@salary_id` |
| Delete | `DELETE FROM Salary WHERE salary_id=@salary_id` |
| Search | `SELECT * FROM Salary WHERE salary_id=@salary_id` |

## Report Flow

```mermaid
flowchart TD
    A["User clicks report button"] --> B["Open report viewer form"]
    B --> C["CrystalReportViewer loads embedded .rpt class"]
    C --> D["Show report preview"]
```

Report viewers:

| Module | Viewer form | Report class/file |
| --- | --- | --- |
| Employees | `EmployeeVRPcs` | `EmployeeRP.rpt` |
| Orders | `OrderVRP` | `OrderRT.rpt` |
| Payments | `pymentVRP` | `pymentRP.rpt` |
| Salary | `SlaryVRP` | `SalaryRP.rpt` |

## Backup And Restore Flow

Backup:

```mermaid
flowchart TD
    A["Open BackUp form"] --> B["Browse backup destination"]
    B --> C["Run BACKUP DATABASE to selected .bak path"]
    C --> D["Show success or error"]
```

Restore:

```mermaid
flowchart TD
    A["Open BackUp form"] --> B["Browse .bak file"]
    B --> C["Run RESTORE DATABASE from selected file"]
    C --> D["Show success or error"]
```
