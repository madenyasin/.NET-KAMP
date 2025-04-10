using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Kitap.CustomHelpers
{
    [HtmlTargetElement("Yaz")]
    public class HaberBandi : TagHelper
    {
        public string EkrandaGozukecekMesaj { get; set; }
        public string YaziYonu { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "marquee";
            output.Attributes.Add("direction", YaziYonu);
            output.Content.AppendHtml(EkrandaGozukecekMesaj);

        }
    }
}
