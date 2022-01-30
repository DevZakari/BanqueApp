
namespace BanqueApp
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.statusLogin = new System.Windows.Forms.StatusStrip();
            this.gvComptes = new System.Windows.Forms.DataGridView();
            this.btnCrediter = new System.Windows.Forms.Button();
            this.btnDebiter = new System.Windows.Forms.Button();
            this.btnOperations = new System.Windows.Forms.Button();
            this.btnVerser = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvComptes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Muslimah", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 109);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage Account";
            // 
            // statusLogin
            // 
            this.statusLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusLogin.Location = new System.Drawing.Point(0, 483);
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(713, 22);
            this.statusLogin.TabIndex = 3;
            // 
            // gvComptes
            // 
            this.gvComptes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvComptes.Location = new System.Drawing.Point(207, 121);
            this.gvComptes.Name = "gvComptes";
            this.gvComptes.Size = new System.Drawing.Size(271, 198);
            this.gvComptes.TabIndex = 4;
            // 
            // btnCrediter
            // 
            this.btnCrediter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrediter.Location = new System.Drawing.Point(129, 334);
            this.btnCrediter.Name = "btnCrediter";
            this.btnCrediter.Size = new System.Drawing.Size(118, 38);
            this.btnCrediter.TabIndex = 5;
            this.btnCrediter.Text = "Créditer";
            this.btnCrediter.UseVisualStyleBackColor = true;
            this.btnCrediter.Click += new System.EventHandler(this.btnCrediter_Click);
            // 
            // btnDebiter
            // 
            this.btnDebiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebiter.Location = new System.Drawing.Point(282, 334);
            this.btnDebiter.Name = "btnDebiter";
            this.btnDebiter.Size = new System.Drawing.Size(118, 38);
            this.btnDebiter.TabIndex = 6;
            this.btnDebiter.Text = "Débiter";
            this.btnDebiter.UseVisualStyleBackColor = true;
            this.btnDebiter.Click += new System.EventHandler(this.btnDebiter_Click);
            // 
            // btnOperations
            // 
            this.btnOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperations.Location = new System.Drawing.Point(222, 404);
            this.btnOperations.Name = "btnOperations";
            this.btnOperations.Size = new System.Drawing.Size(228, 38);
            this.btnOperations.TabIndex = 7;
            this.btnOperations.Text = "Acc Operations";
            this.btnOperations.UseVisualStyleBackColor = true;
            this.btnOperations.Click += new System.EventHandler(this.btnOperations_Click);
            // 
            // btnVerser
            // 
            this.btnVerser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerser.Location = new System.Drawing.Point(437, 334);
            this.btnVerser.Name = "btnVerser";
            this.btnVerser.Size = new System.Drawing.Size(118, 38);
            this.btnVerser.TabIndex = 8;
            this.btnVerser.Text = "Verser";
            this.btnVerser.UseVisualStyleBackColor = true;
            this.btnVerser.Click += new System.EventHandler(this.btnVerser_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 505);
            this.Controls.Add(this.btnVerser);
            this.Controls.Add(this.btnOperations);
            this.Controls.Add(this.btnDebiter);
            this.Controls.Add(this.btnCrediter);
            this.Controls.Add(this.gvComptes);
            this.Controls.Add(this.statusLogin);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusLogin.ResumeLayout(false);
            this.statusLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvComptes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusLogin;
        private System.Windows.Forms.DataGridView gvComptes;
        private System.Windows.Forms.Button btnCrediter;
        private System.Windows.Forms.Button btnDebiter;
        private System.Windows.Forms.Button btnOperations;
        private System.Windows.Forms.Button btnVerser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}