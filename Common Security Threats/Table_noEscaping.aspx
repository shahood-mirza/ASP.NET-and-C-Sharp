﻿<% @Page Language="C#" AutoEventWireup="true" CodeFile="Table_noEscaping.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Non-Escaping HTML</title>
</head>
<body runat="server">  

    <form id="table_form" action="Table_noEscaping.aspx" runat="server">    
       
        <div>
            <%
                List<student> temp_list = dataAccess.Read();

                System.Web.HttpContext.Current.Response.Write("<table border= 1 style= width:50% >");
                System.Web.HttpContext.Current.Response.Write("<tr><th>ID</th><th>Name</th><th>GPA</th></tr>");

                for (int i = 0; i < temp_list.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                        temp_list[i].Id, temp_list[i].Name, temp_list[i].Gpa));
                }

                System.Web.HttpContext.Current.Response.Write("</table>");
                
                %>

        </div>       

    </form>         
            
</body>
</html>