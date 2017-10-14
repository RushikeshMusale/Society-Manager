using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManager.Data.Helpers
{
    public class PersonEmailEqualityComp : EqualityComparer<Person>
    {
        public override bool Equals(Person x, Person y)
        {
            if(x.Email==y.Email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(Person obj)
        {
            return obj.Email.GetHashCode();
        }
    }
}