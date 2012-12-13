<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testCalendar.aspx.cs" Inherits="Apple.Web.Admin.testCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="js/calendar/themes/aqua.css" />
    <link rel="stylesheet" href="js/calendar/themes/layouts/small.css" />
    
    <script type="text/javascript" src="js/calendar/utils/zapatec.js"></script>
    <script type="text/javascript" src="js/calendar/src/calendar.js"></script>
    <script type="text/javascript" src="js/calendar/lang/calendar-en.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtNewsDate" runat="server" ReadOnly="True"></asp:TextBox>
                                <button style="width: 35px;" id="btnShowCalendar" type="button">
                                    ...</button>

                                <script type="text/javascript">
                            //<![CDATA 
                                Zapatec.Calendar.setup({
                                firstDay          : 1,
			                    showOthers        : true,
			                    range             : [2007.01, 2999.12],
			                    electric          : false,
			                    displayArea       : 'none',  
                                inputField        : 'txtNewsDate',
			                    button            : 'btnShowCalendar',
			                    ifFormat          : '%d.%m.%Y',
			                    daFormat          : '%d %b %y'
			                  });
			                //]]>
                                </script>
    </div>
    </form>
</body>
</html>
