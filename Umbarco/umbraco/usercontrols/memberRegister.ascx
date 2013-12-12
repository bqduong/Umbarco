<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="memberRegister.ascx.cs" Inherits="Umbarco.usercontrols.memberRegister" %>
<asp:LoginView ID="lvRegister" runat="server">
    <AnonymousTemplate>
        <asp:CreateUserWizard ID="cwMember" runat="server"
            LoginCreatedUser="False" DisableCreatedUser="True"
            OnCreatedUser="cwMember_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="cuwStep1" runat="server">
                    <ContentTemplate>
 
                        Username: <asp:TextBox ID="Username" runat="server"></asp:TextBox><br />
                        Email: <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
                        Password: <asp:TextBox ID="Password" runat="server"></asp:TextBox><br /><br />
 
                        First name: <asp:TextBox ID="FirstName" runat="server"></asp:TextBox><br />
                        Middle name: <asp:TextBox ID="MiddleName" runat="server"></asp:TextBox><br />
                        Last name: <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
 
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="cuwStep2" runat="server">
                    <ContentTemplate>
 
                        <p>User should now be created, but not approved...</p>
                        <asp:HyperLink ID="hlAuth" runat="server"></asp:HyperLink>
 
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </AnonymousTemplate>
</asp:LoginView>