<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!-- first node match -->
  <xsl:template match="/">
    <html>
      <head>
        <meta charset="utf-8"></meta>
        <title>Ancient Sites</title>
        <!-- css styles -->
        <link rel="stylesheet" type="text/css" href="styles.css"></link>
        <style type="text/css">
          /*
          * styles.css - general css styles
          */

          body {
          width: 900px;
          margin: auto;
          background: #fff;
          font-size: 15px;
          font-family: "Times New Roman", Georgia, Serif;
          }

          header {
          margin: 10px;
          border-bottom: 1px solid #000;
          }

          table {
          margin: 20px;
          border-top: 1px solid #555;
          border-left: 1px solid #555;
          border-collapse: collapse;
          }

          table caption {
          margin: 20px;
          text-align: center;
          }

          th, td {
          padding: 10px;
          border-right: 1px solid #555;
          border-bottom: 1px solid #555;
          }

        </style>
      </head>
      <body>
        <header>
          <h1>Ancient Sites</h1>
          <p>A catalogue of Ancient Sites</p>
        </header>

        <table summary="Tourist sites">
          <caption>Tourist sites</caption>
          <thead>
            <tr>
              <th>Site</th>
              <th>Year Built</th>
              <th>Century</th>
              <th>Years Extant</th>
              <th>Size</th>
              <th>Overview</th>
              <th>Images</th>
              <th>Example</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            <xsl:apply-templates select="ancient_sites/site">
              <xsl:sort select="location" order="ascending" data-type="text" />
            </xsl:apply-templates>
          </tbody>
        </table>
        <table summary="Historical sites">
          <caption>Historical sites</caption>
          <thead>
            <tr>
              <th>Site</th>
              <th>Year Built</th>
              <th>Century</th>
              <th>Years Extant</th>
              <th>Size</th>
              <th>Overview</th>
              <th>Images</th>
              <th>Example</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            <xsl:apply-templates select="ancient_sites/site[./history/year &lt; 1975]">
              <xsl:sort select="year" order="descending" data-type="number" />
            </xsl:apply-templates>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>

  <!-- third match -->
  <xsl:template match="site">
    <tr>
      <xsl:apply-templates select="name[@language='english']"/>
      <xsl:apply-templates select="history"/>
      <xsl:choose>
        <xsl:when test="dimensions">
          <xsl:apply-templates select="dimensions"/>
        </xsl:when>
        <xsl:otherwise>
          <td>
            N/A
          </td>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:apply-templates select="links/overview[@type='general']"/>
      <xsl:apply-templates select="images"/>
      <xsl:apply-templates select="notes/note[@type='intro']"/>
    </tr>
  </xsl:template>

  <!-- fourth match -->
  <xsl:template match="name[@language='english']">
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

  <xsl:template match="history">
    <td>
      <xsl:value-of select="year"/>
      <xsl:text>&#160;</xsl:text>
      <xsl:value-of select="year/@era"/>
    </td>

    <td>
      <xsl:value-of select="./century"/>
      <xsl:text>&#160;century</xsl:text>
    </td>

    <td>
      <xsl:choose>
        <xsl:when test="year[@range='end']">
          <xsl:value-of select="year[@range='end'] - year[@range='start']"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="year[@range='start'] + 2017"/>
        </xsl:otherwise>
      </xsl:choose>
    </td>
  </xsl:template>

  <xsl:template match="dimensions">
    <td>
      approx. <xsl:value-of select="format-number(./height * ./height, '0.#')"/> ft<sup>2</sup>
    </td>
  </xsl:template>

  <xsl:template match="links/overview[@type='general']">
    <td>
      <a>
        <xsl:attribute name="href">
          <xsl:value-of select="./@url"/>
        </xsl:attribute>
        <xsl:value-of select="translate(., 'w', 'W')"/>
      </a>
    </td>
  </xsl:template>

  <xsl:template match="images">
    <td>
      <xsl:value-of select="count(./image)"/>
    </td>
    <td>
      <a href="https://cdn.pixabay.com/photo/2017/07/19/10/52/statue-of-liberty-2518744_960_720.jpg">
        <xsl:value-of select="image[@type='jpg'][position() = last()]"/>
      </a>
    </td>
  </xsl:template>

  <xsl:template match="notes/note[@type='intro']">
    <td>
      <xsl:value-of select="substring(.,1,50)"/>
      ...
    </td>
  </xsl:template>

</xsl:stylesheet>