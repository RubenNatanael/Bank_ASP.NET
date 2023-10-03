using Azure.Core.Pipeline;
using BankProject.Data;
using System.ComponentModel.DataAnnotations;

namespace BankProject.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name {  get; set; }
        public string Bank {  get; set; }
        public int Founds {  get; set; }

        public Client()
        { 

        }
        public void AddFounnds(int Quantity, ApplicationDbContext _db)
        {
            Founds += Quantity;
            _db.Clients.Update(this);
            _db.SaveChanges();
        }
    }
}
