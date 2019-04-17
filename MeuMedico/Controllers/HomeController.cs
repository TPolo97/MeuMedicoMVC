using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Security;
using MeuMedico.ViewModel;
using MeuMedico.Utils;
using System.Security.Claims;
using MeuMedico.Models;

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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade");
            return View();
        }

        // POST: Home/Create
        [Authorize]
        [HttpPost]
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Especialidade", medico.IDEspecialidade);
            return View(medico);
        }

        // POST: Home/Edit/5
        [Authorize]
        [HttpPost]
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
        [Authorize]
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
        [Authorize]
        [HttpPost]
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

        public ActionResult Login(String ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            var usuario = db.Usuarios.FirstOrDefault(u => u.Usuario == viewmodel.Login);
            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Falha no login");
                return View(viewmodel);
            }
            if (usuario.Senha != Hash.GeraHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Login ou senha incorreta");
                return View(viewmodel);
            }
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Usuario)
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);
            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
            {
                return Redirect(viewmodel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Usuario == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Usuário ja existe");
                return View(viewModel);
            }
            Usuarios novoUsuario = new Usuarios { Nome = viewModel.Nome, Usuario = viewModel.Login, Senha = Hash.GeraHash(viewModel.Senha) };
            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            var usuario = db.Usuarios.FirstOrDefault(u => u.Usuario == login);

            if (Hash.GeraHash(viewmodel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }
            usuario.Senha = Hash.GeraHash(viewmodel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Painel");
        }
    }
}
