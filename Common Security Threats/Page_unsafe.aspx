<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page_safe.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unsafe Page</title>
</head>
<body runat ="server">
    <%
        if (Request.QueryString["act"] == "create")
        {
            dataAccess.CreateUnsafe(Request["name_create"], Request["GPA_create"]);
        }
         %>

    <form id="create_form" action="Page_safe.aspx?act=create" runat="server" method="post">
    <div>     
        <table>
            <tr><th>Name</th><th>GPA</th></tr>
            <tr>                
                <td><input type="text" name="name_create"/></td>
                <td><input type="text" name="GPA_create"/></td>                
                <td><input type="submit" formaction="Page_safe.aspx?act=create" value="Create"/></td>
            </tr>
        </table>
        <br/>
        <label>This page is unsafe</label>    
     </div>
    </form>
</body>
</html>