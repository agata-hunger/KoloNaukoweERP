using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services.Koordynator
{
    public interface IKoordynatorServices
    {
        void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        
        void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto);
        void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto);
    }
}
