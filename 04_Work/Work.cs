using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq; // ← Cast, FirstOrDefault で必要
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Taguma
{
    public partial class Work : Form
    {
        private  WorkItem workItem;
      
        public Work()
        {
            InitializeComponent();
            workItem = new WorkItem(this.combYear, this.cmbMonth, this.cmbDay, this.workmanagementView);//thisがないとForm1自分のと判別できない
            workItem.InitializeComboBoxes();
            workItem.InitializeGrid();
        }
      
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Dashboard s = new Dashboard();
            s.Show();
            this.Close();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            
        }
    }
}
