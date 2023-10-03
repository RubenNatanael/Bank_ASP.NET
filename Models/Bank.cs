using BankProject.Data;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BankProject.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name {  get; set; }

        public int _Founds { get; set; }

        public string _Password { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public static Bank? LastBankLoggin {  get; set; }

        public static bool Admin { get; set; }


        public Bank()
        {

        }

        public void addFounds(int money,ApplicationDbContext _db)
        {
            this._Founds += money;
            _db.Banks.Update(this);
            _db.SaveChanges();

        }

    }
}
