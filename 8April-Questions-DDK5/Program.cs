using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8April_Questions_DDK5
{
    internal class Program
    {
        static List<DateTime> dateTimes = new List<DateTime>();

        #region 1) 2010 ile 2022 arasında mesai saatleri içerisinde(09:00 - 18:00) 1000 adet RANDOM TARİH oluştur ve bir tarih listesine ata
        static void randomDate()
        {
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();

                int randomYear = rnd.Next(2010, 2023), randomMonth = rnd.Next(1, 13), randomDay = rnd.Next(1, 28),
                    randomHour = rnd.Next(9, 19), randomMinute = rnd.Next(0, 60);

                DateTime newDate = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, 0);

                if (dateTimes.Any(x => x == newDate) || IsWeekend(newDate))
                    i--;
                else
                {
                    dateTimes.Add(newDate);
                    Console.WriteLine("\t\t\t\t\t\t" + (i + 1) + " -> " + newDate.ToString() + " " + newDate.DayOfWeek + "\n");
                }
            }
        }
        #endregion
      
        #region 2) Bu listede cumartesi ve pazar olmasın!
        static bool IsWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }
        #endregion
        
        #region 3) Bu listenin içerisinde tarihlerin kaçı şubat ayı içerisindedir?
        static int howManyinFeb(List<DateTime> d)
        {
            int sayac = 0;

            foreach (DateTime dt in d)
            {
                if (dt.Month == 2)
                {
                    sayac++;
                }
            }
            return sayac;
        }
        #endregion

        #region 4) Bu listenin içerisindeki tarihlerin kaçı 12:00(öğlen) den öncedir
        static int beforeMidday(List<DateTime> date)
        {
            return date.Where(d => d.Hour < 12).Count();
        }
        #endregion

        #region 5) Bu listede kaç tane pazartesi var?
        static int howManyMondays(List<DateTime> date)
        {
            return date.Where(d => d.DayOfWeek == DayOfWeek.Monday).Count();
        }
        #endregion

        #region 6) Saat aralığı 17:00 - 18:00 arasında olan tüm tarihleri ekrana yaz.
        static void timeRange(List<DateTime> date)
        {
            List<DateTime> timeRangeList = (date.Where(d => d.Hour >= 17 && d.Hour <= 18).ToList());
            foreach (var item in timeRangeList)
                Console.WriteLine(item);
        }
        #endregion

        #region 7) Kullanıcı ekrandan bir yıl girsin ve o yıla ait tüm tarihleri ekrana yaz
        static void searchYear(List<DateTime> date)
        {
            Console.Write("Yıl giriniz: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (!date.Any(d => d.Year == year))
                Console.WriteLine("Kayıtta " + year + " yılı yoktur. Tekrar deneyiniz.");
            else
                Console.WriteLine(year + " yılın kayıtları;");
            List<DateTime> searchYearList = (date.Where(d => d.Year == year).ToList());

            foreach (var item in searchYearList)
                Console.WriteLine(item);
        }
        #endregion

        #region 8) Kullanıcı ekrandan önce yıl sonra ay girsin ve bu ay ve yıla ait tüm tarihler sıralansın.
        static void sortYearAndMonth(List<DateTime> date)
        {
            Console.Write("Yıl giriniz: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ay giriniz: ");
            int month = Convert.ToInt32(Console.ReadLine());

            List<DateTime> sortYearMontList = (date.Where(d => d.Year == year && d.Month == month).ToList());
            sortYearMontList = sortYearMontList.OrderBy(s => s).ToList();
            foreach (var item in sortYearMontList)
                Console.WriteLine(item);
        }
        #endregion

        #region 9) 2010 SONRASI tarihleri ekrana yazdır.
        static void yearLater(List<DateTime> date)
        {
            List<DateTime> yearLaterList = (date.Where(d => d.Year > 2010).ToList());

            yearLaterList = yearLaterList.OrderBy(x => x).ToList();

            foreach (var item in yearLaterList)
                Console.WriteLine(item);
        }
        #endregion

        #region 10) 2010 - 2015 arasında SADECE OCAK ayında geçen tarihleri ekrana yazdır.
        static void januaryWithYearRange(List<DateTime> date)
        {
            List<DateTime> januaryWithYearRangeList = (date.Where(d => d.Year > 2010 && d.Year < 2015 && d.Month == 1).ToList());

            foreach (var item in januaryWithYearRangeList)
                Console.WriteLine(item);
        }
        #endregion

        static void Main(string[] args)
        {
            randomDate();
            //Console.WriteLine(howManyinFeb(dateTimes));
            //Console.WriteLine(beforeMidday(dateTimes));
            //Console.WriteLine(howManyMondays(dateTimes));
            //timeRange(dateTimes);
            //searchYear(dateTimes);
            //sortYearAndMonth(dateTimes);
            //yearLater(dateTimes);
            //januaryWithYearRange(dateTimes);
            Console.ReadLine();
        }
    }
}
