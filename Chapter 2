using System;

namespace ders2
{
    class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string Aciklama { get; set; }
        public int SayfaSayisi { get; set; }
        public bool Odunc { get; set; }
        public int KitapID { get; set; }
    }

    class Kutuphane
    {
        private Kitap[] kitaplar;
        private int kitapsayisi;

        public Kutuphane(int kapasite)
        {
            kitaplar = new Kitap[kapasite];
            kitapsayisi = 0;
        }

        public void KitapEkle(string ad, string yazar, string aciklama, int sayfaSayisi)
        {
            if (kitapsayisi < kitaplar.Length)
            {
                Kitap yenikitap = new Kitap();
                yenikitap.Ad = ad;
                yenikitap.Aciklama = aciklama;
                yenikitap.SayfaSayisi = sayfaSayisi;
                yenikitap.Yazar = yazar;
                yenikitap.KitapID = kitapsayisi + 1;
                yenikitap.Odunc = false;
                
                kitaplar[kitapsayisi] = yenikitap;
                kitapsayisi++;
                
                Console.WriteLine($"'{ad}' kitabı başarıyla eklendi!");
            }
            else
            {
                Console.WriteLine("Kütüphane Dolu!");
            }
        }

        public void KitaplariListele()
        {
            Console.WriteLine("\n--- KÜTÜPHANE KİTAPLARI ---");
            for (int i = 0; i < kitapsayisi; i++)
            {
                Console.WriteLine($"ID: {kitaplar[i].KitapID} | " +
                               $"Ad: {kitaplar[i].Ad} | " +
                               $"Yazar: {kitaplar[i].Yazar} | " +
                               $"Aciklama: {kitaplar[i].Aciklama} | " +
                               $"Sayfa Sayısı: {kitaplar[i].SayfaSayisi} | " +
                               $"Durum: {(kitaplar[i].Odunc ? "Ödünç Verildi" : "Mevcut")}");
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane(5);
            
            kutuphane.KitapEkle("Harry Potter", "J.K. Rowling", "Açıklama Test", 350);
            
            kutuphane.KitapEkle("1984", "George Orwell", 
                "1984 romanı, yazarın geleceğe ilişkin bir kabus senaryosudur. " +
                "Bireyselliğin ve insan haklarının tamamen yok edildiği, zihnin kontrol altına alındığı, " +
                "insanların makineleşmiş kitlelere dönüştürüldüğü totaliter bir dünya düzeni, " +
                "inanılmaz bir hayal gücüyle ve en ince ayrıntısına kadar romana aktarılmıştır.", 280);
            
            kutuphane.KitaplariListele();
            Console.ReadKey();
        }
    }
}
