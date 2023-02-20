namespace A_Trivia
{
    partial class ResetPassword
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblErrorMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblErrorCode = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblErrorNewPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lblErrorConfirmPass = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSendAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(-1, -2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 30);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(243, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 31);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "Reset your password";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(208, 109);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(42, 17);
            this.lblMail.TabIndex = 18;
            this.lblMail.Text = "Email";
            // 
            // lblErrorMail
            // 
            this.lblErrorMail.AutoSize = true;
            this.lblErrorMail.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMail.Location = new System.Drawing.Point(531, 109);
            this.lblErrorMail.Name = "lblErrorMail";
            this.lblErrorMail.Size = new System.Drawing.Size(0, 17);
            this.lblErrorMail.TabIndex = 20;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(287, 106);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(238, 22);
            this.txtMail.TabIndex = 22;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(211, 145);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(315, 31);
            this.btnSend.TabIndex = 23;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(211, 248);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(138, 31);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next Step";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(287, 211);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(238, 22);
            this.txtCode.TabIndex = 26;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // lblErrorCode
            // 
            this.lblErrorCode.AutoSize = true;
            this.lblErrorCode.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCode.Location = new System.Drawing.Point(531, 214);
            this.lblErrorCode.Name = "lblErrorCode";
            this.lblErrorCode.Size = new System.Drawing.Size(0, 17);
            this.lblErrorCode.TabIndex = 25;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(209, 214);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(73, 17);
            this.lblCode.TabIndex = 24;
            this.lblCode.Text = "Digit Code";
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(211, 384);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(315, 31);
            this.btnChange.TabIndex = 31;
            this.btnChange.Text = "Change Password";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Enabled = false;
            this.txtNewPass.Location = new System.Drawing.Point(328, 319);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(197, 22);
            this.txtNewPass.TabIndex = 30;
            this.txtNewPass.TextChanged += new System.EventHandler(this.txtNewPass_TextChanged);
            // 
            // lblErrorNewPass
            // 
            this.lblErrorNewPass.AutoSize = true;
            this.lblErrorNewPass.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNewPass.Location = new System.Drawing.Point(531, 322);
            this.lblErrorNewPass.Name = "lblErrorNewPass";
            this.lblErrorNewPass.Size = new System.Drawing.Size(0, 17);
            this.lblErrorNewPass.TabIndex = 29;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(208, 322);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(100, 17);
            this.lblNewPass.TabIndex = 28;
            this.lblNewPass.Text = "New Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Enabled = false;
            this.txtConfirmPass.Location = new System.Drawing.Point(328, 347);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(197, 22);
            this.txtConfirmPass.TabIndex = 34;
            this.txtConfirmPass.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            // 
            // lblErrorConfirmPass
            // 
            this.lblErrorConfirmPass.AutoSize = true;
            this.lblErrorConfirmPass.ForeColor = System.Drawing.Color.Red;
            this.lblErrorConfirmPass.Location = new System.Drawing.Point(531, 350);
            this.lblErrorConfirmPass.Name = "lblErrorConfirmPass";
            this.lblErrorConfirmPass.Size = new System.Drawing.Size(0, 17);
            this.lblErrorConfirmPass.TabIndex = 33;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Location = new System.Drawing.Point(208, 350);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(121, 17);
            this.lblConfirmPass.TabIndex = 32;
            this.lblConfirmPass.Text = "Confirm Password";
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(174, 179);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(384, 17);
            this.lblLine1.TabIndex = 35;
            this.lblLine1.Text = "_______________________________________________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(384, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "_______________________________________________";
            // 
            // btnSendAgain
            // 
            this.btnSendAgain.Location = new System.Drawing.Point(387, 248);
            this.btnSendAgain.Name = "btnSendAgain";
            this.btnSendAgain.Size = new System.Drawing.Size(138, 31);
            this.btnSendAgain.TabIndex = 37;
            this.btnSendAgain.Text = "Send Again";
            this.btnSendAgain.UseVisualStyleBackColor = true;
            this.btnSendAgain.Click += new System.EventHandler(this.btnSendAgain_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSendAgain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lblErrorConfirmPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblErrorNewPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblErrorCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblErrorMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResetPassword_FormClosed);
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblErrorMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblErrorCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblErrorNewPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label lblErrorConfirmPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSendAgain;
    }
}