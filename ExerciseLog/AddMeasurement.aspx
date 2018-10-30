<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMeasurement.aspx.cs" Inherits="ExerciseLog.AddMeasurement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Measurement</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h2>Measurements</h2>
            <div class="row">
                <asp:Label ID="dateLabel" AssociatedControlID="dateDDL" Text="Date" runat="server"></asp:Label>
                <asp:DropDownList ID="dateDDL" runat="server" 
                    OnSelectedIndexChanged="dateDDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="exerciseLabel" AssociatedControlID="exerciseDDL" Text="Exercise" runat="server"></asp:Label>
                <asp:DropDownList ID="exerciseDDL" runat="server"></asp:DropDownList>
                <asp:Label ID="Test" runat="server"></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="weightLabel" AssociatedControlID="weight" Text="Weight (lbs)" runat="server"></asp:Label>
                <asp:TextBox ID="weight" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="chestLabel" AssociatedControlID="chest" Text="Chest (in)" runat="server"></asp:Label>
                <asp:TextBox ID="chest" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="waistLabel" AssociatedControlID="waist" Text="Waist (in)" runat="server"></asp:Label>
                <asp:TextBox ID="waist" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="hipsLabel" AssociatedControlID="hips" Text="Hips (in)" runat="server"></asp:Label>
                <asp:TextBox ID="hips" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="upperArmLabel" AssociatedControlID="upperArm" Text="UpperArm (in)" runat="server"></asp:Label>
                <asp:TextBox ID="upperArm" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="thighLabel" AssociatedControlID="thigh" Text="Thigh (in)" runat="server"></asp:Label>
                <asp:TextBox ID="thigh" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="calfLabel" AssociatedControlID="calf" Text="Calf (in)" runat="server"></asp:Label>
                <asp:TextBox ID="calf" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Button ID="btnsubmit" Text="Add" OnClick="AddMeasurement_Click" runat="server"></asp:Button>
            </div>
            <asp:HyperLink ID="home" NavigateUrl="~/Default.aspx" Text="Logs" runat="server"></asp:HyperLink>

        </div>
    </form>
</body>
</html>


