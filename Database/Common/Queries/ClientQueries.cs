using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Common.Queries
{
    public static class ClientQueries
    {
        public static ClientModel Login(string login,string password)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                return db.Klienci.Where(x => x.Login == login && x.Haslo == password).Select(x => new ClientModel()
                {
                    ClientID = x.KlientID,
                    Password = x.Haslo,
                    Name = x.Imie,
                    Login = x.Login,
                    Surname = x.Nazwisko
                }).FirstOrDefault();
            }
        }
        public static void RegisterClient(ClientModel model)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.Klienci.Add(new Klienci()
                {
                    Imie = model.Name,
                    Nazwisko = model.Surname,
                    Haslo = model.Password,
                    Login = model.Login
                });
                db.SaveChanges();
            }
        }
        public static void RemoveClient(int clientID)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                db.Klienci.Remove(db.Klienci.Where(x => x.KlientID == clientID).FirstOrDefault());
                db.SaveChanges();
            }
        }
        public static void UpdatePassword(int clientID,string password)
        {
            using (FilmyEntities db = new FilmyEntities())
            {
                Klienci klient = db.Klienci.Where(x => x.KlientID == clientID).FirstOrDefault();
                klient.Haslo = password;
                db.SaveChanges();
            }
        }
    }
}
