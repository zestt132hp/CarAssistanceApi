namespace CarAssistance.Data.Repository
{
    public abstract class BaseRepository
    {
        public bool _dispose;
        protected readonly DataContext _db;

        protected BaseRepository(DataContext db)
        {
            _db = db;
        }
    }
}
