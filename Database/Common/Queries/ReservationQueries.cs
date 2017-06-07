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
                    SeanceID = x.SeansID,
                    ClientID = x.KlientID,
                    ReservationInfo = x.RezerwacjeMiejsca.Select(y => new ReservationPositionModel()
                    {
                        ReservationID = y.RezerwacjaID,
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
                    SeanceID = x.SeansID,
                    ClientID = x.KlientID,
                    ReservationInfo = x.RezerwacjeMiejsca.Select(y => new ReservationPositionModel()
                    {
                        ReservationID = y.RezerwacjaID,
                        Position = y.Miejsce,
                        Row = y.Rzad,
                        ReservationPositionID = y.RezerwacjaMiejsceID
                    }).ToList()
                }).ToList();
            }
        }
        public static List<ReservationPositionModel> GetReservationPositions(int seanceID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.RezerwacjeMiejsca.Where(x => x.Rezerwacje.SeansID == seanceID).Select(x => new ReservationPositionModel()
                {
                    ReservationID = x.RezerwacjaID,
                    Position = x.Miejsce,
                    ReservationPositionID = x.RezerwacjaMiejsceID,
                    Row = x.Rzad
                }).ToList();
            }
        }
        public static void AddReservation(int seanceID,int rzad,int miejsce,int clientID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                Rezerwacje r = new Rezerwacje()
                {
                    DataRezerwacji = DateTime.Now,
                    SeansID = seanceID,
                    KlientID = clientID
                   
                };
                db.Rezerwacje.Add(r);
                db.SaveChanges();

                db.RezerwacjeMiejsca.Add(new RezerwacjeMiejsca()
                {
                    RezerwacjaID = r.RezerwacjaID,
                    Miejsce = miejsce,
                    Rzad = rzad
                });
                db.SaveChanges();
            }
        }
        public static void RemoveReservations(int seanceID,int clientID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.RezerwacjeMiejsca.RemoveRange(db.RezerwacjeMiejsca.Where(x => x.Rezerwacje.SeansID == seanceID && x.Rezerwacje.KlientID == clientID).ToList());
                db.Rezerwacje.Remove(db.Rezerwacje.Where(x => x.SeansID == seanceID).FirstOrDefault());
                db.SaveChanges();
            }
        }
        public static void RemoveReservation(int reservationID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.RezerwacjeMiejsca.RemoveRange(db.RezerwacjeMiejsca.Where(x => x.RezerwacjaID == reservationID).ToList());
                db.Rezerwacje.Remove(db.Rezerwacje.Where(x => x.RezerwacjaID == reservationID).FirstOrDefault());
                db.SaveChanges();
            }
        }
        public static void RemoveReservation(int reservationID,int row,int position)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                RezerwacjeMiejsca miejsce = db.RezerwacjeMiejsca.Where(x => x.RezerwacjaID == reservationID && x.Rzad == row && x.Miejsce == position).FirstOrDefault();
                db.RezerwacjeMiejsca.Remove(miejsce);
                db.SaveChanges();
                if(db.RezerwacjeMiejsca.Count() == 0)
                {
                    db.Rezerwacje.Remove(db.Rezerwacje.Where(x => x.RezerwacjaID == reservationID).FirstOrDefault());
                }
            }
        }
    }
}
