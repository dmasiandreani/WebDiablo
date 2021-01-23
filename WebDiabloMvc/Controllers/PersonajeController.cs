using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebDiabloMvc.Models;

namespace WebDiabloMvc.Controllers
{
    public class PersonajeController : Controller
    {
        private readonly string connection_Sql;

        public PersonajeController(IConfiguration configuration)
        {
            connection_Sql = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Index()
        {
            IEnumerable<Personaje> lst = null;
            using (var db = new SqlConnection(connection_Sql))
            {
                var sql = "SELECT * FROM Personaje p INNER JOIN Clase c ON c.Cls_Id = p.Cls_Id";
                
                lst = db.Query<Personaje, Clase, Personaje>(
                                    sql,
                                    (personaje, clase) =>
                                    {
                                        personaje.Clase = clase;
                                        return personaje;
                                    },
                                    splitOn: "Cls_Id").Distinct().ToList();
            }

            return View(lst);
        }
        [HttpPost]
         public IActionResult Index(MyFiltersPersonaje filtro)
        {
            return View();
        }
    }
}

//string sql = "SELECT * FROM Invoice AS A INNER JOIN InvoiceDetail AS B ON A.InvoiceID = B.InvoiceID;";

//using (var connection = My.ConnectionFactory())
//{
//    connection.Open();

//    var invoices = connection.Query<Invoice, InvoiceDetail, Invoice>(
//            sql,
//            (invoice, invoiceDetail) =>
//            {
//                invoice.InvoiceDetail = invoiceDetail;
//                return invoice;
//            },
//            splitOn: "InvoiceID")
//        .Distinct()
//        .ToList();
