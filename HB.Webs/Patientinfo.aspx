<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientLoginId.aspx.cs" Inherits="HB.Webs.HB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>

          <input type="text" name ="PatientLoginID" id="txtid" value="" />
          <asp:Button ID="Button1" runat="server" Text="PatientInfoID" />
      </div>   
    <div id ="MyDiv">
    
    </div>
    </form>
       
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script>   
      
        $(document).ready(function () {
            $.getJSON("http://localhost:55622/Api/Patientinfo.aspx",
                function (data) {
                    var table = "<table border='1'><tr><td>PatientInfoID</td><td>Firstname</td><td>Lastname</td><td>Gender</td><td>PhoneNumber</td><td>Address</td></tr>";
                    for (var i = 0; i < data.length; i++) {
                        table = table + "<tr><td>" + data[i].PatientInfoID + "</td><td>" + data[i].Firstname + "</td><td>" + data[i].Lastname + "</td><td>" + data[i].Gender + "</td><td>" + data[i].PhoneNumber + "</td><td>" + data[i].Address + "</td></tr>";
                    }
                    table = table + "</table>";
                    $("#MyDiv").html(table);

                });
        });
        function getdata() {
            var id = document.getElementById("txtid").value;
            var url = "http://localhost:55622/Api/Patientinfo.aspx?id=" + id;
            $.getJSON(url,function(data){
                var table = "<table><tr><td>PatientLoginID</td><td>PatientName</td><td>PassWord</td></tr>";
                table = table +"<tr><td>" + data.PatientLoginID + "</td><td>" + data.PatientName + "</td><td>" + data.PassWord + "</td></tr>";
                
                table = table + "</table>";
                $("#MyDiv").html(table);
            });
            }
        
    </script>
</body>
</html>
