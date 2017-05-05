using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTableCrystalReport.CrystalReport;
using DataTableCrystalReport.Model;

namespace DataTableCrystalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExpenseModel model = GetData();
            crystalReportViewer1.ReportSource = GetReport(model);
        }

        private ExpenseModel GetData()
        {
            ExpenseModel model = new ExpenseModel();

            model.FirstName = "สนุก";
            model.Lastname = "สุขสุนต์";
            model.Date = new DateTime(2017, 5, 4);
            model.ExpenseItems.Add(new ExpenseItemModel() { Date = new DateTime(2017, 5, 4), Money = 200, Name = "เงินประจำวัน", Type = 0 });
            model.ExpenseItems.Add(new ExpenseItemModel() { Date = new DateTime(2017, 5, 4), Money = 20, Name = "อาหารเช้า", Type = 1 });
            model.ExpenseItems.Add(new ExpenseItemModel() { Date = new DateTime(2017, 5, 4), Money = 21, Name = "Mrt", Type = 1 });
            model.ExpenseItems.Add(new ExpenseItemModel() { Date = new DateTime(2017, 5, 4), Money = 55, Name = "อาหารกลางวัน", Type = 1 });
            model.ExpenseItems.Add(new ExpenseItemModel() { Date = new DateTime(2017, 5, 4), Money = 29, Name = "ขนมปังสังขยา", Type = 1 });
            return model;
        }


        private ExpenseReport GetReport(ExpenseModel data)
        {
            var report = new ExpenseReport();
            var dataTable = GetDataTable();

            var dataSet = new System.Data.DataSet();
            dataSet.Tables.Add(dataTable);

            for (int i = 0; i < data.ExpenseItems.Count; i++)
            {
                DataRow row = dataSet.Tables["ExpenseItem"].NewRow();
                row["No"] = i + 1;
                row["Name"] = data.ExpenseItems[i].Name;
                row["Income"] = data.ExpenseItems[i].Type == 0 ? data.ExpenseItems[i].Money : 0;
                row["Expense"] = data.ExpenseItems[i].Type == 1 ? data.ExpenseItems[i].Money : 0;
                dataSet.Tables["ExpenseItem"].Rows.Add(row);
            }
            report.SetDataSource(dataSet);
            report.SetParameterValue("FullName",data.FullName);
            report.SetParameterValue("Date",data.Date);
            return report;
        }

        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable("ExpenseItem");

            dataTable.Columns.Add(new DataColumn("No", typeof (int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof (string)));
            dataTable.Columns.Add(new DataColumn("Income", typeof (decimal)));
            dataTable.Columns.Add(new DataColumn("Expense", typeof (decimal)));

            return dataTable;
        }
    }

    
}
