using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task2
{
    static void Main()
    {
        Console.Write("Введите площадь помещения (в кв. м.): ");
        double area = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите количество проживающих: ");
        int residents = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите сезон (осень/зима/весна/лето): ");
        string season = Console.ReadLine().ToLower();

        Console.Write("Есть ли льготы (да/нет): ");
        bool hasBenefits = Console.ReadLine().ToLower() == "да";

        // Базовые тарифы
        double heatingRate = 10; // тариф на отопление за 1 кв. м.
        double waterRate = 5; // тариф на воду за 1 чел.
        double gasRate = 7; // тариф на газ за 1 чел.
        double repairRate = 15; // тариф на текущий ремонт за 1 кв. м.

        double heatingSeasonalMultiplier = (season == "осень" || season == "зима") ? 1.2 : 1.0;

        double heatingPayment = area * heatingRate * heatingSeasonalMultiplier;
        double waterPayment = residents * waterRate;
        double gasPayment = residents * gasRate;
        double repairPayment = area * repairRate;

        double benefits = 0;

        if (hasBenefits)
        {
            Console.Write("Введите категорию льгот (ветеран труда/ветеран войны): ");
            string category = Console.ReadLine().ToLower();

            switch (category)
            {
                case "ветеран труда":
                    benefits = (heatingPayment + waterPayment + gasPayment + repairPayment) * 0.3;
                    break;
                case "ветеран войны":
                    benefits = (heatingPayment + waterPayment + gasPayment + repairPayment) * 0.5;
                    break;
                default:
                    Console.WriteLine("Некорректная категория льгот.");
                    break;
            }
        }

        double totalPayment = heatingPayment + waterPayment + gasPayment + repairPayment - benefits;

        Console.WriteLine("\nТаблица платежей:");
        Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-10}", "Вид платежа", "Начислено", "Льготная скидка", "Итого");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("{0,-20} {1,-10:C} {2,-20:C} {3,-10:C}", "Отопление", heatingPayment, (hasBenefits ? benefits : 0), heatingPayment - (hasBenefits ? benefits : 0));
        Console.WriteLine("{0,-20} {1,-10:C} {2,-20:C} {3,-10:C}", "Вода", waterPayment, (hasBenefits ? benefits : 0), waterPayment - (hasBenefits ? benefits : 0));
        Console.WriteLine("{0,-20} {1,-10:C} {2,-20:C} {3,-10:C}", "Газ", gasPayment, (hasBenefits ? benefits : 0), gasPayment - (hasBenefits ? benefits : 0));
        Console.WriteLine("{0,-20} {1,-10:C} {2,-20:C} {3,-10:C}", "Ремонт", repairPayment, (hasBenefits ? benefits : 0), repairPayment - (hasBenefits ? benefits : 0));

        Console.WriteLine(new string('-', 60));
        Console.WriteLine("{0,-20} {1,-10:C}", "Итого", totalPayment);
    }
}
