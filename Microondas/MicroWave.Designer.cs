namespace Microondas
{
    partial class MicroWave
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnNewProgram = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.dgvPrograms = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnStartProgram = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.txtPotency = new System.Windows.Forms.MaskedTextBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrograms)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tempo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Potência";
            // 
            // txtProgram
            // 
            this.txtProgram.Location = new System.Drawing.Point(468, 30);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(100, 20);
            this.txtProgram.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(574, 67);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnNewProgram
            // 
            this.btnNewProgram.Location = new System.Drawing.Point(468, 113);
            this.btnNewProgram.Name = "btnNewProgram";
            this.btnNewProgram.Size = new System.Drawing.Size(111, 23);
            this.btnNewProgram.TabIndex = 7;
            this.btnNewProgram.Text = "Novo Programa";
            this.btnNewProgram.UseVisualStyleBackColor = true;
            this.btnNewProgram.Click += new System.EventHandler(this.btnNewProgram_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(468, 70);
            this.txtTime.Mask = "90:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(37, 20);
            this.txtTime.TabIndex = 8;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            // 
            // dgvPrograms
            // 
            this.dgvPrograms.AllowUserToAddRows = false;
            this.dgvPrograms.AllowUserToDeleteRows = false;
            this.dgvPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrograms.Location = new System.Drawing.Point(3, 12);
            this.dgvPrograms.Name = "dgvPrograms";
            this.dgvPrograms.Size = new System.Drawing.Size(456, 184);
            this.dgvPrograms.TabIndex = 9;
            this.dgvPrograms.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrograms_CellMouseClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(574, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnStartProgram
            // 
            this.btnStartProgram.Location = new System.Drawing.Point(465, 142);
            this.btnStartProgram.Name = "btnStartProgram";
            this.btnStartProgram.Size = new System.Drawing.Size(114, 23);
            this.btnStartProgram.TabIndex = 11;
            this.btnStartProgram.Text = "Iniciar Programa";
            this.btnStartProgram.UseVisualStyleBackColor = true;
            this.btnStartProgram.Click += new System.EventHandler(this.btnStartProgram_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(587, 113);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(59, 23);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Pausar";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(587, 142);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(59, 23);
            this.btnResume.TabIndex = 13;
            this.btnResume.Text = "Retomar";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // txtPotency
            // 
            this.txtPotency.Location = new System.Drawing.Point(511, 69);
            this.txtPotency.Mask = "00";
            this.txtPotency.Name = "txtPotency";
            this.txtPotency.Size = new System.Drawing.Size(57, 20);
            this.txtPotency.TabIndex = 14;
            this.txtPotency.ValidatingType = typeof(int);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(468, 173);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(59, 23);
            this.Cancelar.TabIndex = 15;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // MicroWave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 220);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.txtPotency);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStartProgram);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvPrograms);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnNewProgram);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtProgram);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MicroWave";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrograms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnNewProgram;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private System.Windows.Forms.DataGridView dgvPrograms;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnStartProgram;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.MaskedTextBox txtPotency;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Timer timer1;
    }
}

