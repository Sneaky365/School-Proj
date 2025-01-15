using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage;
internal class UserClass
{
    public string Name { get; set; }
    public string Password { get; set; }
    public int HighestScore { get; set; }
    public string ID { get; set; }
    
    public UserClass(string name, string password, string id, int highestScore)
    {
        this.Name = name;
        this.Password = password;
        this.ID = id;
        this.HighestScore = highestScore;

    }

   
}
