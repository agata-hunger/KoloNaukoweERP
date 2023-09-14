using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Uzytkownik
{
    public class UzytkownikServices : IUzytkownikServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UzytkownikServices(IUnitOfWork unitOfWork, IMapper mapper)
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
    }
}
