using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyr
{
    public partial class Form1 : Form
    {
        private readonly DatabaseConnection _dbConnection;
        
        public Form1()
        {
            InitializeComponent();
            _dbConnection = new DatabaseConnection();
            LoadCouriers();
        }
        private void LoadCouriers()
        {
            dataGridView1.DataSource = _dbConnection.GetCouriers();
        }

        private void buttonAddViolation_Click(object sender, EventArgs e)
        {
            int idKyri = (int)dataGridView1.SelectedRows[0].Cells["IdKyri"].Value;
            string violation = textBoxViolation.Text;

            _dbConnection.AddViolation(idKyri, violation);
            textBoxViolation.Clear();
        }

    }
}