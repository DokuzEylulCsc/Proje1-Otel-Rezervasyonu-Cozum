using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class Hotel : ReservationProcedures
    {
        private string hotelName; //Otel adi
        private int numberOfRooms; //Otel oda sayisi

        Room[] rooms; //Odaları tutan koleksiyon
        public Hotel(string name,int n_rooms)  //Otel oluşturucu metod
        {
            hotelName = name;
            numberOfRooms = n_rooms;
            rooms = new Room[numberOfRooms];
            createRooms(numberOfRooms); //Tek tek odaları oluşturmak için çağrılıyor.
        }

        public string HotelName
        {
            get
            {
                return hotelName;
            }
        }

        public int NumberOfRooms
        {
            get
            {
                return numberOfRooms;
            }
        }
        private void createRooms(int n) //Otelin tüm odalarının oluşturulduğu fonksiyon
        {
            for(int i=0;i< n;i++)
            {
                bool bal;
                bool sea;
                string inp;
                Console.WriteLine("{0} nolu oda oluşuturuluyor.", i + 100);
                Console.WriteLine("Balkon (1:true,2:false)");
                inp = Console.ReadLine();
                bal = (inp == "1") ? true : false;
                Console.WriteLine("Deniz Manzarası (1:true,2:false)");
                inp = Console.ReadLine();
                sea = (inp == "1") ? true : false;
                Console.WriteLine("Oda Tipi (1:Single Room,2:Double Room,3:Twin Room)");
                inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        rooms[i] = new SingleRoom(i + 100, bal, sea);
                    break;
                    case "2":
                        rooms[i] = new DoubleRoom(i + 100, bal, sea);
                    break;
                    case "3":
                        rooms[i] = new TwinRoom(i + 100, bal, sea);
                    break;
                }
                
            }
        }

        public int makeReservation(Reservation rev) // Otel için rezervasyon yapma
        {
            int ch = -1;
            foreach(Room a in rooms) //Her odaya rezervasyon için başvuruluyor
            {
                ch = a.makeReservation(rev); //Oda ilgili rezervasyon için musaitse oda nosunu değilse -1
                if (ch>-1) break;
            }
            return ch;
        }
        public bool cancelReservation(int id) //Girilen rezervasyon numarasına göre iptal
        {
            bool ch = false;
            foreach (Room a in rooms)
            {
                ch = a.cancelReservation(id); //İptal sağlanırsa true dönüyor.
                if (ch) break;
            }
            return ch;
        }

        public void listAllReservations() // Tüm rezervasyonları listeme
        {
            foreach (Room a in rooms)
            {
                a.listAllReservations();
            }
        }


    }
}
