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
        loginForm.OnLoginSuccess += () =>
        {
            this.Show();
        };
        
        loginForm.OnRegisterRequested += () =>
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.OnRegisterCompleted += () => this.Show();
            registerForm.FormClosed += (a, b) => this.Show();
            registerForm.Show();
            this.Hide();
        };
        loginForm.FormClosed += (a, b) => this.Show();
        
        loginForm.Show();
    }

    private void HomeForm_Load(object sender, EventArgs e)
    {

    }
}
