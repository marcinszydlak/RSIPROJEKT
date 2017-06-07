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
        List<SeanceModel> GetSeances(int movieId);
        [OperationContract]
        List<SeanceModel> GetSeances(string title);
        [OperationContract]
        void AddReservation(int seanceId,int clientId, int row, int position);
        [OperationContract]
        void AddReservation(int seanceId,int clientId, int[] rows, int[] positions);
        [OperationContract]
        ReservationModel GetReservation(int ReservationId);
        [OperationContract]
        List<ReservationModel> GetReservations(int clientId);
        [OperationContract]
        void RemoveReservation(int reservationId);
        [OperationContract]
        void RemoveReservation(int reservationId, int row, int position);
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
