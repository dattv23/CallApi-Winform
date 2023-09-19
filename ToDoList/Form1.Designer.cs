namespace ToDoList
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPriority = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoad.Location = new System.Drawing.Point(95, 51);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(180, 40);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(95, 103);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(830, 34);
            this.txtInput.TabIndex = 1;
            // 
            // dgvTasks
            // 
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvId,
            this.dgvDone,
            this.dgvDueDate,
            this.dgvPriority,
            this.dgvTask});
            this.dgvTasks.Location = new System.Drawing.Point(95, 149);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.Size = new System.Drawing.Size(830, 266);
            this.dgvTasks.TabIndex = 2;
            this.dgvTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Location = new System.Drawing.Point(299, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Task";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Location = new System.Drawing.Point(517, 51);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(192, 40);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit Task";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Location = new System.Drawing.Point(733, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete Task";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvId
            // 
            this.dgvId.HeaderText = "ID";
            this.dgvId.MinimumWidth = 6;
            this.dgvId.Name = "dgvId";
            this.dgvId.Width = 40;
            // 
            // dgvDone
            // 
            this.dgvDone.HeaderText = "Done";
            this.dgvDone.Items.AddRange(new object[] {
            "Open",
            "Close"});
            this.dgvDone.MinimumWidth = 6;
            this.dgvDone.Name = "dgvDone";
            this.dgvDone.Width = 125;
            // 
            // dgvDueDate
            // 
            this.dgvDueDate.HeaderText = "Due Date";
            this.dgvDueDate.MinimumWidth = 6;
            this.dgvDueDate.Name = "dgvDueDate";
            this.dgvDueDate.Width = 125;
            // 
            // dgvPriority
            // 
            this.dgvPriority.HeaderText = "Priority";
            this.dgvPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.dgvPriority.MinimumWidth = 6;
            this.dgvPriority.Name = "dgvPriority";
            this.dgvPriority.Width = 125;
            // 
            // dgvTask
            // 
            this.dgvTask.HeaderText = "Task";
            this.dgvTask.MinimumWidth = 6;
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvTask.Width = 340;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 450);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvId;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDueDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTask;
    }
}

