﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monte_marai_library;
using System.Globalization;


namespace MMPSv1._1
{
    public partial class UC_payroll_compute : UserControl
    {
        Objdtr_payroll_date dates = new Objdtr_payroll_date();
        Objall_queries query = new Objall_queries();
        TextInfo txt = CultureInfo.CurrentCulture.TextInfo;

        public UC_payroll_compute()
        {
            InitializeComponent();
            cmbox_date = dates.GetDates(cmbox_date);
        }

        private void cmbox_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbox_date.SelectedIndex != -1)
            {

                query.Payroll_date_id = dates.Payroll_date_id;

                dates.Payroll_date = DateTime.Parse(cmbox_date.Text);
                dates.Payroll_date_id = dates.GetDateId();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query.Payroll_date_id = dates.Payroll_date_id;

            dgv_attendance = query.GetEmployees_by_Payrolldate(dgv_attendance);
            SetGrid();
        }
        void SetGrid()
        {

            dgv_attendance.Columns["employee_name"].Width = 200;
           


            foreach (DataGridViewColumn col in dgv_attendance.Columns)
            {
                col.HeaderText = txt.ToTitleCase(col.HeaderText).Replace("_", " ");

            }
        }
    }
}