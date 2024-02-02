using System;

namespace AppAliquota
{
    internal class Contribuente
    {
        private string _name;
        private string _surname;
        private int _giornoDinascita;
        private int _meseDiNascita;
        private int _annoDiNascita;
        private string _CF;
        private string _sex;
        private string _city;
        private int _annualIncome;
        private decimal _imposta;


        public Contribuente() { }

        // Metodo iniziale 
        public void Menu()
        {
            Console.WriteLine("BENVENUTO \n" +
                "=============================== \n" +
                "Prima di poter calcolare la tua aliquota abbiamo bisogno di alcuni dati \n" +
                "Premi un tasto per continuare");
            Console.ReadKey();
            InsertData();
        }

        // Metodo che parte in automatico dopo Menu() da cui otteniamo i dati dell'utente e che gestisce anche
        // il metodo per calcolare l'imposta e imposta il risultato finale
        public void InsertData()
        {
            AddName();
            AddSurname();
            AddDayOfBorn();
            AddMounthOfBorn();
            AddYearOfBorn();
            AddSex();
            AddCF();
            AddCity();
            AddAnnualIncome();
            Calcoulation();
            Results();
        }

        // Metodo che calcola l'imposta e restituisce il suo valore in base al valore di _annualIncome;
        public decimal Calcoulation()
        {

            if (_annualIncome <= 15000)
            {
                _imposta = _annualIncome * 23 / 100;
            }
            else if (_annualIncome <= 28000)
            {
                _imposta = 3450 + (_annualIncome - 15000) * 27 / 100;
            }
            else if (_annualIncome <= 55000)
            {
                _imposta = 6960 + (_annualIncome - 28000) * 28 / 100;
            }
            else if (_annualIncome <= 75000)
            {
                _imposta = 17220 + (_annualIncome - 55000) * 41 / 100;
            }
            else
            {
                _imposta = 25420 + (_annualIncome - 75000) * 43 / 100;
            }
            return _imposta;

        }

        // Metodo che restituisce tutti i risultati
        public void Results()
        {
            Console.WriteLine("\n===================================\n" +
                "CALCOLO DELL'IMPOSTA DA VERSARE:  \n" +
                $"Contribuente: {_name} {_surname} \n" +
                $"Nato il: {_giornoDinascita}/{_meseDiNascita}/{_annoDiNascita} ({_sex}) \n" +
                $"Residente in: {_city} \n" +
                $"Codice Fiscale: {_CF} \n" +
                $"Reddito dichiarato: {_annualIncome} \n" +
                $"IMPOSTA DA VERSARE: {_imposta} \n" +
                "Premere un tasto per chiudere, ma soprattuto paga il pizzo.");

            Console.ReadKey();
        }

        // Metodo che effettua un controllo per verificare se il giorno immesso e' valido
        public void AddDayOfBorn()
        {
            Console.WriteLine("Quando sei nato?");
            Console.WriteLine("Giorno: ");
            if (int.TryParse(Console.ReadLine(), out int giorno) && giorno >= 1 && giorno <= 31)
            {
                _giornoDinascita = giorno;
            }
            else
            {
                Console.WriteLine("Inserisci un giorno valido \n" +
                    "=============================================");
                AddDayOfBorn();
            }
        }

        // Metodo che effettua un controllo per verificare se il mese immesso e' valido
        public void AddMounthOfBorn()
        {
            Console.WriteLine("Mese: ");
            if (int.TryParse(Console.ReadLine(), out int mese) && mese >= 1 && mese <= 12)
            {
                _meseDiNascita = mese;
            }
            else
            {
                Console.WriteLine("Inserisci un mese valido \n" +
                    "=============================================");
                AddMounthOfBorn();
            }
        }

        // Metodo che effettua un controllo per verificare se il giorno immesso e' valido
        public void AddYearOfBorn()
        {
            Console.WriteLine("Anno: ");
            if (int.TryParse(Console.ReadLine(), out int anno) && anno >= 1900 && anno <= 2024)
            {
                _annoDiNascita = anno;
            }
            else
            {
                Console.WriteLine("Inserisci un anno valido \n" +
                    "=============================================");
                AddYearOfBorn();
            }
        }

        // Metodo che effettua un controllo per verificare se il nome immesso e' valido e non vuoto
        public void AddName()
        {
            Console.WriteLine("Inserisci il tuo nome e premi INVIO: ");
            string inputName = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputName))
            {
                _name = inputName;
            }
            else
            {
                Console.WriteLine("Inserisci un nome valido \n" +
                    "=============================================");
                AddName();
            }
        }

        // Metodo che effettua un controllo per verificare se il cognome immesso e' valido e non vuoto
        public void AddSurname()
        {
            Console.WriteLine("Inserisci il tuo cognome e premi INVIO: ");
            string inputSurname = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputSurname))
            {
                _surname = inputSurname;
            }
            else
            {
                Console.WriteLine("Inserisci un cognome valido \n" +
                    "=============================================");
                AddSurname();
            }
        }

        // Metodo che effettua un controllo per verificare se il sesso immesso e' valido e non vuoto,
        // non ho aggiunto controlli aggiuntivi perche mi piace l'idea di poter mettere qualsiasi genere si desideri
        // al di fuori del semplice M/F
        public void AddSex()
        {
            Console.WriteLine("Inserisci il tuo genere: ");
            string inputSex = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputSex))
            {
                _sex = inputSex;
            }
            else
            {
                Console.WriteLine("Inserisci un sesso valido \n" +
                    "=============================================");
                AddSex();
            }
        }

        // Metodo che effettua un controllo per verificare se il CF immesso e' valido e non vuoto
        public void AddCF()
        {
            Console.WriteLine("Inserisci il tuo Codice Fiscale: ");
            string inputCF = Console.ReadLine().ToUpper();

            if (!string.IsNullOrEmpty(inputCF) && inputCF.Length == 16)
            {
                _CF = inputCF;
            }
            else
            {
                Console.WriteLine("Inserisci un Codice Fiscale valido \n" +
                    "=============================================");
                AddCF();
            }
        }

        // Metodo che effettua un controllo per verificare se la citta' immessa e' valida e non vuota
        public void AddCity()
        {
            Console.WriteLine("Comune di residenza: ");
            string inputCity = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputCity))
            {
                _city = inputCity;
            }
            else
            {
                Console.WriteLine("Inserisci una citta' valida \n" +
                    "=============================================");
                AddCity();
            }
        }

        // Metodo che effettua un controllo per verificare se il reddito annuo immessa e' valido
        public void AddAnnualIncome()
        {
            Console.WriteLine("Inserisci il reddito annuale: ");
            if (int.TryParse(Console.ReadLine(), out int income) && income >= 0)
            {
                _annualIncome = income;
            }
            else
            {
                Console.WriteLine("Inserisci un valore numerico valido e non negativo \n" +
                    "=============================================");
                AddAnnualIncome();
            }
        }
    }
}
