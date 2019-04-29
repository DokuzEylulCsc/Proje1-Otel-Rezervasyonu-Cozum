using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    internal abstract class Room : ReservationProcedures 
    {
        private int no; //Oda no
        private ArrayList reservations; //Odaya ait rezervasyonlar
        private bool hasBolcony; //Balkonu var mi
        private bool hasSeaView; //Deniz manzaralımı
        protected int capacity; //kapasite
        protected int bedCount; //Yatak sayisi
        protected int singleBedCount; //Tek yatak sayisi
        protected int doubleBedCount; //Çift yatak sayisi
        /*
        Olası başka özellikler
        private bool hasAirConditioner;
        private bool hasMiniBar;
        private bool hasTv;
        ...
        */

        protected Room(int no) //Sadece oda numarası olan oluşturucu metod
        {
            this.no = no;
            reservations = new ArrayList();
            hasBolcony = false;
            hasSeaView = false;
            Console.WriteLine(ToString());

        }
        protected Room(int no,bool bolcony) //Oluşturucu metod overload
        {
            this.no = no;
            reservations = new ArrayList();
            hasBolcony = bolcony;
            hasSeaView = false;
            Console.WriteLine(ToString());

        }
        protected Room(int no, bool bolcony,bool seaview) //Oluşturucu metod overload
        {
            this.no = no;
            reservations = new ArrayList();
            hasBolcony = bolcony;
            hasSeaView = seaview;
            Console.WriteLine(ToString());

        }
        public int No
        {
            get
            {
                return no;
            }

          
        }
        public ArrayList Reservations
        {
            get
            {
                return reservations;
            }

            protected set
            {
                reservations = value;
            }
        }
        public bool HasBolcony
        {
            get
            {
                return hasBolcony;
            }
            protected set
            {
                hasBolcony = value;
            }

            
        }
        public bool HasSeaView
        {
            get
            {
                return hasSeaView;
            }
            protected set
            {
                hasSeaView = value;
            }
        }

        protected abstract void createCapacity();

        public int makeReservation(Reservation rev) //odaya rezervasyon yapma
        {
            bool check = true;
            if (this.GetType() == rev.RoomType)
            {
                foreach (Reservation a in reservations)
                {
                    if (a.StartDate < rev.EndDate && rev.StartDate < a.EndDate) //Daha önce yapılan rezervasyonların tarihleri ile kıyaslanıyor.
                    {
                        check = false;
                        break;
                    }
                   
                }
                if (check)
                {
                    if (this.capacity < rev.PersonCount || this.HasSeaView != rev.HasSeaView || this.HasBolcony != rev.HasBolcony) //oda rezervasyonda istenen özellikleri sağlıyor mu?
                    {
                        check = false;
                    }
                }
            }
            else
                check = false;
            if(check) 
            {
                reservations.Add(rev); //Rezervasyonu ekle
                return this.No;
            }
            else
            {
                return -1;
            }
           
        }

        public bool cancelReservation(int id) //Verilen rezervasyon numaralı rezervasyon bu oda ise iptal eder değilse false döndürür.
        {
            bool ch = false;
            foreach (Reservation a in reservations)
            {
                if(id == a.Id_number)
                {
                    reservations.Remove(a);
                    ch = true;
                    break;
                }
            }
            return ch;
        }

        public void listAllReservations() //Odaya ait tüm rezervasyonları döndürür.
        {
          
            Reservation[] ress = (Reservation[])reservations.ToArray(typeof(Reservation));
            Array.Sort(ress); //Rezervasyonarın başlangıç tarihlerine göre sıralar
            foreach (Reservation a in ress) 
            {
                Console.WriteLine("Oda No:{0} Oda Tipi:{1} Rezervasyon No:{2} Rezervasyon Başlangıç Tarihi:{3} Rezervasyon Bitiş Tarihi:{4} ", this.No, this.GetType().Name,a.Id_number, a.StartDate.ToShortDateString(), a.EndDate.ToShortDateString());   
            }

        }

        public override string ToString()
        {
            return String.Format("Oda No:{0} Oda Tipi:{1} Balkon var mi:{2} Deniz manzarasi var mi:{3}", this.No, this.GetType().Name, this.HasBolcony, this.hasSeaView);
        }

        }
    }
