<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Timer Example Page</title>
    <link href="DivStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="100" />
        <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            <h2> Live Statistics</h2>
            <asp:Table runat="server" CellPadding="5" GridLines="horizontal" HorizontalAlign="Center">
               <asp:TableRow>
                 <asp:TableCell>Joueur</asp:TableCell>
                 <asp:TableCell><%: joueurA %></asp:TableCell>
                 <asp:TableCell><%:joueurB%></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Taux de Service Gagnant</asp:TableCell>
                 <asp:TableCell><%: (statsA.TauxServiceGagnant*100).ToString("F2") %>% </asp:TableCell>
                 <asp:TableCell><%: (statsB.TauxServiceGagnant*100).ToString("F2") %>%</asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Taux Coup Droit Gagnant</asp:TableCell>
                 <asp:TableCell><%:(statsA.TauxCoupDroitGagnant*100).ToString("F2") %>%</asp:TableCell>
                 <asp:TableCell><%:(statsB.TauxCoupDroitGagnant*100).ToString("F2") %>%</asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Taux Revers Gagnant</asp:TableCell>
                 <asp:TableCell><%:(statsA.TauxReversGagnant*100).ToString("F2")%>%</asp:TableCell>
                 <asp:TableCell><%:(statsB.TauxReversGagnant*100).ToString("F2")%>%</asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Nombre de Services Gagnants</asp:TableCell>
                 <asp:TableCell><%:statsA.NbServiceGagnant%></asp:TableCell>
                 <asp:TableCell><%:statsB.NbServiceGagnant %></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Nombre de Coups Droits Gagnants</asp:TableCell>
                 <asp:TableCell><%:statsA.NbDroitGagnant %></asp:TableCell>
                 <asp:TableCell><%:statsB.NbDroitGagnant %></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Nombre de Revers Gagnants</asp:TableCell>
                 <asp:TableCell><%:statsA.NbReversGagnant%></asp:TableCell>
                 <asp:TableCell><%:statsB.NbReversGagnant %></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Nombre de Services </asp:TableCell>
                 <asp:TableCell><%:statsA.NbService%></asp:TableCell>
                 <asp:TableCell><%:statsB.NbService%></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Nombre de Coups Droits </asp:TableCell>
                 <asp:TableCell><%:statsA.NbDroit%></asp:TableCell>
                 <asp:TableCell><%:statsB.NbDroit%></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                 <asp:TableCell>Nombre de Revers </asp:TableCell>
                 <asp:TableCell><%:statsA.NbRevers %></asp:TableCell>
                 <asp:TableCell><%:statsB.NbRevers %></asp:TableCell>
               </asp:TableRow>
            </asp:Table>


              <h2> Score </h2>
            <asp:Table runat="server" CellPadding="5" GridLines="horizontal" HorizontalAlign="Center">
               <asp:TableRow>
                 <asp:TableCell>Joueur</asp:TableCell>
                 <asp:TableCell><%: joueurA %></asp:TableCell>
                 <asp:TableCell><%:joueurB%></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Score</asp:TableCell>
                 <asp:TableCell><%:scoreA %></asp:TableCell>
                 <asp:TableCell><%: scoreB%></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Score du set 1</asp:TableCell>
                 <asp:TableCell><%:scoreAPdtSet %></asp:TableCell>
                 <asp:TableCell><%: scoreBPdtSet%></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Score du set 2</asp:TableCell>
                 <asp:TableCell><%:scoreAPdtSet2 %></asp:TableCell>
                 <asp:TableCell><%: scoreBPdtSet2%></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                 <asp:TableCell>Score du set 3</asp:TableCell>
                 <asp:TableCell><%:scoreAPdtSet3 %></asp:TableCell>
                 <asp:TableCell><%: scoreBPdtSet3%></asp:TableCell>
               </asp:TableRow>
            </asp:Table>
            iteration <%: test %>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
