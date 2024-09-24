using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.TableModel
{
    public class AboutPhoto : BaseEntity,IEntity
    {
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
