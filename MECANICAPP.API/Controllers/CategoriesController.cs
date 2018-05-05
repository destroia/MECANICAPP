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
using MECANICAPP.API.Models;
using MECANICAPP.Domain;

namespace MECANICAPP.API.Controllers
{
   // [Authorize]
    public class CategoriesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Categories
        public async Task <IHttpActionResult> GetCategories()
        {

            var categoria = await db.Categories.ToListAsync();
            var categoriaRespons = new List<CategoryRespons>();
            foreach (var category in categoria)
            {

                var historiaRespons = new List<HistoriaRespons>();


                var itemsRespons = new List<ItemRespons>();
                foreach (var item in category.Items)
                {
                   
                    foreach (var hist in item.Historias)
                    {
                        historiaRespons.Add(new HistoriaRespons
                        {
                            FechaIntervecion = hist.FechaIntervecion,
                            Repuestos = hist.Repuestos,
                            Historias = hist.Historias,
                            Valor = hist.Valor,

                        });
                        // Valor= hist.Valor,
                        //Repuestos = hist.Repuestos,
                    }
                    itemsRespons.Add(new ItemRespons
                    {

                        ItemsId = item.ItemsId,
                        Descripcion = item.Descripcion,
                        Codigo = item.Codigo,
                        Marca = item.Marca,
                        Medelo = item.Medelo,
                        Serial = item.Serial,
                        anoCompra = item.anoCompra,
                        precio = item.precio,
                        Ubicacion = item.Ubicacion,
                        Historias =historiaRespons,
                        
                    });
                }
              
                categoriaRespons.Add(new CategoryRespons
                {
                    CategoryId = category.CategoryId,
                    Descripcion = category.Descripcion,
                    Items = itemsRespons,

                });
            }
            return Ok(categoriaRespons);

          
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}