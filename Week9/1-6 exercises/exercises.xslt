<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!-- first node match -->
  <xsl:template match="/">
    <html>
      <body>
        <h3>Ancient Sites</h3>
        <!-- second match -->
        <table>
          <xsl:apply-templates select="ancient_sites/site">
            <xsl:sort select="location" order="ascending" data-type="text" />
          </xsl:apply-templates>
        </table>
      </body>
    </html>
  </xsl:template>

  <!-- third match -->
  <xsl:template match="site">
    <tr>
      <xsl:apply-templates select="name[@language='english']"/>
      <xsl:apply-templates select="history"/>
      <xsl:apply-templates select="links/overview[@type='general']"/>
      <xsl:apply-templates select="images"/>
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
  </xsl:template>

  <xsl:template match="links/overview[@type='general']">
    <td>
      <a>
        <xsl:attribute name="href">
          <xsl:value-of select="./@url"/>
        </xsl:attribute>
        <xsl:value-of select="."/>
      </a>
    </td>
  </xsl:template>

  <xsl:template match="images">
    <td>
      <xsl:value-of select="image[@type='jpg'][position() = last()]"/>
    </td>
  </xsl:template>

</xsl:stylesheet>
