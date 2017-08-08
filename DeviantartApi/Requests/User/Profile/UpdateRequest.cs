using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Profile
{
    public class UpdateRequest : Request<Objects.PostResponse>
    {
        public enum LevelOfArtist
        {
            Student = 1,
            Hobbyist = 2,
            Professional = 3
        }

        public enum SpecialtyOfArtsit
        {
            ArisanCratfts = 1,
            DesignAndInterfaces = 2,
            DigitalArt = 3,
            FilmAndAnimation = 4,
            Literature = 5,
            Photography = 6,
            TraditionalArt = 7,
            Other = 8,
            Varied = 9
        }

        [Parameter("user_is_artist")]
        [EnumToNum]
        public bool UserIsArtist { get; set; }

        [Parameter("artist_level")]
        [EnumToNum]
        public LevelOfArtist ArtistLevel { get; set; } = LevelOfArtist.Student;

        [Parameter("artist_specialty")]
        [EnumToNum]
        public SpecialtyOfArtsit ArtistSpecialty { get; set; } = SpecialtyOfArtsit.ArisanCratfts;

        [Parameter("real_name")]
        public string RealName { get; set; }

        [Parameter("tagline")]
        public string TagLine { get; set; }

        [Parameter("countryid")]
        public int CountryId { get; set; } // no way for enum be here

        [Parameter("website")]
        public string Website { get; set; }

        [Parameter("bio")]
        public string Bio { get; set; }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => UserIsArtist);
            if (UserIsArtist)
            {
                values.AddParameter(() => ArtistLevel);
                values.AddParameter(() => ArtistSpecialty);
            }
            values.AddParameter(() => RealName);
            values.AddParameter(() => TagLine);
            values.AddParameter(() => CountryId);
            values.AddParameter(() => Website);
            values.AddParameter(() => Bio);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("user/profile/update", values, cancellationToken);
        }
    }
}
