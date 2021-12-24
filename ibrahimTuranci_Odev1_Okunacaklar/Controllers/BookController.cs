using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ibrahimTuranci_Odev1_Okunacaklar.Controllers
{
    public class Book
    {
        public int Id { get; set; }

        public long KitapSeriNo { get; set; }

        public String KitapAdi { get; set; }

        public String Yazari { get; set; }

        public int SayfaSayisi { get; set; }


    }
    [Route("bookapi/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> bookList;
        public BookController()
        {
            bookList = new List<Book>();

            bookList.Add(new Book { Id = 1, KitapSeriNo = 5123464344234, SayfaSayisi = 421, KitapAdi = "Pia Mater", Yazari = "Serkan Karaismailoğlu" });
            bookList.Add(new Book { Id = 2, KitapSeriNo = 5213642362097, SayfaSayisi = 551, KitapAdi = "Dura Mater", Yazari = "Serkan Karaismailoğlu" });
            bookList.Add(new Book { Id = 3, KitapSeriNo = 9786053608288, SayfaSayisi = 177, KitapAdi = "Kumarbaz", Yazari = "Dostoyevski" });
            bookList.Add(new Book { Id = 4, KitapSeriNo = 9789754732481, SayfaSayisi = 312, KitapAdi = "Bir Değirmendir Bu Dünya", Yazari = "Cahit Zarifoğlu" });
            bookList.Add(new Book { Id = 5, KitapSeriNo = 9786055388829, SayfaSayisi = 278, KitapAdi = "İçimizdeki Şeytan", Yazari = "Sabahattin Ali" });
            bookList.Add(new Book { Id = 6, KitapSeriNo = 5234876234876, SayfaSayisi = 181, KitapAdi = "Hasretinden Prangalar Eskittim", Yazari = "Ahmed Arif" });
        }


        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id == 0)
            {
                return Unauthorized();

            }
            var book = bookList.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<List<Book>> Post([FromBody] Book request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(request.Yazari))
            {
                return BadRequest();
            }

            bookList.Add(request);
            return bookList;
        }

        [HttpPut]
        public ActionResult<List<Book>> Put(int id, [FromBody] Book request)
        {
            var temp = bookList.Where(x => x.KitapSeriNo == id).FirstOrDefault();
            if (temp is null)
            {
                return Ok("Not Found");
            }
            temp.Yazari = request.Yazari;
            temp.KitapAdi = request.KitapAdi;
            temp.SayfaSayisi = request.SayfaSayisi;

            return Ok(bookList);

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var temp = bookList.Where(x => x.KitapSeriNo == id).FirstOrDefault();
            if (temp is null)
            {
                return NotFound();
            }
            bookList.Remove(temp);
            return Ok();
        }
    }
}
