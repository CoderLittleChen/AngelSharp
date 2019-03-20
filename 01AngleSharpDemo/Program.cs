using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace _01AngleSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //拿到网页的html源代码
            string html = GetHtml("http://www.cnblogs.com","UTF-8");
            //创建一个html解析器    创建
            var parser = new HtmlParser();
            //使用解析器解析文档
            IHtmlDocument document = parser.ParseDocument(html);
            IEnumerable<IElement> titleElementList = document.All.Where(m => m.ClassName == "titlelnk");
            foreach (var item in titleElementList) 
            {
                //Console.WriteLine(item.GetAttribute("href")); 
                //输出链接中的文本内容
                Console.WriteLine(item.InnerHtml);
            }
            //Console.WriteLine(document.DocumentElement.TextContent);


            //Console.WriteLine(html);
            Console.ReadKey();

        }


        /// <summary>
        /// 根据网页url和网页的编码获取该网页的html代码
        /// </summary>
        /// <param name="url">网页链接</param>
        /// <param name="encoder">网页编码</param>
        /// <returns></returns>
        static  string  GetHtml(string url,string encoder)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;


            //WebRequest request = WebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            //Stream resStream = response.GetResponseStream();
            //StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding(encoder));
            //string SourceCode = sr.ReadToEnd();
            //resStream.Close();
            //sr.Close();
            //return SourceCode;

        }



    }
}
