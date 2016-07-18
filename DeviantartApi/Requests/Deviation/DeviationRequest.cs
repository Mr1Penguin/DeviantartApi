using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class DeviationRequest : Request<Objects.Deviation>
    {

        public enum UserExpand
        {
            Watch
        }

        public enum DeviationExpand
        {
            Challenge
        }

        public readonly HashSet<UserExpand> UserExpands = new HashSet<UserExpand>();
        public readonly HashSet<DeviationExpand> DeviationExpands = new HashSet<DeviationExpand>();

        private string _deviationID;

        public DeviationRequest(string deviationID)
        {
            _deviationID = deviationID;
        }

        public override async Task<Response<Objects.Deviation>> ExecuteAsync()
        {
            Objects.Deviation result;
            try
            {
                await Requester.CheckTokenAsync();
                result =
                    await
                        Requester.MakeRequestAsync<Objects.Deviation>($"deviation/{_deviationID}?" + "expand=" + 
                                                                      string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()) + "," + //legal on 2016-07-18
                                                                      string.Join(",", DeviationExpands.Select(x => "deviation." + x.ToString().ToLower()).ToList()) + 
                                                                      $"&access_token={Requester.AccessToken}");
            }
            catch (Exception e)
            {
                return new Response<Objects.Deviation>(true, e.Message);
            }
            return new Response<Objects.Deviation>(result);
        }
    }
}
