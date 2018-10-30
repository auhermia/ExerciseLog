<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExerciseLog.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    <title>Exercise Log</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h2>Exercise Log</h2>
            <h4>Because you want to justify eating a whole pizza</h4>
            <div class="row">
                <asp:Label ID="datelabel" AssociatedControlID="date" Text="Date: " runat="server"></asp:Label>
                <asp:TextBox ID="date" type="date" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="exerciseLabel" AssociatedControlID="exercise" Text="Exercise: " runat="server"></asp:Label>
                <asp:TextBox ID="exercise" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="timeLabel" AssociatedControlID="time" Text="Time: " runat="server"></asp:Label>
                <asp:TextBox ID="time" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Button ID="submit" Text="Add" OnClick="Submit_Click" runat="server" />
            </div>
            <div id="results">
                <asp:GridView ID="resultsTable" runat="server" AutoGenerateColumns="false" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="Date" ReadOnly="true" HeaderText="Date" ItemStyle-Width="10em" />
                        <asp:BoundField DataField="Exercise" ReadOnly="true" HeaderText="Exercise" ItemStyle-Width="10em" />
                        <asp:BoundField DataField="TimeSpent" ReadOnly="true" HeaderText="Time Spent" ItemStyle-Width="10em"/>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HyperLink ID="addMeasurement" NavigateUrl="~/AddMeasurement.aspx" Text="Add Measurement" runat="server"></asp:HyperLink>

        </div>
    </form>
    <%--<asp:Button ID="create" Text="Add Measurement" navigateUrl="~/WebForm2.aspx" OnClick="AddMeasurement_Click" runat="server" />--%>
</body>
</html>
