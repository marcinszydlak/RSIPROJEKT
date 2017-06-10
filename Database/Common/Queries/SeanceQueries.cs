using Common.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public static class SeanceQueries
    {
        public static List<SeanceModel> GetSeances()
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Seanse.Select(x => new SeanceModel()
                {
                    SeanceID = x.SeansID,
                    CinemaHallID = x.SalaID,
                    MovieID = x.FilmID,
                    SeanceDate = x.DataSeansu,
                    MovieInfo = new MovieModel()
                    {
                        MovieID = x.FilmID,
                        Cast = x.Filmy.Obsada,
                        Description = x.Filmy.Opis,
                        ImageContent = x.Filmy.Zdjecie,
                        Note = x.Filmy.Ocena,
                        PublicationDate = x.Filmy.RokWydania,
                        Regisseur = x.Filmy.Rezyser,
                        Title = x.Filmy.Tytul
                    }
                }).ToList();
            }
        }
        public static List<SeanceModel> GetSeances(int movieID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Seanse.Where(x => x.Filmy.FilmID == movieID).Select(x => new SeanceModel()
                {
                    SeanceID = x.SeansID,
                    CinemaHallID = x.SalaID,
                    MovieID = x.FilmID,
                    SeanceDate = x.DataSeansu,
                    MovieInfo = new MovieModel()
                    {
                        MovieID = x.FilmID,
                        Cast = x.Filmy.Obsada,
                        Description = x.Filmy.Opis,
                        ImageContent = x.Filmy.Zdjecie,
                        Note = x.Filmy.Ocena,
                        PublicationDate = x.Filmy.RokWydania,
                        Regisseur = x.Filmy.Rezyser,
                        Title = x.Filmy.Tytul
                    }
                }).ToList();
            }
        }
        public static List<SeanceModel> GetSeances(string title)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Seanse.Where(x => x.Filmy.Tytul.Contains(title)).Select(x => new SeanceModel()
                {
                    SeanceID = x.SeansID,
                    CinemaHallID = x.SalaID,
                    MovieID = x.FilmID,
                    SeanceDate = x.DataSeansu,
                    MovieInfo = new MovieModel()
                    {
                        MovieID = x.FilmID,
                        Cast = x.Filmy.Obsada,
                        Description = x.Filmy.Opis,
                        ImageContent = x.Filmy.Zdjecie,
                        Note = x.Filmy.Ocena,
                        PublicationDate = x.Filmy.RokWydania,
                        Regisseur = x.Filmy.Rezyser,
                        Title = x.Filmy.Tytul
                    }
                    
                }).ToList();
            }
        }
        public static SeanceModel GetSeance(int seanceID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Seanse.Where(x => x.SeansID == seanceID).Select(x => new SeanceModel()
                {
                    SeanceID = x.SeansID,
                    CinemaHallID = x.SalaID,
                    MovieID = x.FilmID,
                    SeanceDate = x.DataSeansu,
                    MovieInfo = new MovieModel()
                    {
                        MovieID = x.FilmID,
                        Cast = x.Filmy.Obsada,
                        Description = x.Filmy.Opis,
                        ImageContent = x.Filmy.Zdjecie,
                        Note = x.Filmy.Ocena,
                        PublicationDate = x.Filmy.RokWydania,
                        Regisseur = x.Filmy.Rezyser,
                        Title = x.Filmy.Tytul
                    }
                }).FirstOrDefault();
            }
        }
        public static void AddSeance(int movieID, int cinemaHallID, DateTime date)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.Seanse.Add(new Seanse()
                {
                    FilmID = movieID,
                    SalaID = cinemaHallID,
                    DataSeansu = date
                });
                db.SaveChanges();
            }
        }
    }
}

