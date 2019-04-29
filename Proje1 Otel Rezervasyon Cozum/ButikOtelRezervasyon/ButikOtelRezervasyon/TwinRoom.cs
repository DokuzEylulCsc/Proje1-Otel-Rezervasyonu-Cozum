using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    class TwinRoom:Room
    {
        public TwinRoom(int no):base(no)
        {
            createCapacity();
        }
        public TwinRoom(int no, bool bolcony):base(no,bolcony)
        {
            createCapacity();
        }
        public TwinRoom(int no, bool bolcony, bool seaview) : base(no, bolcony,seaview)
        {
            createCapacity();
        }

        protected override void createCapacity()
        {
            capacity = 2;
            bedCount = 2;
            singleBedCount = 2;
            doubleBedCount = 0;
        }
    }
}
