<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <strong>Reference</strong>: <asp:Label ID="labelReference" runat="server" /><br />
    <strong>Amount (&euro;)</strong>: 19,99 &euro; <br />
    <strong>Customer e-mail address</strong>: test@example.com
    
    <br /><br />
    
    <asp:Button ID="StartPayment" runat="server" Text="Start Payment" 
            onclick="StartPayment_Click" style="width: 126px" />
    
    </div>
    </form>
</body>
</html>
