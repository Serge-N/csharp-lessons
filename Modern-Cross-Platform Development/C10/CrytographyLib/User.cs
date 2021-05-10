
namespace Packt.Shared
{
    public class User
    {
        public string[] Roles {get; set;}
        public string Name { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }
    }
}