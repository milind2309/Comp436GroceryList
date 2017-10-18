﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

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
                </div>          
                <%  }   %> 
    </div>
    <h1 class="page-header">Vegetable</h1>
    <div class="row placeholders">
              <% foreach (var veg in VegetablesData) { %>
                <div class="col-xs-6 col-sm-3 placeholder">
                    <a href="javascript:void(0)" class="lnk-fruit-details" data-id="<%= veg.ID %>">
                        <% if (string.IsNullOrEmpty(veg.ImageName)) { %>
                         <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } else { %>
                         <img src="<%= Page.ResolveUrl("~/Images/vegetables/" + veg.ImageName) %>"  width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                        <% } %>
                    </a>
                  <h4><%= veg.Name %></h4>
                </div>          
                <%  }   %> 
    </div>
    <h1 class="page-header">Dairy</h1>
</asp:Content>