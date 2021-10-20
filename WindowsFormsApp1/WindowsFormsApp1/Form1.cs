using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool firstLoad = false;
        private bool isSearch = false;
        private string _saveFilePath;
        private Dictionary<string, string> _saveSearchFilePath = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();

        }
        #region TreeView 작성하는 기능 및 동작 관련 이벤트 처리
        // 드라이브 및 폴더를 TreeView의 노드로 입력
        private void Form_Load(object sender, EventArgs e)
        {
            firstLoad = true;
            string[] drivers = Directory.GetLogicalDrives();
            foreach(string drive in drivers)
            {
                TreeNode root = new TreeNode(drive);
                showFolderTree.Nodes.Add(root);

                DirectoryInfo dir = new DirectoryInfo(drive);

                if (dir.Exists) { AddDirectoryNodes(root, dir, false); }
            }
        }
        // 하위 폴더가 없을 때까지 계속 TreeView의 노드를 입력하는 재귀 함수
        private void AddDirectoryNodes(TreeNode root, DirectoryInfo dir, bool isLoop)
        {
            try
            {
                DirectoryInfo[] directories = dir.GetDirectories();
                foreach (DirectoryInfo directory in directories)
                {
                    TreeNode childRoot = new TreeNode(directory.Name);
                    root.Nodes.Add(childRoot);

                    if (isLoop) { AddDirectoryNodes(childRoot, directory, false); }
                }
            } 
            catch (Exception error) { if (firstLoad == false) { MessageBox.Show(error.Message); } }
        }
        
        // TreeView의 항목을 눌렀을 때 파일 및 폴더 목록을 ListView로 출력
        private void treeDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string _fullPath = e.Node.FullPath;

            // 선택한 노드의 전체 경로를 전역 변수에 저장
            _saveFilePath = e.Node.FullPath;

            try { ListViewInput(_fullPath); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void treeDir_AfterExpand(object sender, TreeViewEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(e.Node.FullPath);
            e.Node.Nodes.Clear();
            AddDirectoryNodes(e.Node, dir, true);
        }
        #endregion

        #region ListView 작성
        #region 파일에 대한 데이터 입력
        // ListView에 파일에 대한 정보를 한 행에 입력
        public void MakeListRow(FileInfo file)
        {
            ListViewItem item = new ListViewItem(file.Name);

            item.SubItems.Add(file.LastWriteTime.ToString());
            item.SubItems.Add(String.Format($"{file.Extension}"));
            item.ImageIndex = 2;

            if (file.Length > 1024 * 1024 * 1024) { item.SubItems.Add(String.Format("{0} GB", file.Length / 1024 / 1024 / 1024)); }
            else if (file.Length > 1024 * 1024) { item.SubItems.Add(String.Format("{0} MB", file.Length / 1024 / 1024)); }
            else if (file.Length > 1024) { item.SubItems.Add(String.Format("{0} KB", file.Length / 1024)); }
            else { item.SubItems.Add(String.Format("{0} Byte", file.Length)); }

            showAllFile.Items.Add(item);
        }

        // 검색을 할 때 이름을 키로, 경로를 값으로 저장
        public void MakeFileList (DirectoryInfo dir, string searchName = "", string searchPath = "")
        {
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (searchName != "")
                {
                    if (file.Name.ToUpper().Contains(searchName) || file.Name.ToLower().Contains(searchName))
                    {
                        MakeListRow(file);
                        _saveSearchFilePath.Add(file.Name, searchPath);
                    }
                }
                else
                {
                    MakeListRow(file);
                }
            }
        }
        #endregion

        #region
        public void MakeFolderList(DirectoryInfo folder)
        {
            ListViewItem item = new ListViewItem(folder.Name);
            item.SubItems.Add(folder.LastWriteTime.ToString());
            item.SubItems.Add(folder.Attributes.ToString());
            item.SubItems.Add("파일 폴더");

            showAllFile.Items.Add(item);
        }
        #endregion
        // ListView를 작성하는 기능
        public void ListViewInput(string fullPath)
        {
            showAllFile.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo(fullPath);
            DirectoryInfo[] folders = dir.GetDirectories();

            foreach (DirectoryInfo folder in folders)
            {
                MakeFolderList(folder);
            }

            MakeFileList(dir);
        }
        #endregion

        #region 부가 기능
        // 입력한 주소에 있는 폴더 및 파일을 ListView에 출력
        private void GoToDir_Click(object sender, EventArgs e)
        {
            isSearch = false;
            string _selectDir = inputFilePath.Text;
            try { ListViewInput(_selectDir); _saveFilePath = _selectDir; }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        // ListView 항목을 두 번 눌렀을 때 파일 실행이나 하위 폴더로 이동하는 이벤트 처리
        // 검색한 경우와 그렇지 않은 경우를 구분
        private void ShowAllFile_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _whetherFile = showAllFile.SelectedItems[0].SubItems[2].Text;
                string _selectedName = showAllFile.SelectedItems[0].Text;
                string _makeFIlePath = Path.Combine(_saveFilePath, _selectedName);

                if (isSearch) 
                {
                    
                    if (_whetherFile == "Directory") 
                    {
                        ListViewInput(_saveSearchFilePath[_selectedName]); _saveFilePath = _saveSearchFilePath[_selectedName]; 
                    }
                    else
                    {
                        string _makeSearchFilePath = Path.Combine(_saveSearchFilePath[_selectedName], _selectedName);
                        Process.Start(_makeSearchFilePath); 
                    }
                }
                else
                {
                    if (_whetherFile == "Directory") { ListViewInput(_makeFIlePath); _saveFilePath = _makeFIlePath; }
                    else { Process.Start(_makeFIlePath); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        // 뒤로 가기
        private void BackDir_Click(object sender, EventArgs e)
        {
            int _findBackSlash = _saveFilePath.LastIndexOf("\\");
            string _backDirPath = _saveFilePath.Substring(0, _findBackSlash);

            if (_findBackSlash >= 3) { ListViewInput(_backDirPath); _saveFilePath = _backDirPath; inputFilePath.Text = _backDirPath; }
            else { MessageBox.Show("더 이상 상위 디렉터리로 갈 수 없습니다."); }
        }

        // 검색을 위한 재귀 함수
        public void RecursiveFindFile(DirectoryInfo dirInfo, string searchName, string filePath)
        {
            MakeFileList(dirInfo, searchName, filePath);
            DirectoryInfo[] subDirs = dirInfo.GetDirectories();

            foreach (var dir in subDirs)
            {
                string _filePath = Path.Combine(filePath, dir.Name);
                if (dir.Name.ToUpper().Contains(searchName) || dir.Name.ToLower().Contains(searchName))
                {
                    MakeFolderList(dir);
                    _saveSearchFilePath.Add(dir.Name, _filePath);
                }

                RecursiveFindFile(dir, searchName, _filePath);
            }
        }

        // 검색 기능
        private void FileSearch_Click(object sender, EventArgs e)
        {
            try 
            {
                isSearch = true; _saveSearchFilePath = new Dictionary<string, string>();
                string _setDirRange = showDir.Text; string _serachName = searchFileName.Text; _saveFilePath = _setDirRange;
                DirectoryInfo dirRangeInfo = new DirectoryInfo(_setDirRange);

                showAllFile.Items.Clear(); RecursiveFindFile(dirRangeInfo, _serachName, _setDirRange);
            }
            catch (UnauthorizedAccessException) { MessageBox.Show("접근 권한이 없습니다!"); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        #endregion
    }
}
