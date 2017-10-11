<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dairy.aspx.cs" Inherits="Dairy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1 class="page-header">Dairy</h1>

          
     <div class="row placeholders">
              <% foreach (var dairy in DairyProductsData) { %>
                <div class="col-xs-6 col-sm-3 placeholder">
                    <a href="javascript:void(0)" class="lnk-vegetable-details" data-id="<%= dairy.ID %>">
                        <% if (string.IsNullOrEmpty(dairy.ImageName)) { %>
                         <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } else { %>
                         <img src="<%= Page.ResolveUrl("~/Images/dairy/" + dairy.ImageName) %>"  width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } %>
                    </a>
                  <h4><%= dairy.Name %></h4>
                  <span class="text-muted">Something else</span>
                </div>          
                <%  }   %> 
          </div>
          

          

</asp:Content>

