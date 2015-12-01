namespace StoreUI
{
    partial class PopupInventory
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
            this.txtbxDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbxSupplier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbbxProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtbxQuantity = new System.Windows.Forms.TextBox();
            this.txtbxCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbxDiscount
            // 
            this.txtbxDiscount.Location = new System.Drawing.Point(485, 53);
            this.txtbxDiscount.Name = "txtbxDiscount";
            this.txtbxDiscount.Size = new System.Drawing.Size(130, 22);
            this.txtbxDiscount.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Discount:";
            // 
            // cmbbxSupplier
            // 
            this.cmbbxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxSupplier.FormattingEnabled = true;
            this.cmbbxSupplier.Location = new System.Drawing.Point(385, 9);
            this.cmbbxSupplier.Name = "cmbbxSupplier";
            this.cmbbxSupplier.Size = new System.Drawing.Size(230, 24);
            this.cmbbxSupplier.TabIndex = 39;
            this.cmbbxSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbbxSupplier_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Supplier:";
            // 
            // cmbbxProduct
            // 
            this.cmbbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxProduct.FormattingEnabled = true;
            this.cmbbxProduct.Location = new System.Drawing.Point(83, 9);
            this.cmbbxProduct.Name = "cmbbxProduct";
            this.cmbbxProduct.Size = new System.Drawing.Size(230, 24);
            this.cmbbxProduct.TabIndex = 37;
            this.cmbbxProduct.SelectedIndexChanged += new System.EventHandler(this.cmbbxProduct_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cost:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(356, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 33);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(139, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 33);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtbxQuantity
            // 
            this.txtbxQuantity.Location = new System.Drawing.Point(280, 51);
            this.txtbxQuantity.Name = "txtbxQuantity";
            this.txtbxQuantity.Size = new System.Drawing.Size(121, 22);
            this.txtbxQuantity.TabIndex = 33;
            // 
            // txtbxCost
            // 
            this.txtbxCost.Location = new System.Drawing.Point(83, 49);
            this.txtbxCost.Name = "txtbxCost";
            this.txtbxCost.Size = new System.Drawing.Size(121, 22);
            this.txtbxCost.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Product:";
            // 
            // PopupInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 137);
            this.Controls.Add(this.txtbxDiscount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbbxSupplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbbxProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtbxQuantity);
            this.Controls.Add(this.txtbxCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PopupInventory";
            this.Text = "PopupInventory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbbxSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbbxProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtbxQuantity;
        private System.Windows.Forms.TextBox txtbxCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}