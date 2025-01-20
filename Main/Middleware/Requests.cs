using Data_Layer;
using System.Data.OleDb;

namespace Middleware;
internal class Requests : Dir
{
    public string root;
    public string connectionS;
    public delegate void closingCtx();
    public Requests()
    {

        root = getPath();
        connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(root, "Resources", "Users.accdb")}";
    }
    public void GetUserData(UserClass user, string txt1, string txt2, Action OnLoginSuccess, closingCtx closing)
    {

        string queryS = @"SELECT ID, [PASSWORD], USERNAME, HS FROM UserData WHERE ID=@id";

        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            try
            {
                OleDbCommand loginCmd = new OleDbCommand(queryS, connection);

                loginCmd.Parameters.AddWithValue("@username", txt1);
                loginCmd.Parameters.AddWithValue("@password", txt2);

                OleDbDataReader reader = loginCmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("Wrong username or password");
                }
                while (reader.Read())
                {

                    user = new UserClass(reader["ID"].ToString(), reader["USERNAME"].ToString(), reader["PASSWORD"].ToString(), int.Parse(reader["HS"].ToString()));
                    modifyTextFileUserData(user.ID, root);
                }
                OnLoginSuccess?.Invoke();
                closing();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

        }

    }

    public void SetUserData(string txt1, string txt2, Action OnRegisterCompleted, closingCtx closing)
    {
        string queryS = @"INSERT INTO UserData ([PASSWORD], USERNAME, ID, HS) VALUES(@password, @username, @id, @hs)";
        string checkAvailability = $@"SELECT USERNAME FROM UserData WHERE USERNAME= @username";

        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            try
            {
                if (usernameExists(connection, checkAvailability, txt1))
                {
                    throw new Exception("Username already exists!");
                }
                OleDbCommand registerCmd = new OleDbCommand(queryS, connection);
                string userID = Guid.NewGuid().ToString();
                registerCmd.Parameters.AddWithValue("@password", txt2);
                registerCmd.Parameters.AddWithValue("@username", txt1);
                registerCmd.Parameters.AddWithValue("@id", userID);
                registerCmd.Parameters.AddWithValue("@hs", 0);

                registerCmd.ExecuteNonQuery();

                UserClass user = new UserClass(userID, txt1, txt2, 0);
                modifyTextFileUserData(userID, Path.Combine(root, "Resources", "currUser.txt"));
                OnRegisterCompleted?.Invoke();
                closing();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    private bool usernameExists(OleDbConnection connection, string checkAvailability, string txt1)
    {
        OleDbCommand avaibilityCmd = new OleDbCommand(checkAvailability, connection);
        avaibilityCmd.Parameters.AddWithValue("@username", txt1);
        OleDbDataReader avaibilityReader = avaibilityCmd.ExecuteReader();
        if (avaibilityReader.HasRows)
        {
            return true;
        }
        return false;
    }

    public void UpdateUserData(UserClass user)
    {
        string queryS = @"UPDATE UserData SET HS=@hs WHERE ID=@id";
        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            try
            {
                using (OleDbCommand command = new OleDbCommand(queryS, connection))
                {
                    command.Parameters.AddWithValue("@id", user.ID);
                    command.Parameters.AddWithValue("@hs", user.HighestScore);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public string getPath()
    {
        string path = Directory.GetCurrentDirectory();
        for (int i = 0; i < 5; i++)
        {
            path = Directory.GetParent(path).ToString();
        }
        return path;
    }

    public void modifyTextFileUserData(string id, string path, string operation = "")
    {
        if (operation == "DELELE")
        {
            File.WriteAllText(path, String.Empty);

        }
        else
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(id);
            }
        }
    }
}
