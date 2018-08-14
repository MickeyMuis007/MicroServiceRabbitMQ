using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService_Consumer.Models
{
    [Serializable]
    public class Son : IPerson
    {
        /* Class Properties */
        public string Name { get; set; }
        public string SonsName { get; set; }

        /* Constructors */

        //Default Constructor
        public Son()
        {
            Name = "";
            SonsName = "";
        }
        
        //Constructor setting Name and SonsName property
        public Son(string name, string sonsName)
        {
            Name = name;
            SonsName = sonsName;
        }

        /* IPerson Interface Implemtations */
        
        //Get Name
        public string GetName()
        {
            return Name;
        }

        //Get SonsName
        public string GetSonsName()
        {
            return SonsName;
        }

        //Get greeting method from Son
        public string GreetingMessage()
        {
            var msg = "";
            if(Name != "")
            {
                msg = "Hello my name is " + Name;
            }

            return msg;
        }
    }
}
