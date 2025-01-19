using LoginPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Layer;
public partial class AccountInfo : Form
{
    public AccountInfo()
    {
        InitializeComponent();
    }
    LoginForm loginForm;
    private void AccountInfo_Load(object sender, EventArgs e)
    {
        loginForm = new LoginForm();
        textBox1.Text = loginForm.user.Name;
        
    }

}
