using System;
using System.Collections.Generic;

namespace DataTableCrystalReport.Model
{
    public class ExpenseModel
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FullName
        {
            get { return FirstName + " " + Lastname; }
        }
        public DateTime Date { get; set; }
        public List<ExpenseItemModel> ExpenseItems { get; set; }

        public ExpenseModel()
        {
            ExpenseItems = new List<ExpenseItemModel>();
        }
    }
}
