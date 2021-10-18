
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.showDir = new System.Windows.Forms.TextBox();
            this.SelectDir = new System.Windows.Forms.Button();
            this.fileSearch = new System.Windows.Forms.Button();
            this.GoToDir = new System.Windows.Forms.Button();
            this.inputFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchFileName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.showFolderTree = new System.Windows.Forms.TreeView();
            this.showAllFile = new System.Windows.Forms.ListView();
            this.folderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backDir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backDir);
            this.panel1.Controls.Add(this.showDir);
            this.panel1.Controls.Add(this.SelectDir);
            this.panel1.Controls.Add(this.fileSearch);
            this.panel1.Controls.Add(this.GoToDir);
            this.panel1.Controls.Add(this.inputFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 79);
            this.panel1.TabIndex = 0;
            // 
            // showDir
            // 
            this.showDir.Location = new System.Drawing.Point(160, 22);
            this.showDir.Name = "showDir";
            this.showDir.Size = new System.Drawing.Size(123, 21);
            this.showDir.TabIndex = 5;
            // 
            // SelectDir
            // 
            this.SelectDir.Location = new System.Drawing.Point(12, 20);
            this.SelectDir.Name = "SelectDir";
            this.SelectDir.Size = new System.Drawing.Size(142, 23);
            this.SelectDir.TabIndex = 4;
            this.SelectDir.Text = "상위 디렉토리 설정";
            this.SelectDir.UseVisualStyleBackColor = true;
            // 
            // fileSearch
            // 
            this.fileSearch.Location = new System.Drawing.Point(208, 49);
            this.fileSearch.Name = "fileSearch";
            this.fileSearch.Size = new System.Drawing.Size(75, 23);
            this.fileSearch.TabIndex = 3;
            this.fileSearch.Text = "검색";
            this.fileSearch.UseVisualStyleBackColor = true;
            this.fileSearch.Click += new System.EventHandler(this.FileSearch_Click);
            // 
            // GoToDir
            // 
            this.GoToDir.Location = new System.Drawing.Point(713, 49);
            this.GoToDir.Name = "GoToDir";
            this.GoToDir.Size = new System.Drawing.Size(75, 23);
            this.GoToDir.TabIndex = 2;
            this.GoToDir.Text = "이동";
            this.GoToDir.UseVisualStyleBackColor = true;
            this.GoToDir.Click += new System.EventHandler(this.GoToDir_Click);
            // 
            // inputFilePath
            // 
            this.inputFilePath.Location = new System.Drawing.Point(325, 51);
            this.inputFilePath.Name = "inputFilePath";
            this.inputFilePath.Size = new System.Drawing.Size(353, 21);
            this.inputFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "주소";
            // 
            // searchFileName
            // 
            this.searchFileName.Location = new System.Drawing.Point(12, 50);
            this.searchFileName.Name = "searchFileName";
            this.searchFileName.Size = new System.Drawing.Size(190, 21);
            this.searchFileName.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.showFolderTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.showAllFile);
            this.splitContainer1.Size = new System.Drawing.Size(800, 371);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 1;
            // 
            // showFolderTree
            // 
            this.showFolderTree.Location = new System.Drawing.Point(0, 0);
            this.showFolderTree.Name = "showFolderTree";
            this.showFolderTree.Size = new System.Drawing.Size(283, 368);
            this.showFolderTree.TabIndex = 0;
            this.showFolderTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeDir_AfterExpand);
            this.showFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDir_AfterSelect);
            // 
            // showAllFile
            // 
            this.showAllFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.folderFileName,
            this.UpdateDate,
            this.fileExtension,
            this.fileSize});
            this.showAllFile.HideSelection = false;
            this.showAllFile.Location = new System.Drawing.Point(2, 0);
            this.showAllFile.Name = "showAllFile";
            this.showAllFile.Size = new System.Drawing.Size(508, 371);
            this.showAllFile.TabIndex = 0;
            this.showAllFile.UseCompatibleStateImageBehavior = false;
            this.showAllFile.View = System.Windows.Forms.View.Details;
            this.showAllFile.DoubleClick += new System.EventHandler(this.ShowAllFile_DoubleClick);
            // 
            // folderFileName
            // 
            this.folderFileName.Text = "이름";
            this.folderFileName.Width = 200;
            // 
            // UpdateDate
            // 
            this.UpdateDate.Text = "수정한 날짜";
            this.UpdateDate.Width = 150;
            // 
            // fileExtension
            // 
            this.fileExtension.Text = "유형";
            this.fileExtension.Width = 75;
            // 
            // fileSize
            // 
            this.fileSize.Text = "크기";
            this.fileSize.Width = 75;
            // 
            // backDir
            // 
            this.backDir.Location = new System.Drawing.Point(684, 49);
            this.backDir.Name = "backDir";
            this.backDir.Size = new System.Drawing.Size(23, 23);
            this.backDir.TabIndex = 6;
            this.backDir.Text = "←";
            this.backDir.UseVisualStyleBackColor = true;
            this.backDir.Click += new System.EventHandler(this.BackDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "파일 탐색기";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox showDir;
        private System.Windows.Forms.Button SelectDir;
        private System.Windows.Forms.Button fileSearch;
        private System.Windows.Forms.Button GoToDir;
        private System.Windows.Forms.TextBox inputFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchFileName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView showFolderTree;
        private System.Windows.Forms.ListView showAllFile;
        private System.Windows.Forms.ColumnHeader folderFileName;
        private System.Windows.Forms.ColumnHeader UpdateDate;
        private System.Windows.Forms.ColumnHeader fileExtension;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.Button backDir;
    }
}

