namespace Stopwatch
{
    class Program
    {
        static void MainWF(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string? data = Console.ReadLine();

            if (data == null)
            {
                Console.WriteLine("No input provided. Exiting...");
                Thread.Sleep(1000);
                return;
            }

            data = data.ToLower();

            if (data.Length < 2)
            {
                Console.WriteLine("Invalid input format.");
                Thread.Sleep(1000);
                return;
            }

            char type = char.Parse(data.Substring(data.Length - 1, 1));
            if (!int.TryParse(data.Substring(0, data.Length - 1), out int time))
            {
                Console.WriteLine("Invalid time format.");
                Thread.Sleep(1000);
                return;
            }

            int multiplier = (type == 'm') ? 60 : 1;

            if (time == 0)
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(1000);
                System.Environment.Exit(0);
            }

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}