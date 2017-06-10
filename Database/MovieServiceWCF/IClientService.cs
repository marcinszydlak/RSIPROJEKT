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
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        ClientModel Login(string login, string password);
        [OperationContract]
        List<SeanceModel> GetSeancesByMovieId(int movieId);
        [OperationContract]
        List<SeanceModel> GetSeancesByTitle(string title);
        [OperationContract]
        void AddReservationSinglePosition(int seanceId,int clientId, int row, int position);
        [OperationContract]
        void AddReservationMultiplePosition(int seanceId,int clientId, int[] rows, int[] positions);
        [OperationContract]
        void UpdateReservation(int reservationPositionId, int newRow, int newPosition);
        [OperationContract]
        ReservationModel GetReservation(int ReservationId);
        [OperationContract]
        List<ReservationModel> GetReservations(int clientId);
        [OperationContract]
        void RemoveReservation(int reservationId, int? row = null, int? position = null);
        [OperationContract]
        void RemoveReservations(int reservationId, int[] rows, int[] positions);
        [OperationContract]
        MovieModel GetMovie(int movieId);
        [OperationContract]
        List<MovieModel> GetMovies();
        [OperationContract]
        CinemaHallModel GetCinemaHall(int cinemaHallId);
        [OperationContract]
        List<CinemaHallModel> GetCinemaHallsForMovie(MovieModel model);
        [OperationContract]
        List<ReservationPositionModel> GetActualCinemaHallState(int seanceId);
        

        // TODO: Add your service operations here
    }
}
