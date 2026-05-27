# Cafeteria Management System

<style>
.cm-wrap{font-family:Segoe UI,Arial,sans-serif;color:#10201b}.cm-hero{display:grid;grid-template-columns:1.25fr .75fr;gap:24px;align-items:center;margin:24px 0;padding:28px;border-radius:26px;background:linear-gradient(135deg,#06281f,#0f766e 48%,#38bdf8);box-shadow:0 24px 55px rgba(15,118,110,.28);overflow:hidden;animation:cmFade .8s ease both}.cm-hero h2{margin:12px 0 10px;color:#fff;font-size:34px;line-height:1.05}.cm-hero p{color:#dffcf4;font-size:16px;line-height:1.65}.cm-chip{display:inline-block;margin:4px 6px 4px 0;padding:7px 12px;border-radius:999px;background:rgba(255,255,255,.16);color:#fff;border:1px solid rgba(255,255,255,.25);font-size:12px;font-weight:700}.cm-type{display:inline-block;max-width:100%;overflow:hidden;white-space:nowrap;border-right:3px solid #a7f3d0;animation:cmType 3.4s steps(34,end),cmCursor .8s step-end infinite}.cm-hero img{width:100%;height:245px;object-fit:cover;border-radius:20px;box-shadow:0 18px 40px rgba(0,0,0,.28);animation:cmFloat 5s ease-in-out infinite}.cm-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(180px,1fr));gap:16px;margin:24px 0}.cm-card{padding:18px;border-radius:20px;background:#fff;border:1px solid #dbeafe;box-shadow:0 16px 35px rgba(2,8,23,.09);transition:.25s ease;animation:cmFade .8s ease both}.cm-card:hover{transform:translateY(-6px);box-shadow:0 24px 50px rgba(15,118,110,.18)}.cm-card img{width:54px;height:54px;object-fit:contain}.cm-card h3{margin:10px 0 5px;color:#0f172a}.cm-card p{margin:0;color:#475569;line-height:1.45}.cm-shots{display:grid;grid-template-columns:repeat(auto-fit,minmax(210px,1fr));gap:14px;margin:18px 0 28px}.cm-shot{position:relative;overflow:hidden;border-radius:20px;box-shadow:0 18px 40px rgba(15,23,42,.16)}.cm-shot img{width:100%;height:170px;object-fit:cover;display:block;transition:.3s ease}.cm-shot:hover img{transform:scale(1.06)}.cm-shot span{position:absolute;left:12px;bottom:12px;padding:7px 11px;border-radius:999px;background:rgba(2,6,23,.72);color:#fff;font-size:12px;font-weight:700}.cm-flow{display:grid;grid-template-columns:repeat(auto-fit,minmax(130px,1fr));gap:10px;margin:20px 0}.cm-step{padding:14px;border-radius:16px;background:linear-gradient(180deg,#ecfeff,#fff);border:1px solid #bae6fd;text-align:center;font-weight:800;color:#075985;animation:cmPulse 2.2s ease-in-out infinite}.cm-step:nth-child(2){animation-delay:.2s}.cm-step:nth-child(3){animation-delay:.4s}.cm-step:nth-child(4){animation-delay:.6s}.cm-step:nth-child(5){animation-delay:.8s}@keyframes cmFade{from{opacity:0;transform:translateY(18px)}to{opacity:1;transform:translateY(0)}}@keyframes cmFloat{0%,100%{transform:translateY(0)}50%{transform:translateY(-9px)}}@keyframes cmType{from{width:0}to{width:100%}}@keyframes cmCursor{50%{border-color:transparent}}@keyframes cmPulse{0%,100%{transform:scale(1)}50%{transform:scale(1.035)}}@media(max-width:760px){.cm-hero{grid-template-columns:1fr;padding:20px}.cm-hero h2{font-size:26px}.cm-type{white-space:normal;border-right:0}}
</style>
<link rel="stylesheet" href="https://unpkg.com/aos@2.3.1/dist/aos.css">
<script src="https://cdn.tailwindcss.com"></script>
<script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
<script>
document.addEventListener("DOMContentLoaded",function(){document.querySelectorAll(".cm-card,.cm-shot,.cm-step").forEach(function(el,i){el.setAttribute("data-aos","fade-up");el.style.animationDelay=(i*90)+"ms"});if(window.AOS){AOS.init({duration:850,once:true,easing:"ease-out-cubic"})}});
</script>

<div class="cm-wrap">
  <div class="cm-hero">
    <div>
      <span class="cm-chip">Windows Forms</span><span class="cm-chip">SQL Server LocalDB</span><span class="cm-chip">Crystal Reports</span>
      <h2><span class="cm-type">Cafeteria Management System</span></h2>
      <p>A desktop admin app for managing cafeteria employees, orders, payments, salary records, reports, and database backup/restore.</p>
      <div class="cm-flow">
        <div class="cm-step">Splash</div><div class="cm-step">Login</div><div class="cm-step">Dashboard</div><div class="cm-step">CRUD</div><div class="cm-step">Reports</div>
      </div>
    </div>
    <img src="SS_Assment_Cafateria_C%23/Resources/plash.png" alt="Cafeteria food overview" />
  </div>

  <div class="cm-grid">
    <div class="cm-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-employee-64.png" alt="Employee icon" /><h3>Employees</h3><p>Staff profiles, search, reports, and payroll links.</p></div>
    <div class="cm-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-order-100.png" alt="Order icon" /><h3>Orders</h3><p>Food and drink orders with totals and category charts.</p></div>
    <div class="cm-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-payment-64.png" alt="Payment icon" /><h3>Payments</h3><p>Cash, card, and mobile payment tracking.</p></div>
    <div class="cm-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-salary-94.png" alt="Salary icon" /><h3>Salary</h3><p>Salary month, bonuses, deductions, and reports.</p></div>
  </div>
</div>

This repository contains a Windows Forms cafeteria management application written in C# for .NET Framework 4.7.2. The project name is `SS_Assment_Cafateria_C#`, and the application is designed for an administrator/operator who manages cafeteria employees, orders, payments, salaries, reports, and database backup/restore.

The application uses SQL Server LocalDB through `System.Data.SqlClient`. The configured database is:

```text
(localdb)\ProjectModels
Cafeteria_management_C_DB
```

## What The App Does

<div class="cm-wrap">
  <div class="cm-shots">
    <div class="cm-shot"><img src="state/SL-100820-36440-01.jpg" alt="Modern login visual" /><span>Login concept</span></div>
    <div class="cm-shot"><img src="state/ChatGPT%20Image%20May%2028%2C%202026%2C%2012_01_30%20AM.png" alt="Database schema visual" /><span>Database schema</span></div>
    <div class="cm-shot"><img src="state/ChatGPT%20Image%20May%2027%2C%202026%2C%2011_44_28%20PM.png" alt="Data flow visual" /><span>Data flow</span></div>
  </div>
</div>

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
