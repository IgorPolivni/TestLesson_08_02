using System;

namespace Transcard
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cPaymentMethods = 2;//Количество способов оплаты
            const int cBusTypes = 3; //Количество типов автобусов
            const int cTariff = 3; //Количество тарифов
            const int cNonCashMethods = 3; //Количество тарифов

            Console.WriteLine("Введите тип автобуса: ");
            for (int i = 1;i<= cBusTypes; i++)
            {
                Console.WriteLine($"{i}.{(BusTypes)i}");
            }
            int.TryParse(Console.ReadLine(), out int Choose);

            BusTypes bysType = (BusTypes)Choose;

            Console.WriteLine("Введите Тариф: ");
            for (int i = 1; i <= cTariff; i++)
            {
                Console.WriteLine($"{i}.{(Tariff)i}");
            }
            int.TryParse(Console.ReadLine(), out  Choose);

            Tariff tariff = (Tariff)Choose;


            Console.WriteLine("Введите метод оплаты: ");
            for (int i = 1; i <=2; i++)
            {
                Console.WriteLine($"{i}.{(PaymentMethods)i}");
            }
            int.TryParse(Console.ReadLine(), out Choose);

            PaymentMethods paymentMethod = (PaymentMethods)Choose;

            Tiket tiket = new Tiket()
            {
                Date = DateTime.Now,
                TiketNumbet = Servise.GetRandomNumber(),
                Bus = new BusClass()
                {
                    Id = Servise.GetRandomNumber(),
                    BusPark = Servise.GetRandomPark(),
                    Type = bysType
                },
                Tariff = tariff,
                paymentMethod = PaymentMethods.CashMethod
            };

            switch ((int)paymentMethod)
            {
                case 1:
                    tiket.paymentMethod = PaymentMethods.CashMethod;
                    PayService.showTiket(tiket);
                    break;
                case 2:
                    Console.WriteLine("Введите вид безналичной оплаты: ");
                    for (int i = 1; i <= cNonCashMethods; i++)
                    {
                        Console.WriteLine($"{i}.{(NonCashMethods)i}");
                    }
                    int.TryParse(Console.ReadLine(), out Choose);
                    
                    NonCashMethods NonCashMethod = (NonCashMethods)Choose;

                    tiket.paymentMethod = PaymentMethods.NonCashMethods;
                    PayService.showTiket(tiket);
                    Console.WriteLine("Было оплачено через: " +NonCashMethod);
                    break;
            }
        }
    }
}
