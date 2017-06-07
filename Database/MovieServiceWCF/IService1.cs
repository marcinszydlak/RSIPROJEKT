using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MovieServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        CinemaHallModel GetSala(int SalaID);
        [OperationContract]
        MovieModel GetFilm(int FilmID);
        [OperationContract]
        ReservationModel GetRezerwacja(int ReservationID);
        [OperationContract]
        List<ReservationModel> GetRezerwacje();
        [OperationContract]
        List<MovieModel> GetFilmy();
        [OperationContract]
        List<SeanceModel> GetSeanse();
        [OperationContract]
        void AddRezerwacja(int SeansID, int Rzad, int Miejsce);

        // TODO: Add your service operations here
    }
}
