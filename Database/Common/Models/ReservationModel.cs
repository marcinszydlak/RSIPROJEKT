using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class ReservationModel
    {
        [DataMember]
        public int ReservationID { get; set; }
        [DataMember]
        public int SeanceID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public DateTime ReservationDate { get; set; }
        [DataMember]
        public List<ReservationPositionModel> ReservationInfo { get; set; }
        [DataMember]
        public SeanceModel SeanceInfo { get; set; }
    }
}
