namespace TestAsync
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
            this.Sync = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Async = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sync
            // 
            this.Sync.Location = new System.Drawing.Point(110, 229);
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(288, 41);
            this.Sync.TabIndex = 0;
            this.Sync.Text = "Sync";
            this.Sync.UseVisualStyleBackColor = true;
            this.Sync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 146);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 77);
            this.textBox1.TabIndex = 1;
            // 
            // Async
            // 
            this.Async.Location = new System.Drawing.Point(110, 276);
            this.Async.Name = "Async";
            this.Async.Size = new System.Drawing.Size(288, 41);
            this.Async.TabIndex = 2;
            this.Async.Text = "Async";
            this.Async.UseVisualStyleBackColor = true;
            this.Async.Click += new System.EventHandler(this.Async_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 403);
            this.Controls.Add(this.Async);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Sync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sync;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Async;
    }
}

