using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;
using LPPA.Process;

namespace LPPA.WebSite.Controllers
{
    public class EstadisticaController : Controller
    {
        private SolicitudProcessController process = new SolicitudProcessController();
        // GET: Estadistica
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [WebMethod]
        public string GetChart(string type)
        {
            if (type == "EntidadChart")
            {
                return this.EntidadChart();
            }
            else if (type == "TerminalChart")
            {
                return this.TerminalChart();
            }
            else if (type == "AprobadasChart")
            {
                return this.AprobadasChart();
            }
            return "";
        }

        private string AprobadasChart()
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<string> estados = process.GetAllStatus();
            var categorias = new List<string>();
            var series = new List<string>();
            var title = new List<string>();
            title.Add("Solicitudes Aprobadas y Rechazadas");
            foreach (string estado in estados.Where(e => e != null).Distinct().ToList())
            {
                categorias.Add(estado);
                series.Add(estados.FindAll(e => e == estado).Count().ToString());
            }
            map.Add("categories", categorias);
            map.Add("series", series);
            map.Add("title", title);
            return JsonConvert.SerializeObject(map);
        }

        private string TerminalChart()
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<string> terminales = process.GetTerminales();
            var categorias = new List<string>();
            var series = new List<string>();
            var title = new List<string>();
            title.Add("Terminales emisoras");
            foreach (string terminal in terminales.Where(t => t != null).Distinct().ToList()) {
                categorias.Add(terminal);
                series.Add(terminales.FindAll(e => e == terminal).Count().ToString());
            }
            map.Add("categories", categorias);
            map.Add("series", series);
            map.Add("title", title);
            return JsonConvert.SerializeObject(map);
        }

        private string EntidadChart()
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<string> entidades = process.GetEntidadesEmisoras();
            var categorias = new List<string>();
            var series = new List<string>();
            var title = new List<string>();
            title.Add("Entidades emisoras");
            foreach (string terminal in entidades.Where(e => e != null).Distinct().ToList())
            {
                categorias.Add(terminal);
                series.Add(entidades.FindAll(e => e == terminal).Count().ToString());
            }
            map.Add("categories", categorias);
            map.Add("series", series);
            map.Add("title", title);
            return JsonConvert.SerializeObject(map);
        }
    }
}