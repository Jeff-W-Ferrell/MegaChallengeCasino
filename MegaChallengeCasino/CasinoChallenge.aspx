<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasinoChallenge.aspx.cs" Inherits="MegaChallengeCasino.CasinoChallenge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="firstSlotMachineImage" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="secondSlotMachineImage" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="thirdSlotMachineImage" runat="server" Height="150px" Width="150px" />
        <h3><span class="auto-style1">Your Bet:</span>&nbsp;
            <asp:TextBox ID="yourBetTextBox" runat="server"></asp:TextBox>
        </h3>
        <p>
            <asp:Button ID="pullLeverButton" runat="server" Text="Pull the Lever!" OnClick="pullLeverButton_Click" />
        </p>
        <p>
            <asp:Label ID="winnerLoserLabel" runat="server"></asp:Label>
        </p>
        <p>
            Player&#39;s Money:
            <asp:Label ID="playersMoneyLabel" runat="server"></asp:Label>
        </p>
        <p>
            1 Cherry - x2 Your Bet
        <br/>
            2 Cherry - x3 Your Bet
        <br/>
            3 Cherry - x4 Your Bet
        <br/>
        </p>
        <p>
            3 7&#39;s - Jackpot - x100 Your Bet</p>
        <p>
            HOWEVER</p>
        <p>
            If there&#39;s even one BAR, you win nothing</p>
    </form>
</body>
</html>
