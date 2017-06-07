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
    public class ClientService : IClientService
    {
        public void AddReservation(int seanceId, int clientId, int[] rows, int[] positions)
        {
            for (int i = 0; i < rows.Count(); i++)
            {
                ReservationQueries.AddReservation(seanceId, clientId, rows[i], positions[i]);
            }
        }

        public void AddReservation(int seanceId, int clientId, int row, int position)
        {
            ReservationQueries.AddReservation(seanceId, clientId, row, position);
        }

        public List<ReservationPositionModel> GetActualCinemaHallState(int seanceId)
        {
            return ReservationQueries.GetReservationPositions(seanceId);
        }

        public CinemaHallModel GetCinemaHall(int cinemaHallId)
        {
            return CinemaHallsQueries.GetCinemaHall(cinemaHallId);
        }

        public List<CinemaHallModel> GetCinemaHallsForMovie(MovieModel model)
        {
            List<CinemaHallModel> cinemaHalls = new List<CinemaHallModel>();
            List<int> cinemaHallsID = SeanceQueries.GetSeances(model.MovieID).Select(x => x.CinemaHallID).Distinct().ToList();
            foreach(int cinemaHallID in cinemaHallsID)
            {
                cinemaHalls.Add(CinemaHallsQueries.GetCinemaHall(cinemaHallID));
            }
            return cinemaHalls;
        }

        public MovieModel GetMovie(int movieId)
        {
            return MovieQueries.GetMovie(movieId);
        }

        public List<MovieModel> GetMovies()
        {
            return MovieQueries.GetMovies();
        }

        public ReservationModel GetReservation(int reservationId)
        {
            return ReservationQueries.GetReservation(reservationId);
        }

        public List<ReservationModel> GetReservations(int clientId)
        {
            return ReservationQueries.GetReservations().Where(x => x.ClientID == clientId).ToList();
        }

        public List<SeanceModel> GetSeances(string title)
        {
            return SeanceQueries.GetSeances(title);
        }

        public List<SeanceModel> GetSeances(int movieId)
        {
            return SeanceQueries.GetSeances(movieId);
        }

        public ClientModel Login(string login, string password)
        {
            ClientModel model = ClientQueries.Login(login, password);
            if(model == null)
            {
                throw new Exception("Nie istnieje użytkownik o podanych danych");
            }
            return model;
        }

        public void RemoveReservation(int reservationId)
        {
            ReservationQueries.RemoveReservation(reservationId);
        }

        public void RemoveReservation(int reservationId, int row, int position)
        {
            ReservationQueries.RemoveReservation(reservationId, row, position);
        }

        public void RemoveReservations(int reservationId, int[] rows, int[] positions)
        {
            for(int i=0;i< rows.Count();i++)
            {
                ReservationQueries.RemoveReservation(reservationId,rows[i],positions[i]);
            }
        }
    }
}
