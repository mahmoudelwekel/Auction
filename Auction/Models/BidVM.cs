using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction
{
    public class BidVM
    {
        public BidVM()
        {
        }
        public BidVM(Bid model)
        {
            ID = model.ID;
            AuctionID = model.AuctionID;
            ClientID = model.ClientID;
            Amount = model.Amount;
            CreateDate = model.CreateDate;
            IsAuto = model.IsAuto;
            UpdateDate = model.UpdateDate;

            //Auction = new AuctionVM(model.Auction);

        }
        public Bid Map()
        {
            return new Bid()
            {
                ID = this.ID,
                AuctionID = this.AuctionID,
                ClientID = this.ClientID,
                Amount = this.Amount,
                CreateDate = this.CreateDate,
                IsAuto = this.IsAuto,
                UpdateDate = this.UpdateDate,

                //Auction = this.Auction.Map()

            };
        }
        public static List<BidVM> Map(List<Bid> modelList)
        {
            return modelList.Select(model => new BidVM()
            {
                ID = model.ID,
                AuctionID = model.AuctionID,
                ClientID = model.ClientID,
                Amount = model.Amount,
                CreateDate = model.CreateDate,
                IsAuto = model.IsAuto,
                UpdateDate = model.UpdateDate,

                //Auction = new AuctionVM(model.Auction),
            }).ToList();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Auction")]
        public int AuctionID { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Bid Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [Display(Name = "Auto Bidding")]
        public Nullable<bool> IsAuto { get; set; }


        [Display(Name = "Update Date")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public Nullable<System.DateTime> UpdateDate { get; set; }

        //public virtual AuctionVM Auction { get; set; }
        public virtual ClientVM Client { get; set; }
    }
}