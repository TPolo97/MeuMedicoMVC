using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Security;
using MeuMedico.Filtros;

namespace MeuMedico.Controllers
{
    public class HomeController : Controller
    {
        private MeuMedicoEntities db = new MeuMedicoEntities();
        // GET: Home
        public ActionResult Index()
        {
            var medico = db.Medicos.Include(m => m.Cidades).Include(m => m.Especialidades).ToList();
            ViewBag.IDCidade = db.Cidades.ToList();
            ViewBag.IDEspecialidade = db.Especialidades.ToList();
            return View(medico);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade", medico.IDEspecialidade);
            return View(medico);
        }

        // GET: Home/Create
        [LoginFiltro]
        public ActionResult Create()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade");
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [LoginFiltro]
        public ActionResult Create(Medicos medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Medicos.Add(medico);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade");
                ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade");
                return View(medico);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        [LoginFiltro]
        public ActionResult Edit(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade", medico.IDEspecialidade);
            return View(medico);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [LoginFiltro]
        public ActionResult Edit(Medicos medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(medico).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico.IDCidade);
                ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade", medico.IDEspecialidade);
                return View(medico);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        [LoginFiltro]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Home/Delete/5
        [HttpPost]
        [LoginFiltro]
        public ActionResult Delete(long IDMedico)
        {
            try
            {
                Medicos medico = db.Medicos.Find(IDMedico);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                using (MeuMedicoEntities dc = new MeuMedicoEntities())
                {
                    var v = dc.Usuarios.Where(a => a.Usuario.Equals(u.Usuario) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.IDUsuario.ToString();
                        Session["nomeUsuarioLogado"] = v.Nome.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
