using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.Models
{
    [Serializable]
    public class Father : IPerson
    {
        /* Class Properties */
        public string Name { get; set; }
        public string SonsName { get; set; }

        /* Constructors */

        //Default Constructor
        public Father()
        {
            Name = "";
            SonsName = "";
        }

        //Constructor setting Name property
        public Father(string name, string sonsName)
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

        //Get greeting message from father
        public string GreetingMessage()
        {
            var msg = "";
            if (SonsName != "")
            {
                msg = "Hello " + SonsName + " I am your father!";
            }
            return msg;
        }

    }
}
