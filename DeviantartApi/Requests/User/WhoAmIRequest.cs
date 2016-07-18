using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class WhoAmIRequest : Request<Objects.User>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        public readonly HashSet<UserExpand> UserExpands = new HashSet<UserExpand>();

        public override async Task<Response<Objects.User>> ExecuteAsync()
        {
            Objects.User result;
            try
            {
                await Requester.CheckTokenAsync();
                result =
                    await
                        Requester.MakeRequestAsync<Objects.User>("user/whoami?" + "expand=" +
                                                                 string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()) +
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
