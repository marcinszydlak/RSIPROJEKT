using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Common.Models;
using Common.Queries;

namespace MovieServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void AddRezerwacja(int SeansID, int Rzad, int Miejsce)
        {
            ReservationQueries.AddReservation(SeansID, Rzad, Miejsce);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public MovieModel GetFilm(int FilmID)
        {
            return MovieQueries.GetMovie(FilmID);
        }

        public List<MovieModel> GetFilmy()
        {
            throw new NotImplementedException();
        }

        public ReservationModel GetRezerwacja(int ReservationID)
        {
            return ReservationQueries.GetReservation(ReservationID);
        }

        public List<ReservationModel> GetRezerwacje()
        {
            return ReservationQueries.GetReservations();
        }

        public CinemaHallModel GetSala(int SalaID)
        {
            return CinemaHallsQueries.GetCinemaHall(SalaID);
        }

        public List<SeanceModel> GetSeanse()
        {
            return SeanceQueries
        }
    }
}
