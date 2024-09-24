using Core.Entities;

namespace Entity.TableModel
{
    public class About : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AboutPhoto> AboutPhotos { get; set; }
    }
}
