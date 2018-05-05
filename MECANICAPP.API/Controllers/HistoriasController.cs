using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MECANICAPP.Domain;

namespace MECANICAPP.API.Controllers
{
    public class HistoriasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Historias
        public IQueryable<Historia> GetHistorias()
        {
            return db.Historias;
        }

        // GET: api/Historias/5
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> GetHistoria(string id)
        {
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }

            return Ok(historia);
        }

        // PUT: api/Historias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistoria(string id, Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historia.Historias)
            {
                return BadRequest();
            }

            db.Entry(historia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(id))
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

        // POST: api/Historias
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> PostHistoria(Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historias.Add(historia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistoriaExists(historia.Historias))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = historia.Historias }, historia);
        }

        // DELETE: api/Historias/5
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> DeleteHistoria(string id)
        {
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }

            db.Historias.Remove(historia);
            await db.SaveChangesAsync();

            return Ok(historia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaExists(string id)
        {
            return db.Historias.Count(e => e.Historias == id) > 0;
        }
    }
}