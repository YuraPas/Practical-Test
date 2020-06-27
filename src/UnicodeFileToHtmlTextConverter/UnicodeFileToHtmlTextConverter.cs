using System.IO;
using System.Text;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter : IFileHtmlConverter
    {
        public string ConvertFileToHtml(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }

            using (var unicodeFileStream = File.OpenText(filePath))
            {
                var convertedHtml = new StringBuilder();

                string line;
                while ((line = unicodeFileStream.ReadLine()) != null)
                {
                    convertedHtml.Append(HttpUtility.HtmlEncode(line));
                    convertedHtml.Append("<br />");
                }

                return convertedHtml.ToString();
            }
        }
    }
}
