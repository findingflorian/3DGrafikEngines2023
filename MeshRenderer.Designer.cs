namespace _3DEngine
{
    partial class MeshRenderer
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
            button1 = new Button();
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(15, 17);
            button1.Name = "button1";
            button1.Size = new Size(110, 23);
            button1.TabIndex = 0;
            button1.Text = "Load mesh data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkCyan;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(15, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 16);
            textBox1.TabIndex = 1;
            textBox1.Text = "Information";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(15, 82);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 95);
            textBox2.TabIndex = 2;
            // 
            // MeshRenderer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "MeshRenderer";
            Size = new Size(170, 197);
            MouseClick += MeshRendererMenu_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox2;
    }
}
