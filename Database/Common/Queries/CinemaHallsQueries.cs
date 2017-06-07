using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Common.Models;

namespace Common.Queries
{
    public static class CinemaHallsQueries
    {
        public static CinemaHallModel GetCinemaHall(int ID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Sale.Where(x => x.SalaID == ID).Select(x => new CinemaHallModel()
                {
                    CinemaHallID = x.SalaID,
                    Rows = x.IloscRzedow,
                    Positions = x.IloscMiejscWRzedzie
                }).FirstOrDefault();
            }
        }
        public static List<CinemaHallModel> GetCinemaHalls()
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Sale.Select(x => new CinemaHallModel()
                {
                    CinemaHallID = x.SalaID,
                    Rows = x.IloscRzedow,
                    Positions = x.IloscMiejscWRzedzie
                }).ToList();
            }
        }
    }
}
