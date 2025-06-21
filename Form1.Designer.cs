using System.Windows.Forms;

namespace at3_c_1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxPlateView = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxTaggedPlates = new System.Windows.Forms.ListBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLinearSearch = new System.Windows.Forms.Button();
            this.buttonBinarySearch = new System.Windows.Forms.Button();
            this.buttonTag = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.toolTipInputBox = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPlateView = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipTaggedPlates = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEdit = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipTag = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSearchLinear = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSave = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDelete = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOpen = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSearchBinary = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipReset = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxPlateView
            // 
            this.listBoxPlateView.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxPlateView.FormattingEnabled = true;
            this.listBoxPlateView.Location = new System.Drawing.Point(10, 120);
            this.listBoxPlateView.Name = "listBoxPlateView";
            this.listBoxPlateView.Size = new System.Drawing.Size(211, 316);
            this.listBoxPlateView.TabIndex = 0;
            this.toolTipPlateView.SetToolTip(this.listBoxPlateView, "View all untagged plates");
            this.listBoxPlateView.SelectedIndexChanged += new System.EventHandler(this.listBoxPlateView_SelectedIndexChanged);
            this.listBoxPlateView.SelectedValueChanged += new System.EventHandler(this.listBoxPlateView_SelectedValueChanged);
            this.listBoxPlateView.DoubleClick += new System.EventHandler(this.listBoxPlateView_DoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 511);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(464, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "ready.";
            // 
            // listBoxTaggedPlates
            // 
            this.listBoxTaggedPlates.FormattingEnabled = true;
            this.listBoxTaggedPlates.Location = new System.Drawing.Point(234, 120);
            this.listBoxTaggedPlates.Name = "listBoxTaggedPlates";
            this.listBoxTaggedPlates.Size = new System.Drawing.Size(211, 316);
            this.listBoxTaggedPlates.TabIndex = 2;
            this.toolTipTaggedPlates.SetToolTip(this.listBoxTaggedPlates, "View all tagged plates.");
            this.listBoxTaggedPlates.SelectedIndexChanged += new System.EventHandler(this.listBoxTaggedPlates_SelectedIndexChanged);
            this.listBoxTaggedPlates.SelectedValueChanged += new System.EventHandler(this.listBoxTaggedPlates_SelectedValueChanged);
            this.listBoxTaggedPlates.DoubleClick += new System.EventHandler(this.listBoxTaggedPlates_DoubleClick);
            // 
            // textBoxInput
            // 
            this.textBoxInput.BackColor = System.Drawing.Color.White;
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInput.Location = new System.Drawing.Point(10, 94);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(330, 20);
            this.textBoxInput.TabIndex = 3;
            this.toolTipInputBox.SetToolTip(this.textBoxInput, "Input box - used for edit, search, add, ect");
            this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyDown);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 442);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(99, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.toolTipEdit.SetToolTip(this.buttonEdit, "Edits selected plate based on whatever is in the input box");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(346, 91);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(99, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 471);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.toolTipDelete.SetToolTip(this.buttonDelete, "Deletes selected plate from list.");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(346, 442);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(99, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.toolTipSave.SetToolTip(this.buttonSave, "Brings up menu where you can choose to save the current data to a text file.");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLinearSearch
            // 
            this.buttonLinearSearch.Location = new System.Drawing.Point(234, 442);
            this.buttonLinearSearch.Name = "buttonLinearSearch";
            this.buttonLinearSearch.Size = new System.Drawing.Size(99, 23);
            this.buttonLinearSearch.TabIndex = 9;
            this.buttonLinearSearch.Text = "Search (Linear)";
            this.toolTipSearchLinear.SetToolTip(this.buttonLinearSearch, "Searches for plate in inputBox on both lists, and displays results in status bar." +
        " Uses a Linear search algorithm\r\n");
            this.buttonLinearSearch.UseVisualStyleBackColor = true;
            this.buttonLinearSearch.Click += new System.EventHandler(this.buttonLinearSearch_Click);
            // 
            // buttonBinarySearch
            // 
            this.buttonBinarySearch.Location = new System.Drawing.Point(234, 471);
            this.buttonBinarySearch.Name = "buttonBinarySearch";
            this.buttonBinarySearch.Size = new System.Drawing.Size(99, 23);
            this.buttonBinarySearch.TabIndex = 10;
            this.buttonBinarySearch.Text = "Search (Binary)";
            this.toolTipSearchBinary.SetToolTip(this.buttonBinarySearch, "Searches Lists for the plate in Input box. uses a binary search algorithm");
            this.buttonBinarySearch.UseVisualStyleBackColor = true;
            this.buttonBinarySearch.Click += new System.EventHandler(this.buttonBinarySearch_Click);
            // 
            // buttonTag
            // 
            this.buttonTag.Location = new System.Drawing.Point(122, 442);
            this.buttonTag.Name = "buttonTag";
            this.buttonTag.Size = new System.Drawing.Size(99, 23);
            this.buttonTag.TabIndex = 11;
            this.buttonTag.Text = "Tag";
            this.toolTipTag.SetToolTip(this.buttonTag, "Tags a plate in the main list if selected, or untags a plate from the tagged list" +
        " if selected");
            this.buttonTag.UseVisualStyleBackColor = true;
            this.buttonTag.Click += new System.EventHandler(this.buttonTag_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(372, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(354, 32);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Licence Plate Managment\r\n";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 53);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(185, 35);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Active Systems PTY";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(122, 471);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(99, 23);
            this.buttonOpen.TabIndex = 15;
            this.buttonOpen.Text = "Open";
            this.toolTipOpen.SetToolTip(this.buttonOpen, "Brings up list of previously saved data, and loads it into\r\n the program if selec" +
        "ted\r\n");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(346, 471);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(99, 23);
            this.buttonReset.TabIndex = 16;
            this.buttonReset.Text = "Reset";
            this.toolTipReset.SetToolTip(this.buttonReset, "Wipe all data from lists.");
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 533);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonTag);
            this.Controls.Add(this.buttonBinarySearch);
            this.Controls.Add(this.buttonLinearSearch);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.listBoxTaggedPlates);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listBoxPlateView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPlateView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListBox listBoxTaggedPlates;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLinearSearch;
        private System.Windows.Forms.Button buttonBinarySearch;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonOpen;
        private Button buttonReset;
        private ToolTip toolTipPlateView;
        private ToolTip toolTipTaggedPlates;
        private ToolTip toolTipInputBox;
        private ToolTip toolTipEdit;
        private ToolTip toolTipTag;
        private ToolTip toolTipDelete;
        private ToolTip toolTipSave;
        private ToolTip toolTipSearchLinear;
        private ToolTip toolTipSearchBinary;
        private ToolTip toolTipOpen;
        private ToolTip toolTipReset;
    }
}

