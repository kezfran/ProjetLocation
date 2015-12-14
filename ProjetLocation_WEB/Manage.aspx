<%@ Page Title="Manage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjetLocation_WEB.Contact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <form id="form1" runat="server">
        <div style="padding: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="442px" Width="1166px">

                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Voiture">
                    <HeaderTemplate>
                        Voiture
                    </HeaderTemplate>
                   <ContentTemplate>
                       <asp:GridView ID="voitGridView" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Id: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Marque: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtMarque" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Modèle: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtModele" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Année: "></asp:Label>
                        &nbsp;&nbsp;<asp:TextBox ID="txtAnnee" runat="server"></asp:TextBox>
                       <br />
                       <br />
                        <asp:Button ID="ajoutVoiture" runat="server" Text="Ajouter" OnClick="ajoutVoiture_Click" />
                        &nbsp;<asp:Button ID="modVoiture" runat="server" Text="Modifier" OnClick="modVoiture_Click" />
                        &nbsp;<asp:Button ID="delVoiture" runat="server" Text="Supprimer" OnClick="delVoiture_Click" />
                   </ContentTemplate> 
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Membre">
                
                    <HeaderTemplate>
                        Membre
                    </HeaderTemplate>
                
                    <ContentTemplate>
                        <asp:GridView ID="membreGridView" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Id: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txteID" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Nom: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Téléphone: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Adresse: "></asp:Label>
                        &nbsp;<asp:TextBox ID="txtAdresse" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Email: "></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Nb Location: "></asp:Label>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="ajoutEmploye" runat="server" Text="Ajouter" OnClick="ajoutEmploye_Click" />
                        &nbsp;<asp:Button ID="modEmploye" runat="server" Text="Modifier" OnClick="modEmploye_Click" />
                        &nbsp;<asp:Button ID="delEmploye" runat="server" Text="Supprimer" OnClick="delEmploye_Click" />
                    </ContentTemplate>
                
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Réservation">
                
                    <ContentTemplate>
                        <asp:GridView ID="reservGridView" runat="server">
                        </asp:GridView>
                    </ContentTemplate>
                
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Location">
                
                    <HeaderTemplate>
                        Location
                    </HeaderTemplate>
                
                    <ContentTemplate>
                        <asp:GridView ID="locGridView" runat="server">
                        </asp:GridView>
                    </ContentTemplate>
                
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Facture">
                
                    <ContentTemplate>
                        <asp:GridView ID="facGridView" runat="server">
                        </asp:GridView>
                    </ContentTemplate>
                
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>
            <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click" />
        </div>
        </form>
</asp:Content>
