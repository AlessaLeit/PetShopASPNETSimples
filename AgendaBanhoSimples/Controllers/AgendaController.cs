using AgendaBanhoSimples.Models;
using Microsoft.AspNetCore.Mvc;
using PacotesPetShop.Data;

namespace AgendaBanhoSimples.Controllers
{
    public class AgendaController : Controller
    {
        readonly private ApplicationDbContext _db;
        public AgendaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<AgendaModel> horarios = _db.Agenda;
            return View(horarios);
        }
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AgendaModel horario = _db.Agenda.FirstOrDefault(x => x.IdBanho == id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AgendaModel horario = _db.Agenda.FirstOrDefault(x => x.IdBanho == id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);

        }

        [HttpPost]
        public IActionResult Cadastrar(AgendaModel horarios)
        {
            if (ModelState.IsValid)
            {
                _db.Agenda.Add(horarios);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Horário cadastrado com sucesso!";

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Editar(AgendaModel horario)
        {
            if (ModelState.IsValid)
            {
                _db.Agenda.Update(horario);
                _db.SaveChanges();
                
                TempData["MensagemSucesso"] = "Horário editado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição";

            return View(horario);
        }

        [HttpPost]
        public IActionResult Excluir(AgendaModel horario)
        {
            if (horario == null)
            {
                return NotFound();
            }
            _db.Agenda.Remove(horario);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Horário excluido com sucesso!";

            return RedirectToAction("Index");
        }

    }
}
