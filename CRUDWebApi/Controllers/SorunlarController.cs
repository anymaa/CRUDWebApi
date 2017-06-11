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
using CRUDWebApi;

namespace CRUDWebApi.Controllers
{
    public class SorunlarController : ApiController
    {
        private STS2017Entities db = new STS2017Entities();

        // GET: api/Sorunlar
        public IQueryable<TBL_SORUN_> GetTBL_SORUN_()
        {
            return db.TBL_SORUN_;
        }

        // GET: api/Sorunlar/5
        [ResponseType(typeof(TBL_SORUN_))]
        public IHttpActionResult GetTBL_SORUN_(int id)
        {
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            if (tBL_SORUN_ == null)
            {
                return NotFound();
            }

            return Ok(tBL_SORUN_);
        }

        // PUT: api/Sorunlar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBL_SORUN_(int id, TBL_SORUN_ tBL_SORUN_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_SORUN_.Id)
            {
                return BadRequest();
            }

            db.Entry(tBL_SORUN_).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBL_SORUN_Exists(id))
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

        // POST: api/Sorunlar
        [ResponseType(typeof(TBL_SORUN_))]
        public IHttpActionResult PostTBL_SORUN_(TBL_SORUN_ tBL_SORUN_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_SORUN_.Add(tBL_SORUN_);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TBL_SORUN_Exists(tBL_SORUN_.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBL_SORUN_.Id }, tBL_SORUN_);
        }

        // DELETE: api/Sorunlar/5
        [ResponseType(typeof(TBL_SORUN_))]
        public IHttpActionResult DeleteTBL_SORUN_(int id)
        {
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            if (tBL_SORUN_ == null)
            {
                return NotFound();
            }

            db.TBL_SORUN_.Remove(tBL_SORUN_);
            db.SaveChanges();

            return Ok(tBL_SORUN_);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBL_SORUN_Exists(int id)
        {
            return db.TBL_SORUN_.Count(e => e.Id == id) > 0;
        }
    }
}