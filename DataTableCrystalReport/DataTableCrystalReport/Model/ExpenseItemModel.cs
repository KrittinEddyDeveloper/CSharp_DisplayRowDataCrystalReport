using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableCrystalReport.Model
{
    public class ExpenseItemModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Type { get; set; } // Type 0 = Income, Type 1 = Expense
        public Decimal Money { get; set; }
    }
}
