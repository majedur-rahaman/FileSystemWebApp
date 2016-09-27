<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileSystemWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <div>File name with path:</div>
                <div>
                    <asp:TextBox ID="FilePathId" runat="server"></asp:TextBox>
                    <asp:Label ID="ErrorLabel" ForeColor="Red" runat="server"></asp:Label>
                    <span>
                        <asp:Button runat="server" Text="Create" OnClick="CreateFile_Click" OnClientClick="return validate();"/>
                    </span>

                </div>
            </div>
            <div>
                <div>File Content:
                    <asp:Label ID="ErrorPermission" ForeColor="Red" runat="server"></asp:Label></div>
                <div>
                    <asp:TextBox ID="ContentTextArea" TextMode="multiline" Columns="50" Rows="5" runat="server" /></div>
                <div>
                    <asp:RadioButtonList ID="PermissionId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioPermissionChange_CheckedChanged">
                        <asp:ListItem Value="1">Read</asp:ListItem>
                        <asp:ListItem Value="2">Write</asp:ListItem>
                        <asp:ListItem Value="3">Append</asp:ListItem>
                    </asp:RadioButtonList>

                </div>
            </div>
            <div>
                <span>
                    <asp:Button runat="server" Text="Read" OnClick="ReadFile_Click"  OnClientClick="return validate();"  />
                </span>
                <span>
                    <asp:Button runat="server" Text="Write" OnClick="WriteOnFile_Click"  OnClientClick="return validate();" />
                </span>
                <span>
                    <asp:Button runat="server" Text="Append" OnClientClick="return validate();" OnClick="AppendFile_Click" />
                </span>
                <span>
                    <asp:DropDownList ID="ChangePermissionId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownPermissionChange_CheckedChanged">
                        <asp:ListItem Text="Change Permision" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Read" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Write" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Append" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </span>

            </div>
        </div>
    </form>
    <script type="text/javascript">
        function validate() {
            var filePath = document.getElementById("FilePathId").value;
            var accessModeRadio = document.getElementById("PermissionId").value;
            var accessModeDropDown = document.getElementById("ChangePermissionId").value;

            if (filePath === "") {
                document.getElementById("ErrorLabel").innerHTML = null;
                alert("File path should not be null!");
                return false;
            }
            if (accessModeRadio === "" || accessModeDropDown === "") {
                alert("You Should define your file access mode!");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>