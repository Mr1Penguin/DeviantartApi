using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class PublishRequest : Request<Objects.PublishResult>
    {
        public enum Error
        {
            MustAcceptDaSubmissionPolicy = 0,
            MustAcceptDaTermsOfService = 1,
            CategoryNotFound = 2,
            InvalidCategoryOrNotAllowed = 3,
            InvalidLicenseConfiguration = 4,
            InvalidDisplayResolutionConfiguration = 5,
            PublicationFailed = 6,
            DeviationNotFound = 7,
            PreviewImageRequired = 8,
            DeviationAlreadyPublished = 9
        }

        public enum LevelOFMature
        {
            Strict,
            Moderate
        }

        public enum ClassificationOfMature
        {
            Nudity,
            Sexual,
            Gore,
            Language,
            Ideology
        }

        public enum Resolution
        {
            rOriginal,
            r400px,
            r600px,
            r800px,
            r900px,
            r1024px,
            r1280px,
            r1600px
        }

        public enum SharingOption
        {
            Allow,
            HideShareButtons,
            HideAndMembersOnly
        }

        public enum LicenseModifyOption
        {
            Yes,
            No,
            Share
        }

        public bool IsMature { get; set; }
        public LevelOFMature MatureLevel { get; set; }
        public ClassificationOfMature MatureClassification { get; set; }
        public bool AgreeSubmission { get; set; }
        public bool AgreeTos { get; set; }
        public string CatPath { get; set; }
        public bool Feature { get; set; }
        public bool AllowComments { get; set; }
        public bool RequestCritique { get; set; }
        public Resolution DisplayResolution { get; set; }
        public SharingOption Sharing { get; set; }
        public bool LicenseCreativeCommons { get; set; }
        public bool LicenseComercial { get; set; }
        public LicenseModifyOption LicenseModify { get; set; }
        public HashSet<string> GalleryIds { get; set; } = new HashSet<string>();
        public bool AllowFreeDownload { get; set; }
        public bool AddWatermark { get; set; }
        public string ItemId { get; set; }

        public override async Task<Response<Objects.PublishResult>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            ulong i;
            values.Add("is_mature", IsMature.ToString().ToLower());
            values.Add("mature_level", MatureLevel.ToString().ToLower());
            values.Add("mature_classification", MatureClassification.ToString().ToLower());
            values.Add("agree_submission", AgreeSubmission.ToString().ToLower());
            values.Add("agree_tos", AgreeTos.ToString().ToLower());
            values.Add("catpath", CatPath);
            values.Add("feature", Feature.ToString().ToLower());
            values.Add("aloow_comments", AllowComments.ToString().ToLower());
            values.Add("request_critique", RequestCritique.ToString().ToLower());
            values.Add("display_resolution", DisplayResolution.ToString().ToLower());
            values.Add("sharing", Sharing.ToString().ToLower());
            values.Add("creative_commons", LicenseCreativeCommons.ToString().ToLower());
            values.Add("comercial", LicenseComercial.ToString().ToLower());
            values.Add("modify", LicenseModify.ToString().ToLower());
            i = 0;
            foreach(var val in GalleryIds)
                values.Add($"galleryids[{i++}]", val);
            values.Add("allow_free_download", AllowFreeDownload.ToString().ToLower());
            values.Add("add_watermark", AddWatermark.ToString().ToLower());
            values.Add("itemid", ItemId);
            return await ExecuteDefaultPostAsync("stash/publish", values);
        }
    }
}
