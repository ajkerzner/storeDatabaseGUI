namespace StoreUI
{
    partial class PopupOrder
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtbxShippingCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbbxShippingPref = new System.Windows.Forms.ComboBox();
            this.cmbbxCustomers = new System.Windows.Forms.ComboBox();
            this.lstvwOrderedProducts = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(305, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 33);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(105, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 33);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtbxShippingCost
            // 
            this.txtbxShippingCost.Location = new System.Drawing.Point(117, 42);
            this.txtbxShippingCost.Name = "txtbxShippingCost";
            this.txtbxShippingCost.Size = new System.Drawing.Size(87, 22);
            this.txtbxShippingCost.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Shipping Cost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Customer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Shipping Preference:";
            // 
            // cmbbxShippingPref
            // 
            this.cmbbxShippingPref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxShippingPref.FormattingEnabled = true;
            this.cmbbxShippingPref.Items.AddRange(new object[] {
            "Overnight",
            "Priority (1-3 Days)",
            "First Class (1-3 Days)",
            "Standard (2 - 8 Days)"});
            this.cmbbxShippingPref.Location = new System.Drawing.Point(361, 42);
            this.cmbbxShippingPref.Name = "cmbbxShippingPref";
            this.cmbbxShippingPref.Size = new System.Drawing.Size(183, 24);
            this.cmbbxShippingPref.TabIndex = 27;
            // 
            // cmbbxCustomers
            // 
            this.cmbbxCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxCustomers.FormattingEnabled = true;
            this.cmbbxCustomers.Location = new System.Drawing.Point(90, 6);
            this.cmbbxCustomers.Name = "cmbbxCustomers";
            this.cmbbxCustomers.Size = new System.Drawing.Size(454, 24);
            this.cmbbxCustomers.TabIndex = 28;
            this.cmbbxCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbbxCustomers_SelectedIndexChanged);
            // 
            // lstvwOrderedProducts
            // 
            this.lstvwOrderedProducts.CheckBoxes = true;
            this.lstvwOrderedProducts.FullRowSelect = true;
            this.lstvwOrderedProducts.Location = new System.Drawing.Point(15, 98);
            this.lstvwOrderedProducts.Name = "lstvwOrderedProducts";
            this.lstvwOrderedProducts.Size = new System.Drawing.Size(529, 286);
            this.lstvwOrderedProducts.TabIndex = 29;
            this.lstvwOrderedProducts.UseCompatibleStateImageBehavior = false;
            this.lstvwOrderedProducts.View = System.Windows.Forms.View.Details;
            this.lstvwOrderedProducts.SelectedIndexChanged += new System.EventHandler(this.lstvwOrderedProducts_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Products:";
            // 
            // PopupOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 442);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstvwOrderedProducts);
            this.Controls.Add(this.cmbbxCustomers);
            this.Controls.Add(this.cmbbxShippingPref);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtbxShippingCost);
            this.Controls.Add(this.label1);
            this.Name = "PopupOrder";
            this.Text = "PopupOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtbxShippingCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbbxShippingPref;
        private System.Windows.Forms.ComboBox cmbbxCustomers;
        private System.Windows.Forms.ListView lstvwOrderedProducts;
        private System.Windows.Forms.Label label3;
    }
}