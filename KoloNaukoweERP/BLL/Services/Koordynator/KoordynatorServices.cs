using AutoMapper;
using BLL.Models;
using BLL.Services.Uzytkownik;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Koordynator
{
    public class KoordynatorServices : IKoordynatorServices 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public KoordynatorServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if(sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.InsertWypozyczenie(idCzlonka, sprzet);
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if(sprzetDto==null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.DeleteWypozyczenie(idCzlonka, sprzet);
            unitOfWork.Save(); 
        }

        public void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
            if(zespolDto==null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Wydarzenia.InsertZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
            if(zespolDto==null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Wydarzenia.DeleteZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }
    }
}
