using System.ComponentModel.DataAnnotations;

namespace poker.Models
{
    public class Programmer
    {
        public Programmer( int theID, string theName )
        {
            ID = theID;
            Name = theName;
        } 
        
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}