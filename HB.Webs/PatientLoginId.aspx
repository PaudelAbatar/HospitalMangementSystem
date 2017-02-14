<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientLoginId.aspx.cs" Inherits="HB.Webs.HB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #btngetPatientLogin {
            width: 142px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <input type="text" name="name" id="txtid" value="" />
            <input type="button" id="btngetPatientLogin" onclick="GetData()" name="name" value="GetID" />
        </div>
        <div id="MyDiv">
        </div>
    </form>
    <form id="myform" action="http://localhost:55622/api/PatientLogins" method="post">
        <div>
           <table>
            <tr>
                <td>PatientLoginId</td>
                <td>
                    <input type="text" name="PatientLoginId" value="" />
                </td>
            </tr>
            <tr>
                <td>PatientName</td>
                <td>
                    <input type="text" name="PatientName" value="" />
                </td>
            </tr>
            <tr>
                 <td>PassWord</td>
                <td>
                    <input type="text" name="PassWord" value="" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" name="name" onclick="PostData();" value="Save Data" />
    <input type="button" name="name1" value="Delete" style="width: 104px" /></td>
            </tr>

        </table>
</div>
    </form>
    &nbsp;<script src="Scripts/jquery-3.1.1.min.js"></script>

    <script>

        $(document).ready(function () {
            $.getJSON("http://localhost:55622/api/PatientLogins",
                function (data) {
                    var table = "<table border='1'><tr><td>PatientLoginID</td><td>PatientName</td><td>PassWord</td></tr>";
                    for (var i = 0; i < data.length; i++) {
                        table = table + "<tr><td>" + data[i].PatientLoginID + "</td><td>" + data[i].PatientName + "</td><td>" + data[i].PassWord + "</td></tr>";
                    }
                    table = table + "</table>";
                    $("#MyDiv").html(table);

                });

        });
        function GetData() {
            var id = document.getElementById("txtid").value;
            var url = "http://localhost:55622/api/PatientLogins?id=" + id;
            $.getJSON(url, function (data) {
                var table = "<table><tr><td>PatientLoginID</td><td>PatientName</td><td>PassWord</td></tr>";
                table = table + "<tr><td>" + data.PatientLoginID + "</td><td>" + data.PatientName + "</td><td>" + data.PassWord + "</td></tr>";

                table = table + "</table>";
                $("#MyDiv").html(table);
            });
     
        }
        function DeleteData() {
            var id = document.getElementById("txtid").value;
            var url = "http://localhost:55622/api/PatientLogins?id=" + id;
            $.getJSON(url, function (data) {
                var table = "<table><tr><td>PatientLoginID</td><td>PatientName</td><td>PassWord</td></tr>";
                table = table + "<tr><td>" + data.PatientLoginID + "</td><td>" + data.PatientName + "</td><td>" + data.PassWord + "</td></tr>";

                table = table + "</table>";
                $("#MyDiv").html(table);
            });

        }
            function PostData()
            {
                $.post("http://localhost:55622/api/PatientLogins", $("#myform").serialize(), function (msg)
                {
                    alert(msg)
            
                });
            }
           
        
    </script>
</body>
</html>
