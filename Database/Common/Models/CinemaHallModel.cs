using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class CinemaHallModel
    {
        [DataMember]
        public int CinemaHallID { get; set; }
        [DataMember]
        public int Rows { get; set; }
        [DataMember]
        public int Positions { get; set; }
    }
}
