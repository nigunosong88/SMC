namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.speedtext = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.UpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gogoABS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.清除 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.status_BUSY = new System.Windows.Forms.TextBox();
            this.status_SVRE = new System.Windows.Forms.TextBox();
            this.status_SETON = new System.Windows.Forms.TextBox();
            this.status_INP = new System.Windows.Forms.TextBox();
            this.status_ALARM = new System.Windows.Forms.TextBox();
            this.BUSY1 = new System.Windows.Forms.Label();
            this.SVRE1 = new System.Windows.Forms.Label();
            this.SETON1 = new System.Windows.Forms.Label();
            this.INP1 = new System.Windows.Forms.Label();
            this.alarm = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SVRE_1 = new System.Windows.Forms.Button();
            this.SVRE_0 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ABSorINC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.distance_mm = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.rate = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(23, 34);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "開始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(23, 83);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 7;
            this.close.Text = "關閉";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(115, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 22);
            this.button4.TabIndex = 8;
            this.button4.Text = "復位";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // speedtext
            // 
            this.speedtext.AutoSize = true;
            this.speedtext.Font = new System.Drawing.Font("新細明體", 12F);
            this.speedtext.Location = new System.Drawing.Point(306, 62);
            this.speedtext.Name = "speedtext";
            this.speedtext.Size = new System.Drawing.Size(42, 16);
            this.speedtext.TabIndex = 30;
            this.speedtext.Text = "mm/s";
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(285, 32);
            this.speedBar.Maximum = 200;
            this.speedBar.Minimum = 10;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(104, 45);
            this.speedBar.TabIndex = 29;
            this.speedBar.Value = 10;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 16F);
            this.label4.Location = new System.Drawing.Point(231, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "速度";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(69, 56);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F);
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "INC";
            // 
            // UpDown1
            // 
            this.UpDown1.Location = new System.Drawing.Point(69, 18);
            this.UpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.UpDown1.Name = "UpDown1";
            this.UpDown1.Size = new System.Drawing.Size(75, 22);
            this.UpDown1.TabIndex = 24;
            // 
            // gogoABS
            // 
            this.gogoABS.Location = new System.Drawing.Point(150, 20);
            this.gogoABS.Name = "gogoABS";
            this.gogoABS.Size = new System.Drawing.Size(75, 23);
            this.gogoABS.TabIndex = 23;
            this.gogoABS.Text = "Go";
            this.gogoABS.UseVisualStyleBackColor = true;
            this.gogoABS.Click += new System.EventHandler(this.gogoABS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F);
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "ABS";
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(150, 55);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(28, 23);
            this.left.TabIndex = 31;
            this.left.Text = "<";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(197, 55);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(28, 23);
            this.right.TabIndex = 32;
            this.right.Text = ">";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 33;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 302);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(167, 99);
            this.textBox1.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.清除);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.speedtext);
            this.groupBox1.Controls.Add(this.right);
            this.groupBox1.Controls.Add(this.speedBar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.left);
            this.groupBox1.Controls.Add(this.gogoABS);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.UpDown1);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(252, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 263);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            // 
            // 清除
            // 
            this.清除.Location = new System.Drawing.Point(423, 228);
            this.清除.Name = "清除";
            this.清除.Size = new System.Drawing.Size(75, 23);
            this.清除.TabIndex = 54;
            this.清除.Text = "清除";
            this.清除.UseVisualStyleBackColor = true;
            this.清除.Click += new System.EventHandler(this.button5_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(350, 228);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 55;
            this.button5.Text = "輸入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(488, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "mm/s";
            // 
            // status_BUSY
            // 
            this.status_BUSY.Location = new System.Drawing.Point(541, 20);
            this.status_BUSY.Name = "status_BUSY";
            this.status_BUSY.ReadOnly = true;
            this.status_BUSY.Size = new System.Drawing.Size(50, 22);
            this.status_BUSY.TabIndex = 50;
            // 
            // status_SVRE
            // 
            this.status_SVRE.Location = new System.Drawing.Point(431, 20);
            this.status_SVRE.Name = "status_SVRE";
            this.status_SVRE.ReadOnly = true;
            this.status_SVRE.Size = new System.Drawing.Size(50, 22);
            this.status_SVRE.TabIndex = 49;
            // 
            // status_SETON
            // 
            this.status_SETON.Location = new System.Drawing.Point(307, 20);
            this.status_SETON.Name = "status_SETON";
            this.status_SETON.ReadOnly = true;
            this.status_SETON.Size = new System.Drawing.Size(50, 22);
            this.status_SETON.TabIndex = 48;
            // 
            // status_INP
            // 
            this.status_INP.Location = new System.Drawing.Point(189, 20);
            this.status_INP.Name = "status_INP";
            this.status_INP.ReadOnly = true;
            this.status_INP.Size = new System.Drawing.Size(50, 22);
            this.status_INP.TabIndex = 47;
            // 
            // status_ALARM
            // 
            this.status_ALARM.Location = new System.Drawing.Point(68, 20);
            this.status_ALARM.Name = "status_ALARM";
            this.status_ALARM.ReadOnly = true;
            this.status_ALARM.Size = new System.Drawing.Size(50, 22);
            this.status_ALARM.TabIndex = 46;
            this.status_ALARM.Click += new System.EventHandler(this.warning);
            // 
            // BUSY1
            // 
            this.BUSY1.AutoSize = true;
            this.BUSY1.Font = new System.Drawing.Font("新細明體", 12F);
            this.BUSY1.Location = new System.Drawing.Point(487, 20);
            this.BUSY1.Name = "BUSY1";
            this.BUSY1.Size = new System.Drawing.Size(48, 16);
            this.BUSY1.TabIndex = 45;
            this.BUSY1.Text = "BUSY";
            // 
            // SVRE1
            // 
            this.SVRE1.AutoSize = true;
            this.SVRE1.Font = new System.Drawing.Font("新細明體", 12F);
            this.SVRE1.Location = new System.Drawing.Point(379, 20);
            this.SVRE1.Name = "SVRE1";
            this.SVRE1.Size = new System.Drawing.Size(46, 16);
            this.SVRE1.TabIndex = 44;
            this.SVRE1.Text = "SVRE";
            // 
            // SETON1
            // 
            this.SETON1.AutoSize = true;
            this.SETON1.Font = new System.Drawing.Font("新細明體", 12F);
            this.SETON1.Location = new System.Drawing.Point(245, 20);
            this.SETON1.Name = "SETON1";
            this.SETON1.Size = new System.Drawing.Size(56, 16);
            this.SETON1.TabIndex = 43;
            this.SETON1.Text = "SETON";
            // 
            // INP1
            // 
            this.INP1.AutoSize = true;
            this.INP1.Font = new System.Drawing.Font("新細明體", 12F);
            this.INP1.Location = new System.Drawing.Point(134, 20);
            this.INP1.Name = "INP1";
            this.INP1.Size = new System.Drawing.Size(32, 16);
            this.INP1.TabIndex = 42;
            this.INP1.Text = "INP";
            // 
            // alarm
            // 
            this.alarm.AutoSize = true;
            this.alarm.Font = new System.Drawing.Font("新細明體", 12F);
            this.alarm.Location = new System.Drawing.Point(0, 20);
            this.alarm.Name = "alarm";
            this.alarm.Size = new System.Drawing.Size(62, 16);
            this.alarm.TabIndex = 39;
            this.alarm.Text = "ALARM";
            // 
            // reset
            // 
            this.reset.Enabled = false;
            this.reset.Location = new System.Drawing.Point(23, 178);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 36;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(23, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 51;
            this.button3.Text = "拍照";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SVRE_1
            // 
            this.SVRE_1.Enabled = false;
            this.SVRE_1.Location = new System.Drawing.Point(115, 83);
            this.SVRE_1.Name = "SVRE_1";
            this.SVRE_1.Size = new System.Drawing.Size(75, 23);
            this.SVRE_1.TabIndex = 56;
            this.SVRE_1.Text = "伺服開啟";
            this.SVRE_1.UseVisualStyleBackColor = true;
            this.SVRE_1.Click += new System.EventHandler(this.SVRE_1_Click);
            // 
            // SVRE_0
            // 
            this.SVRE_0.Enabled = false;
            this.SVRE_0.Location = new System.Drawing.Point(115, 135);
            this.SVRE_0.Name = "SVRE_0";
            this.SVRE_0.Size = new System.Drawing.Size(75, 23);
            this.SVRE_0.TabIndex = 57;
            this.SVRE_0.Text = "伺服關閉";
            this.SVRE_0.UseVisualStyleBackColor = true;
            this.SVRE_0.Click += new System.EventHandler(this.SVRE_0_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.status_BUSY);
            this.groupBox2.Controls.Add(this.status_SVRE);
            this.groupBox2.Controls.Add(this.alarm);
            this.groupBox2.Controls.Add(this.INP1);
            this.groupBox2.Controls.Add(this.SETON1);
            this.groupBox2.Controls.Add(this.status_ALARM);
            this.groupBox2.Controls.Add(this.BUSY1);
            this.groupBox2.Controls.Add(this.status_INP);
            this.groupBox2.Controls.Add(this.status_SETON);
            this.groupBox2.Controls.Add(this.SVRE1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(252, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 48);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "狀態";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "距離";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "速度";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ABSorINC,
            this.distance_mm,
            this.rate});
            this.dataGridView2.Location = new System.Drawing.Point(6, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(492, 150);
            this.dataGridView2.TabIndex = 56;
            // 
            // ABSorINC
            // 
            this.ABSorINC.HeaderText = "模式";
            this.ABSorINC.Name = "ABSorINC";
            // 
            // distance_mm
            // 
            this.distance_mm.HeaderText = "距離";
            this.distance_mm.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.distance_mm.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.distance_mm.Name = "distance_mm";
            // 
            // rate
            // 
            this.rate.HeaderText = "速度";
            this.rate.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.rate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rate.Name = "rate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 428);
            this.Controls.Add(this.SVRE_0);
            this.Controls.Add(this.SVRE_1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label speedtext;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown UpDown1;
        private System.Windows.Forms.Button gogoABS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button reset;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox status_BUSY;
        public System.Windows.Forms.TextBox status_SVRE;
        public System.Windows.Forms.TextBox status_SETON;
        public System.Windows.Forms.TextBox status_INP;
        public System.Windows.Forms.TextBox status_ALARM;
        public System.Windows.Forms.Label BUSY1;
        public System.Windows.Forms.Label SVRE1;
        public System.Windows.Forms.Label SETON1;
        public System.Windows.Forms.Label INP1;
        public System.Windows.Forms.Label alarm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.Button 清除;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button SVRE_1;
        private System.Windows.Forms.Button SVRE_0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewComboBoxColumn ABSorINC;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn distance_mm;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn rate;
    }
}

