using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer;
internal interface IData
{
    void modifyTextFileUserData(string path, string operation = "");
    string getPath(string currentDirectory, int i = 5);
}
