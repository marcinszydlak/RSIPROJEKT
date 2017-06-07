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
        public static SeanceModel GetSeances()
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Seanse.Select(x => new SeanceModel()
                {
                    CinemaHallID = x.SalaID.Value,
                    MovieID = x.FilmID.Value,
                    MovieInfo = new MovieModel()
                    {
                        MovieID = x.FilmID.Value,
                        Cast = x.Filmy.Obsada,
                        Description = x.Filmy.Opis,
                        ImageContent = x.Filmy.Zdjecie,
                        Note = x.Filmy.Ocena,
                        PublicationDate = x.Filmy.RokWydania,
                        Regisseur = x.Filmy.Rezyser,
                        Title = x.Filmy.Tytul
                    }
            }
        }
    }
}

