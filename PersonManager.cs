using System;
using System.Collections.Generic;

namespace Telefon_Rehberi
{
    public class PersonManager
    {
        List<Person> persons = new List<Person>();

        public PersonManager(List<Person> Persons)
        {
            this.persons=Persons;
        }

         public void personShow(Person person)
        {
            Console.WriteLine("\nİsim             : {0}",person.Name);
            Console.WriteLine("Soyisim          : {0}", person.Surename);
            Console.WriteLine("Telefon Numarası : {0}\n", person.PhoneNumber);
        }
        public void ChooseAction()
        {
             Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
             Console.WriteLine("*******************************************");
             Console.WriteLine("(1) Yeni Numara kaydetmek");
             Console.WriteLine("(2) Varolan Numarayı Silmek");
             Console.WriteLine("(3) Varolan Numarayı Güncellemek");
             Console.WriteLine("(4) Rehberi Listelemek");
             Console.WriteLine("(5) Rehberde Arama Yapmak");
        }

         public void nameSureNamePhoneNumberSearch(string find)
         {
             Console.WriteLine("**************");

             bool isThere=false;

             for (int i = 0; i < persons.Count; i++)
             {
                 if (find==persons[i].Name || find==persons[i].Surename || find==persons[i].PhoneNumber )
                 {
                     personShow(persons[i]);
                     isThere=true;
                 }
             }
             if (isThere==false)
             {
                 Console.WriteLine("Aradiginiz krtiterlere uygun veri rehberde bulunamadi. Lutfen bir secim yapınız.");
             }
             
         }

         public bool isTherePhoneNumber(string find, out int index)
         {
             for (int i = 0; i < persons.Count; i++)
            {
                if (find == persons[i].Name || find == persons[i].Name)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;

         }

         public void phoneNumberRemove (int index)
         {
             Console.WriteLine("{} kisisi silindi.",persons[index]);
             persons.RemoveAt(index);
         }

         public void phoneNumberUpdate(int index, string phoneNumber)
         {
             persons[index].PhoneNumber=phoneNumber;
             Console.WriteLine("Numara Güncellenmiştir.");
         }

         public void phoneBookList(int order)
         {
             persons.Sort((u1,u2)=> u1.Name.CompareTo(u2.Name));

             if (order==2)
             {
                 persons.Reverse();
             }
             Console.WriteLine("********************");

             for (int i = 0; i < persons.Count; i++)
             {
                 personShow(persons[i]);
             }
         }

       
    }

}