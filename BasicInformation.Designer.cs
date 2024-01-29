namespace _3DEngine
{
    partial class BasicInformation
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
            name = new TextBox();
            SuspendLayout();
            // 
            // name
            // 
            name.Location = new Point(23, 33);
            name.Name = "name";
            name.Size = new Size(100, 23);
            name.TabIndex = 0;
            name.TextChanged += name_TextChanged;
            // 
            // BasicInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(name);
            Name = "BasicInformation";
            Size = new Size(150, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox name;
    }
}
