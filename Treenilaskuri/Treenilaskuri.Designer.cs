namespace viikkotehtava2
{
    partial class Treenilaskuri
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
            this.tableLayoutPanelAsettelu = new System.Windows.Forms.TableLayoutPanel();
            this.labelOtsikko = new System.Windows.Forms.Label();
            this.flowLayoutPanelTreenit = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelYhteenveto = new System.Windows.Forms.FlowLayoutPanel();
            this.labelYhteenveto = new System.Windows.Forms.Label();
            this.labelKestot = new System.Windows.Forms.Label();
            this.labelMatkat = new System.Windows.Forms.Label();
            this.labelKokonaisvauhti = new System.Windows.Forms.Label();
            this.labelKokonaisnopeus = new System.Windows.Forms.Label();
            this.tableLayoutPanelAsettelu.SuspendLayout();
            this.flowLayoutPanelYhteenveto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAsettelu
            // 
            this.tableLayoutPanelAsettelu.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelAsettelu.ColumnCount = 1;
            this.tableLayoutPanelAsettelu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAsettelu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAsettelu.Controls.Add(this.labelOtsikko, 0, 0);
            this.tableLayoutPanelAsettelu.Controls.Add(this.flowLayoutPanelTreenit, 0, 1);
            this.tableLayoutPanelAsettelu.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelAsettelu.Name = "tableLayoutPanelAsettelu";
            this.tableLayoutPanelAsettelu.RowCount = 2;
            this.tableLayoutPanelAsettelu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.820225F));
            this.tableLayoutPanelAsettelu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.17978F));
            this.tableLayoutPanelAsettelu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAsettelu.Size = new System.Drawing.Size(250, 445);
            this.tableLayoutPanelAsettelu.TabIndex = 0;
            // 
            // labelOtsikko
            // 
            this.labelOtsikko.AutoSize = true;
            this.labelOtsikko.Location = new System.Drawing.Point(4, 1);
            this.labelOtsikko.Name = "labelOtsikko";
            this.labelOtsikko.Size = new System.Drawing.Size(53, 16);
            this.labelOtsikko.TabIndex = 0;
            this.labelOtsikko.Text = "Treenit";
            this.labelOtsikko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelTreenit
            // 
            this.flowLayoutPanelTreenit.AutoScroll = true;
            this.flowLayoutPanelTreenit.Location = new System.Drawing.Point(4, 21);
            this.flowLayoutPanelTreenit.Name = "flowLayoutPanelTreenit";
            this.flowLayoutPanelTreenit.Size = new System.Drawing.Size(240, 412);
            this.flowLayoutPanelTreenit.TabIndex = 1;
            // 
            // flowLayoutPanelYhteenveto
            // 
            this.flowLayoutPanelYhteenveto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanelYhteenveto.BackColor = System.Drawing.Color.Snow;
            this.flowLayoutPanelYhteenveto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelYhteenveto.Controls.Add(this.labelYhteenveto);
            this.flowLayoutPanelYhteenveto.Controls.Add(this.labelKestot);
            this.flowLayoutPanelYhteenveto.Controls.Add(this.labelMatkat);
            this.flowLayoutPanelYhteenveto.Controls.Add(this.labelKokonaisvauhti);
            this.flowLayoutPanelYhteenveto.Controls.Add(this.labelKokonaisnopeus);
            this.flowLayoutPanelYhteenveto.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelYhteenveto.Location = new System.Drawing.Point(268, 12);
            this.flowLayoutPanelYhteenveto.Name = "flowLayoutPanelYhteenveto";
            this.flowLayoutPanelYhteenveto.Size = new System.Drawing.Size(267, 106);
            this.flowLayoutPanelYhteenveto.TabIndex = 1;
            // 
            // labelYhteenveto
            // 
            this.labelYhteenveto.AutoSize = true;
            this.labelYhteenveto.Location = new System.Drawing.Point(3, 0);
            this.labelYhteenveto.Name = "labelYhteenveto";
            this.labelYhteenveto.Size = new System.Drawing.Size(80, 17);
            this.labelYhteenveto.TabIndex = 0;
            this.labelYhteenveto.Text = "Yhteenveto";
            // 
            // labelKestot
            // 
            this.labelKestot.AutoSize = true;
            this.labelKestot.Location = new System.Drawing.Point(3, 17);
            this.labelKestot.Name = "labelKestot";
            this.labelKestot.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelKestot.Size = new System.Drawing.Size(89, 29);
            this.labelKestot.TabIndex = 2;
            this.labelKestot.Text = "Yhteiskesto: ";
            // 
            // labelMatkat
            // 
            this.labelMatkat.AutoSize = true;
            this.labelMatkat.Location = new System.Drawing.Point(3, 46);
            this.labelMatkat.Name = "labelMatkat";
            this.labelMatkat.Size = new System.Drawing.Size(108, 17);
            this.labelMatkat.TabIndex = 1;
            this.labelMatkat.Text = "Kokonaismatka:";
            // 
            // labelKokonaisvauhti
            // 
            this.labelKokonaisvauhti.AutoSize = true;
            this.labelKokonaisvauhti.Location = new System.Drawing.Point(3, 63);
            this.labelKokonaisvauhti.Name = "labelKokonaisvauhti";
            this.labelKokonaisvauhti.Size = new System.Drawing.Size(112, 17);
            this.labelKokonaisvauhti.TabIndex = 3;
            this.labelKokonaisvauhti.Text = "Kokonaisvauhti: ";
            // 
            // labelKokonaisnopeus
            // 
            this.labelKokonaisnopeus.AutoSize = true;
            this.labelKokonaisnopeus.Location = new System.Drawing.Point(3, 80);
            this.labelKokonaisnopeus.Name = "labelKokonaisnopeus";
            this.labelKokonaisnopeus.Size = new System.Drawing.Size(117, 17);
            this.labelKokonaisnopeus.TabIndex = 4;
            this.labelKokonaisnopeus.Text = "Kokonaisnopeus:";
            // 
            // Treenilaskuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(547, 469);
            this.Controls.Add(this.flowLayoutPanelYhteenveto);
            this.Controls.Add(this.tableLayoutPanelAsettelu);
            this.Name = "Treenilaskuri";
            this.Text = "Treenilaskuri";
            this.tableLayoutPanelAsettelu.ResumeLayout(false);
            this.tableLayoutPanelAsettelu.PerformLayout();
            this.flowLayoutPanelYhteenveto.ResumeLayout(false);
            this.flowLayoutPanelYhteenveto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAsettelu;
        private System.Windows.Forms.Label labelOtsikko;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTreenit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelYhteenveto;
        private System.Windows.Forms.Label labelYhteenveto;
        private System.Windows.Forms.Label labelKestot;
        private System.Windows.Forms.Label labelMatkat;
        private System.Windows.Forms.Label labelKokonaisvauhti;
        private System.Windows.Forms.Label labelKokonaisnopeus;
    }
}

