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
        public void AddReservationMultiplePosition(int seanceId, int clientId, int[] rows, int[] positions)
        {
            try
            {
                for (int i = 0; i < rows.Count(); i++)
                {
                    if (ReservationQueries.ReservationExists(seanceId, rows[i], positions[i]))
                    {
                        ReservationQueries.AddReservation(seanceId, rows[i], positions[i], clientId);
                    }
                    else
                    {
                        throw new Exception("Rezerwacja już istnieje");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public void AddReservationSinglePosition(int seanceId, int clientId, int row, int position)
        {
            try
            {
                if (!ReservationQueries.ReservationExists(seanceId, row, position))
                {
                    ReservationQueries.AddReservation(seanceId, row, position, clientId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public void UpdateReservation(int reservationPositionId,int newRow,int newPosition)
        {
            ReservationQueries.UpdateReservation(reservationPositionId, newRow, newPosition);
        }

        public List<ReservationPositionModel> GetActualCinemaHallState(int seanceId)
        {
            try
            {
                return ReservationQueries.GetReservationPositions(seanceId);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public CinemaHallModel GetCinemaHall(int cinemaHallId)
        {
            try
            {
                return CinemaHallsQueries.GetCinemaHall(cinemaHallId);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public List<CinemaHallModel> GetCinemaHallsForMovie(MovieModel model)
        {
            try
            {
                List<CinemaHallModel> cinemaHalls = new List<CinemaHallModel>();
                List<int> cinemaHallsID = SeanceQueries.GetSeances(model.MovieID).Select(x => x.CinemaHallID).Distinct().ToList();
                foreach (int cinemaHallID in cinemaHallsID)
                {
                    cinemaHalls.Add(CinemaHallsQueries.GetCinemaHall(cinemaHallID));
                }
                return cinemaHalls;
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public MovieModel GetMovie(int movieId)
        {
            try
            {
                return MovieQueries.GetMovie(movieId);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public List<MovieModel> GetMovies()
        {
            try
            {
                return MovieQueries.GetMovies();
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public ReservationModel GetReservation(int reservationId)
        {
            try
            {
                return ReservationQueries.GetReservation(reservationId);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public List<ReservationModel> GetReservations(int clientId)
        {
            try
            {
                return ReservationQueries.GetReservations().Where(x => x.ClientID == clientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public List<SeanceModel> GetSeancesByTitle(string title)
        {
            try
            {
                return SeanceQueries.GetSeances(title);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public List<SeanceModel> GetSeancesByMovieId(int movieId)
        {
            try
            {
                return SeanceQueries.GetSeances(movieId);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public ClientModel Login(string login, string password)
        {
            try
            {
                ClientModel model = ClientQueries.Login(login, password);
                if (model == null)
                {
                    throw new Exception("Nie istnieje użytkownik o podanych danych");
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveReservation(int reservationId, int? row = null, int? position = null)
        {
            try
            {
                if (row.HasValue && position.HasValue)
                {
                    ReservationQueries.RemoveReservation(reservationId, row.Value, position.Value);
                }
                else
                {
                    ReservationQueries.RemoveReservation(reservationId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }

        public void RemoveReservations(int reservationId, int[] rows, int[] positions)
        {
            try
            {
                for (int i = 0; i < rows.Count(); i++)
                {
                    ReservationQueries.RemoveReservation(reservationId, rows[i], positions[i]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił problem z wywołaniem żądania", ex);
            }
        }
    }
}
