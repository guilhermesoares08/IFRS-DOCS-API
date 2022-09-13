using System;

namespace IfrsDocs.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Role Role { get; set; }

        public User Clone()
        {
            User obj = new User();
            obj.Id = this.Id;
            obj.Login = this.Login;
            obj.Email = this.Email;
            obj.Password = this.Password;
            obj.CPF = this.CPF;
            obj.CreateDate = this.CreateDate;
            obj.UpdateDate = this.UpdateDate;
            obj.RoleId = this.RoleId;
            obj.Role = this.Role.Clone();
            return obj;
        }
    }
}
