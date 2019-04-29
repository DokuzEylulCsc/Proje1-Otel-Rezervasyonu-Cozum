using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class HotelReservationApp
    {
        private Hotel hotel;
        public HotelReservationApp()
        {
            string configvalue1 = ConfigurationSettings.AppSettings["numberOfRooms"]; //App.config'den oda sayısını aldık.
            int numberOfRooms = int.Parse(configvalue1);
            hotel = new Hotel("Butik Hotel", numberOfRooms); //Oteli ayaklandırıyor
            appMain();
        } 

        private void appMain() //Ana ekran
        {
            string select;
            do
            {
                Console.WriteLine("Rezervasyon yapmak için(1) \nRezervasyon iptali için(2) \nTüm rezervasyonları listelemek için(3) \nÇıkmak için(4)");
                select = Console.ReadLine();
                switch(select)
                {
                    case "1": createReservation();  break;
                    case "2": cancelReservation();  break;
                    case "3": listReservations(); break;
                    case "4": Console.WriteLine("Otelimizi tercih ettiğiniz için teşşekür ederiz.Yine bekleriz.");  break;
                    default: Console.WriteLine("Yanlış giriş yaptınız.Lütfen tekrar giriniz."); break;    

                }
            } while (select != "4");
        }

        private void createReservation() //Rezervasyon yaratıp otele gönderiyor
        {
            Console.WriteLine("Konuk sayini giriniz: ");
            int p_c = int.Parse(Console.ReadLine());
            Console.WriteLine("Balkon (1:true,2:false)");
            string inp = Console.ReadLine();
            bool bal = (inp == "1") ? true : false;
            Console.WriteLine("Deniz Manzarası (1:true,1:false)");
            inp = Console.ReadLine();
            bool sea = (inp == "1") ? true : false;
            Console.WriteLine("Oda Tipi (1:Single Room,2:Double Room,3:Twin Room)");
            inp = Console.ReadLine();
            Type tip = null;
            switch (inp)
            {
                case "1":
                    tip = typeof(SingleRoom);
                    break;
                case "2":
                    tip = typeof(DoubleRoom);
                    break;
                case "3":
                    tip = typeof(TwinRoom);
                    break;
            }

            Console.WriteLine("Başlangıç tarihi giriniz (e.g. 23/05/2018): ");
            DateTime sDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Bitiş tarihi giriniz (e.g. 25/05/2018): ");
            DateTime eDate = DateTime.Parse(Console.ReadLine());
            Reservation rev = new Reservation(p_c, tip, bal, sea, sDate, eDate);
            int r_n=hotel.makeReservation(rev);
            if (r_n > -1) Console.WriteLine("Rezervasyonunuz {0}. nolu odaya yapıldı! Rezervasyon Numranız: {1} ",r_n,rev.Id_number);
            else Console.WriteLine("Üzgünüz aradığınız kriterlere uygun odamız bulunmamaktadır.");
        }
        private void cancelReservation() //Otele rezervasyon iptal talebi gönderiyor
        {
            Console.WriteLine("İptel etmek istediğiniz rezervasyonun rezervasyon numarasını giriniz:");
            int id = int.Parse(Console.ReadLine());
            bool result = hotel.cancelReservation(id);
            if (result)
                Console.WriteLine("Rezervasyonunuz iptal edildi.");
            else
                Console.WriteLine("Rezervasyon numarasına ait aktif bir rezarvasyon bulunamadı.");
        }

        private void listReservations() //Otelin tüm rezervasonyoları listeliyor.
        {
            hotel.listAllReservations();
        }



    }
}
