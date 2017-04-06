
using BuisnessWeb.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace BuisnessWeb.Services
{
    public class HourRegistrationRepository : IHourRegistrationRepository
    {
        private readonly AppDbContext _appDbContext;

        public HourRegistrationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddHourRegistration(HourRegistration hourRegistration)
        {
            EntityEntry<HourRegistration> result = _appDbContext.HourRegistration.Add(hourRegistration);
            _appDbContext.SaveChanges();
        }

    }
}
