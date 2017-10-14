<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">     
        <xsl:for-each select="dairy">
          <div class="form-group">
            <label class="control-label col-sm-3">Name:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="name"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Serving Size:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="servingsize"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3" for="email">Calories:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="calories"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Fat:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="fat"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Cholesterol:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="cholesterol"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Sodium:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="sodium"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Potassium:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="potassium"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Carbs:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="carbs"/>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-3">Protein:</label>
            <div class="col-sm-9">
              <p class="form-control-static">
                <xsl:value-of select="protein"/>
              </p>
            </div>
          </div>
        </xsl:for-each>      
    </xsl:template>
</xsl:stylesheet>