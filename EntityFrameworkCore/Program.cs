using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

            #region Verifica se existe migrations pendentes

            using var db = new Data.ApplicationContext();
            var existeMigrationsPendentes = db.Database.GetPendingMigrations().Any();

            if (existeMigrationsPendentes)
            {
                // Realiza alguma ação, como encerrar a aplicação para não ocorrer problemas
            }

            #endregion Verifica se existe migrations pendentes

            Console.WriteLine("Hello World!");
        }
    }
}
