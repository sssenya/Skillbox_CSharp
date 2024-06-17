using System.Data;

using Microsoft.EntityFrameworkCore;


namespace Practice_17_Entity {
    public class PurchasesViewModel : BaseViewModel {
        private readonly Mssqltest2Context _contextdb;
        private Purchase _selectedPurchase;

        public PurchasesViewModel(Client client)
        {
            string clientEmail = client.Email;

            _contextdb = new Mssqltest2Context();
            _contextdb.Purchases.Load<Purchase>();

            Purchases = _contextdb.Purchases.Local
                .ToList()
                .Where(x => x.Email == clientEmail)
                .ToList();
        }

        public List<Purchase> Purchases { get; set; }
    }
}
