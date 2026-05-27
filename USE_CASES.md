# Use Cases

<style>
.uc-wrap{font-family:Segoe UI,Arial,sans-serif}.uc-hero{display:grid;grid-template-columns:1.15fr .85fr;gap:24px;align-items:center;margin:24px 0;padding:28px;border-radius:26px;background:linear-gradient(135deg,#7c2d12,#ea580c 48%,#e11d48);box-shadow:0 24px 55px rgba(234,88,12,.25);overflow:hidden;animation:ucFade .8s ease both}.uc-hero h2{margin:12px 0 10px;color:#fff;font-size:34px;line-height:1.05}.uc-hero p{color:#ffedd5;font-size:16px;line-height:1.65}.uc-tag{display:inline-block;margin:4px 6px 4px 0;padding:7px 12px;border-radius:999px;background:rgba(255,255,255,.16);color:#fff;border:1px solid rgba(255,255,255,.25);font-size:12px;font-weight:800}.uc-hero img{width:100%;height:245px;object-fit:cover;border-radius:20px;box-shadow:0 18px 40px rgba(0,0,0,.28);animation:ucFloat 5s ease-in-out infinite}.uc-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(185px,1fr));gap:14px;margin:22px 0}.uc-card{padding:18px;border-radius:20px;background:#fff;border:1px solid #fed7aa;box-shadow:0 16px 35px rgba(2,8,23,.09);transition:.25s ease;animation:ucFade .8s ease both}.uc-card:hover{transform:translateY(-6px);box-shadow:0 24px 50px rgba(234,88,12,.18)}.uc-card img{width:54px;height:54px;object-fit:contain}.uc-card h3{margin:10px 0 5px;color:#0f172a}.uc-card p{margin:0;color:#475569;line-height:1.45}.uc-lane{display:grid;grid-template-columns:repeat(auto-fit,minmax(135px,1fr));gap:10px;margin:20px 0}.uc-pill{padding:12px;border-radius:999px;background:linear-gradient(90deg,#fff7ed,#ffe4e6);border:1px solid #fed7aa;text-align:center;font-weight:900;color:#9a3412;animation:ucPulse 2.2s ease-in-out infinite}.uc-pill:nth-child(2){animation-delay:.15s}.uc-pill:nth-child(3){animation-delay:.3s}.uc-pill:nth-child(4){animation-delay:.45s}@keyframes ucFade{from{opacity:0;transform:translateY(18px)}to{opacity:1;transform:translateY(0)}}@keyframes ucFloat{0%,100%{transform:translateY(0)}50%{transform:translateY(-9px)}}@keyframes ucPulse{0%,100%{transform:scale(1)}50%{transform:scale(1.035)}}@media(max-width:760px){.uc-hero{grid-template-columns:1fr;padding:20px}.uc-hero h2{font-size:26px}}
</style>
<link rel="stylesheet" href="https://unpkg.com/aos@2.3.1/dist/aos.css">
<script src="https://cdn.tailwindcss.com"></script>
<script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
<script>
document.addEventListener("DOMContentLoaded",function(){document.querySelectorAll(".uc-card,.uc-pill").forEach(function(el,i){el.setAttribute("data-aos","flip-up");el.style.animationDelay=(i*90)+"ms"});if(window.AOS){AOS.init({duration:850,once:true,easing:"ease-out-cubic"})}});
</script>

<div class="uc-wrap">
  <div class="uc-hero">
    <div>
      <span class="uc-tag">Actors</span><span class="uc-tag">Actions</span><span class="uc-tag">Outcomes</span>
      <h2>Use Case Storyboard</h2>
      <p>The admin/operator signs in, opens a dashboard section, performs a focused task, and stores the result in the matching SQL table.</p>
      <div class="uc-lane"><div class="uc-pill">Login</div><div class="uc-pill">Manage</div><div class="uc-pill">Report</div><div class="uc-pill">Backup</div></div>
    </div>
    <img src="state/images.jpeg" alt="Cafeteria food photo" />
  </div>

  <div class="uc-grid">
    <div class="uc-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-login.gif" alt="Login animation" /><h3>Authenticate</h3><p>Log in or reset a password.</p></div>
    <div class="uc-card"><img src="SS_Assment_Cafateria_C%23/Resources/icons8-order-100.png" alt="Order icon" /><h3>Operate</h3><p>Create and review order records.</p></div>
    <div class="uc-card"><img src="SS_Assment_Cafateria_C%23/Resources/print_32px.png" alt="Print icon" /><h3>Report</h3><p>Open Crystal Report previews.</p></div>
    <div class="uc-card"><img src="SS_Assment_Cafateria_C%23/Resources/Refresh_32px.png" alt="Refresh icon" /><h3>Maintain</h3><p>Refresh lists, backup, and restore data.</p></div>
  </div>
</div>

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
