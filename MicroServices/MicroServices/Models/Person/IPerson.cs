using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.Models
{
    public interface IPerson
    {
        string GetName();
        string GetSonsName();
        string GreetingMessage();
    }
}
