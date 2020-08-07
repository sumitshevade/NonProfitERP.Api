using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Header : Entity
    {
        public Header()
        {
            Detail = new HashSet<Detail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Detail> Detail { get; set; }
    }
}
