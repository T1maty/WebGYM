namespace WebGYM.Domain
{
    public class User : BaseObject
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public  string? Email { get; set; }
        public int UserId { get;  set; }
        
    }
}
