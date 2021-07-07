using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction
{
    public class AuctionVM
    {
        public AuctionVM()
        {
        }
        public AuctionVM(Auction model)
        {
            ID = model.ID;
            Name = model.Name;
            Image = model.Image;
            Price = model.Price;
            CreateDate = model.CreateDate;
            EndDate = model.EndDate;
            Description = model.Description;
             Bids =  BidVM.Map(model.Bids.ToList());
            MaxBid = model.Bids.Count != 0 ? new BidVM(model.Bids.OrderByDescending(x => x.Amount).FirstOrDefault()) : null;
        }
        public Auction Map()
        {
            return new Auction()
            {
                ID = this.ID,
                Name = this.Name,
                Image = this.Image,
                Price = this.Price,
                CreateDate = this.CreateDate,
                EndDate = this.EndDate,
                Description = this.Description,

                Bids = this.Bids.Select(d => d.Map()).ToList(),
             };
        }
        public static List<AuctionVM> Map(List<Auction> modelList)
        {
            return modelList.Select(model => new AuctionVM()
            {
                ID = model.ID,
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
                CreateDate = model.CreateDate,
                EndDate = model.EndDate,
                Description = model.Description,

                Bids = BidVM.Map(model.Bids.ToList()),
                MaxBid = model.Bids.Count!=0? new BidVM(model.Bids.OrderByDescending(x => x.Amount).FirstOrDefault()) :null,
            }).ToList();
        }




        [Key]
        public int ID { get; set; }

        [Required]
        //[Display(Name = "Name"]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        public string Image { get; set; }

        [Required]
        [Display(Name = "Start Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }



        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public System.DateTime EndDate { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<BidVM> Bids { get; set; }
        public virtual BidVM MaxBid { get; set; }
    }
}