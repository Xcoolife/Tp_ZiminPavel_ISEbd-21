﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.BusinessLogics;
using Unity;

namespace Tp_2kurs
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic orderLogic;
        public FormMain(OrderLogic orderLogic)
        {
            InitializeComponent();
            this.orderLogic = orderLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormComponents>();
            form.ShowDialog();

        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormWoods>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    orderLogic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
