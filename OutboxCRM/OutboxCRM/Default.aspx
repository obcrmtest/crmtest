<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OutboxCRM.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>test</title>
</head>
<body>
    
        <form id="form1" runat="server">
    
        <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
        <script>
            var uri = 'api/phone';

            function formatItem(item) {
                return item.PhoneNumber;
            }

            function find() {
                var id = $('#accountnumber').val(); 
                $.getJSON(uri + '/' + id)
                    .done(function (data) {
                        $('#phones').text('-');
                        $.each(data, function (key, item) {
                            $('<li>', { text: formatItem(item) }).appendTo($('#phones'));
                        });
                    })
                    .fail(function (jqXHR, textStatus, err) {
                        $('#phones').text('Error: ' + err);
                    });
            }
        </script>

        <div>
            <h2>Search by accountnumber (js)</h2>
            <input type="text" id="accountnumber" />
            <input type="button" value="Search" onclick="find();" />
            <ul id="phones" />
        </div>

        <div>
            <h2>Search by accountnumber (cs)</h2>
            <asp:TextBox ID="acouuntnumbercs" runat="server"></asp:TextBox>
            <asp:Button ID="SearchCS" runat="server" Text="Search" OnClick="SearchCS_Click" />
            <br />
            <asp:Label ID="phonescs" runat="server" Text="..."></asp:Label>
        </div>

        </form>

</body>
</html>
