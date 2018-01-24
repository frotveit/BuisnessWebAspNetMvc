
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace BuisnessWebStore.Repositories
{
    public class HourRegistrationRepository : IHourRegistrationRepository
    {
        private readonly IAppDbContext _appDbContext;

        public HourRegistrationRepository(IAppDbContext appDbContext)
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
