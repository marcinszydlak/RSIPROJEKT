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
                    }).ToList(),
                    SeanceInfo = new SeanceModel()
                    {
                        CinemaHallID = x.Seanse.SalaID,
                        MovieID = x.Seanse.FilmID,
                        MovieInfo = new MovieModel()
                        {
                            MovieID = x.Seanse.Filmy.FilmID,
                            Cast = x.Seanse.Filmy.Obsada,
                            Description = x.Seanse.Filmy.Opis,
                            ImageContent = x.Seanse.Filmy.Zdjecie,
                            Note = x.Seanse.Filmy.Ocena,
                            PublicationDate = x.Seanse.Filmy.RokWydania,
                            Regisseur = x.Seanse.Filmy.Rezyser,
                            Title = x.Seanse.Filmy.Tytul
                        },
                        SeanceDate = x.Seanse.DataSeansu

                    }
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
                    }).ToList(),
                    SeanceInfo = new SeanceModel()
                    {
                        CinemaHallID = x.Seanse.SalaID,
                        MovieID = x.Seanse.FilmID,
                        MovieInfo = new MovieModel()
                        {
                            MovieID = x.Seanse.Filmy.FilmID,
                            Cast = x.Seanse.Filmy.Obsada,
                            Description = x.Seanse.Filmy.Opis,
                            ImageContent = x.Seanse.Filmy.Zdjecie,
                            Note = x.Seanse.Filmy.Ocena,
                            PublicationDate = x.Seanse.Filmy.RokWydania,
                            Regisseur = x.Seanse.Filmy.Rezyser,
                            Title = x.Seanse.Filmy.Tytul
                        },
                        SeanceDate = x.Seanse.DataSeansu
                        
                    }
                   
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
        public static bool ReservationExists(int seanceID, int rzad, int miejsce)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.RezerwacjeMiejsca.Where(x => x.Rezerwacje.SeansID == seanceID && x.Rzad == rzad && x.Miejsce == miejsce).FirstOrDefault() != null;
            }
        }
        public static void AddReservation(int seanceID,int rzad,int miejsce,int clientID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                Rezerwacje r = db.Rezerwacje.Where(x => x.SeansID == seanceID && x.KlientID == clientID).FirstOrDefault();
                if (r == null)
                {
                    r = new Rezerwacje()
                    {
                        DataRezerwacji = DateTime.Now,
                        SeansID = seanceID,
                        KlientID = clientID
                    };

                    db.Rezerwacje.Add(r);
                    db.SaveChanges();
                }
                int val = r.RezerwacjaID;
                db.RezerwacjeMiejsca.Add(new RezerwacjeMiejsca()
                {
                    RezerwacjaID = val,
                    Miejsce = miejsce,
                    Rzad = rzad
                });
                db.SaveChanges();
            }
        }
        public static void UpdateReservation(int reservationPositionID,int newRow,int newPosition)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                RezerwacjeMiejsca rezerwowane = db.RezerwacjeMiejsca.Where(x => x.RezerwacjaMiejsceID == reservationPositionID).FirstOrDefault();
                rezerwowane.Rzad = newRow;
                rezerwowane.Miejsce = newPosition;
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
