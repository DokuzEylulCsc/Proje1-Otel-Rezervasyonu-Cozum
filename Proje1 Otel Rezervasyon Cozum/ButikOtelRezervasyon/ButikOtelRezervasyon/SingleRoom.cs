using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class SingleRoom : Room
    {
        public SingleRoom(int no):base(no)
        {
            createCapacity();
        }
        public SingleRoom(int no,bool bolcony):base(no,bolcony)
        {
            createCapacity();
        }
        public SingleRoom(int no, bool bolcony,bool seaview) : base(no, bolcony,seaview)
        {
            createCapacity();
        }
   
        protected override void createCapacity()
        {
            capacity = 1;
            bedCount = 1;
            singleBedCount = 1;
            doubleBedCount = 0;
        }

   

    }
}
