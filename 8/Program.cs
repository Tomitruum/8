namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            Pomoshnik.ProchitatIzBinara();

            while (true)
            {
                Console.WriteLine("\n1. Добавить задачу");
                Console.WriteLine("2. Просмотр задач");
                Console.WriteLine("3. Удалить задачу по ID");
                Console.WriteLine("4. Запросы LINQ");
                Console.WriteLine("5. Сохранить и выйти");
                Console.Write("Выберите действие: ");
                string otvet = Console.ReadLine();

                switch (otvet)
                {
                    case "1": Pomoshnik.DobavitZadachu(); break;
                    case "2": Pomoshnik.PosmotretVse(); break;
                    case "3": Pomoshnik.UdalitPoId(); break;
                    case "4": Pomoshnik.SdelatZaprosy(); break;
                    case "5": Pomoshnik.ZapisatDannyeVBinar(); return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }
    }
}
