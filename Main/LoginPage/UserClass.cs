using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer;
 public class UserClass
{
    public string Name { get; set; }
    public string Password { get; set; }
    public int HighestScore { get; set; }
    public string ID { get; set; }
    
    public UserClass(string id, string name, string password, int highestScore)
    {
        this.Name = name;
        this.Password = password;
        this.ID = id;
        this.HighestScore = highestScore;

    }

   
}
