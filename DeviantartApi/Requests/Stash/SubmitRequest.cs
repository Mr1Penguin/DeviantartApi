using DeviantartApi.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    public class SubmitRequest : Request<Objects.SubmitResult>
    {
        public enum Error
        {
            ClientError = 1,
            ValidationError = 2
        }

        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("artist_comments")]
        public string ArtistComments { get; set; }

        [Parameter("tags")]
        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        [Parameter("original_url")]
        public string OriginalUrl { get; set; }

        [Parameter("is_dirty")]
        public bool IsDirty { get; set; }

        public byte[] Data { get; set; }

        [Parameter("itemid")]
        public int ItemId { get; set; }

        [Parameter("stack")]
        public string Stack { get; set; }

        [Parameter("stackid")]
        public int StackId { get; set; }

        public override async Task<Response<Objects.SubmitResult>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => ArtistComments);
            values.AddHashSetParameter(() => Tags);
            values.AddParameter(() => OriginalUrl);
            values.AddParameter(() => IsDirty);
            values.AddParameter(() => ItemId);
            values.AddParameter(() => Stack);
            values.AddParameter(() => StackId);
            Objects.SubmitResult result;
            try
            {
                await Requester.CheckTokenAsync();
                values.Add("access_token", Requester.AccessToken);
                cancellationToken.ThrowIfCancellationRequested();

                string boundary = "deviapi---" + DateTime.Now.Ticks.ToString("x");

                var request = WebRequest.CreateHttp("https://www.deviantart.com/api/v1/oauth2/stash/submit");
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.Method = "POST";
                request.UserAgent = "DeviantartApi";

                using (var stream = await request.GetRequestStreamAsync())
                using (var sw = new StreamWriter(stream))
                {
                    foreach (var pair in values)
                    {
                        if (pair.Value == null) continue;
                        sw.WriteLine("--" + boundary);
                        sw.WriteLine($"Content-Disposition: form-data; name=\"{pair.Key}\"");
                        sw.WriteLine();
                        sw.WriteLine(pair.Value);
                    }

                    sw.WriteLine("--" + boundary);
                    sw.WriteLine("Content-Disposition: form-data; name=\"file\"; filename=\"file\"");
                    sw.WriteLine();
                    await sw.FlushAsync();

                    stream.Write(Data, 0, Data.Length);
                    await stream.FlushAsync();

                    sw.WriteLine();
                    sw.WriteLine("--" + boundary + "--");
                    await sw.FlushAsync();
                }

                using (var response = await request.GetResponseAsync())
                using (var responseStream = response.GetResponseStream())
                using (var sr = new StreamReader(responseStream))
                {
                    string json = await sr.ReadToEndAsync();
                    result = JsonConvert.DeserializeObject<Objects.SubmitResult>(json);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                return new Response<Objects.SubmitResult>(true, e.Message);
            }
            return new Response<Objects.SubmitResult>(result);
        }
    }
}

//it stays here until request not tested
/*0000: --------------------------486c99da311ac2d4
002c: Content-Disposition: form-data; name="title"
005a:
005c: My great stash item&artist_comments=This is a great image&keywor
009c: ds=test image
00ab: --------------------------486c99da311ac2d4
00d7: Content-Disposition: form-data; name="access_token"
010c:
010e: Alph4num3r1ct0k3nv4lu3
0126: --------------------------486c99da311ac2d4
0152: Content-Disposition: form-data; name="test"; filename="VLOhVm2Rm
0192: 0Y.jpg"
019b: Content-Type: image/jpeg
01b5:
=> Send SSL data, 5 bytes (0x5)
0000: ...(}
=> Send data, 10341 bytes (0x2865)
0000: ......JFIF.....H.H.....C........................................
0040: ............................C...................................
0080: ........................................."......................
00c0: ...................F...........................!..1AQa."#2Rq...B
0100: br...$3....Sc.....Cst..................
=> Send SSL data, 5 bytes (0x5)
0000: .....
=> Send data, 245 bytes (0xf5)
0000:
0002: --------------------------5cb69de8086a95d7
002e: Content-Disposition: form-data; name="tags[0]"
005e:
0060: abc
0065: --------------------------5cb69de8086a95d7
0091: Content-Disposition: form-data; name="tags[1]"
00c0:
00c2: bva
00c7: --------------------------5cb69de8086a95d7--
<= Recv SSL data, 5 bytes (0x5)
0000: ....g
<= Recv header, 27 bytes (0x1b)
*/
