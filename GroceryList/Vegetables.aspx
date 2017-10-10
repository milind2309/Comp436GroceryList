<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Vegetables.aspx.cs" Inherits="Vegetables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1 class="page-header">vegetables</h1>

          <div class="row placeholders">
              <% foreach (var vegetable in VegetablesData) { %>
                <div class="col-xs-6 col-sm-3 placeholder">
                    <a href="javascript:void(0)" class="lnk-vegetable-details" data-id="<%= vegetable.ID %>">
                        <% if (string.IsNullOrEmpty(vegetable.ImageName)) { %>
                         <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } else { %>
                         <img src="<%= Page.ResolveUrl("~/Images/vegetables/" + vegetable.ImageName) %>"  width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } %>
                    </a>
                  <h4><%= vegetable.Name %></h4>
                  <span class="text-muted">Something else</span>
                </div>          
                <%  }   %> 
          </div>

</asp:Content>

