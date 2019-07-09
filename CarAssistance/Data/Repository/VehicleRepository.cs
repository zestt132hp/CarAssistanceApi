using System;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class VehicleRepository:IRepository<VehicleDrive>
    {
        private readonly DataContext _db;
        private bool _dispose;

        public VehicleRepository(DataContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public VehicleDrive Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(VehicleDrive item)
        {
            throw new NotImplementedException();
        }

        public void Delete(VehicleDrive item)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(VehicleDrive[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleDrive item)
        {
            throw new NotImplementedException();
        }
    }
}
