

using Back_End_U1_W1_D3.Class;


class Program()
{


    public static string Tastiera(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine();
    }

    public static void RicercaUtente(string str, string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (str == arr[i])
            {
                Console.WriteLine($"Il nome {str} è presente nell'array nella posizione: {i}");
                return;
            }
        }

        Console.WriteLine($"Il nome {str} non è presente nell'array.");

    }



    static void Main(string[] args)
    {

        int scelta = 0;

        Cliente user1 = new Cliente();

        do
        {
            scelta = int.Parse(Tastiera("1. Apri il conto corrente. \n 2. Fai un prelievo \n 3. Fai un accredito \n 4. Visualizza dettagli: \n 5: Per uscire."));

            switch (scelta)
            {
                case 1:
                    user1.Name = Tastiera("Inserisci il nome:");
                    user1.LastName = Tastiera("Inserisci il cognome:");
                    user1.OpenContoCorrente();
                    break;
                case 2:
                    user1.Prelievo(int.Parse(Tastiera("Quanto vuoi prelevare? ")));
                    break;
                case 3:
                    user1.Accredito(int.Parse(Tastiera("Quanto vuoi accreditare? ")));
                    break;
                case 4:
                    Console.WriteLine($"Nome: {user1.Name}, Cognome: {user1.LastName} ,numero conto {user1.NumeroContoCorrente}, numero carta {user1.NumeroCarta}, iban {user1.Iban}, numero segreto {user1.NumeroSegreto} , saldo {user1.Saldo}");
                    break;
                default:
                    scelta = 5;
                    break;
            }

        } while (scelta != 5);

        // Esercizio 2
        int inputArray = int.Parse(Tastiera("Inserisci la lunghezza dell'array per i nome:"));

        string[] nameInput = new string[inputArray];

        for (int i = 0; i < nameInput.Length; i++)
        {
            nameInput[i] = Tastiera("Inserisci il nome:");
        }

        foreach (var item in nameInput)
        {
            Console.WriteLine(item);
        }


        RicercaUtente(Tastiera("Inserisci il nome per la ricerca:"), nameInput);



        //Esercizio 3

        int inputArrayNumber = int.Parse(Tastiera("Inserisci la lunghezza dell'array per i numeri:"));

        int[] numberInput = new int[inputArrayNumber];

        for (int i = 0; i < numberInput.Length; i++)
        {
            numberInput[i] = int.Parse(Tastiera("Inserisci un numero:"));
        }

        foreach (var item in numberInput)
        {
            Console.WriteLine(item);
        }

        int somma = 0;
        foreach (var item in numberInput)
        {
            somma += item;
        }

        Console.WriteLine("La somma è: " + somma);

        float mediaNumeri = somma / numberInput.Length;

        Console.WriteLine("La media è: " + mediaNumeri);


    }

}