using ProvaWeek7GiadaPantalone.Models;
using ProvaWeek7GiadaPantalone.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone
{
    internal static class GestoreAssicurazione
    {
        static IRepositoryCliente repoCliente = new RepositoryCliente();
        static IRepositoryPolizza repoPolizza = new RepositoryPolizza();
        internal static void Menu()
        {
            char choice;
            do
            {
                Console.WriteLine("==== BENVENUTO ====");
                Console.WriteLine("Scegli una delle seguenti opzioni: " +
                    "\n[ 1 ] Inserisci un nuovo cliente," +
                    "\n[ 2 ] Inserisci una nuova polizza per un cliente," +
                    "\n[ 3 ] Stampa i dati delle polizze con info sul cliente," +
                    "\n[ q ] Esci");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        AzioniCliente();
                        break;
                    case '2':
                        AzioniPolizza();
                        break;
                    case '3':
                        Print();
                        break;
                    case 'q':
                        Console.WriteLine("\nARRIVEDERCI!!!!");
                        break;
                    default: Console.WriteLine("Scelta inserita non valida.");
                        break;

                }

            } while (choice != 'q');
        }

        private static void Print()
        {
            //    string code = GetData("codice fiscale del cliente");
            //    var cliente = repoCliente.GetByCodiceFiscale(code);

            var polizze = repoPolizza.GetAll();
                foreach (var p in polizze)
                {
                    Console.WriteLine(p);

                    Console.WriteLine(p.Cliente);
                    Console.WriteLine($"Spesa tot mensile del cliente: {p.Cliente.SumPolizze()} Euro");
                }
                              
        }

        private static void AzioniPolizza()
        {
            Polizza newPolizza = new Polizza();
            DateTime dataStipula = GetDate("data della stipulazione");
            float importoAssicurato = GetFloat("importo assicurato");
            float rataMensile = GetFloat("rata mensile");
            string clientCode = GetData("codice fiscale del cliente");

            Console.WriteLine("Quale tipo di polizza vuoi stipulare?" +
                "\n( a ) RC Auto," +
                "\n( b ) Furto," +
                "\n( c ) Vita");
            char userChoice= Console.ReadKey().KeyChar;
            if(userChoice == 'a')
            {
                string targa;        
                bool flag=false;
                do {
                     targa = GetData("targa");
                    if (targa.Length > 5 || targa.Length <5 )
                    {
                        Console.WriteLine("targa non valida");
                        flag=true;

                    }
                    else
                    {
                        Console.WriteLine("targa valida");
                        flag = false;
                    }
                } while (flag);

                int cilindrata = (int)GetFloat("cilindrata");
                newPolizza = new PolizzaRCAuto()
                {
                    DataStipula = dataStipula,
                    ImportoAssicurato=importoAssicurato,
                    RataMensile=rataMensile,
                    ClienteCodiceFiscale=clientCode,
                    Targa= targa,
                    Cilindrata=cilindrata
                };
            }
            else if (userChoice == 'b')
            {
                int percentualeCoperta = (int)GetFloat("percentuale coperta");
                newPolizza = new PolizzaFurto()
                {
                    DataStipula = dataStipula,
                    ImportoAssicurato = importoAssicurato,
                    RataMensile = rataMensile,
                    ClienteCodiceFiscale = clientCode,
                    PercentualeCoperta=percentualeCoperta
                };
            }
            else if(userChoice == 'c')
            {
                int anni = (int)GetFloat("anni del cliente");
                newPolizza = new PolizzaVita()
                {
                    DataStipula = dataStipula,
                    ImportoAssicurato = importoAssicurato,
                    RataMensile = rataMensile,
                    ClienteCodiceFiscale = clientCode,
                    AnniAssicurato=anni
                };
            }
            else
            {
                Console.WriteLine("Scelta inserita non valida.");
            }

            repoPolizza.Create(newPolizza);
            Console.WriteLine("Polizza aggiunta");
        }

        private static float GetFloat(string v)
        {
           float i;
            do
            {
                Console.Write($"\nInserisci {v}: ");

            } while (!float.TryParse(Console.ReadLine(), out i));
            return i;
        }

        private static DateTime GetDate(string v)
        {
            DateTime dt;
            do
            {
                Console.Write($"\nInserisci {v} mm/dd/yy : ");
                
            } while (!DateTime.TryParse(Console.ReadLine(),out dt));
            return dt;
        }

        private static void AzioniCliente()
        {

            string codice = GetData("codice fiscale");
            string nome = GetData("nome");
            string cognome = GetData("cognome");
            string indirizzo = GetData("indirizzo");

            var newCliente = repoCliente.Create(new Cliente()
            {
                CodiceFiscale = codice,
                Nome = nome,
                Cognome = cognome,
                Indirizzo=indirizzo

            });
            if(newCliente != null)
            {
                Console.WriteLine("Cliente aggiunto.");
                Console.WriteLine(newCliente);
            }
            else
            {
                Console.WriteLine("Ops! Qualcosa è andato storto.");
            }

        }

        private static string GetData(string info)
        {
            string s;
            do
            {
               
                Console.Write($"\nInserisci {info}: ");
                s = Console.ReadLine();

            } while (string.IsNullOrEmpty(s));
            return s;
        }
    }
}
