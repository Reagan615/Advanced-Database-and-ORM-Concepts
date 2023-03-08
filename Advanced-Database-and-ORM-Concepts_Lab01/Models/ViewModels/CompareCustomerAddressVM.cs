using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advanced_Database_and_ORM_Concepts_Lab01.Models.ViewModels
{
    public class CompareCustomerAddressVM
    {
        public List<SelectListItem> CustomerIds { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AddressIds { get; set; } = new List<SelectListItem>();
        public int? SelectedCustomerId { get; set; }
        public int? SelectedAddressId { get; set; }
        public bool IsCustomerAtAddress { get; set; }
    }
}
