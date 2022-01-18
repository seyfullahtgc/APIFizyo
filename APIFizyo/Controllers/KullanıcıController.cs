using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanıcıController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public KullanıcıController(APIFizyoDBContext context)
        {
            _context = context;
        }


        // GET: api/TümKullanıcılarıGetir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> TümKullanıcılarıGetir()
        {
            
            return await _context.Kullanıcılar.ToListAsync(); 
        }


        // GET: api/seçiliKullanıcıyıGetir
        [HttpGet("seçiliKullanıcıyıGetir/{id}")]
        public async Task<ActionResult<Kullanıcı>> seçiliKullanıcıyıGetir(int id)
        {

            return await _context.Kullanıcılar.FindAsync(id);
        }

        // GET: api/KullanıcılarByRol
        
        [HttpGet("KullanıcılarByRol/{id}")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarByRol(int id)
        {

            return await _context.Kullanıcılar.Where(a => a.RolID == id).ToListAsync();
        }


        // GET: api/KullanıcılarByRolAdı
        [HttpGet("KullanıcılarByRolAdı/{Adı}")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarByRolAdı(string Adı)
        {

            return await _context.Kullanıcılar.Include(a=>a.Rol).Where(a=>a.Rol.RolAdı==Adı).ToListAsync();
        }
        //GET: api/KullanıcılarFilitreli
        [HttpGet("KullanıcılarFilitreli")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarFilitreli(string EpostaUzantı, string RolAdı)
        {
            return await _context.Kullanıcılar.
            Include(a => a.Rol).
            Where(a=> (a.Rol.RolAdı == RolAdı || RolAdı==null)
            &&(a.Eposta.Contains(EpostaUzantı)|| EpostaUzantı==null)
             ).ToListAsync();




        }
    }
}
