﻿
namespace LendBook
{
    partial class frmLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtUserEmail_S = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtUserName_S = new System.Windows.Forms.TextBox();
            this.txtUserID_S = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "비밀번호";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 26);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 26);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(76, 266);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(57, 20);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "회원가입";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(189, 266);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(121, 20);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "아이디/비밀번호찾기";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtUserEmail_S);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.button3);
            this.pnlSearch.Controls.Add(this.button4);
            this.pnlSearch.Controls.Add(this.txtUserName_S);
            this.pnlSearch.Controls.Add(this.txtUserID_S);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label4);
            this.pnlSearch.Location = new System.Drawing.Point(41, 28);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(348, 257);
            this.pnlSearch.TabIndex = 8;
            this.pnlSearch.Visible = false;
            // 
            // txtUserEmail_S
            // 
            this.txtUserEmail_S.Location = new System.Drawing.Point(119, 147);
            this.txtUserEmail_S.Name = "txtUserEmail_S";
            this.txtUserEmail_S.Size = new System.Drawing.Size(210, 26);
            this.txtUserEmail_S.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(204, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 35);
            this.button3.TabIndex = 11;
            this.button3.Text = "취소";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(73, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 35);
            this.button4.TabIndex = 10;
            this.button4.Text = "비밀번호찾기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtUserName_S
            // 
            this.txtUserName_S.Location = new System.Drawing.Point(119, 89);
            this.txtUserName_S.Name = "txtUserName_S";
            this.txtUserName_S.Size = new System.Drawing.Size(136, 26);
            this.txtUserName_S.TabIndex = 9;
            // 
            // txtUserID_S
            // 
            this.txtUserID_S.Location = new System.Drawing.Point(119, 31);
            this.txtUserID_S.Name = "txtUserID_S";
            this.txtUserID_S.Size = new System.Drawing.Size(136, 26);
            this.txtUserID_S.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "회원아이디";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 312);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLogin";
            this.Text = "로그인";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtUserEmail_S;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtUserName_S;
        private System.Windows.Forms.TextBox txtUserID_S;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}