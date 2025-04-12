namespace SweetCakeFrontend.Models.Response
{
    public class CheckRoleResponse
    {
        public bool Allowed { get; set; }
        public string Redirect { get; set; }
        public string Message { get; set; }
    }
}
