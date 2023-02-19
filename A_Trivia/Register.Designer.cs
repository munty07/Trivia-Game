namespace A_Trivia
{
    partial class Register
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblCPass = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtCPass = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(238, 111);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(238, 143);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(238, 181);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(47, 17);
            this.lblMail.TabIndex = 2;
            this.lblMail.Text = "E-mail";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(238, 221);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(69, 17);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password";
            // 
            // lblCPass
            // 
            this.lblCPass.AutoSize = true;
            this.lblCPass.Location = new System.Drawing.Point(238, 260);
            this.lblCPass.Name = "lblCPass";
            this.lblCPass.Size = new System.Drawing.Size(121, 17);
            this.lblCPass.TabIndex = 4;
            this.lblCPass.Text = "Confirm Password";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAccount.Location = new System.Drawing.Point(238, 342);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(173, 17);
            this.lblAccount.TabIndex = 5;
            this.lblAccount.Text = "Already have an account?";
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSignIn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSignIn.Location = new System.Drawing.Point(434, 340);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(56, 18);
            this.lblSignIn.TabIndex = 6;
            this.lblSignIn.Text = "Sign In.";
            this.lblSignIn.Click += new System.EventHandler(this.lblSignIn_Click);
            this.lblSignIn.MouseEnter += new System.EventHandler(this.lblSignIn_MouseEnter);
            this.lblSignIn.MouseLeave += new System.EventHandler(this.lblSignIn_MouseLeave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(376, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 22);
            this.txtName.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(376, 140);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(155, 22);
            this.txtUsername.TabIndex = 8;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(376, 178);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(155, 22);
            this.txtMail.TabIndex = 9;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(376, 218);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(155, 22);
            this.txtPass.TabIndex = 10;
            // 
            // txtCPass
            // 
            this.txtCPass.Location = new System.Drawing.Point(376, 257);
            this.txtCPass.Name = "txtCPass";
            this.txtCPass.PasswordChar = '*';
            this.txtCPass.Size = new System.Drawing.Size(155, 22);
            this.txtCPass.TabIndex = 11;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(241, 295);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(290, 32);
            this.btnSignUp.TabIndex = 12;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            this.btnSignUp.MouseEnter += new System.EventHandler(this.btnSignUp_MouseEnter);
            this.btnSignUp.MouseLeave += new System.EventHandler(this.btnSignUp_MouseLeave);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRegister.Location = new System.Drawing.Point(244, 39);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(282, 31);
            this.lblRegister.TabIndex = 13;
            this.lblRegister.Text = "Register your Account";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(-2, -1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 30);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.txtCPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblCPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblName);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblCPass;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtCPass;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Button btnBack;
    }
}