using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService_Consumer.Models
{
    public interface IPerson
    {       
        string GetName();
        string GetSonsName();
        string GreetingMessage();
    }
}
