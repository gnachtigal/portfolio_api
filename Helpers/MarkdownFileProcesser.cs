using Markdig;

namespace portfolio_api.Helpers
{
    public class MarkdownFileProcesser : IMarkdownFileProcesser
    {
        public string GetHtmlFrom(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var html = Markdown.ToHtml(markdown, pipeline);
            return html;
        }
    }

    public interface IMarkdownFileProcesser
    {
        public string GetHtmlFrom(string markdown);
    }
}
