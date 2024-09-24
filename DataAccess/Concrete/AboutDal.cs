using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entity.TableModel;

namespace DataAccess.Concrete
{
    public class AboutDal : RepositoryBase<About, ApplicationDbContext>, IAboutDal
    {
        public AboutDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
