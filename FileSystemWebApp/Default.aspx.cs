using System;
using System.Diagnostics;
using System.IO;

namespace FileSystemWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        private string FilePath { set; get; }
        private string FileContent { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
        }

        protected void CreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                FilePath = FilePathId.Text;
                var fileInfo = new FileInfo(FilePath);
                if (File.Exists(FilePath))
                {
                    ErrorLabel.Text = "File Already Exist!";
                }
                else
                {
                    fileInfo.Directory?.Create();
                    File.WriteAllText(fileInfo.FullName, FileContent);
                    ErrorLabel.Text = "";
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        protected void ReadFile_Click(object sender, EventArgs e)
        {
            FilePath = FilePathId.Text;
            if ((PermissionId.Text == "1" || ChangePermissionId.Text == "1") 
                && !string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    ContentTextArea.Text = File.ReadAllText(FilePath);
                    ErrorPermission.Text = "";
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
                ContentTextArea.ReadOnly = true;
            }
            else
            {
                ErrorPermission.Text = "Required permission to read data from file!";
            }

        }

        protected void WriteOnFile_Click(object sender, EventArgs e)
        {
            FilePath = FilePathId.Text;

            if ((PermissionId.Text == "2" || ChangePermissionId.Text == "2") 
                && !string.IsNullOrEmpty(FilePath))
            {
                
                FileContent = ContentTextArea.Text;
                var file = new FileInfo(FilePath);

                try
                {
                    File.WriteAllText(file.FullName, FileContent);
                    ErrorPermission.Text = "";
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
            else
            {
                ErrorPermission.Text = "Required permission to write data to file!";
            }

        }
        protected void AppendFile_Click(object sender, EventArgs e)
        {
            FilePath = FilePathId.Text;

            if ((PermissionId.Text == "3" || ChangePermissionId.Text == "3") 
                && !string.IsNullOrEmpty(FilePath))
            {

                FileContent = ContentTextArea.Text;
                var file = new FileInfo(FilePath);

                try
                {
                    File.AppendAllText(file.FullName, FileContent);
                    ErrorPermission.Text = "";
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
            else
            {
                ErrorPermission.Text = "Required permission to append data to file!";
            }
        }

        protected void RadioPermissionChange_CheckedChanged(object sender, EventArgs e)
        {
            FilePath = FilePathId.Text;
            if (FilePath == "")
            {
                ErrorPermission.Text = "Required file name!";
            }
            else if (!File.Exists(FilePath))
            {
                ErrorPermission.Text = "File is not yet created!";
            }
            else
            {
                ErrorPermission.Text = "";
                try
                {
                    switch (PermissionId.Text)
                    {
                        case "1":
                            ContentTextArea.Text = File.ReadAllText(FilePath);
                            ContentTextArea.ReadOnly = true;
                            break;
                        case "2":
                            ContentTextArea.Text = File.ReadAllText(FilePath);
                            ContentTextArea.ReadOnly = false;
                            break;
                        case "3":
                            ContentTextArea.ReadOnly = false;
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }

        protected void DropDownPermissionChange_CheckedChanged(object sender, EventArgs e)
        {
            FilePath = FilePathId.Text;

            if (FilePath == "")
            {
                ErrorPermission.Text = "Required file name!";
            }
            else if (!File.Exists(FilePath))
            {
                ErrorPermission.Text = "File is not yet created!";
            }
            else
            {
                ErrorPermission.Text = "";
                try
                {
                    PermissionId.Visible = false;
                    switch (ChangePermissionId.Text)
                    {
                        case "1":
                            ContentTextArea.Text = File.ReadAllText(FilePath);
                            ContentTextArea.ReadOnly = true;
                            break;
                        case "2":
                            ContentTextArea.Text = File.ReadAllText(FilePath);
                            ContentTextArea.ReadOnly = false;
                            break;
                        case "3":
                            ContentTextArea.ReadOnly = false;
                            break;
                            default:
                            PermissionId.Visible = true;
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }
    }
}