using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class WhoAmIRequest : Request<Objects.User>
    {
        public enum Expand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        public HashSet<Expand> Expands = new HashSet<Expand>();

        public override async Task<Response<Objects.User>> ExecuteAsync()
        {
            Objects.User result;
            try
            {
                await Requester.CheckTokenAsync();
                result =
                    await
                        Requester.MakeRequestAsync<Objects.User>(
                            "https://www.deviantart.com/api/v1/oauth2/user/whoami?" +
                            "expand=" + string.Join(",", Expands.Select(x => x.ToString().ToLower()).ToList()) +
                            $"&access_token={Requester.AccessToken}");
            }
            catch (Exception e)
            {
                return new Response<Objects.User>(true, e.Message);
            }
            return new Response<Objects.User>(result);
        }
    }
}
