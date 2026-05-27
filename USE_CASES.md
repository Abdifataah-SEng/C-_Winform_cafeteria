# Use Cases

The current application behaves like an admin/operator tool. The `userlogin.role` column exists, but the code does not enforce different permissions by role.

## Actors

| Actor | Description |
| --- | --- |
| Admin/operator | Uses the dashboard to manage cafeteria employees, orders, payments, salaries, reports, and backup/restore. |
| SQL Server LocalDB | Stores all application data. |

## UC-01: Log In

Primary actor: Admin/operator

Preconditions:

- `Cafeteria_management_C_DB` exists.
- `userlogin` contains a matching username/password row.

Main flow:

1. Open the application.
2. Wait for the splash screen to finish.
3. Enter username and password.
4. Click `Login`.
5. System queries `userlogin`.
6. System opens the dashboard when credentials match.

Alternative flow:

- If credentials do not match, system shows `Incorrect`.

## UC-02: Reset Password

Primary actor: Admin/operator

Preconditions:

- User record exists in `userlogin`.

Main flow:

1. From login screen, click `Forgot password ?`.
2. Enter username, email, and full name.
3. Click `Check`.
4. System verifies the user record.
5. Enter and confirm a new password.
6. Click `Change`.
7. System attempts to update `userlogin.password_hash`.

Implementation note:

- The current reset SQL uses `fullname`, while the dataset column is `full_name`. It also references `Users` in the update statement. The database or code must be aligned for this use case to work.

## UC-03: View Dashboard

Primary actor: Admin/operator

Main flow:

1. Log in successfully.
2. Click `Dashbourd` from the side menu.
3. System loads totals from `AbouvTotal`.
4. System loads order counts by category from `Orderall`.
5. System loads payment counts by method from `payment`.
6. System displays summary cards and charts.

## UC-04: Manage Employees

Primary actor: Admin/operator

Main flow:

1. Click `Employees`.
2. System displays all records from `employees`.
3. Type in the search box to filter by first or last name.
4. Click refresh to reload all employees.
5. Click the editor button to open the employee form.
6. Save, update, delete, or search employee records.
7. Click report to open the employee Crystal Report.

Data affected:

- `employees`
- `userlogin` is required as the parent table for `employees.userlogin_id`.

## UC-05: Manage Orders

Primary actor: Admin/operator

Main flow:

1. Click `Order`.
2. System displays all records from `Orderall`.
3. Type in the search box to filter by order id, item name, or quantity.
4. Use the category filter for `Drink` or `Food`.
5. Click the editor button to open the order form.
6. Save, update, delete, or search order records.
7. Click report to open the order Crystal Report.

Data affected:

- `Orderall`
- `employees` is required as the parent table for `Orderall.employee_id`.

## UC-06: Manage Payments

Primary actor: Admin/operator

Main flow:

1. Click `Payment`.
2. System displays all records from `payment`.
3. Type in the search box to filter by payment id.
4. Use the method filter for `cash`, `card`, or `mobile`.
5. Click the editor button to open the payment form.
6. Save, update, delete, or search payment records.
7. Click report to open the payment Crystal Report.

Data affected:

- `payment`
- `Orderall` should exist before recording a payment.

## UC-07: Manage Salaries

Primary actor: Admin/operator

Main flow:

1. Click `Salary`.
2. System displays all records from `salary`.
3. Type in the search box to filter by salary id.
4. Click the editor button to open the salary form.
5. Save, update, delete, or search salary records.
6. Click report to open the salary Crystal Report.

Data affected:

- `salary`
- `employees` is required as the parent table for `salary.employee_id`.

## UC-08: Backup Database

Primary actor: Admin/operator

Preconditions:

- SQL Server account has permission to write the selected backup path.

Main flow:

1. Click `BackUp`.
2. Browse to select a `.bak` destination.
3. Click `Backup`.
4. System runs `BACKUP DATABASE [Cafeteria_management_C_DB] TO DISK='...'`.
5. System shows success or error.

## UC-09: Restore Database

Primary actor: Admin/operator

Preconditions:

- A compatible `.bak` file exists.
- SQL Server can access the selected path.
- No active connections block restore.

Main flow:

1. Click `BackUp`.
2. Browse to select a `.bak` file.
3. Click `Restore`.
4. System runs `RESTORE DATABASE [Cafeteria_management_C_DB] FROM DISK='...'`.
5. System shows success or error.

## UC-10: Log Out Or Exit

Primary actor: Admin/operator

Main flow:

1. Click `Logout` on the dashboard.
2. System opens the login screen and hides the dashboard.

Exit flow:

1. Click the close control.
2. System exits the application.
