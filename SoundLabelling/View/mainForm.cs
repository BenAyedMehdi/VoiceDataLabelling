using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

namespace SoundLabelling
{
    public partial class mainForm : Form
    {
        CommandStorage CommandStorage;
        DirectoriesStorage DirectoriesStorage = new DirectoriesStorage();

        public mainForm()
        {
            InitializeComponent();
            ListCommandTypesAndLabels();
            LogFileEmpty();
        }

        private void LogFileEmpty()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                if (File.Exists(appSettings.Get("LogFile")))
                {
                    File.WriteAllText(appSettings.Get("LogFile"), String.Empty);
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
            
        }

        private void moveAndRenameFileButton_Click(object sender, EventArgs e)
        {
            if (SampleFilesListBox.SelectedItem != null && LabelsListBox.SelectedItem != null && CommandTypesListBox.SelectedItem != null)
            {
                TreeNode currentNode = treeView1.SelectedNode;
                SampleFile currentSample = SampleFileOfListBoxItem(SampleFilesListBox.SelectedItem, currentNode);
                string destinationFolder = CommandTypesListBox.SelectedItem.ToString();
                currentSample = MoveFileToFolder(currentSample, destinationFolder);//moved

                if (currentSample != null)
                {
                    if (RenameFile(currentSample, currentSample.FileInfo.Directory, LabelsListBox.SelectedItem.ToString()) != null)
                    {
                        MessageBox.Show("moved and renamed");
                        RefreshTree();
                    }
                }
            }
        }

        private SampleFile MoveFileToFolder(SampleFile currentSample, string destinationFolder)
        {
            string fileName = currentSample.Name;
            DirectoryInfo currentDirectory=  currentSample.FileInfo.Directory;
            DirectoryInfo destination = DestinationFolderFindOrCreate(currentDirectory, destinationFolder);
            
            string oldPath = currentDirectory.ToString() + '\\' + fileName;
            string newPath = destination.FullName + '\\' + fileName;

            if (File.Exists(newPath))
            {
                MessageBox.Show("File already exist in destination folder");
            }
            else
            {
                File.Move(oldPath, newPath);
            }
            LoadFiles(destination);
            LoadFiles(currentDirectory);
            return DirectoriesStorage.FindDirectory(destination).GetSampleByName(fileName);
        }

        private DirectoryInfo DestinationFolderFindOrCreate(DirectoryInfo currentDirectory, string destinationFolder)
        {
            List<DirectoryInfo> subDirectories = currentDirectory.GetDirectories().ToList();
            foreach (DirectoryInfo directory in subDirectories)
            {
                if (directory.Name == destinationFolder)
                {
                    return directory;
                }
            }
            string path = currentDirectory.FullName + "\\" + destinationFolder;
            return Directory.CreateDirectory(path);
        }

        private void UnacceptableButton_Click(object sender, EventArgs e)
        {
            if (SampleFilesListBox.SelectedItem != null)
            {
                string LogFileName = ConfigurationManager.AppSettings.Get("LogFile");

                TreeNode currentNode = treeView1.SelectedNode;
                SampleFile currentSample = SampleFileOfListBoxItem(SampleFilesListBox.SelectedItem, currentNode);
                DirectoryInfo currentDirectory = currentSample.FileInfo.Directory;
                Object nextItem = NextItemFromSampleFilesListBox();
                string fileName;

                if (LabelsListBox.SelectedItem != null)
                {
                    string newName = LabelsListBox.SelectedItem.ToString();
                    fileName= RenameFile(currentSample, currentDirectory, newName);
                    if (fileName != null)
                    {
                        currentSample = SampleFileOfListBoxItem(fileName, currentNode);
                        currentDirectory = currentSample.FileInfo.Directory;
                    }
                }
                MarkSampleAsUnacceptable(currentSample,currentDirectory,LogFileName);
                Select(nextItem);
            }
        }

        private void MarkSampleAsUnacceptable(SampleFile currentSample, DirectoryInfo currentDirectory, string logFileName)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(logFileName))
                {
                    if (CurrentSampleIsAcceptable(currentSample))
                    {
                        if (
                            MessageBox.Show(
                                "Are you sure you want to mark the file as unacceptable?",
                                "Confirmation",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                                ) == DialogResult.Yes
                            )
                        {
                            string lineToWrite = treeView1.SelectedNode.FullPath + "\\" + currentSample.Name;
                            sw.WriteLine(lineToWrite);
                            if (!File.Exists(currentSample.NewUnacceptableName()))
                            {
                                File.Move(currentSample.FullPath(), currentSample.NewUnacceptableName());
                                LoadFiles(currentDirectory);
                            }
                            else
                            {
                                MessageBox.Show("File exist");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sample ALREADY marked as unacceptable");
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }

        private bool CurrentSampleIsAcceptable(SampleFile currentSample)
        {
            if (currentSample != null)
            {
                if (currentSample.IsUnacceptable())
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        
        private void RenameFileButton_Click(object sender, EventArgs e)
        {
            if (SampleFilesListBox.SelectedItem != null && LabelsListBox.SelectedItem != null)
            {
                treeView1.Select();
                SampleFile currentSample = SampleFileOfListBoxItem(SampleFilesListBox.SelectedItem, treeView1.SelectedNode);
                DirectoryInfo currentDirectory = new DirectoryInfo(NodePathToFullPath(treeView1.SelectedNode));
                string newName = LabelsListBox.SelectedItem.ToString();
                
                object nextItem = NextItemFromSampleFilesListBox();

                RenameFile(currentSample, currentDirectory ,newName);

                Select(nextItem);
                SelectNextLabel();
            }
        }

        private string RenameFile(SampleFile currentSample, DirectoryInfo currentDirectory, string newName)
        {
            string oldPath = currentDirectory.ToString() + '\\' + currentSample.Name;
            string newPath = currentDirectory.ToString() + '\\' + newName + currentSample.Extension;
            
            string newNameChanged = newName;

            while (File.Exists(newPath))
            {
                newNameChanged = NewExistingName(newNameChanged);
                newPath = currentDirectory.ToString() + '\\' + newNameChanged + currentSample.Extension;
            }
            
            if (MessageBox.Show("Are you sure you want to rename the file?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                File.Move(oldPath, newPath);
                treeView1.Select();
                currentDirectory = new DirectoryInfo(NodePathToFullPath(treeView1.SelectedNode));
                LoadFiles(currentDirectory);
                return newNameChanged + currentSample.Extension;
            }
            return null;
        }

        private void SelectNextLabel()
        {
            if (LabelsListBox.SelectedIndex < LabelsListBox.Items.Count - 1)
            {
                LabelsListBox.SelectedIndex = LabelsListBox.SelectedIndex + 1;
            }
            else
            {
                LabelsListBox.SelectedIndex = 0;
            }
        }

        private object NextItemFromSampleFilesListBox()
        {
            if (SampleFilesListBox.SelectedIndex < SampleFilesListBox.Items.Count - 1)
            {
                return SampleFilesListBox.Items[SampleFilesListBox.SelectedIndex + 1];
            }
            else
            {
                return SampleFilesListBox.Items[SampleFilesListBox.SelectedIndex];
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (SampleFilesListBox.SelectedIndex >= 0 && SampleFilesListBox.SelectedIndex < SampleFilesListBox.Items.Count - 1)
            {
                object nextItem = SampleFilesListBox.Items[SampleFilesListBox.SelectedIndex + 1];
                Select(nextItem);
                SelectNextLabel();
            }
        }

        private void Select(object item)
        {
            for (int i = 0; i < SampleFilesListBox.Items.Count; i++)
            {
                if (SampleFilesListBox.Items[i].ToString() == item.ToString())
                {
                    SampleFilesListBox.SelectedIndex = i;
                }
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (SampleFilesListBox.SelectedItem != null)
            {
                treeView1.Select();
                TreeNode currentNode = treeView1.SelectedNode;
                SampleFile currentSample = SampleFileOfListBoxItem(SampleFilesListBox.SelectedItem, currentNode);
                FileInfo currentFile = currentSample.FileInfo;
                string currentFilePath = currentSample.ParentDirectoryPath + "\\" + currentFile.Name;
                try
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@currentFilePath);
                    player.Play();
                }
                catch (Exception)
                {
                    MessageBox.Show("invalid wave file");
                }
            }
        }

        private SampleFile SampleFileOfListBoxItem(object selectedItem, TreeNode treeNode)
        {
            string text = selectedItem.ToString();
           
            return TextToSampleFile(text, treeNode);
        }

        private SampleFile TextToSampleFile(string Name, TreeNode treeNode)
        {
            string fullpath = NodePathToFullPath(treeNode);
            DirectoryInfo currentDirectory = new DirectoryInfo(fullpath);

            return DirectoriesStorage.FindDirectory(currentDirectory).GetSampleByName(Name);
        }

        private void RenameFolderButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && CommandTypesListBox.SelectedItem != null)
            {
                string currentFolderPath = NodePathToFullPath(treeView1.SelectedNode);
                DirectoryInfo currentDirectory = new DirectoryInfo(currentFolderPath);

                string newName = CommandTypesListBox.SelectedItem.ToString();
                string pathWithoutName = nodePathWithoutName(treeView1.SelectedNode);
                string newPath = pathWithoutName + '\\' + newName;
                string newNameChanged = newName;

                while (Directory.Exists(newPath))
                {
                    newNameChanged= NewExistingName(newName);
                    newPath = pathWithoutName + '\\' +newNameChanged ;
                }

                if (MessageBox.Show("Are you sure you want to rename the folder?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    Directory.Move(currentFolderPath, newPath);
                    DirectoriesStorage.RenameDirectory(currentDirectory, newPath);
                    MessageBox.Show("The folder was renamed successfully\n New name: " + newNameChanged);
                    RefreshTree();
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SampleFilesListBox.Items.Clear();
            RenameFolderButton.Enabled = true;
            RenameFileButton.Enabled = true;
            PlayButton.Enabled = true;
            NextButton.Enabled = true;
            UnacceptableButton.Enabled = true;
            moveAndRenameFileButton.Enabled = true;

            TreeNode CurrentNode = e.Node;
            LoadFiles(new DirectoryInfo(NodePathToFullPath(CurrentNode)));
        }

        private void LoadFiles(DirectoryInfo currentDirectory)
        {
            DirectoriesStorage.UpdateDirectory(currentDirectory);

            SampleFilesListBox.Items.Clear();
            for (int i = 0; i < DirectoriesStorage.FindDirectory(currentDirectory).Count; i++)
            {
                object item = DirectoriesStorage.FindDirectory(currentDirectory)[i].Name;
                SampleFilesListBox.Items.Add(item);
            }
        }

        private void lbxCommandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelsListBox.Items.Clear();
            string selected;
            if (CommandTypesListBox.SelectedIndex > -1)
            {
                selected = CommandTypesListBox.Items[CommandTypesListBox.SelectedIndex].ToString();
                foreach (var command in CommandStorage.GetByName(selected))
                {
                    LabelsListBox.Items.Add(command.name);
                }
            }
        }
        
        private void ListCommandTypesAndLabels()
        {
            try
            {
                CommandStorage = new CommandStorage();
                
                string fileName = ConfigurationManager.AppSettings.Get("CommandsFile");
                string[] line;

                if (File.Exists(fileName) && new FileInfo(fileName).Length != 0)
                {
                    StreamReader SR = new StreamReader(fileName);

                    line = SR.ReadLine().Split(';');
                    
                    for (int i = 0; i < line.Length; i++)
                    {
                        string commandTypeName = string.Format("{0:D2}_{1}", i, line[i]);
                        CommandStorage.addCommandType(commandTypeName);
                        CommandTypesListBox.Items.Add(commandTypeName);
                    }

                    int lineCount = 0;
                    while (!SR.EndOfStream)
                    {
                        lineCount++;
                        line = SR.ReadLine().Split(';');
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] != "")
                            {
                                CommandStorage.addCommand(
                                    CommandStorage[i].Name,  
                                    string.Format("{0:D2}_{1}", lineCount, line[i])
                                );
                            }
                        }
                    }
                    SR.Close();
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }
        
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = PathTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                PathTextBox.Text = folderBrowserDialog1.SelectedPath;

                RefreshTree();
            }
        }

        private void RefreshTree()
        {
            SampleFilesListBox.Items.Clear();
            treeView1.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(PathTextBox.Text);
            treeView1.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private  TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            
            TreeNode directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            return directoryNode;
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshTree();
            }
        }

        private string NewExistingName(string newName)
        {
            if (newName[newName.Length-1]=='u' && newName[newName.Length - 2] == '_')
            {
                newName = newName.Remove(newName.Length - 1, 1);
                newName = newName.Remove(newName.Length - 1, 1);
            }
            if (Char.IsDigit(newName[newName.Length - 1]))
            {
                int number = (int)Char.GetNumericValue(newName[newName.Length - 1]);
                number++;

                newName = newName.Remove(newName.Length - 1, 1);
                newName = newName + number.ToString();
            }
            else
            {
                newName = newName + "1";
            }
            return newName;
        }

        private string NodePathToFullPath(TreeNode treeNode)
        {
            string fullpath = treeNode.FullPath;

            if (fullpath.Contains('\\'))
            {
                do
                {
                    fullpath = fullpath.Remove(0, 1);

                } while (fullpath[0] != '\\');
                fullpath = PathTextBox.Text + fullpath;
            }
            else
            {
                fullpath = PathTextBox.Text;
            }
            return fullpath;

        }

        private string nodePathWithoutName(TreeNode selectedNode)
        {
            string fullpath = NodePathToFullPath(selectedNode);
            do
            {
                fullpath = fullpath.Remove(fullpath.Length - 1, 1);
            } while (fullpath[fullpath.Length - 1] != '\\');
            fullpath = fullpath.Remove(fullpath.Length - 1, 1);
            return fullpath;
        }
    }
}
