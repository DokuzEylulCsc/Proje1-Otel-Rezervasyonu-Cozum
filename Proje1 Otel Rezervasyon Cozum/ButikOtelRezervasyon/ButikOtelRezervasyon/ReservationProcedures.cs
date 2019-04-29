using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyon
{
    interface ReservationProcedures
    {
        int makeReservation(Reservation rev);
        bool cancelReservation(int id);
        void listAllReservations();
       

    }
}
