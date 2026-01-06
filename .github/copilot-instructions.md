# AI Coding Agent Instructions for Windows Forms Mini Project

## Project Overview
A Windows Forms application (C# .NET Framework 4.8.1) with a user management workflow: Registration → Login → View/Grid Display → Alignment/Navigation.

**Entry point:** [Program.cs](../Windows%20Form%20Mini%20Project/Program.cs) - creates and runs each form sequentially (currently all instantiated in Main).

## Architecture

### Form Hierarchy & Data Flow
- **Form1 (Registration)**: User data entry & SQL INSERT into `wfproject` table
- **Form2 (Registration_Successful)**: Confirmation screen
- **Form3 (Login_Page)**: Authentication via SQL SELECT with username/password
- **Form4 (View_Page)**: Dashboard/hub with navigation buttons
- **Form5 (Grid_View)**: DataGridView displaying all users via TableAdapter or SqlDataAdapter
- **Form6 (Alignment_Page)**: Layout/UI showcase form
- **Form7-9 (Forgot/Recovery)**: Password/username recovery flows

**Key pattern:** Forms navigate by `Show()`/`Hide()` instead of Form closing, maintaining state.

### Data Access
- **Database:** SQL Server (`.netSQL` on `TEJAS\SQL2025`)
- **Table:** `wfproject` with columns: user_id, first_name, last_name, username, email_id, password, confirm_password, phone_no, address, gender, age, language, country
- **Credentials in code:** Connection strings hardcoded in [Form1.cs](../Windows%20Form%20Mini%20Project/Form1.cs#L16), [Form3.cs](../Windows%20Form%20Mini%20Project/Form3.cs#L19), [Form5.cs](../Windows%20Form%20Mini%20Project/Form5.cs#L26) and [App.config](../Windows%20Form%20Mini%20Project/App.config)
- **Access methods:** SqlConnection/SqlCommand for manual queries; [__netSQLDataSet.xsd](../Windows%20Form%20Mini%20Project/__netSQLDataSet.xsd) TableAdapter for declarative data binding (used in Form5)

## Critical Developer Patterns

### SQL & Parameterization
- Forms use parameterized queries (`AddWithValue()`) to prevent injection—follow this pattern in new data operations.
- Example from Form3: `command.Parameters.AddWithValue("@username", username)`
- **TODO:** Connection strings should be moved to App.config and referenced via `ConfigurationManager` to match [App.config](../Windows%20Form%20Mini%20Project/App.config) pattern.

### Input Validation
Forms validate textbox values before SQL operations (empty checks in Form1). Use the same pattern: check for empty strings, show MessageBox, return early.

### Event Handlers
Buttons navigate forms (e.g., Form3 button1_Click opens Form4), labels act as links (Form3 label6_Click opens Forgot form). All event handlers follow `(object sender, EventArgs e)` signature.

## Build & Run
- **Framework:** .NET Framework 4.8.1
- **Project file:** [Windows Form Mini Project.csproj](../Windows%20Form%20Mini%20Project/Windows%20Form%20Mini%20Project.csproj)
- **Output:** WinExe (executable)
- **Build:** Standard MSBuild via Visual Studio or `msbuild` command
- **Debug/Release configs:** Available; output to `bin\Debug\` or `bin\Release\`

## File Organization
- Form code-behind: `FormN.cs` and `FormN.Designer.cs` (auto-generated—edit only `.cs` files)
- Resources: `FormN.resx` for form layouts; [Resources/](../Windows%20Form%20Mini%20Project/Resources/) for images/assets
- Dataset config: `__netSQLDataSet.*` files define the data layer (Designer/xsd/xss/xsc)

## When Adding New Forms
1. Create `FormN.cs` inheriting from `Form` with namespace `Windows_Form_Mini_Project`
2. Define navigation in button/label Click handlers using `Show()`/`Hide()`
3. Update [Program.cs](../Windows%20Form%20Mini%20Project/Program.cs) `Main()` to instantiate if needed (currently all forms are pre-instantiated—questionable practice)
4. Use SqlConnection/SqlCommand or TableAdapter for data access; follow parameterized query pattern
5. Add empty field validation before any database operations

## Known Issues to Address
- **Hardcoded credentials:** Extract connection strings to config (partial migration done to App.config—complete it)
- **Form instantiation:** Program.cs creates all forms upfront; consider lazy loading or single-instance pattern
- **No error handling:** Wrap SqlConnection in try-catch and provide user feedback on database failures
- **SQL injection risk mitigated** but queries could be centralized to a data access layer
