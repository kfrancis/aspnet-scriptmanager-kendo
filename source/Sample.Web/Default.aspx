<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sample.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" EnablePartialRendering="true" EnableCdn="true" EnableCdnFallback="true">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="kendo-web" />
            </Scripts>
        </asp:ScriptManager>
        <div>
        </div>
    </form>
    <script type="text/javascript">
        console.log(window.kendo.version);
    </script>
</body>
</html>
