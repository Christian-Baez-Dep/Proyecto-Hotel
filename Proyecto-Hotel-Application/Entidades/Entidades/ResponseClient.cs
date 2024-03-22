using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entidades
{
    public class ResponseClient
    {
        public ResponseClient(int Id, string Name, string LastName)
        {
            this.Id = Id;
            this.Name = Name;
            this.LastName = LastName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


    }
}
