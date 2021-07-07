using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction
{
    public class ClientVM
    {
        public ClientVM()
        {
        }
        public ClientVM(Client model)
        {
            ID = model.ID;
            Name = model.Name;
            MaxAutoAmount = model.MaxAutoAmount;
             

            Bids =  BidVM.Map( model.Bids.ToList()) ;
        }
        public Client Map()
        {
            return new Client()
            {
                ID = this.ID,
                Name = this.Name,
                MaxAutoAmount = this.MaxAutoAmount,
                
                Bids = this.Bids.Select(d => d.Map()).ToList(),

            };
        }
        public static List<ClientVM> Map(List<Client> modelList)
        {
            return modelList.Select(model => new ClientVM()
            {
                ID = model.ID,
                Name = model.Name,
                MaxAutoAmount = model.MaxAutoAmount,
              
                Bids =  BidVM.Map(model.Bids.ToList()),
            }).ToList();
        }




        [Key]
        public int ID { get; set; }
                
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Max Auto Amount")]
        [DataType(DataType.Currency)]
        public decimal MaxAutoAmount { get; set; }

        public virtual ICollection<BidVM> Bids { get; set; }



    }
}