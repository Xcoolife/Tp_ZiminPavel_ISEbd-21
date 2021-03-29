
namespace Tp_2kurs
{
    partial class FormReportWoodComponents
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.SaveToExcel = new System.Windows.Forms.Button();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Wood,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(12, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(569, 397);
            this.dataGridView.TabIndex = 0;
            // 
            // SaveToExcel
            // 
            this.SaveToExcel.Location = new System.Drawing.Point(12, 12);
            this.SaveToExcel.Name = "SaveToExcel";
            this.SaveToExcel.Size = new System.Drawing.Size(123, 23);
            this.SaveToExcel.TabIndex = 1;
            this.SaveToExcel.Text = "Сохранить в Excel";
            this.SaveToExcel.UseVisualStyleBackColor = true;
            this.SaveToExcel.Click += new System.EventHandler(this.SaveToExcel_Click);
            // 
            // Component
            // 
            this.Component.HeaderText = "Компонент";
            this.Component.Name = "Component";
            // 
            // Wood
            // 
            this.Wood.HeaderText = "Изделие";
            this.Wood.Name = "Wood";
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // FormReportWoodComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.SaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportWoodComponents";
            this.Text = "Столярная Мастерская";
            this.Load += new System.EventHandler(this.FormReportWoodComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button SaveToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wood;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}