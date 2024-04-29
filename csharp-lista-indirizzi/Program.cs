namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> indirizzi = new List<Address>();
            string path = "C:\\.NET\\addresses.csv";
            using StreamReader stream = File.OpenText(path);
            {
                while (stream.EndOfStream == false)
                {
                    string? line = stream.ReadLine();
                    string[] parameters = line.Split(',');
                    try
                    {
                        if (parameters.Length < 6)
                        {
                            throw new IndexOutOfRangeException();
                        }else if (parameters.Length > 6)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        string name = parameters[0];
                        string surname = parameters[1];
                        string street = parameters[2];
                        string city = parameters[3];
                        string province = parameters[4];
                        string zipCode = parameters[5];

                        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                        {
                            throw new ArgumentException();
                        }


                        Address indirizzo = new Address(name, surname, street, city, province, zipCode);
                        indirizzi.Add(indirizzo);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        if (parameters.Length < 6)
                            Console.WriteLine("Sono stati inseriti meno parametri del dovuto: " + line);
                        else if (parameters.Length > 6)
                            Console.WriteLine("Sono stati inseriti piu' parametri del dovuto: " + line);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Nome o cognome mancante: " + line);
                    }
                }
            }

            string bonusPath = "C:\\.NET\\addresses-bonus.csv";
            using (File.Create(bonusPath)) { }
            List<string> bonusList = new List<string>();
            foreach (var indirizzo in indirizzi)
            {
                Console.WriteLine(indirizzo.ToString());
                bonusList.Add(indirizzo.ToString());
            }
            File.WriteAllLines(bonusPath, bonusList);

            Console.WriteLine("File contenente gli indirizzi corretti e' stato creato correttamente!");
        }
    }
}
