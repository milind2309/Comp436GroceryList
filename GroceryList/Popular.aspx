<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Popular.aspx.cs" Inherits="Popular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Fruits</h1>
    <div class="row placeholders">
              <% foreach (var fruit in FruitsData) { %>
                <div class="col-xs-6 col-sm-3 placeholder">
                    <a href="javascript:void(0)" class="lnk-fruit-details" data-id="<%= fruit.ID %>">
                        <% if (string.IsNullOrEmpty(fruit.ImageName)) { %>
                         <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } else { %>
                         <img src="<%= Page.ResolveUrl("~/Images/fruits/" + fruit.ImageName) %>"  width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } %>
                    </a>
                  <h4><%= fruit.Name %></h4>
                  <span class="text-muted">Something else</span>
                </div>          
                <%  }   %> 
    </div>

    <h1 class="page-header">Vegetable</h1>

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

