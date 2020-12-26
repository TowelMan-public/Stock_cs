using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plans
{
    public partial class Form1 : Form
    {
        Salvage salvage;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            //日付の作成
            DateTime date = new DateTime(salvage.year, salvage.moon, 1);
            date = date.AddMonths(-1);
            //ロード・反映
            salvage = new Salvage(date.Year, date.Month);
            this.ReflectGridView();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            //日付の作成
            DateTime date = new DateTime(salvage.year, salvage.moon, 1);
            date = date.AddMonths(1);
            //ロード・反映
            salvage = new Salvage(date.Year, date.Month);
            this.ReflectGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //日付
            int day = e.RowIndex / 5 * 7 - salvage.farstWeek + e.ColumnIndex + 1;
            //ダイアログの表示
            PlanForm planForm = new PlanForm(salvage.year, salvage.moon, day, salvage.Days[day - 1]);
            planForm.Show(this);
        }

        //初期化処理
        private void Form1_Load(object sender, EventArgs e)
        {
            /*データの取得*/
            DateTime today = DateTime.Today;
            salvage = new Salvage(today.Year, today.Month);
            /*反映（表）*/
            this.ReflectGridView();
        }

        private void ReflectGridView()
        {


            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "日曜日";
            dataGridView1.Columns[1].HeaderText = "月曜日";
            dataGridView1.Columns[2].HeaderText = "火曜日";
            dataGridView1.Columns[3].HeaderText = "水曜日";
            dataGridView1.Columns[4].HeaderText = "木曜日";
            dataGridView1.Columns[5].HeaderText = "金曜日";
            dataGridView1.Columns[6].HeaderText = "土曜日";
            dataGridView1.Rows.Add(5 * 6 - 1);
            for (int r = 0, i = 0, week = salvage.farstWeek; i < salvage.dayCount; i++, week = (week == 6 ? 0 : week + 1), r = (week == 0 ? r + 1 : r))
            {
                dataGridView1.Rows[r * 5].Cells[week].Value = i + 1;
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[r * 5 + j + 1].Cells[week].Value = salvage.Days[i].Plan[j].title;
                }
            }
            TextBoxMoon.Text = salvage.year.ToString() + "/" + salvage.moon.ToString();
        }

        public void ReflectPlan(int in_day, DaysPlan in_plan)
        {
            salvage.Days[in_day - 1] = in_plan;
            this.ReflectGridView();
        }

    }
}
