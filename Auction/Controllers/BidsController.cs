using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Auction;
 
namespace Auction.Controllers
{
    public class BidsController : ApiController
    {
        private AuctionEntities db = new AuctionEntities();

        // GET: api/Bids
        public IHttpActionResult GetBidVMs()
        {
            return Json( BidVM.Map(db.Bids.ToList()));

         }

        // GET: api/Bids/5
        [ResponseType(typeof(BidVM))]
        public IHttpActionResult GetBidVM(int id)
        {
            BidVM bidVM = new BidVM( db.Bids.Find(id));
            if (bidVM == null)
            {
                return NotFound();
            }

            return Json(bidVM);
        }

        // PUT: api/Bids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBidVM(int id, BidVM bidVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 

            db.Entry(bidVM).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidVMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bids
        [ResponseType(typeof(BidVM))]
        public IHttpActionResult PostBidVM(BidVM bidVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bidVM.CreateDate = DateTime.Now;
            bidVM.UpdateDate = DateTime.Now;

            db.Bids.Add(bidVM.Map());
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bidVM.ID }, bidVM);
        }

        // DELETE: api/Bids/5
        [ResponseType(typeof(BidVM))]
        public IHttpActionResult DeleteBidVM(int id)
        {
            BidVM bidVM = new BidVM(db.Bids.Find(id));
            if (bidVM == null)
            {
                return NotFound();
            }

            db.Bids.Remove(bidVM.Map());
            db.SaveChanges();

            return Ok(bidVM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BidVMExists(int id)
        {
            return db.Bids.Count(e => e.ID == id) > 0;
        }
    }
}