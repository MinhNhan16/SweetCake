using System.ComponentModel;

namespace SweetCakeFrontend.Enums
{
    public enum RoleEnum
    {
        [Description("Admin")]
        Admin,

        [Description("Customer")]
        Customer,

        [Description("Shipper")]
        Shipper
    }
}
