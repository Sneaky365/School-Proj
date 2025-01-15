namespace LoginPage;
using RegisterPage;
using System.Data.OleDb;
public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        string dbAbsolute = @"Resources\Users.acdbb";
        string dbRelative = Path.GetFullPath(dbAbsolute);

        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=${dbRelative};";
        string queryS = @"INSERT INTO UserData ([PASSWORD], USERNAME, ID)
                            VALUES(@password, @username, @id)";
        
        MessageBox.Show(connectionS);
        this.Close();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        RegisterForm registerForm = new RegisterForm();
        this.Hide();
        registerForm.FormClosed += (arg, args) => this.Show();
        registerForm.Show();

    }
}
