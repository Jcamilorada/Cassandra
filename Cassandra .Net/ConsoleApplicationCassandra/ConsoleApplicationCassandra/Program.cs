using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationCassandra
{
    class Program
    {
        static void Main(string[] args)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").WithPort(9042).Build();
            ISession session = cluster.Connect("example");
            actulizarTransaccion(session, 2);
            consultarTodos(session);
            Console.ReadLine();
        }

        public static void actulizarTransaccion(ISession session, int id)
        {
            String observacion = String.Format("Observacion #{0}", new Random().Next(10, 999999));
            String statment = String.Format("update transaccion set observaciones = '{1}' where id = {0}", id, observacion);
            session.Execute(statment);
        }

        public static void createTransaccion(ISession session, int id) 
        {
            String statment = String.Format("insert into transaccion(id, cliente_mayorista, observaciones, fecha) values ({0}, false, 'observacion', '2015-06-03')", id);
            session.Execute(statment);
        }

        public static void deleteTransaccion(ISession session, int id)
        {
            String statment = String.Format("delete from transaccion where id = {0}", id);
            session.Execute(statment);
        }

        public static void consultarTodos(ISession session)
        {
            RowSet result = session.Execute("select * from transaccion");
            foreach (Row row in result)
            {
                printInformation(row);
            }
        }
        
        public static void consultarUsuario(ISession session, int id)
        {
            String statment = String.Format("select * from transaccion where id = {0}", id);
            Row result = session.Execute(statment).First();
            printInformation(result);
        }

        private static void printInformation(Row result)
        {
            Console.WriteLine(result.ToString());
            Console.WriteLine("id : " + result["id"]);
            Console.WriteLine("cliente_mayorista : " + result["cliente_mayorista"]);
            Console.WriteLine("observaciones : " + result["observaciones"]);
            Console.WriteLine("fecha : " + result["fecha"]);
        }
    }
}
