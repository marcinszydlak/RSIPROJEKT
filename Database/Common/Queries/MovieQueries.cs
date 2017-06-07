using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Common.Queries
{
    public static class MovieQueries
    {
        public static MovieModel GetMovie(int ID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Filmy.Where(x => x.FilmID == ID).Select(x => new MovieModel()
                {
                    MovieID = x.FilmID,
                    Cast = x.Obsada,
                    ImageContent = x.Zdjecie,
                    Note = x.Ocena,
                    PublicationDate = x.RokWydania,
                    Regisseur = x.Rezyser,
                    Title = x.Tytul
                }).FirstOrDefault();
            }
        }
        public static List<MovieModel> GetMovies()
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Filmy.Select(x => new MovieModel()
                {
                    MovieID = x.FilmID,
                    Cast = x.Obsada,
                    ImageContent = x.Zdjecie,
                    Note = x.Ocena,
                    PublicationDate = x.RokWydania,
                    Regisseur = x.Rezyser,
                    Title = x.Tytul,
                    Description = x.Opis
                    
                }).ToList();
            }
        }
        public static void AddMovie(MovieModel model)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.Filmy.Add(new Filmy()
                {
                    Obsada = model.Cast,
                    Ocena = model.Note,
                    Opis = model.Description,
                    Rezyser = model.Regisseur,
                    RokWydania = model.PublicationDate,
                    Tytul = model.Title,
                    Zdjecie = model.ImageContent,
                });
            }
        }
    }
}
