using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class VehicleRepository : RepositoryBase<VehicleDrive>, IVehicleDriveRepo
    {
        public VehicleRepository(DbContext context) : base(context)
        {
        }
    }
}
