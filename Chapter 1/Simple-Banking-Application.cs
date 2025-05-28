using System;

namespace ConsoleApp2
{
    class Program
    {
        private static int ID = -1;
        private static int BankID = -1;
        private static float Balance = 0;
        
        private static int[] Users = new int[] { 103, 121, 325, 487 };
        private static string[] Passwords = new string[] { "sifre1", "sifre2", "sifre3", "sifre4" };
        private static float[] Balances = new float[] { 5421.98f, 65487.43f, 20.32f, 345.92f };

        static void clearChat()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        static void Cprint(Object text)
        {
            clearChat();
            Console.WriteLine(text);
        }

        static Boolean Login()
        {
            Console.Write("Şener Banka Hoş Geldiniz :), Giriş Yapmak İçin Banka Numaranızı Giriniz: ");
            String BankNumS = Console.ReadLine();
            
            if (BankNumS == null || BankNumS == "")
                throw new Exception("Banka Numarası Girmek Zorunludur!");

            int BankNum = int.Parse(BankNumS);
            
            Console.Write("Banka Hesabınızın Şifresini Girin: ");
            String BankPass = Console.ReadLine();
            
            if (BankPass == null || BankPass == "")
                throw new Exception("Banka Şifrenizi Girmek Zorunludur!");

            int cache = 0;
            foreach (int i in Users)
            {
                if (cache >= Users.Length)
                {
                    throw new Exception("Hesap Bulunamadı!");
                }

                if (i == BankNum)
                {
                    break;
                }
                else
                {
                    cache++;
                }
            }
            
            try
            {
                String CachePass = Passwords[cache];
                if (CachePass != BankPass)
                {
                    throw new Exception("Girilen Şifre Yanlış!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            
            ID = cache;
            BankID = BankNum;
            
            try
            {
                Balance = Balances[cache];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            
            Console.WriteLine("Giriş Başarılı! Yönlendiriliyorsunuz");
            clearChat();

            return true;
        }

        static void ActionFunction(int Action)
        {
            try
            {
                switch (Action)
                {
                    case 1:
                        {
                            Console.WriteLine("Güncel Bakiyeniz: " + Balance);
                            break;
                        }
                    case 2:
                        {
                            float amount;
                            Console.WriteLine("Yatırılacak Tutarı Girin:");
                            String Cache1 = Console.ReadLine();
                            
                            if (float.TryParse(Cache1, out amount))
                            {
                                if (amount > 0)
                                {
                                    Balance += amount;
                                    Balances[ID] = Balance;
                                    clearChat();
                                    Console.WriteLine("İşlem Başarılı! " + amount + " Hesabınıza Eklendi!");
                                }
                                else
                                {
                                    clearChat();
                                    Console.WriteLine("Geçerli Bir Miktar giriniz!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Geçerli Bir Miktar giriniz!");
                            }
                            break;
                        }
                    case 3:
                        {
                            float amount;
                            Console.WriteLine("Çekilecek Tutarı Girin:");
                            String Cache1 = Console.ReadLine();
                            
                            if (float.TryParse(Cache1, out amount))
                            {
                                if (amount > 0 && amount <= Balance)
                                {
                                    Balance -= amount;
                                    Balances[ID] = Balance;
                                    clearChat();
                                    Console.WriteLine("İşlem Başarılı! " + amount + " Hesabınızdan Çekildi!");
                                }
                                else
                                {
                                    clearChat();
                                    Console.WriteLine("Geçerli Bir Miktar giriniz!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Geçerli Bir Miktar giriniz!");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Transfer Edilecek Hesap Numarasını Girin: ");
                            String Cache1 = Console.ReadLine();
                            
                            if (Cache1 == null || Cache1 == "")
                                throw new Exception("Hesap Numarası Girmek Zorunludur!");
                            
                            int Anumber = int.Parse(Cache1);

                            if (Anumber == BankID)
                            {
                                Console.WriteLine("Kendine Para Transfer Edemezsin!");
                                break;
                            }

                            int cache = 0;
                            int CF = 0;
                            foreach (int i in Users)
                            {
                                if (i == Anumber)
                                {
                                    CF = 1;
                                    break;
                                }
                                else
                                {
                                    cache++;
                                }
                            }
                            
                            if (CF == 0)
                            {
                                Console.WriteLine("Hesap Bulunamadı!");
                                break;
                            }

                            Console.WriteLine("Transfer Edilecek Miktarı Girin: ");
                            String Cache2 = Console.ReadLine();
                            
                            if (Cache2 == null || Cache2 == "")
                                throw new Exception("Miktar Girilmesi Zorunlu!");
                            
                            float Aamount = float.Parse(Cache2);
                            
                            if (Aamount > Balance)
                            {
                                Cprint("Kendi Bakiyenden Fazla Para Gönderemezsin!");
                                break;
                            }
                            else if (Aamount < 0)
                            {
                                Cprint("0 Dan Küçük Para Gönderemezsin!");
                                break;
                            }
                            
                            float Cbalance = Balances[cache];
                            Cbalance += Aamount;
                            Balance -= Aamount;
                            Balances[ID] = Balance;
                            Balances[cache] = Cbalance;
                            Cprint("Para Transferi Başarıyla Yapıldı!");

                            break;
                        }
                    case 5:
                        {
                            ID = -1;
                            BankID = -1;
                            Balance = -1;
                            clearChat();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    if (ID == -1 || BankID == -1)
                    {
                        if (Login() == false)
                            continue;
                    }
                    else
                    {
                        Console.WriteLine("Sisteme Hoşgeldiniz!\nHesap Numarası:" + BankID + "\tBakiye:" + Balance);
                        Console.Write("İşlemler\n1-Bakiye Görüntüle\t2-Para Yatır\n3-Para Çek\t4-Para Transfer\n5-Çıkış Yap Et\nİşlem:");

                        String Actions = Console.ReadLine();
                        
                        if (Actions == null || Actions == "")
                            throw new Exception("İşlem Seçmek Zorunlu!");
                        
                        int Action = int.Parse(Actions);
                        clearChat();
                        ActionFunction(Action);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
