using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer;
internal interface IDir
{
    void modifyTextFileUserData(string path, string operation = "");
    string getPath(string currentDirectory, int i = 5);
}
