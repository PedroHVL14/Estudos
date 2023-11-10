namespace Calculator
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
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Sair");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção: ");

            if (!short.TryParse(Console.ReadLine(), out short res))
            {
                Console.ReadKey();
                Menu();
                return;
            }

            switch (res)
            {
                case 1:
                    Operacao((v1, v2) => v1 + v2, "soma");
                    break;
                case 2:
                    Operacao((v1, v2) => v1 - v2, "subtração");
                    break;
                case 3:
                    Operacao((v1, v2) => v1 / v2, "divisão");
                    break;
                case 4:
                    Operacao((v1, v2) => v1 * v2, "multiplicação");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }
        static void Operacao(Func<float, float, float> operacao, string nomeOperacao)
        {
            Console.Clear();

            Console.WriteLine($"Primeiro valor para {nomeOperacao}: ");
            float v1 = ReadFloat();
            Console.WriteLine($"Segundo valor para {nomeOperacao}: ");
            float v2 = ReadFloat();

            float resultado = operacao(v1, v2);
            Console.WriteLine($"O resultado da {nomeOperacao} é {resultado}");
            Console.ReadKey();
            Menu();
        }

        static float ReadFloat()
        {
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out float value))
                    return value;

                Console.WriteLine("Valor inválido, tente novamente:");
            }
        }
    }
}
