using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class SeanceModel
    {
        [DataMember]
        public int SeanceID { get; set; }
        [DataMember]
        public int MovieID { get; set; }
        [DataMember]
        public int CinemaHallID { get; set; }
        [DataMember]
        public DateTime SeanceDate { get; set; }
        [DataMember]
        public MovieModel MovieInfo { get; set; }
    }
}
