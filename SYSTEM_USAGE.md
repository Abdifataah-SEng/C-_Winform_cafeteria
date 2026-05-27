# System Usage Guide

<style>
.su-wrap{font-family:Segoe UI,Arial,sans-serif}.su-hero{display:grid;grid-template-columns:1.15fr .85fr;gap:24px;align-items:center;margin:24px 0;padding:28px;border-radius:26px;background:linear-gradient(135deg,#312e81,#4f46e5 50%,#c026d3);box-shadow:0 24px 55px rgba(79,70,229,.25);overflow:hidden;animation:suFade .8s ease both}.su-hero h2{margin:12px 0 10px;color:#fff;font-size:34px;line-height:1.05}.su-hero p{color:#e0e7ff;font-size:16px;line-height:1.65}.su-tag{display:inline-block;margin:4px 6px 4px 0;padding:7px 12px;border-radius:999px;background:rgba(255,255,255,.16);color:#fff;border:1px solid rgba(255,255,255,.25);font-size:12px;font-weight:800}.su-hero img{width:100%;height:245px;object-fit:cover;border-radius:20px;box-shadow:0 18px 40px rgba(0,0,0,.28);animation:suFloat 5s ease-in-out infinite}.su-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(155px,1fr));gap:14px;margin:22px 0}.su-card{padding:16px;border-radius:20px;background:#fff;border:1px solid #ddd6fe;box-shadow:0 16px 35px rgba(2,8,23,.09);transition:.25s ease;text-align:center}.su-card:hover{transform:translateY(-6px);box-shadow:0 24px 50px rgba(79,70,229,.18)}.su-card img{width:52px;height:52px;object-fit:contain}.su-card h3{margin:10px 0 5px;color:#0f172a}.su-card p{margin:0;color:#475569;line-height:1.45}.su-mini{display:grid;grid-template-columns:repeat(auto-fit,minmax(150px,1fr));gap:10px;margin:20px 0}.su-mini div{padding:12px;border-radius:16px;background:linear-gradient(180deg,#eef2ff,#fff);border:1px solid #c7d2fe;text-align:center;font-weight:900;color:#3730a3;animation:suPulse 2.2s ease-in-out infinite}.su-mini div:nth-child(2){animation-delay:.15s}.su-mini div:nth-child(3){animation-delay:.3s}.su-mini div:nth-child(4){animation-delay:.45s}@keyframes suFade{from{opacity:0;transform:translateY(18px)}to{opacity:1;transform:translateY(0)}}@keyframes suFloat{0%,100%{transform:translateY(0)}50%{transform:translateY(-9px)}}@keyframes suPulse{0%,100%{transform:scale(1)}50%{transform:scale(1.035)}}@media(max-width:760px){.su-hero{grid-template-columns:1fr;padding:20px}.su-hero h2{font-size:26px}}
</style>
<link rel="stylesheet" href="https://unpkg.com/aos@2.3.1/dist/aos.css">
<script src="https://cdn.tailwindcss.com"></script>
<script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
<script>
document.addEventListener("DOMContentLoaded",function(){document.querySelectorAll(".su-card,.su-mini div").forEach(function(el,i){el.setAttribute("data-aos","fade-up");el.style.animationDelay=(i*80)+"ms"});if(window.AOS){AOS.init({duration:850,once:true,easing:"ease-out-cubic"})}});
</script>

<div class="su-wrap">
  <div class="su-hero">
    <div>
      <span class="su-tag">Step-by-step</span><span class="su-tag">Operator Guide</span><span class="su-tag">Reports</span>
      <h2>How To Use The System</h2>
      <p>Use the dashboard menu as the control center: log in, choose a module, work with records, print reports, and protect the database with backups.</p>
      <div class="su-mini"><div>Login</div><div>Open Module</div><div>Save/Search</div><div>Report</div></div>
    </div>
    <img src="state/SL-100820-36440-01.jpg" alt="Login screen visual from state folder" />
  </div>

  <div class="su-grid">
    <div class="su-card"><img src="SS_Assment_Cafateria_C%23/Resources/profile.png" alt="Profile icon" /><h3>Login</h3><p>Enter credentials.</p></div>
    <div class="su-card"><img src="SS_Assment_Cafateria_C%23/Resources/home.png" alt="Home image" /><h3>Dashboard</h3><p>Open a section.</p></div>
    <div class="su-card"><img src="SS_Assment_Cafateria_C%23/Resources/registration_32px.png" alt="Registration icon" /><h3>Create</h3><p>Add records.</p></div>
    <div class="su-card"><img src="SS_Assment_Cafateria_C%23/Resources/Refresh_32px.png" alt="Refresh icon" /><h3>Refresh</h3><p>Reload grids.</p></div>
    <div class="su-card"><img src="SS_Assment_Cafateria_C%23/Resources/print_32px.png" alt="Print icon" /><h3>Report</h3><p>Preview reports.</p></div>
  </div>
</div>

This guide explains how to use the Cafeteria Management System from the user interface.

## Before First Use

1. Create the SQL Server database described in [Database.md](Database.md).
2. Add at least one row to `dbo.userlogin`.
3. Make sure the app can connect to `(localdb)\ProjectModels`.
4. Build and run the Windows Forms project.

## Login

1. Start the app.
2. Wait for the loading screen to finish.
3. Enter the username.
4. Enter the password.
5. Optional: check `Show` to reveal the password field.
6. Click `Login`.

If login succeeds, the dashboard opens. If login fails, the app shows `Incorrect`.

## Forgot Password

1. On the login screen, click `Forgot password ?`.
2. Enter username, email, and full name.
3. Click `Check`.
4. If verified, enter a new password and confirmation password.
5. Click `Change`.

Note: the current code has database naming inconsistencies in this workflow. See [Database.md](Database.md).

## Dashboard

Use the left menu to open each section:

- `Dashbourd` for totals and charts.
- `Order` for order list, filters, editor, and order report.
- `Payment` for payment list, filters, editor, and payment report.
- `Employees` for employee list, search, editor, and employee report.
- `Salary` for salary list, search, editor, and salary report.
- `BackUp` for backup and restore.
- `Logout` to return to the login screen.

## Employees

To view employees:

1. Click `Employees`.
2. The grid loads all `employees` records.
3. Type in the search box to filter by first name or last name.
4. Click refresh to reload the full list.

To add an employee:

1. Click the employee editor button.
2. Enter user login id, first name, last name, position, hire date, email, phone, hourly rate, and monthly salary.
3. Click `Save`.

To update an employee:

1. Enter the employee id.
2. Click `Search`.
3. Change the values.
4. Click `Update`.

To delete an employee:

1. Enter the employee id.
2. Click `Delete`.

To print/view report:

1. Click the report button.
2. The Crystal Report viewer opens.

## Orders

To view orders:

1. Click `Order`.
2. The grid loads all `Orderall` records.
3. Type in the search box to filter by order id, item name, or quantity.
4. Use the category dropdown to filter by `Drink` or `Food`.
5. Click refresh to reload the full list.

To add an order:

1. Click the order editor button.
2. Enter employee id, order date, notes, item name, category, item price, quantity, unit price, and total amount.
3. Click `Save`.

To update an order:

1. Enter the order id.
2. Click `Search`.
3. Change the values.
4. Click `Update`.

To delete an order:

1. Enter the order id.
2. Click `Delete`.

To print/view report:

1. Click the report button.
2. The Crystal Report viewer opens.

## Payments

To view payments:

1. Click `Payment`.
2. The grid loads all `payment` records.
3. Type in the search box to filter by payment id.
4. Use the method dropdown to filter by `cash`, `card`, or `mobile`.
5. Click refresh to reload the full list.

To add a payment:

1. Click the payment editor button.
2. Enter order id, amount, payment method, payment date, and status.
3. Optionally leave payment id blank so the database identity can generate it.
4. Click `Save`.

To update a payment:

1. Enter the payment id.
2. Click `Search`.
3. Change the values.
4. Click `Update`.

To delete a payment:

1. Enter the payment id.
2. Click `Delete`.

To print/view report:

1. Click the report button.
2. The Crystal Report viewer opens.

## Salary

To view salaries:

1. Click `Salary`.
2. The grid loads all `salary` records.
3. Type in the search box to filter by salary id.
4. Click refresh to reload the full list.

To add a salary record:

1. Click the salary editor button.
2. Enter employee id, salary month, base salary, bonuses, deductions, payment date, and notes.
3. Click `Save`.

To update a salary record:

1. Enter the salary id.
2. Click `Search`.
3. Change the values.
4. Click `Update`.

To delete a salary record:

1. Enter the salary id.
2. Click `Delete`.

To print/view report:

1. Click the report button.
2. The Crystal Report viewer opens.

## Backup

To create a database backup:

1. Click `BackUp`.
2. Click `Browse` beside the backup path.
3. Choose a `.bak` file path.
4. Click `Backup`.

To restore a database backup:

1. Click `BackUp`.
2. Browse for a `.bak` backup file.
3. Click `Restore`.

The SQL Server process must have access to the selected file path.
