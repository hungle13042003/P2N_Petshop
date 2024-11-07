using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Breed
    {
        public Breed()
        {
            InverseBreedNavigation = new HashSet<Breed>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong? Breedid { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual Breed BreedNavigation { get; set; }
        public virtual ICollection<Breed> InverseBreedNavigation { get; set; }
    }
}
