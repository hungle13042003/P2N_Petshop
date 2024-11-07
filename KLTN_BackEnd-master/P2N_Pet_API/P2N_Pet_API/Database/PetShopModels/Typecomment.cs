using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Typecomment
    {
        public Typecomment()
        {
            Productcomments = new HashSet<Productcomment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Productcomment> Productcomments { get; set; }
    }
}
