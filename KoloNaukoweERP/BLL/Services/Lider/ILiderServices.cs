using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lider
{
    public interface ILiderServices
    {
        void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);

        void AddZespolToProject(int idProjektu, ZespolDTO zespolDto);
        void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto);
    }
}
