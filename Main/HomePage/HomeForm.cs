using LoginPage;
using RegisterPage;
using System.Data.OleDb;
namespace HomePage;

public partial class HomeForm : Form
{
    public HomeForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();

        LoginForm loginForm = new LoginForm();
        RegisterForm registerForm = null;

        loginForm.OnLoginSuccess += () =>
        {
            this.Show();
        };
        
        loginForm.OnRegisterRequested += () =>
        {
            if(registerForm == null || registerForm.IsDisposed)
            {
                registerForm = new RegisterForm();
                registerForm.OnRegisterCompleted += () => this.Show();
                registerForm.OnReturningToHome += () =>
                {
                    this.Show();
                };
                registerForm.OnReturningToLogin += () =>
                {
                    loginForm.Show();
                };
            }             
            registerForm.Show();
            this.Hide();
        };
        loginForm.FormClosed += (a, b) => this.Show();
        loginForm.OnHomeRequested += () => this.Show();
        loginForm.Show();
    }

    private void HomeForm_Load(object sender, EventArgs e)
    {

    }
}
