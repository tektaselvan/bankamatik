using System;

namespace bankamatik
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uygulama Bnkamatik
            // Menü:
            // Bakiye
            // Para Yatırma
            // Para Çekme
            // Çıkış
            string secim = "";
            double bakiye = 0;
            double ekhesap = 1000;
            double ekhesapLimiti = 1000;
            do
            {

                Console.Write("1-Bakiye Görüntüle\n2-Para Yatırma\n3-Para Çekme\n4-Çıkış\nSeçiminiz:");
                secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Bakiyeniz {0} TL", bakiye);
                        Console.WriteLine("Ek Hesap Bakiyeniz {0} TL", ekhesap);
                        break;
                    case "2":
                        Console.Write("Yatırmak istediğiniz miktar: ");
                        double yatirilan = double.Parse(Console.ReadLine());
                        if (ekhesap > ekhesapLimiti)
                        {
                            double ekhesaptankullanilan = ekhesapLimiti - ekhesap;
                            if (yatirilan >= ekhesaptankullanilan)
                            {
                                ekhesap = ekhesapLimiti;
                                bakiye = yatirilan - ekhesaptankullanilan;
                            }
                            else
                            {
                                ekhesap += yatirilan;
                            }
                        }
                        else
                        {
                            bakiye += yatirilan;
                        }

                        break;
                    case "3":
                        Console.Write("Çekmek istediğiniz miktar: ");
                        double cekilenmiktar = double.Parse(Console.ReadLine());
                        if (cekilenmiktar > bakiye)
                        {
                            double toplam = bakiye + ekhesap;
                            if (toplam >= cekilenmiktar)
                            {
                                Console.Write("Ek Hesap Kullanılsın mı? (e/h)");
                                string ekhesaptercihi = Console.ReadLine();

                                if (ekhesaptercihi == "e")
                                {
                                    Console.WriteLine("Paranızı Alabilirsiniz!");
                                    ekhesap -= (cekilenmiktar - bakiye);
                                    bakiye = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Bakiyeniz Yetersiz!");
                                }
                            }


                        }

                        else
                        {
                            Console.WriteLine("Bakiyeniz yetersiz.");
                            bakiye -= cekilenmiktar;
                        }

                        break;
                    case "4":
                        Console.WriteLine("Çıkış");
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim");
                        break;
                }
            } while (secim != "4");
            Console.WriteLine("Uygulamadan Çıkış Yapıldı.");
        }

    }
}
