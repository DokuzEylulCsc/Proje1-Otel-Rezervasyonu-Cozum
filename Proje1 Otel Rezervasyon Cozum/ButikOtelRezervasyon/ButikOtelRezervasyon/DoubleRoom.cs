using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class DoubleRoom:Room
    {
        public DoubleRoom(int no):base(no)
        {
            createCapacity();
        }
        public DoubleRoom(int no, bool bolcony):base(no,bolcony)
        {
            createCapacity();
        }
        public DoubleRoom(int no, bool bolcony, bool seaview) : base(no, bolcony,seaview)
        {
            createCapacity();
        }

        protected override void createCapacity()
        {
            capacity = 2;
            bedCount = 1;
            singleBedCount = 0;
            doubleBedCount = 1;
        }
    }
}
