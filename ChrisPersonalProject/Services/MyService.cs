using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisPersonalProject.Services
{
    public class MyService : IMyService
    {
        public string ShowMessage()
        {
            return "Test Message Interfaz";
        }
    }
}
