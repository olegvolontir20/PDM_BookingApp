using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.ServiceResult;
using BookingApplication.Entities.Models;
using BookingApplication.Entities;
using System.Linq;
using NuGet.Protocol.Core.Types;

namespace BookingApplication.Services
{
    public class AppartmentsService : IAppartmentService
    {
        private readonly IAppartmentResppository _reppository;

        public AppartmentsService(IAppartmentResppository reppository)
        {
            _reppository = reppository;
        }

        public async Task<AppartmentList> GetApartaments()
        {
            var apartamentData = await _reppository.GetApartaments();

            var res = new AppartmentList();

            res.items = apartamentData;

            res.count = apartamentData.Count;

            return res;
        }
    }
}
