using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Common.Models;

namespace Common.Queries
{
    public static class ReservationQueries
    {
        public static ReservationModel GetReservation(int ID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Rezerwacje.Where(x => x.RezerwacjaID == ID).Select(x => new ReservationModel()
                {
                    ReservationID = x.RezerwacjaID,
                    ReservationDate = x.DataRezerwacji,
                    SeanceID = x.SeansID.Value,
                    ReservationInfo = x.RezerwacjeMiejsca.Select(y => new ReservationPositionModel()
                    {
                        ReservationID = y.RezerwacjaID.Value,
                        Position = y.Miejsce,
                        Row = y.Rzad,
                        ReservationPositionID = y.RezerwacjaMiejsceID
                    }).ToList()
                }).FirstOrDefault();
            }
        }
        public static List<ReservationModel> GetReservations()
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Rezerwacje.Select(x => new ReservationModel()
                {
                    ReservationID = x.RezerwacjaID,
                    ReservationDate = x.DataRezerwacji,
                    SeanceID = x.SeansID.Value,
                    ReservationInfo = x.RezerwacjeMiejsca.Select(y => new ReservationPositionModel()
                    {
                        ReservationID = y.RezerwacjaID.Value,
                        Position = y.Miejsce,
                        Row = y.Rzad,
                        ReservationPositionID = y.RezerwacjaMiejsceID
                    }).ToList()
                }).ToList();
            }
        }
        public static void AddReservation(int SeansID,int Rzad,int Miejsce)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                Rezerwacje r = new Rezerwacje()
                {
                    DataRezerwacji = DateTime.Now,
                    SeansID = SeansID
                };
                db.Rezerwacje.Add(r);
                db.SaveChanges();

                db.RezerwacjeMiejsca.Add(new RezerwacjeMiejsca()
                {
                    RezerwacjaID = r.RezerwacjaID,
                    Miejsce = Miejsce,
                    Rzad = Rzad
                });
                db.SaveChanges();
            }
        }
    }
}
