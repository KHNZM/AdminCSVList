namespace AdminTeleWorkList
{
    partial class AdminTeleWorkList
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTeleWorkList));
            this.old_ID = new System.Windows.Forms.NumericUpDown();
            this.new_ID = new System.Windows.Forms.NumericUpDown();
            this.AdminName = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.csvPathTxt = new System.Windows.Forms.TextBox();
            this.csvFilePathLabel = new System.Windows.Forms.Label();
            this.old_ID_label = new System.Windows.Forms.Label();
            this.new_ID_label = new System.Windows.Forms.Label();
            this.管理者label = new System.Windows.Forms.Label();
            this.使用者label = new System.Windows.Forms.Label();
            this.Add_UpdateBtn = new System.Windows.Forms.Button();
            this.ReferBtn = new System.Windows.Forms.Button();
            this.AddLabel = new System.Windows.Forms.Label();
            this.UpdateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.old_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.new_ID)).BeginInit();
            this.SuspendLayout();
            // 
            // old_ID
            // 
            this.old_ID.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.old_ID.Location = new System.Drawing.Point(26, 87);
            this.old_ID.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.old_ID.Name = "old_ID";
            this.old_ID.Size = new System.Drawing.Size(62, 21);
            this.old_ID.TabIndex = 0;
            // 
            // new_ID
            // 
            this.new_ID.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.new_ID.Location = new System.Drawing.Point(106, 87);
            this.new_ID.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.new_ID.Name = "new_ID";
            this.new_ID.Size = new System.Drawing.Size(62, 21);
            this.new_ID.TabIndex = 1;
            // 
            // AdminName
            // 
            this.AdminName.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.AdminName.Location = new System.Drawing.Point(188, 87);
            this.AdminName.Name = "AdminName";
            this.AdminName.Size = new System.Drawing.Size(96, 21);
            this.AdminName.TabIndex = 2;
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.UserName.Location = new System.Drawing.Point(302, 87);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(96, 21);
            this.UserName.TabIndex = 3;
            // 
            // csvPathTxt
            // 
            this.csvPathTxt.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.csvPathTxt.Location = new System.Drawing.Point(26, 36);
            this.csvPathTxt.Name = "csvPathTxt";
            this.csvPathTxt.Size = new System.Drawing.Size(418, 21);
            this.csvPathTxt.TabIndex = 4;
            // 
            // csvFilePathLabel
            // 
            this.csvFilePathLabel.AutoSize = true;
            this.csvFilePathLabel.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.csvFilePathLabel.Location = new System.Drawing.Point(12, 14);
            this.csvFilePathLabel.Name = "csvFilePathLabel";
            this.csvFilePathLabel.Size = new System.Drawing.Size(215, 12);
            this.csvFilePathLabel.TabIndex = 5;
            this.csvFilePathLabel.Text = "テレワーク端末リストcsvファイルパス";
            // 
            // old_ID_label
            // 
            this.old_ID_label.AutoSize = true;
            this.old_ID_label.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.old_ID_label.Location = new System.Drawing.Point(12, 72);
            this.old_ID_label.Name = "old_ID_label";
            this.old_ID_label.Size = new System.Drawing.Size(34, 12);
            this.old_ID_label.TabIndex = 6;
            this.old_ID_label.Text = "old ID";
            // 
            // new_ID_label
            // 
            this.new_ID_label.AutoSize = true;
            this.new_ID_label.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.new_ID_label.Location = new System.Drawing.Point(92, 72);
            this.new_ID_label.Name = "new_ID_label";
            this.new_ID_label.Size = new System.Drawing.Size(39, 12);
            this.new_ID_label.TabIndex = 7;
            this.new_ID_label.Text = "new ID";
            // 
            // 管理者label
            // 
            this.管理者label.AutoSize = true;
            this.管理者label.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.管理者label.Location = new System.Drawing.Point(174, 72);
            this.管理者label.Name = "管理者label";
            this.管理者label.Size = new System.Drawing.Size(41, 12);
            this.管理者label.TabIndex = 8;
            this.管理者label.Text = "管理者";
            // 
            // 使用者label
            // 
            this.使用者label.AutoSize = true;
            this.使用者label.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.使用者label.Location = new System.Drawing.Point(288, 72);
            this.使用者label.Name = "使用者label";
            this.使用者label.Size = new System.Drawing.Size(41, 12);
            this.使用者label.TabIndex = 9;
            this.使用者label.Text = "使用者";
            // 
            // Add_UpdateBtn
            // 
            this.Add_UpdateBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.Add_UpdateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_UpdateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Add_UpdateBtn.FlatAppearance.BorderSize = 0;
            this.Add_UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add_UpdateBtn.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.Add_UpdateBtn.Location = new System.Drawing.Point(424, 86);
            this.Add_UpdateBtn.Name = "Add_UpdateBtn";
            this.Add_UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.Add_UpdateBtn.TabIndex = 10;
            this.Add_UpdateBtn.Text = "更新";
            this.Add_UpdateBtn.UseVisualStyleBackColor = false;
            this.Add_UpdateBtn.Click += new System.EventHandler(this.Add_UpdateBtn_Click);
            // 
            // ReferBtn
            // 
            this.ReferBtn.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.ReferBtn.Location = new System.Drawing.Point(454, 35);
            this.ReferBtn.Name = "ReferBtn";
            this.ReferBtn.Size = new System.Drawing.Size(45, 23);
            this.ReferBtn.TabIndex = 11;
            this.ReferBtn.Text = "参照";
            this.ReferBtn.UseVisualStyleBackColor = true;
            this.ReferBtn.Click += new System.EventHandler(this.ReferBtn_Click);
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.AddLabel.ForeColor = System.Drawing.Color.Tomato;
            this.AddLabel.Location = new System.Drawing.Point(410, 12);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(29, 12);
            this.AddLabel.TabIndex = 12;
            this.AddLabel.Text = "追加";
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.AutoSize = true;
            this.UpdateLabel.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F);
            this.UpdateLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UpdateLabel.Location = new System.Drawing.Point(481, 12);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(29, 12);
            this.UpdateLabel.TabIndex = 13;
            this.UpdateLabel.Text = "更新";
            // 
            // AdminTeleWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(522, 126);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.ReferBtn);
            this.Controls.Add(this.Add_UpdateBtn);
            this.Controls.Add(this.使用者label);
            this.Controls.Add(this.管理者label);
            this.Controls.Add(this.new_ID_label);
            this.Controls.Add(this.old_ID_label);
            this.Controls.Add(this.csvFilePathLabel);
            this.Controls.Add(this.csvPathTxt);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.AdminName);
            this.Controls.Add(this.new_ID);
            this.Controls.Add(this.old_ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminTeleWorkList";
            this.Text = "AdminTeleWorkList";
            ((System.ComponentModel.ISupportInitialize)(this.old_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.new_ID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown old_ID;
        private System.Windows.Forms.NumericUpDown new_ID;
        private System.Windows.Forms.TextBox AdminName;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox csvPathTxt;
        private System.Windows.Forms.Label csvFilePathLabel;
        private System.Windows.Forms.Label old_ID_label;
        private System.Windows.Forms.Label new_ID_label;
        private System.Windows.Forms.Label 管理者label;
        private System.Windows.Forms.Label 使用者label;
        private System.Windows.Forms.Button Add_UpdateBtn;
        private System.Windows.Forms.Button ReferBtn;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label UpdateLabel;
    }
}

