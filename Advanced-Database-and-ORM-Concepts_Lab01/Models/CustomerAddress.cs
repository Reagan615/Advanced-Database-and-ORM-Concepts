namespace Advanced_Database_and_ORM_Concepts_Lab01.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public bool IsOwner { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public CustomerAddress()
        {

        }
        public CustomerAddress(int customerId, int addressId, bool isOwner)
        {
            CustomerId = customerId;
            AddressId = addressId;
            IsOwner = isOwner;
        }
    }
}
