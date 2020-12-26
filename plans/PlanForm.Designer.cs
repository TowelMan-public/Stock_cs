namespace plans
{
    partial class PlanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.labelPlan = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonReflect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(49, 78);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(613, 22);
            this.textBoxTitle.TabIndex = 4;
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(49, 140);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(613, 299);
            this.richTextBoxInfo.TabIndex = 8;
            this.richTextBoxInfo.Text = "";
            // 
            // labelPlan
            // 
            this.labelPlan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlan.AutoSize = true;
            this.labelPlan.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPlan.Location = new System.Drawing.Point(284, 9);
            this.labelPlan.Name = "labelPlan";
            this.labelPlan.Size = new System.Drawing.Size(96, 34);
            this.labelPlan.TabIndex = 20;
            this.labelPlan.Text = "label1";
            this.labelPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(450, 9);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 31);
            this.buttonNext.TabIndex = 21;
            this.buttonNext.Text = "次へ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(124, 9);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 31);
            this.buttonBack.TabIndex = 22;
            this.buttonBack.Text = "戻る";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonReflect
            // 
            this.buttonReflect.Location = new System.Drawing.Point(305, 483);
            this.buttonReflect.Name = "buttonReflect";
            this.buttonReflect.Size = new System.Drawing.Size(75, 23);
            this.buttonReflect.TabIndex = 23;
            this.buttonReflect.Text = "反映";
            this.buttonReflect.UseVisualStyleBackColor = true;
            this.buttonReflect.Click += new System.EventHandler(this.buttonReflect_Click);
            // 
            // PlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 518);
            this.Controls.Add(this.buttonReflect);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelPlan);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "PlanForm";
            this.Text = "PlanForm";
            this.Load += new System.EventHandler(this.PlanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label labelPlan;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonReflect;
    }
}