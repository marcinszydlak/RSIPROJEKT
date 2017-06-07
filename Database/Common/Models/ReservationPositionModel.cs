using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class ReservationPositionModel
    {
        [DataMember]
        public int ReservationPositionID { get; set; }
        [DataMember]
        public int ReservationID { get; set; }
        [DataMember]
        public int Row { get; set; }
        [DataMember]
        public int Position { get; set; }
    }
}
