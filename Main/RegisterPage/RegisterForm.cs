using Microsoft.VisualBasic.ApplicationServices;
using System.Data.OleDb;

namespace RegisterPage;

public partial class RegisterForm : Form
{
    
    public RegisterForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectRoot = getPath(currentDirectory);

        string queryS = @"INSERT INTO UserData ([PASSWORD], USERNAME, ID, HS) 
                            VALUES(@password, @username, @id, @hs)";
        string dbRelative = Path.Combine(projectRoot, "Resources", "Users.accdb");
        
        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbRelative};";
        MessageBox.Show(connectionS);
        try
        {
            using(OleDbConnection connection = new OleDbConnection(connectionS))
            {
                try
                {
                    OleDbCommand registerCmd = new OleDbCommand(queryS, connection);
                    string userID = Guid.NewGuid().ToString();
                    registerCmd.Parameters.AddWithValue("@password", textBox2.Text);
                    registerCmd.Parameters.AddWithValue("@username", textBox1.Text);
                    registerCmd.Parameters.AddWithValue("@id", userID);
                    registerCmd.Parameters.AddWithValue("@hs", 0);

                    registerCmd.ExecuteNonQuery();
                    
                   
                    this.Close();
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        catch(Exception ex)
        {

        }
    }
    private string getPath(string currentDirectory, int i = 5)
    {
        for (int p = 0; p < i; p++)
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }
        return currentDirectory;
    }
    private void modifyTextFileUserData(string operation, string path)
    {
        if (operation == "DELELE")
        {
            File.WriteAllText(path, String.Empty);
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                //sw.WriteLine(user.ID);
            }
        }
    }
}
