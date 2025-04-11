using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kitap.CustomHelpers
{
    public static class Genislet
    {
        public static IHtmlContent HaberBandi(this IHtmlHelper content, string mesaj)
        {
            string strHtml = "<marquee>" + mesaj + "</marquee>";

            return new HtmlString(strHtml);
        }

        public static IHtmlContent ListeYazdir<T>(this IHtmlHelper content, IEnumerable<T> liste)
        {
            var listStr = "<ul>";
            foreach (var item in liste)
            {
                listStr += $"<li>{item}</li>";
            }
            listStr += "</ul>";


            return new HtmlString(listStr);

        }
    }
}
