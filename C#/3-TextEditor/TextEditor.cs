namespace TextEditor
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
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            if (short.TryParse(Console.ReadLine(), out short option))
            {
                switch (option)
                {
                    case 0: Environment.Exit(0); break;
                    case 1: Abrir(); break;
                    case 2: Editar(); break;
                    default: Menu(); break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                Menu();
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string? path = Console.ReadLine();

            if (File.Exists(path))
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("----------------");
            string text = "";

            do
            {
                text += Console.ReadLine() + Environment.NewLine;
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();
            if (!string.IsNullOrEmpty(path))
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            }
            else
            {
                Console.WriteLine("Caminho inválido.");
            }

            Console.ReadLine();
            Menu();
        }

    }
}
