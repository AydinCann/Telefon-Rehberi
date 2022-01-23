using System;
using System.Collections.Generic;

namespace Telefon_Rehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Can","Aydın", "0555 111 11 11"));
            persons.Add(new Person("Cem", "Aydın", "0541 222 33 44"));
            persons.Add(new Person("Baho", "Reis", "0532 444 55 66"));
            persons.Add(new Person("Buket", "Türk", "0533 333 75 76"));
            persons.Add(new Person("Çisem", "Kurt", "0545 345 87 21"));

            PersonManager personManager =new PersonManager(persons);

            while (true)
            {
                Console.WriteLine("\n\n  Lutfen yapmak istediginiz islemi seciniz :) ");
                Console.WriteLine("  *******************************************");
                Console.WriteLine("  (1) Yeni Numara Kaydetmek");
                Console.WriteLine("  (2) Varolan Numarayi Silmek");
                Console.WriteLine("  (3) Varolan Numarayi Guncelleme");
                Console.WriteLine("  (4) Rehberi Listelemek");
                Console.WriteLine("  (5) Rehberde Arama Yapmak");
                Console.WriteLine("  (6) Uygulamayi Kapat\n");

                try
                {
                    Console.Write("  Lutfen yapmak istediginiz islemi seciniz : ");
                    int choose = Convert.ToInt32(Console.ReadLine());

                    if (choose <1 || choose > 6)
                    {
                        Console.WriteLine("Hatalı secim, 1 ile 6 arası secim yapmalisiniz.");
                        continue;
                    }
                    else if (choose == 6)
                    {
                        break;
                    }

                    Console.Clear();

                    if (choose == 1)
                    {
                        Console.Write(" Lutfen isim giriniz : ");
                        string name = Console.ReadLine();
                        Console.Write(" Lutfen soyisim giriniz : ");
                        string surename = Console.ReadLine();
                        Console.Write(" Lutfen telefon no giriniz : ");
                        string phonenumber = Console.ReadLine();
                        Person personSaveAs = new Person(name, surename, phonenumber);

                        persons.Add(personSaveAs);

                        Console.WriteLine("Kayit islemi gerceklestirildi.");
                        break;
                    }else if (choose == 2)
                    {
                        while (true)
                        {
                            Console.Write("  Lutfen numarasini silmek istediginiz kisinin adini ya da soyadini giriniz : ");
                            string find = Console.ReadLine();
                            int index = -1;

                            if (personManager.isTherePhoneNumber(find, out index))
                            {
                                Console.WriteLine(find + " degerinizle eslesen kayit silinmek uzere, onayliyor musunuz? (y/n) ");
                                Console.Write("Seciminiz : ");
                                string chooseOK = Console.ReadLine();

                                if (chooseOK == "y" ||  chooseOK == "Y")
                                {
                                    personManager.phoneNumberRemove(index);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi. Lutfen islem seciniz.");
                                Console.WriteLine(" *Islemi sonlandirmak icin: (1)");
                                Console.WriteLine(" *Yeniden denemek icin: (2)");

                                Console.Write("Seçiminiz:");
                                int newChoose = Convert.ToInt32(Console.ReadLine());
                                if (newChoose == 1)
                                {
                                    break;
                                }
                            }

                        }
                        break;

                    }
                    else if (choose == 3)
                    {
                        while (true)
                        {
                            Console.Write("Lutfen numarasini guncellemek istediginiz kisinin adini ya da soyadini giriniz : ");
                            string find = Console.ReadLine();
                            int index = -1;

                            if (personManager.isTherePhoneNumber(find, out index))
                            {
                                Console.Write(find + " degerinizle eslesen kaydi güncellemek icin yeni numara giriniz : ");
                                string yeniNumara = Console.ReadLine();

                                personManager.phoneNumberUpdate(index, yeniNumara);

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi. Lütfen islem seciniz.");
                                Console.WriteLine(" *Guncellemeyi sonlandırmak icin : (1)");
                                Console.WriteLine(" *Yeniden denemek icin : (2)");

                                Console.Write("Seciminiz : ");
                                int newChoose = Convert.ToInt32(Console.ReadLine());
                                if (newChoose == 1)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    else if (choose == 4)
                    {
                        Console.WriteLine("Hangi duzende siralamak istediginizi seciniz.");
                        Console.WriteLine(" *A-Z icin: (1)");
                        Console.WriteLine(" *Z-A icin: (2)");
                        Console.Write("Seciminiz:");
                        int orderChoose = Convert.ToInt16(Console.ReadLine());

                        if (orderChoose == 2)
                        {
                            personManager.phoneBookList(orderChoose);
                        }
                        else
                        {
                            personManager.phoneBookList(orderChoose);
                        }

                        break;
                    }
                    else if (choose == 5)
                    {
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                        Console.WriteLine(" *İsim veya soyisime göre arama yapmak için: (1)");
                        Console.WriteLine(" *Telefon numarasına göre arama yapmak için: (2)");

                        Console.Write("Seçiminiz:");
                        int newChoose = Convert.ToInt16(Console.ReadLine());

                        if (newChoose == 1)
                        {
                            Console.Write("İsim veya soyisim giriniz:");
                            string nameAndSurename = Console.ReadLine();
                            personManager.nameSureNamePhoneNumberSearch(nameAndSurename);
                        }
                    
                        break;
                    }

                Console.WriteLine("\n Yeni islem icin bir tusa basiniz.");
                Console.ReadKey();
                Console.Clear();
                }
                
                catch (Exception e)
                {
                    Console.WriteLine("Bir hata tespit edildi.");
                    Console.WriteLine(e.Message.ToString());
                    break;
                }


            }
            
            Console.ReadLine();
        }
    }
}
