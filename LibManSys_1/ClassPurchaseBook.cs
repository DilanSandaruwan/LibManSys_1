using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManSys_1
{
    
    public class ClassPurchaseBook
    {
        int p_book_id;
        int p_quantity;
        string p_dop;

        public int P_quantity { get => p_quantity; set => p_quantity = value; }
        public int P_book_id { get => p_book_id; set => p_book_id = value; }
        public string P_dop { get => p_dop; set => p_dop = value; }
    }
}
