using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type='text/javascript'>");
            //sb.Append("alert('alert');");

            //sb.Append("if (parent.parent.name == 'BodyAndMenu'){");
            //sb.Append("parent.parent.document.all('LeftFrame').cols='162,*';");
            //sb.Append("window.parent.location = 'www.google.com.pk';");

            //sb.Append("}");
            //sb.Append("else{");
            //sb.Append("parent.document.all('LeftFrame').cols='162,*';");
            //sb.Append("window.location = 'www.google.com';");
            //sb.Append("}");

            //sb.Append("</script>");
            //HttpUtility.JavaScriptStringEncode(sb.ToString());
            //string scriptEscaping = sb.ToString();
            //System.Web.HttpContext.Current.Response.Write(scriptEscaping);
            //System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();
            GenrateFieldData();

        }

        public void GenrateFieldData()
        {
            string fieldValuesHtml = "";
            string field = "loannumber";
            string value = "123456789";
            fieldValuesHtml += "<table>";
            for (int i = 0; i < 10; i++)
            {
                fieldValuesHtml += "<tr><td style=\"text-align:right;\"> <b>" + field + ":</b></td><td>" + value + "</td></tr>";
            }
            fieldValuesHtml += "</table>";

            //System.Web.HttpContext.Current.Response.Write(HttpUtility.HtmlEncode(fieldValuesHtml));
            //System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();

            //return HttpUtility.HtmlEncode(fieldValuesHtml);

        }
    }
}