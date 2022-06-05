using Inventory_management_System.Models;
using Inventory_management_System.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_management_System
{
    public partial class Form1 : Form
    {
        private InventoryServices inventory = new InventoryServices();
        private CategoryServices category = new CategoryServices();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCategory();
        }

        private void LoadData()
        {
            grdInventory.DataSource = inventory.GetAll();
            grdInventory.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var obj = new Inventory()
            {
                Name = txtName.Text,
                CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),
                DateOfPurchase = Convert.ToDateTime(dtPurchase.Text),
                Description = rtxtDescription.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                Stock = Convert.ToDouble(txtStock.Text),
            };
            var res = inventory.Create(obj);
            if (res.Item1)
            {
                //Show the message
                LoadData();
                ResetTextField();
            }
            else
            {
                MessageBox.Show(res.Item2);
            }
        }

        private void ResetTextField()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            rtxtDescription.Clear();
            dtPurchase.ResetText();
            cmbCategory.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextField();
        }

        private void LoadCategory()
        {
            var List = category.GetAll();
            List.Insert(0, new Category() { Id = 0, Name = "Select Category" });
            cmbCategory.DataSource = new BindingSource(List, null);
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void grdInventory_SelectionChanged(object sender, EventArgs e)
        {
            var rows = grdInventory.SelectedRows;
            if (rows == null || rows.Count == 0)
            {
                return;
            }
            else
            {
                var selectedRow = rows[0];
            }
        }
    }
}