using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UsingDapper.Models;

namespace UsingDapper.Repository
{
    public class ClienteRepository
    {
        private string sqlConnectionString = @"Server=(Local); Database=Tienda; Integrated Security = true";

        public List<ClienteModel> ListarClientes()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                clientes = connection.Query<ClienteModel>("Select * from Cliente").ToList();
                connection.Close();
            }
            return clientes;
        }

        public ClienteModel getClientexID(int id)
        {
            ClienteModel cliente = null;
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                /*connection.Open();
                cliente = connection.Execute("Select * from Cliente where IdCliente = @IdCliente ", new {IdCliente = id });
                connection.Close();*/

                var sql = "Select * from Cliente where IdCliente =" + id;
                cliente = connection.QuerySingle<ClienteModel>(sql);
                
            }
            return cliente;
        }

        public int CrearCliente(ClienteModel cliente)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("insert into Cliente(NroDocumento, Nombre, Direccion, Telefono, Observacion) values(@NroDocumento, @Nombre, @Direccion, @Telefono, @Observacion)", 
                                    new {NroDocumento = cliente.NroDocumento, Nombre = cliente.Nombre, Direccion = cliente.Direccion, Telefono = cliente.Telefono, Observacion = cliente.Observacion });
                connection.Close();
                return affectedRows;
            }
        }
        
       
        public int EditarCliente(ClienteModel cliente)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Update Cliente set NroDocumento = @NroDocumento, Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Observacion = @Observacion Where IdCliente = @IdCliente", 
                                new { IdCliente = cliente.IdCliente, NroDocumento = cliente.NroDocumento, Nombre = cliente.Nombre, Direccion = cliente.Direccion, Telefono = cliente.Telefono, Observacion = cliente.Observacion });
                connection.Close();
                return affectedRows;
            }
        }


       public int EliminarCliente(int id)
       {
           using (SqlConnection connection = new SqlConnection(sqlConnectionString))
           {
               connection.Open();
               var affectedRows = connection.Execute("Delete from Cliente Where IdCliente =" + id);
               connection.Close();
               return affectedRows;
           }
       }
    }
}