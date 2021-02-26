using System.Collections.Generic;

namespace Normfall_studie
{
    public class User
    {
        public int UserId { get; set; }

        public ICollection<Property_Owner> Property_Owners { get; set; }
    }
}
