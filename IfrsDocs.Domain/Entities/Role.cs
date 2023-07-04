using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }

        public Role Clone()
        {
            return new Role
            {
                Id = Id,
                Description = Description,
                Users = Users.GetRange(0, Users.Count)
            };
        }
    }
}
