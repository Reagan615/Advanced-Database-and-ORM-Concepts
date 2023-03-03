namespace Advanced_Database_and_ORM_Concepts_Lab01.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }

        public Address()
        {

        }
    }
}
