﻿
namespace LendBook
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.학생관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도서관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대여관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반납관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.회원메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.학생관리ToolStripMenuItem,
            this.도서관리ToolStripMenuItem,
            this.대여관리ToolStripMenuItem,
            this.반납관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 학생관리ToolStripMenuItem
            // 
            this.학생관리ToolStripMenuItem.Name = "학생관리ToolStripMenuItem";
            this.학생관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.학생관리ToolStripMenuItem.Text = "학생관리";
            this.학생관리ToolStripMenuItem.Click += new System.EventHandler(this.학생관리ToolStripMenuItem_Click);
            // 
            // 도서관리ToolStripMenuItem
            // 
            this.도서관리ToolStripMenuItem.Name = "도서관리ToolStripMenuItem";
            this.도서관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.도서관리ToolStripMenuItem.Text = "도서관리";
            this.도서관리ToolStripMenuItem.Click += new System.EventHandler(this.도서관리ToolStripMenuItem_Click);
            // 
            // 대여관리ToolStripMenuItem
            // 
            this.대여관리ToolStripMenuItem.Name = "대여관리ToolStripMenuItem";
            this.대여관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.대여관리ToolStripMenuItem.Text = "대여관리";
            this.대여관리ToolStripMenuItem.Click += new System.EventHandler(this.대여관리ToolStripMenuItem_Click);
            // 
            // 반납관리ToolStripMenuItem
            // 
            this.반납관리ToolStripMenuItem.Name = "반납관리ToolStripMenuItem";
            this.반납관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.반납관리ToolStripMenuItem.Text = "반납관리";
            this.반납관리ToolStripMenuItem.Click += new System.EventHandler(this.반납관리ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(904, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.회원메뉴ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 회원메뉴ToolStripMenuItem
            // 
            this.회원메뉴ToolStripMenuItem.Name = "회원메뉴ToolStripMenuItem";
            this.회원메뉴ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.회원메뉴ToolStripMenuItem.Text = "회원메뉴";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 686);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1124, 725);
            this.Name = "frmMain";
            this.Text = "도서대여관리";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 학생관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도서관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대여관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반납관리ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 회원메뉴ToolStripMenuItem;
    }
}

