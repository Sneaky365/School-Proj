using LoginPage;

namespace HomePage;

public partial class HomeForm : Form
{
    public HomeForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        LoginForm logP  = new LoginForm();
        this.Hide();
        logP.FormClosed += (arg, args) => this.Show();
        logP.ShowDialog();
    }
}
