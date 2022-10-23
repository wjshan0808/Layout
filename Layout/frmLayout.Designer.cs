namespace Layout
{
    partial class frmLayout
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLayout));
            this.tsMenuItems = new System.Windows.Forms.ToolStrip();
            this.btnLinearLayout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTreeLayout = new System.Windows.Forms.ToolStripButton();
            this.dcLinearLayout = new DevExpress.XtraDiagram.DiagramControl();
            this.dcTreeLayout = new DevExpress.XtraDiagram.DiagramControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tsMenuItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dcLinearLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcTreeLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuItems
            // 
            this.tsMenuItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLinearLayout,
            this.toolStripSeparator1,
            this.btnTreeLayout});
            this.tsMenuItems.Location = new System.Drawing.Point(0, 0);
            this.tsMenuItems.Name = "tsMenuItems";
            this.tsMenuItems.Size = new System.Drawing.Size(940, 27);
            this.tsMenuItems.TabIndex = 1;
            this.tsMenuItems.Text = "toolStrip1";
            // 
            // btnLinearLayout
            // 
            this.btnLinearLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnLinearLayout.Image")));
            this.btnLinearLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinearLayout.Name = "btnLinearLayout";
            this.btnLinearLayout.Size = new System.Drawing.Size(109, 24);
            this.btnLinearLayout.Text = "Linear Layout";
            this.btnLinearLayout.Click += new System.EventHandler(this.btnNewLayout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnTreeLayout
            // 
            this.btnTreeLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnTreeLayout.Image")));
            this.btnTreeLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTreeLayout.Name = "btnTreeLayout";
            this.btnTreeLayout.Size = new System.Drawing.Size(100, 24);
            this.btnTreeLayout.Text = "Tree Layout";
            this.btnTreeLayout.Click += new System.EventHandler(this.btnTreeLayout_Click);
            // 
            // dcLinearLayout
            // 
            this.dcLinearLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcLinearLayout.Location = new System.Drawing.Point(0, 0);
            this.dcLinearLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dcLinearLayout.Name = "dcLinearLayout";
            this.dcLinearLayout.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes"});
            this.dcLinearLayout.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.dcLinearLayout.Size = new System.Drawing.Size(465, 657);
            this.dcLinearLayout.TabIndex = 2;
            this.dcLinearLayout.Text = "Layout";
            // 
            // dcTreeLayout
            // 
            this.dcTreeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTreeLayout.Location = new System.Drawing.Point(0, 0);
            this.dcTreeLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dcTreeLayout.Name = "dcTreeLayout";
            this.dcTreeLayout.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes"});
            this.dcTreeLayout.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.dcTreeLayout.Size = new System.Drawing.Size(472, 657);
            this.dcTreeLayout.TabIndex = 3;
            this.dcTreeLayout.Text = "Layout";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dcLinearLayout);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dcTreeLayout);
            this.splitContainer1.Size = new System.Drawing.Size(940, 657);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // frmLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 684);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMenuItems);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLayout";
            this.Text = "TreeLayout";
            this.tsMenuItems.ResumeLayout(false);
            this.tsMenuItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dcLinearLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcTreeLayout)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuItems;
        private System.Windows.Forms.ToolStripButton btnTreeLayout;
        private DevExpress.XtraDiagram.DiagramControl dcLinearLayout;
        private DevExpress.XtraDiagram.DiagramControl dcTreeLayout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnLinearLayout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

