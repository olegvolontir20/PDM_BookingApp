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

            res.Apartaments = apartamentData;

            res.count = apartamentData.Count;

            return res;
        }

        public async Task<Apartament> GetApartament(int id)
        {
            var apartamentData = await _reppository.GetApartamentById(id);

            var res = new Apartament();

            res = apartamentData;

            return res;
        }


        public async Task<AppartmentList> SearchFilterAndSortApartaments(BookModel bookModel)
        {
            List<Apartament> apartaments = new();
            try
            {
                var apartamentData = await _reppository.GetApartaments();
                var availableApartaments = new List<Apartament>();

                foreach (var apartament in apartaments)
                {
                    var apartamentbookings = await _reppository.GetApartamentBookings();
                    bool isbooked = false;

                    foreach (var apartamentbooking in apartamentbookings)
                    {
                        if (apartamentbooking.Id == apartament.Id)
                        {
                            if (bookModel.StartDate <= apartamentbooking.LastDay.Date && bookModel.EndDate >= apartamentbooking.FirstDay.Date)
                            {
                                isbooked = true;
                                break;
                            }
                        }
                    }

                    if (!isbooked)
                    {
                        availableApartaments.Add(apartament);
                    }

                  
                }

                availableApartaments = availableApartaments.OrderBy(a => a.Name).ToList();

                // Assuming AppartmentList has a property named Apartaments
                var result = new AppartmentList { Apartaments = availableApartaments };

                return result;

            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, rethrow, etc.)
                throw ex;
            }
        }
           



}
}
