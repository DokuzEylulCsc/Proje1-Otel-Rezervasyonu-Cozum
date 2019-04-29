using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class Reservation : IComparable<Reservation> //Reservasyonlar karşılaştıralbilir.
    {
        private static int reservationCount = 0;
        private int id_number; //rezervasyon numaraıs
        private int personCount; //kişi sayisi
        private Type roomType; //Oda tipi
        private bool hasBolcony; //Balkon varmı?
        private bool hasSeaView; //Deniz manzarılı mi?
        private DateTime startDate; //Başlangıç tarihi
        private DateTime endDate; //Bitiş tarihi

        public Reservation(int personcount,Type roomtype, bool bolcony,bool seaview,DateTime startdate,DateTime enddate)
        {
            if((enddate - startdate).TotalHours>0) //Başlangıç > Bitiş tarihi ise yeniden tarhileri soruyor.
            {
                startDate = startdate;
                endDate = enddate;
            }
            else
            {
                askNewDate();
            }
            personCount = personcount;
            roomType = roomtype;
            hasBolcony = bolcony;
            hasSeaView = seaview;
            reservationCount++;
            id_number = reservationCount;
        }

        private void askNewDate() //Yeniden tarihleri sorma
        {
            Console.WriteLine("Başlangıç tarihi giriniz (e.g. 10/22/2018): ");
            DateTime sDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Bitiş tarihi giriniz (e.g. 10/22/2018): ");
            DateTime eDate = DateTime.Parse(Console.ReadLine());
            if ((eDate - sDate).TotalHours > 0)
            {
                startDate = sDate;
                endDate = eDate;
            }
            else
            {
                askNewDate();
            }

        }
        public int CompareTo(Reservation other)
        {
            return StartDate.CompareTo(other.StartDate);
        }

        public int PersonCount
        {
            get
            {
                return personCount;
            }

            
        }

        public Type RoomType
        {
            get
            {
                return roomType;
            }

           
        }

        public bool HasBolcony
        {
            get
            {
                return hasBolcony;
            }              
        }

        public bool HasSeaView
        {
            get
            {
                return hasSeaView;
            }  
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
        
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

        }
        public int Id_number
        {
            get
            {
                return id_number;
            }
        }
    }
}
