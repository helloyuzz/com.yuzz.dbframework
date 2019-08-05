using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class SmartWeb
{
    public static string QueryString(HttpSessionState Session, string key)
    {
        if (Session[key] == null)
        {
            return "";
        }
        return Session[key].ToString();
    }

    public static int QueryInt(HttpSessionState Session, string key)
    {
        int value = -1;
        if (Session[key] != null)
        {
            int.TryParse(Session[key].ToString(), out value);
        }
        return value;
    }

    public static string QueryString(HttpRequest Request, string key)
    {
        string value = Request[key];
        if (string.IsNullOrEmpty(value))
        {
            return "";
        }
        return value;
    }

    public static int QueryInt(HttpRequest Request, string key)
    {
        int value = -1;
        if (Request[key] != null)
        {
            int.TryParse(Request[key].ToString(), out value);
        }
        return value;
    }

    public static int QueryIntCookie(string key)
    {
        int value = -1;
        if (HttpContext.Current.Request.Cookies[key] != null)
        {
            int.TryParse(HttpContext.Current.Request.Cookies[key].Value, out value);
        }
        return value;
    }

    public static string BuildRegCode(string prefix, int length)
    {
        string code = prefix + Guid.NewGuid().ToString();
        code = code.Replace("0", "K").ToUpper();
        code = code.Replace("O", "K");
        code = code.Replace("-", "");
        code = code.Substring(0, length);
        code = code.Insert(4, "-");
        code = code.Insert(9, "-");
        code = code.Insert(14, "-");
        return code;
    }
}
