
using HW_Week13_End.Contracts;
using HW_Week13_End.Entities;
using HW_Week13_End.InfraStracture;
using Microsoft.EntityFrameworkCore;


namespace HW_Week13_End.Repositories
{
    class LibrarianRepository : ILibrarianRepository
    {
        AppDBContext appDBContext;
        public LibrarianRepository()
        {
            appDBContext = new AppDBContext();
            //appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Create(Librarian librarian)
        {
            appDBContext.Librarians.Add(librarian);
            appDBContext.SaveChanges();
        }

        public List<Librarian> GetAll()
        {
            appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return appDBContext.Librarians.ToList();
        }
    }
}
