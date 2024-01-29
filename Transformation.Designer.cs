namespace _3DEngine
{
    partial class Transformation
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 9;
            label1.Text = "Rotate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 92);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 10;
            label2.Text = "Scale";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 155);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 11;
            label3.Text = "Translate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 62);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 12;
            label4.Text = "x";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(79, 62);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 13;
            label5.Text = "y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(133, 62);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 14;
            label6.Text = "z";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 136);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 15;
            label7.Text = "x";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 199);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 16;
            label8.Text = "x";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(79, 136);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 17;
            label9.Text = "y";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(79, 199);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 18;
            label10.Text = "y";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(133, 136);
            label11.Name = "label11";
            label11.Size = new Size(12, 15);
            label11.TabIndex = 19;
            label11.Text = "z";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(133, 199);
            label12.Name = "label12";
            label12.Size = new Size(12, 15);
            label12.TabIndex = 20;
            label12.Text = "z";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(16, 36);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(36, 23);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.Tag = "rotate_x";
            numericUpDown1.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(70, 36);
            numericUpDown2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(37, 23);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.Tag = "rotate_y";
            numericUpDown2.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(123, 36);
            numericUpDown3.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(38, 23);
            numericUpDown3.TabIndex = 23;
            numericUpDown3.Tag = "rotate_z";
            numericUpDown3.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(23, 110);
            numericUpDown4.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(29, 23);
            numericUpDown4.TabIndex = 24;
            numericUpDown4.Tag = "scale_x";
            numericUpDown4.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown4.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(70, 110);
            numericUpDown5.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(29, 23);
            numericUpDown5.TabIndex = 25;
            numericUpDown5.Tag = "scale_y";
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(123, 110);
            numericUpDown6.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(29, 23);
            numericUpDown6.TabIndex = 26;
            numericUpDown6.Tag = "scale_z";
            numericUpDown6.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown6.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(23, 173);
            numericUpDown7.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(29, 23);
            numericUpDown7.TabIndex = 27;
            numericUpDown7.Tag = "translate_x";
            numericUpDown7.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(70, 173);
            numericUpDown8.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(29, 23);
            numericUpDown8.TabIndex = 28;
            numericUpDown8.Tag = "translate_y";
            numericUpDown8.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown9
            // 
            numericUpDown9.Location = new Point(123, 173);
            numericUpDown9.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(29, 23);
            numericUpDown9.TabIndex = 29;
            numericUpDown9.Tag = "translate_z";
            numericUpDown9.ValueChanged += onTranslationChanged;
            // 
            // Transformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDown9);
            Controls.Add(numericUpDown8);
            Controls.Add(numericUpDown7);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Transformation";
            Size = new Size(183, 236);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
    }
}
