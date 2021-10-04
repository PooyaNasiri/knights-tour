using System;
using System.Windows.Forms;

namespace Knight_tour
{
    partial class Form1
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
            int BoardSize = Form1.BoardSize;
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                {
                    label[j, i] = new Label();
                    label[j, i].Location = new System.Drawing.Point(60 * j + 40, 50 * i + 50);
                    label[j, i].Name = (j + 1 + (i * BoardSize)) + "";
                    label[j, i].Size = new System.Drawing.Size(55, 45);
                    label[j, i].Text = (j + 1 + (i * BoardSize)) + "";
                    Controls.Add(label[j, i]);
                }

            this.status = new Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Xtextbox = new System.Windows.Forms.TextBox();
            this.Ytextbox = new System.Windows.Forms.TextBox();

            status.Location = new System.Drawing.Point(40, 10);
            status.Name = "status";
            status.Text = "status: Play";
            status.AutoSize = true;
            Controls.Add(status);

            // 
            // Xtextbox
            // 
            this.Xtextbox.Location = new System.Drawing.Point(120, 50 * BoardSize + 72);
            this.Xtextbox.MaxLength = 1;
            this.Xtextbox.Name = "Xtextbox";
            this.Xtextbox.Size = new System.Drawing.Size(21, 20);
            this.Xtextbox.TabIndex = 19;
            this.Xtextbox.Text = "0";
            // 
            // Ytextbox
            // 
            this.Ytextbox.Location = new System.Drawing.Point(77, 50 * BoardSize + 72);
            this.Ytextbox.MaxLength = 1;
            this.Ytextbox.Name = "Ytextbox";
            this.Ytextbox.Size = new System.Drawing.Size(21, 20);
            this.Ytextbox.TabIndex = 20;
            this.Ytextbox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 50 * BoardSize + 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50 * BoardSize + 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Start pos. : Y:          X :  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 50 * BoardSize + 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 50 * BoardSize + 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "way: ";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(149, 50 * BoardSize + 70);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(37, 23);
            this.Start.TabIndex = 17;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(Start_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(191, 50 * BoardSize + 70);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(39, 23);
            this.Clear.TabIndex = 24;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Ytextbox);
            this.Controls.Add(this.Xtextbox);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(60 * BoardSize + 80, 50 * BoardSize + 200);
            this.MinimumSize = new System.Drawing.Size(60 * BoardSize + 80, 50 * BoardSize + 200);
            this.MaximumSize = new System.Drawing.Size(60 * BoardSize + 500, 50 * BoardSize + 200);
            this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            this.ShowIcon = false;
            this.AutoSize = true;

            this.Name = "Knight_tour";
            this.Text = "Knight_tour";
            this.ResumeLayout(true);
            this.PerformLayout();

        }

       

        public Label[,] label = new Label[BoardSize, BoardSize];
        public Label  status;
        public Label  label2;
        public Label  label3;
        public Label  label4;
        public Label  label5;
        public Button Clear;
        public Button Start;
        public TextBox Xtextbox;
        public TextBox Ytextbox;

    }
    #endregion

}
