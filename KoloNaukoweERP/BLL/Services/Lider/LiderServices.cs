using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lider
{
    public class LiderServices : ILiderServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public LiderServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.InsertWypozyczenie(idCzlonka, sprzet);
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.DeleteWypozyczenie(idCzlonka, sprzet);
            unitOfWork.Save();
        }

        public void AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Projekty.InsertZespol(idProjektu, zespol);
            unitOfWork.Save();
        }

        public void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Projekty.DeleteZespol(idProjektu, zespol);
            unitOfWork.Save();
        }
    }
}
