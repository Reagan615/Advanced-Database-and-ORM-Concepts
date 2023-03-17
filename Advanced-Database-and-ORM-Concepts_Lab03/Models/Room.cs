namespace Advanced_Database_and_ORM_Concepts_Lab03.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public enum Section
        {
            First,
            Second,
            Third
        }
    }
}
