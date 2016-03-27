using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    class YoutubeSearch
    {
        internal class Search
        {
            [STAThread]
            public async Task<List<String>> Run(string searchTerm)
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDhFIZosaBiPZybhmG0FLWIxsZsf_adu0E",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = searchTerm;
                searchListRequest.MaxResults = 20;

                var searchListResponse = await searchListRequest.ExecuteAsync().ConfigureAwait(true);


                List<string> videos = new List<string>();

                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            videos.Add(String.Format("{0} |{1}", searchResult.Snippet.Title, searchResult.Id.VideoId));
                            break;
                    } 
                }
                return (videos);
            }
        }
    }
}
