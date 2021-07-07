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
    public class AuctionsController : ApiController
    {
        private AuctionEntities db = new AuctionEntities();

        // GET: api/Auctions
        public IHttpActionResult GetAuctions()
        {
            return Json(  AuctionVM.Map( db.Auctions.ToList()));
        }

        // GET: api/Auctions/5
        [ResponseType(typeof(AuctionVM))]
        public IHttpActionResult GetAuction(int id)
        {
            AuctionVM auction = new AuctionVM( db.Auctions.Find(id));
            if (auction == null)
            {
                return NotFound();
            }

            return Json(auction);
        }

        // PUT: api/Auctions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuction(int id, AuctionVM auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auction.ID)
            {
                return BadRequest();
            }

            db.Entry(auction.Map()).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(id))
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

        // POST: api/Auctions
        [ResponseType(typeof(AuctionVM))]
        public IHttpActionResult PostAuction(AuctionVM auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Auctions.Add(auction.Map());

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AuctionExists(auction.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = auction.ID }, auction);
        }

        // DELETE: api/Auctions/5
        [ResponseType(typeof(AuctionVM))]
        public IHttpActionResult DeleteAuction(int id)
        {
            AuctionVM auction = new AuctionVM( db.Auctions.Find(id));
            if (auction == null)
            {
                return NotFound();
            }

            db.Auctions.Remove(auction.Map());
            db.SaveChanges();

            return Ok(auction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuctionExists(int id)
        {
            return db.Auctions.Count(e => e.ID == id) > 0;
        }
    }
}