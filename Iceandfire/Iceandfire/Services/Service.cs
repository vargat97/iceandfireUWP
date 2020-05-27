using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    public class Service
    {

        protected readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/");

        /*
         * Represent the response HTTP header's links. 
         * Actuelly API doesn't support PrevLink
         */
        protected string FirstLink;
        protected string NextLink;
        protected string LastLink;

        public string GetNextLink()
        {
            return this.NextLink;
        }
        public string GetFirstLink()
        {
            return this.FirstLink;
        }
        public string GetLastLink()
        {
            return this.LastLink;
        }

        /*
         * Generic method, which the helps of HttpClient class makes
         * an async GET request, then deserialize the result.
         */
        protected async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);

                var header = response.Headers;

                string headerValue = null;
                // we can find the Links in the http header
                if (header.Contains("link"))
                {
                    headerValue = header.GetValues("link").FirstOrDefault();
                }
                // fill the links
                this.LinksFromHeader(headerValue);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }

        }

        // https://gist.github.com/pimbrouwers/8f78e318ccfefff18f518a483997be29
        private void LinksFromHeader(string linkheaderStr)
        {
            if (!string.IsNullOrWhiteSpace(linkheaderStr))
            {
                string[] linkStrings = linkheaderStr.Split(',');

                if (linkStrings != null && linkStrings.Any())
                {
                    foreach (string linkString in linkStrings)
                    {
                        var relMatch = Regex.Match(linkString, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                        var linkMatch = Regex.Match(linkString, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                        if (relMatch.Success && linkMatch.Success)
                        {
                            string rel = relMatch.Value.ToUpper();
                            string link = linkMatch.Value;

                            switch (rel)
                            {
                                case "FIRST":
                                    this.FirstLink = link;
                                    break;
                                case "NEXT":
                                    this.NextLink = link;
                                    break;
                                case "LAST":
                                    this.LastLink = link;
                                    break;
                            }
                        }
                    }
                }
            }

        }

    }
}

