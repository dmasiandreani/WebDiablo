﻿using Dapper;
using DapperQueryBuilder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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

            var model = new PersonajeViewModel();
            model.Personajes = lst;
            model.DropClases = DropClases();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(MyFiltersPersonaje filtro)
        {        
            IEnumerable<Personaje> lst = null;
            using (var db = new SqlConnection(connection_Sql))
            {
                var sql = "SELECT * FROM Personaje p INNER JOIN Clase c ON c.Cls_Id = p.Cls_Id";

                sql = AgregarFiltrado(sql, filtro);

                lst = db.Query<Personaje, Clase, Personaje>(
                                    sql,
                                    (personaje, clase) =>
                                    {
                                        personaje.Clase = clase;
                                        return personaje;
                                    },
                                    splitOn: "Cls_Id").Distinct().ToList();
            }

            var model = new PersonajeViewModel();
            model.Personajes = lst;
            model.DropClases = DropClases();
            return View(model);
        }

        private string AgregarFiltrado(string sql, MyFiltersPersonaje filtro)
        {
            sql += " WHERE ";

            if (!String.IsNullOrWhiteSpace(filtro.Filtro_Nombre))
            {
                sql += $"Persj_Nombre LIKE '%{filtro.Filtro_Nombre}%'";
            }

            if (!String.IsNullOrWhiteSpace(filtro.Filtro_Clase))
            {
                sql += $"AND Cls_Nombre LIKE '{filtro.Filtro_Clase}'";
            }

            if (filtro.Filtro_Lvl != 0)
            {
                sql += $"AND Persj_Lvl = {filtro.Filtro_Lvl}";
            }
            return sql;
        }

        private IEnumerable<string> DropClases(){
            IEnumerable<string> nombres = null;
            using (var db = new SqlConnection(connection_Sql))
            {
                var sql = "SELECT Cls_Nombre FROM Clase";
                nombres = db.Query<string>(sql);
            }

            return nombres;
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
