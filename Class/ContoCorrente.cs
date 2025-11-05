using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_U1_W1_D3.Class
{
    public abstract class ContoCorrente
    {
        public bool HasContoCorrente = false;
        public string? NumeroContoCorrente { get; set; }

        public long NumeroCarta { get; set; }
        public string? Iban { get; set; }

        private int _numeroSegreto;

        public int Saldo { get; set; }
        public int NumeroSegreto
        {
            get { return _numeroSegreto; }
            set { _numeroSegreto = value; }
        }



        //METODO PER GENERARE UNA STRINGA DI NUMERI RANDOM DA CASTARE POI IN INTEGER E ASSEGNARLO ALLE PROPRIETA' NUMERO CARTA E NUMERO SEGRETO
        public string GenerateNumberRandom(int length)
        {
            Random rnd = new Random();

            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += rnd.Next(0, 10);
            }

            //Console.WriteLine(result);

            return result;
        }


        //METODO PER GENERARE UNA STRINGA DI NUMERI RANDOM CON LETTERE ALFABETICHE E ASSEGNARLO ALLE PROPRIETA' NUMERO CONTO CORRENTE E IBAN
        public string GenerateStringRandom(int length)
        {
            Random rnd = new Random();
            string result = "";

            string[] letter = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "z" };

            for (int i = 0; i < length; i++)
            {
                if (i < 3 || (i > 6 && i < 9) || (i > 11))
                {
                    result += rnd.Next(0, 10);

                }
                else
                {
                    result += letter[rnd.Next(0, letter.Length)].ToUpper();
                }
            }

            return result;

        }



        //METODO PER L'APERTURA DEL CONTO CORRENTE IMPOSTANDO DEI VALORI RANDOM A TUTTE LE PROPRIETA' TRANNE AL SALDO CON VALORE DI DEFAULT DI 1000
        public void OpenContoCorrente()
        {
            if (HasContoCorrente == false)
            {

                NumeroContoCorrente = GenerateStringRandom(10);
                NumeroCarta = int.Parse(GenerateNumberRandom(8));
                Iban = "IT" + GenerateStringRandom(16);
                NumeroSegreto = int.Parse(GenerateNumberRandom(5));

                int valore = 0;

                do
                {
                    Console.Write("Inserisci il valore da inserire nel saldo:");
                    valore = int.Parse(Console.ReadLine());

                    if (valore >= 1000)
                    {

                        Saldo = valore;
                    }
                    else
                    {
                        Console.WriteLine("Devi inserire una somma di almeno 1000€");
                    }

                } while (valore < 1000);


                HasContoCorrente = true;
            }
            else
            {
                Console.WriteLine("Hai già aperto il conto corrente!");
            }
        }


        //METODO PER IL PRELIEVO
        public int Prelievo(int valore)
        {
            return Saldo -= valore;
        }


        //METODO PER L'ACCREDITO
        public int Accredito(int valore)
        {
            return Saldo += valore;
        }


    }
}
