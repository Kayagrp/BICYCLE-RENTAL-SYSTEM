using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje3
{
    public class Durak//durak sınıfı 
    {
        public string durak_adi;
        public int bos_park;
        public int tandem_bisiklet;
        public int normal_bisiklet;
        public string GetDurakAdi()
        {
            return durak_adi;
        }

        public Durak()
        {

        }
        public Durak(String durak_adi, int bos_park, int tandem_bisiklet, int normal_bisiklet)
        {
            this.durak_adi = durak_adi;
            this.bos_park = bos_park;
            this.tandem_bisiklet = tandem_bisiklet;
            this.normal_bisiklet = normal_bisiklet;
        }
    }
    public class Dugum<Durak>//durak nesnelerinden oluşan ve müşteri listesi içeren düğüm
    {
        public Durak durak { get; set; }
        public Dugum<Durak> sag { get; set; }
        public Dugum<Durak> sol { get; set; }
        public List<Musteri> musteri_list;

    }
    public class Agac<Durak>// Dugum<Durak> düğümlerinden oluşan ağaç
    {
        public Dugum<Durak> kok { get; set; }

        public int derinlik(Dugum<Durak> dugum)//ağacın derinliğini bulduran metod
        {
            if (dugum == null)
                return 0;
            else
            {
                int sol_derinlik = derinlik(dugum.sol);
                int sag_derinlik = derinlik(dugum.sag);

                if (sol_derinlik > sag_derinlik)
                    return (sol_derinlik + 1);
                else
                    return (sag_derinlik + 1);
            }
        }
    }
    public class Musteri// id ve saat içeren müşteri sınıfı
    {
        string id;
        string saat;
        public Musteri(string id, string saat)
        {
            this.id = id;
            this.saat = saat;
        }
        public Musteri()
        {

        }
        public string Getİd()
        {
            return id;
        }
        public string GetSaat()
        {
            return saat;
        }
    }

    class HeapDugum
    {
        public Durak durak;
        public HeapDugum(Durak durak)
        {
            this.durak = durak;
        }
        public HeapDugum()
        {

        }
        public Durak GetDurak()
        {
            return durak;
        }
    }
    class Heap
    {
        private HeapDugum[] heapDizisi;
        private int boyut; 
        private int currentSize; 
        public Heap(int mx) 
        {
            boyut = mx;
            currentSize = 0;
            heapDizisi = new HeapDugum[boyut]; 
        }
        public Boolean isEmpty()
        { return currentSize == 0; }
        public Boolean insert(Durak durak)
        {
            if (currentSize == boyut)
                return false;
            HeapDugum heap_dugum = new HeapDugum(durak);
            heapDizisi[currentSize] = heap_dugum;
            trickleUp(currentSize++);
            return true;
        } 
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugum bottom = heapDizisi[index];
            while (index > 0 && heapDizisi[parent].durak.normal_bisiklet < bottom.durak.normal_bisiklet)
            {
                heapDizisi[index] = heapDizisi[parent]; 
                index = parent;
                parent = (parent - 1) / 2;
            } 
            heapDizisi[index] = bottom;
        } 

        public HeapDugum remove()
        {
            HeapDugum kok = heapDizisi[0];
            heapDizisi[0] = heapDizisi[--currentSize];
            trickleDown(0);
            return kok;

        }
        public void trickleDown(int index)
        {
            int largeChild;
            HeapDugum tepe = heapDizisi[index];
            while (index < currentSize / 2)
            {
                int leftChild=2*index+1;
                int rightChild=leftChild+1;
                if (rightChild < currentSize && heapDizisi[leftChild].durak.normal_bisiklet < heapDizisi[rightChild].durak.normal_bisiklet)
                {
                    largeChild = rightChild;
                }
                else
                    largeChild = leftChild;
                if (tepe.durak.normal_bisiklet >= heapDizisi[largeChild].durak.normal_bisiklet)
                    break;
                heapDizisi[index] = heapDizisi[largeChild];
                index = largeChild;
           
            }
            heapDizisi[index] = tepe;
        }


    }



    class HeapDugumDeneme
    {
        public int deger;
        public HeapDugumDeneme()
        {
        }
        public HeapDugumDeneme(int deger)
        {
            this.deger = deger;
        }

        public int GetDurak()
        {
            return deger;
        }
    }
    class HeapDeneme
    {
        private HeapDugumDeneme[] heapDizisi;
        private int boyut; 
        private int currentSize; 
        public HeapDeneme(int byt) 
        {
            boyut = byt;
            currentSize = 0;
            heapDizisi = new HeapDugumDeneme[boyut];
        }
        public Boolean isEmpty()
        { return currentSize == 0; }
        public Boolean insert(int deger)
        {
            if (currentSize == boyut)
                return false;
            HeapDugumDeneme heap_dugum = new HeapDugumDeneme(deger);
            heapDizisi[currentSize] = heap_dugum;
            trickleUp(currentSize++);
            return true;
        } 
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumDeneme bottom = heapDizisi[index];
            while (index > 0 && heapDizisi[parent].deger < bottom.deger)
            {
                heapDizisi[index] = heapDizisi[parent]; 
                index = parent;
                parent = (parent - 1) / 2;
            } 
            heapDizisi[index] = bottom;
        } 

        public HeapDugumDeneme remove()
        {
            HeapDugumDeneme kok = heapDizisi[0];
            heapDizisi[0] = heapDizisi[--currentSize];
            trickleDown(0);
            return kok;

        }
        public void trickleDown(int index)
        {
            int largeChild;
            HeapDugumDeneme tepe = heapDizisi[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && heapDizisi[leftChild].deger < heapDizisi[rightChild].deger)
                {
                    largeChild = rightChild;
                }
                else
                    largeChild = leftChild;
                if (tepe.deger >= heapDizisi[largeChild].deger)
                    break;
                heapDizisi[index] = heapDizisi[largeChild];
                index = largeChild;

            }
            heapDizisi[index] = tepe;
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
                Agac<Durak> agac = new Agac<Durak>();
                string[] duraklar = { "İnciraltı,28,2,10", "Sahilevleri,8,1,11", "Doğal Yaşam Parkı,17,1,6", "Bostanlı İskele,7,0,5", "Bornova,9,5,10", "Hasanağa,4,6,8", "Bayraklı,21,7,10", "Karataş,5,12,7", "Fahrettin Altay,3,8,12" };
                List<Durak> Duraklar_Listesi = Durak_olustur(duraklar);
                List<Musteri> Musteri_Listesi = MusteriOlustur();
                agac = AgacYapici(Duraklar_Listesi, Musteri_Listesi);
                Hashtable hst = HashtableYap(duraklar);
                int derin = agac.derinlik(agac.kok);
                Console.WriteLine("----------------AĞAÇ VERİ YAPISI YAZDIRILIYOR-----------------");
                agacYazdır(agac.kok);
                Console.WriteLine("-----------------------AĞAÇ DERİNLİĞİ-------------------------");
                Console.WriteLine(derin);
                Console.WriteLine("----------------------KİRALAMA BİLGİSİ------------------------");
                Console.WriteLine("Kiralama bilgisi istenen müşterinin ID'sini girin");
                string mus_id = Console.ReadLine();
                MusteriBilgisi(agac.kok, mus_id);
                Console.WriteLine("--------------------");
                Console.WriteLine("----------------KİRALATMA UYGULAMASI---------------");
                Console.WriteLine("Durak adı girin: ");
                string ad_tut = Console.ReadLine();
                Console.WriteLine("Müşteri ID girin: ");
                string id_tut = Console.ReadLine();
                MusteriKiralama(agac.kok, ad_tut, id_tut);
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------------HASHTABLE YAZDIRILIYOR---------------");
                for (int i = 0; i < Duraklar_Listesi.Count; i++)
                {
                    HashtableYazdir(hst, Duraklar_Listesi[i].durak_adi);
                }
                Console.WriteLine("----------------------------------------------------");


                Console.WriteLine("-------------------------HEAP---------------------------");
                Heap heap = new Heap(9);
            HeapDeneme deneme = new HeapDeneme(9);
                for (int i = 0; i < Duraklar_Listesi.Count; i++)
                {
                    heap.insert(Duraklar_Listesi[i]);
                    deneme.insert(i);
                }
                HeapDugum hpDugum = new HeapDugum();
                HeapDugumDeneme hpDugumDeneme = new HeapDugumDeneme();
            Console.WriteLine("----------------------Int Heap----------------------------");
            for (int i = 0; i < 9; i++)
            {
                hpDugumDeneme = deneme.remove();
                Console.WriteLine(hpDugumDeneme.deger);
            }
            Console.WriteLine("----------------------Duraklar Heap----------------------------");
            for (int i = 0; i < 3; i++)
                {
                hpDugum = heap.remove();
                Console.WriteLine(String.Format("{0,17}{1,17}{2,17}{3,17}", "Durak Adı", "Boş Park", "Tandem Bisiklet", "Normal Bisiklet"));
                Console.WriteLine(String.Format("{0,17}{1,17}{2,17}{3,17}", hpDugum.durak.durak_adi, hpDugum.durak.bos_park, hpDugum.durak.tandem_bisiklet, hpDugum.durak.normal_bisiklet));
                Console.WriteLine();
                }
            Random rand = new Random();
                int[] bubble_dizi = new int[15];
                int[] shell_dizi = new int[15];
            Console.WriteLine("Bubble sort dizinin ilk hali   "+"Shell sort dizinin ilk hali");
                for (int i = 0; i < 15; i++)
                {
                    bubble_dizi[i] = rand.Next(0,999);
                    shell_dizi[i] = rand.Next(0,999);
                    Console.WriteLine("            "+bubble_dizi[i].ToString("000")+"                            "+shell_dizi[i].ToString("000"));
                }

                Console.WriteLine("-------------------------BUBBLE SORT SIRALAMA---------------------------");
                BubbleSort(bubble_dizi);
                for (int i = 0; i < bubble_dizi.Length; i++)
                {
                    Console.WriteLine(bubble_dizi[i]);
                }
                Console.WriteLine("-------------------------SHELL SORT SIRALAMA---------------------------");
                ShellSort(shell_dizi);
                for(int i = 0; i < shell_dizi.Length; i++)
                {
                    Console.WriteLine(shell_dizi[i]);
                }
                Console.ReadKey();
            }
            public static void HashtableYazdir(Hashtable hashtbl, string durakAdi)//hashtable yazdırır
            {
                if (hashtbl.ContainsKey(durakAdi))
                {
                    Console.WriteLine(hashtbl[durakAdi]);
                }
            }
            public static Hashtable HashtableYap(string[] Duraklar_Dizisi)//durak adına göre hashtable oluşturur
            {
                Hashtable hashtbl = new Hashtable();
                for (int i = 0; i < Duraklar_Dizisi.Length; i++)
                {
                    string[] durak_dizisi = Duraklar_Dizisi[i].Split(',');
                    hashtbl.Add(durak_dizisi[0], Duraklar_Dizisi[i]);
                }

                for (int j = 0; j < Duraklar_Dizisi.Length; j++)
                {
                    string[] durak_dizisi = Duraklar_Dizisi[j].Split(',');
                    string durak_adi = durak_dizisi[0];
                    int bos_park = Int32.Parse(durak_dizisi[1]);
                    int tandem_say = Int32.Parse(durak_dizisi[2]);
                    int normal_say = Int32.Parse(durak_dizisi[3]);
                    if (bos_park > 5)
                    {
                        normal_say = normal_say + 5;
                        bos_park -= 5;
                    }
                    Duraklar_Dizisi[j] = durak_adi + "," + bos_park.ToString() + "," + tandem_say.ToString() + "," + normal_say.ToString();
                    hashtbl[durak_adi] = Duraklar_Dizisi[j];
                }
                return hashtbl;
            }
            public static List<Durak> Durak_olustur(string[] duraklar)//duraklar dizisindeki elemanlarla durak nesnelerinden oluşan liste döndürür
            {
                List<Durak> Duraklar_Listesi = new List<Durak>();
                string bilgiler;
                string[] parcalar;
                for (int i = 0; i < duraklar.Length; i++)
                {
                    bilgiler = duraklar[i];
                    parcalar = bilgiler.Split(',');
                    Duraklar_Listesi.Add(new Durak(parcalar[0], Int32.Parse(parcalar[1]), Int32.Parse(parcalar[2]), Int32.Parse(parcalar[3])));
                }
                return Duraklar_Listesi;
            }
            public static List<Musteri> MusteriOlustur()//Müşteri oluşturur
            {
                Random rand = new Random();
                List<Musteri> Musteri_Listesi = new List<Musteri>();
                for (int j = 0; j < 20; j++)
                {
                    int saat = rand.Next(0, 24);
                    int saniye = rand.Next(0, 59);
                    string zaman = saat.ToString("00") + ":" + saniye.ToString("00");
                    Musteri_Listesi.Add(new Musteri((j + 1).ToString(), zaman));
                }
                return Musteri_Listesi;
            }
            public static void MusteriKiralama(Dugum<Durak> dugum, string durakAdi, string id)//durak adı ve id si verilen müşteriye normal bisiklet kiralatır
            {
                if (dugum == null)
                {
                }
                else
                {
                    MusteriKiralama(dugum.sol, durakAdi, id);
                    
                        for (int i = 0; i < dugum.musteri_list.Count(); i++)
                        {
                            if (dugum.durak.durak_adi == durakAdi)
                            {
                                Random rand = new Random();
                                List<Musteri> Musteri_Listesi = new List<Musteri>();
                                int saat = rand.Next(0, 24);
                                int saniye = rand.Next(0, 59);
                                string zaman = saat.ToString("00") + ":" + saniye.ToString("00");
                                Musteri musteri = new Musteri(id, zaman);
                                dugum.musteri_list.Add(musteri);
                                dugum.durak.bos_park++;
                                dugum.durak.normal_bisiklet--;
                                Console.WriteLine(id + " ID'li müşteri saat " + zaman + " de " + durakAdi + " durağından normal bisiklet kiraladı. ");
                                Console.WriteLine("Devam etmek için enter'a basın.");
                                Console.ReadKey();
                                break;
                            }
                    }
                    MusteriKiralama(dugum.sag, durakAdi, id);
                }
            }
            public static void MusteriBilgisi(Dugum<Durak> dugum, string id)//id si verilen müşterinin bilgilerini yazdırır
            {

                if (dugum == null)
                {
                }
                else
                {
                    MusteriBilgisi(dugum.sol, id);
                    for (int i = 0; i < dugum.musteri_list.Count(); i++)
                    {
                        if (dugum.musteri_list[i].Getİd() == id)
                        {
                            Console.WriteLine("--------------------");
                            Console.WriteLine("Verilen ID:" + id);
                            Console.WriteLine(String.Format("{0,-12}{1,15}", "Durak Adı", "Kiralama Saati"));
                            Console.WriteLine(String.Format("{0,-12}{1,15}", dugum.durak.durak_adi, dugum.musteri_list[i].GetSaat()));
                        }
                    }
                    MusteriBilgisi(dugum.sag, id);
                }
            }
            public static void agacYazdır(Dugum<Durak> dugum)
            {
                if (dugum == null)
                {
                }
                else
                {
                    agacYazdır(dugum.sol);
                    Console.WriteLine(String.Format("{0,17}{1,17}{2,17}{3,17}", "Durak Adı", "Boş Park", "Tandem Bisiklet", "Normal Bisiklet"));
                    Console.WriteLine(String.Format("{0,17}{1,17}{2,17}{3,17}", dugum.durak.durak_adi, dugum.durak.bos_park, dugum.durak.tandem_bisiklet, dugum.durak.normal_bisiklet));

                    for (int i = 0; i < dugum.musteri_list.Count(); i++)
                    {

                        Console.Write("|ID: " + Int32.Parse(dugum.musteri_list[i].Getİd()).ToString("00") + "  Saat: ");
                        Console.Write(dugum.musteri_list[i].GetSaat() + "|");
                        Console.WriteLine();
                    }
                    Console.WriteLine("--------------------------------------------------------------");
                    agacYazdır(dugum.sag);
                }
            }
            public static Agac<Durak> AgacYapici(List<Durak> Duraklar_Listesi, List<Musteri> Musteri_Listesi)
            {
                Musteri musteri = new Musteri();
                Dugum<Durak> dugum = new Dugum<Durak>();
                Random rand = new Random();
                List<int> rastgele = new List<int>();
                Agac<Durak> agac = new Agac<Durak>();
                for (int i = 0; i < Duraklar_Listesi.Count; i++)
                {
                    if (agac.kok == null)
                    {
                        agac.kok = new Dugum<Durak>();
                        agac.kok.durak = Duraklar_Listesi[i];
                        dugum.musteri_list = new List<Musteri>();
                        int rnd = rand.Next(1, 11);
                        for (int j = 0; j < rnd; j++)
                        {
                            if (agac.kok.durak.normal_bisiklet > rnd)
                            {
                                dugum.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                agac.kok.durak.normal_bisiklet--;
                                agac.kok.durak.bos_park++;
                            }
                            else if (agac.kok.durak.normal_bisiklet < rnd && agac.kok.durak.tandem_bisiklet > rnd - agac.kok.durak.normal_bisiklet)
                            {
                                if (agac.kok.durak.normal_bisiklet > 0)
                                {
                                    dugum.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                    agac.kok.durak.normal_bisiklet--;
                                    agac.kok.durak.bos_park++;
                                }
                                else
                                {
                                    dugum.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                    agac.kok.durak.tandem_bisiklet--;
                                    agac.kok.durak.bos_park++;
                                }
                            }
                            else
                            {
                                if (agac.kok.durak.normal_bisiklet > 0)
                                {
                                    dugum.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                    agac.kok.durak.normal_bisiklet--;
                                    agac.kok.durak.bos_park++;

                                }
                                else if (agac.kok.durak.tandem_bisiklet > 0)
                                {
                                    dugum.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                    agac.kok.durak.tandem_bisiklet--;
                                    agac.kok.durak.bos_park++;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        agac.kok.musteri_list = dugum.musteri_list;
                        continue;
                    }
                    Dugum<Durak> mevcut = agac.kok;
                    Boolean eklendi_mi = false;
                    while (eklendi_mi == false)
                    {
                        if (Comparer<string>.Default.Compare(Duraklar_Listesi[i].durak_adi, mevcut.durak.durak_adi) == -1)
                        {
                            if (mevcut.sol == null)
                            {
                                mevcut.sol = new Dugum<Durak>();
                                mevcut.sol.durak = Duraklar_Listesi[i];
                                mevcut.sol.musteri_list = new List<Musteri>();
                                int rnd = rand.Next(1, 11);
                                for (int j = 0; j < rnd; j++)
                                {
                                    if (mevcut.sol.durak.normal_bisiklet > rnd)
                                    {
                                        mevcut.sol.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                        mevcut.sol.durak.normal_bisiklet--;
                                        mevcut.sol.durak.bos_park++;
                                    }
                                    else if (mevcut.sol.durak.normal_bisiklet < rnd && mevcut.sol.durak.tandem_bisiklet > rnd - mevcut.sol.durak.normal_bisiklet)
                                    {
                                        if (mevcut.sol.durak.normal_bisiklet > 0)
                                        {
                                            mevcut.sol.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sol.durak.normal_bisiklet--;
                                            mevcut.sol.durak.bos_park++;
                                        }
                                        else
                                        {
                                            mevcut.sol.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sol.durak.tandem_bisiklet--;
                                            mevcut.sol.durak.bos_park++;
                                        }
                                    }
                                    else
                                    {
                                        if (mevcut.sol.durak.normal_bisiklet > 0)
                                        {
                                            mevcut.sol.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sol.durak.normal_bisiklet--;
                                            mevcut.sol.durak.bos_park++;
                                        }
                                        else if (mevcut.sol.durak.tandem_bisiklet > 0)
                                        {
                                            mevcut.sol.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sol.durak.tandem_bisiklet--;
                                            mevcut.sol.durak.bos_park++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                eklendi_mi = true;
                            }
                            else
                            {
                                mevcut = mevcut.sol;
                            }
                        }
                        else
                        {
                            if (mevcut.sag == null)
                            {
                                mevcut.sag = new Dugum<Durak>();
                                mevcut.sag.durak = Duraklar_Listesi[i];
                                mevcut.sag.musteri_list = new List<Musteri>();
                                int rnd = rand.Next(1, 11);
                                for (int j = 0; j < rnd; j++)
                                {
                                    if (mevcut.sag.durak.normal_bisiklet > rnd)
                                    {
                                        mevcut.sag.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                        mevcut.sag.durak.normal_bisiklet--;
                                        mevcut.sag.durak.bos_park++;
                                    }
                                    else if (mevcut.sag.durak.normal_bisiklet < rnd && mevcut.sag.durak.tandem_bisiklet > rnd - mevcut.sag.durak.normal_bisiklet)
                                    {
                                        if (mevcut.sag.durak.normal_bisiklet > 0)
                                        {
                                            mevcut.sag.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sag.durak.normal_bisiklet--;
                                            mevcut.sag.durak.bos_park++;
                                        }
                                        else
                                        {
                                            mevcut.sag.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sag.durak.tandem_bisiklet--;
                                            mevcut.sag.durak.bos_park++;
                                        }
                                    }
                                    else
                                    {
                                        if (mevcut.sag.durak.normal_bisiklet > 0)
                                        {
                                            mevcut.sag.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sag.durak.normal_bisiklet--;
                                            mevcut.sag.durak.bos_park++;
                                        }
                                        else if (mevcut.sag.durak.tandem_bisiklet > 0)
                                        {
                                            mevcut.sag.musteri_list.Add(Musteri_Listesi.ElementAt(rand.Next(0, 20)));
                                            mevcut.sag.durak.tandem_bisiklet--;
                                            mevcut.sag.durak.bos_park++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                eklendi_mi = true;
                            }
                            else
                            {
                                mevcut = mevcut.sag;
                            }
                        }
                    }
                }
                return agac;
            }
            public static void BubbleSort(int[] dizi)
            {
                int tutmac;
                for (int i = 0; i < dizi.Length; i++)
                {
                    for (int j = dizi.Length - 1; j > 0; j--)
                    {
                        if (dizi[j - 1] > dizi[j])
                        {
                            tutmac = dizi[j];
                            dizi[j] = dizi[j - 1];
                            dizi[j - 1] = tutmac;
                        }
                    }
                }
                
            }
            public static void ShellSort(int[] dizi)
            {
                int uzunluk = dizi.Length;
                int orta = uzunluk / 2;
                for(int i = orta; i > 0; i/=2)
                {
                    for(int j = i; j < uzunluk; j++)
                    {
                        int tut = dizi[j];
                        int k;
                        for(k = j; k >= i && dizi[k - i] > tut; k -= i)
                        {
                            dizi[k] = dizi[j - i];
                        }
                        dizi[k] = tut;
                    }
                }
            }

        }
    }

