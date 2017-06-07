using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class MovieModel
    {
        [DataMember]
        public int MovieID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Regisseur { get; set; }
        [DataMember]
        public int PublicationDate { get; set; }
        [DataMember]
        public string Cast { get; set; }
        [DataMember]
        public decimal Note { get; set; }
        [DataMember]
        public byte[] ImageContent { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
