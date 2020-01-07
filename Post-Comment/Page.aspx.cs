using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Post_Comment
{
    public partial class Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlPosts = $"https://jsonplaceholder.typicode.com/posts";
            string jsonPosts;

            string urlComments = $"https://jsonplaceholder.typicode.com/comments";
            string jsonComments;

            HttpWebRequest requestPosts = WebRequest.Create(urlPosts.ToString()) as HttpWebRequest;
            using (HttpWebResponse responsePosts = requestPosts.GetResponse() as HttpWebResponse)
            {
                StreamReader readerPosts = new StreamReader(responsePosts.GetResponseStream());
                jsonPosts = readerPosts.ReadToEnd();
            }
            List<Posts> resultPosts = JsonConvert.DeserializeObject<List<Posts>>(jsonPosts);

            HttpWebRequest requestComments = WebRequest.Create(urlComments.ToString()) as HttpWebRequest;
            using (HttpWebResponse responseComments = requestComments.GetResponse() as HttpWebResponse)
            {
                StreamReader readerComments = new StreamReader(responseComments.GetResponseStream());
                jsonComments = readerComments.ReadToEnd();
            }
            List<Comments> resultcomments = JsonConvert.DeserializeObject<List<Comments>>(jsonComments);

            postTitle.InnerHtml = resultPosts[0].Title;
            postBody.InnerHtml = resultPosts[0].Body;
            commentName.InnerHtml = resultcomments[0].Name;
            commentBody.InnerHtml = resultcomments[0].Body;

            H1.InnerHtml = resultPosts[1].Title;
            p1.InnerHtml = resultPosts[1].Body;
            H2.InnerHtml = resultcomments[1].Name;
            p2.InnerHtml = resultcomments[1].Body;
        }
    }
}