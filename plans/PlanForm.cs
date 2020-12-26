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
    public partial class PlanForm : Form
    {
        private DaysPlan plan;
        int nowIndex;
        int year;
        int moon;
        int day;


        public PlanForm()
        {
            nowIndex = 0;
            InitializeComponent();
        }

        public PlanForm(int in_year, int in_moon, int in_day, DaysPlan in_plan)
        {
            nowIndex = 0;
            year = in_year;
            moon = in_moon;
            day = in_day;
            plan = in_plan;
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (nowIndex == 0)
            {
                MessageBox.Show("これ以上戻れません！", "失敗",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                return;
            }

            plan.Plan[nowIndex].title = textBoxTitle.Text ?? "";
            plan.Plan[nowIndex].info = richTextBoxInfo.Text ?? "";

            --nowIndex;
            textBoxTitle.Text = plan.Plan[nowIndex].title;
            richTextBoxInfo.Text = plan.Plan[nowIndex].info;
            labelPlan.Text = year.ToString() + "/" + moon.ToString() + "/" + day.ToString() + "-" + (nowIndex + 1).ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (nowIndex == 3)
            {
                MessageBox.Show("これ以上進めません！", "失敗",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                return;
            }

            plan.Plan[nowIndex].title = textBoxTitle.Text ?? "";
            plan.Plan[nowIndex].info = richTextBoxInfo.Text ?? "";

            ++nowIndex;
            textBoxTitle.Text = plan.Plan[nowIndex].title;
            richTextBoxInfo.Text = plan.Plan[nowIndex].info;
            labelPlan.Text = year.ToString() + "/" + moon.ToString() + "/" + day.ToString() + "-" + (nowIndex + 1).ToString();
        }

        private void buttonReflect_Click(object sender, EventArgs e)
        {
            plan.Plan[nowIndex].title = textBoxTitle.Text ?? "";
            plan.Plan[nowIndex].info = richTextBoxInfo.Text ?? "";
            ((Form1)this.Owner).ReflectPlan(day, plan);
            this.Close();
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            textBoxTitle.Text = plan.Plan[nowIndex].title;
            richTextBoxInfo.Text = plan.Plan[nowIndex].info;
            labelPlan.Text = year.ToString() + "/" + moon.ToString() + "/" + day.ToString() + "-" + (nowIndex+1).ToString();
        }
    }
}
