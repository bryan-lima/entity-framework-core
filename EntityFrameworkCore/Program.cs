using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Aplica as migrations na base de dados no momento em que executar a aplicação

            /*
            
            ATENÇÃO! 
            Não é recomendado utilizar este método para aplicar as migrations em ambiente de PRODUÇÃO, recomenda-se o uso apenas em ambiente local ou de testes.

            using var db = new Data.ApplicationContext();
            db.Database.Migrate();
            
             */

            #endregion Aplica as migrations na base de dados no momento em que executar a aplicação

            Console.WriteLine("Hello World!");
        }
    }
}
