using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class PublishRequest : Request<Objects.PublishResponse>
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
            rOriginal = 0,
            r400px = 1,
            r600px = 2,
            r800px = 3,
            r900px = 4,
            r1024px = 5,
            r1280px = 6,
            r1600px = 7
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

        [Parameter("is_mature")]
        public bool IsMature { get; set; }

        [Parameter("mature_level")]
        public LevelOFMature MatureLevel { get; set; }

        [Parameter("mature_classification")]
        public HashSet<ClassificationOfMature> MatureClassification { get; set; } = new HashSet<ClassificationOfMature>();

        [Parameter("agree_submission")]
        public bool AgreeSubmission { get; set; }

        [Parameter("agree_tos")]
        public bool AgreeTos { get; set; }

        [Parameter("catpath")]
        public string CatPath { get; set; }

        [Parameter("feature")]
        public bool? Feature { get; set; }

        [Parameter("allow_comments")]
        public bool? AllowComments { get; set; }

        [Parameter("request_critique")]
        public bool? RequestCritique { get; set; }

        [Parameter("display_resolution")]
        [EnumToNum]
        public Resolution DisplayResolution { get; set; } = Resolution.rOriginal;

        [Parameter("sharing")]
        public SharingOption Sharing { get; set; } = SharingOption.Allow;

        [Parameter("creative_commons")]
        public bool? LicenseCreativeCommons { get; set; }

        [Parameter("comercial")]
        public bool? LicenseComercial { get; set; }

        [Parameter("modify")]
        public LicenseModifyOption LicenseModify { get; set; } = LicenseModifyOption.No;

        [Parameter("galleryids")]
        public HashSet<string> GalleryIds { get; set; } = new HashSet<string>();

        [Parameter("allow_free_download")]
        public bool? AllowFreeDownload { get; set; }

        [Parameter("idd_watermark")]
        public bool? AddWatermark { get; set; }

        [Parameter("itemid")]
        public long ItemId { get; set; }

        public PublishRequest(bool isMature, bool agreeSubmission, bool agreeTos, long itemId)
        {
            IsMature = isMature;
            AgreeSubmission = agreeSubmission;
            AgreeTos = agreeTos;
            ItemId = itemId;
        }

        public override Task<Response<Objects.PublishResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => IsMature);
            if (IsMature)
            {
                values.AddParameter(() => MatureLevel);
                values.AddHashSetParameter(() => MatureClassification);
            }
            values.AddParameter(() => AgreeSubmission);
            values.AddParameter(() => AgreeTos);
            values.AddParameter(() => CatPath);
            values.AddParameter(() => Feature);
            values.AddParameter(() => AllowComments);
            values.AddParameter(() => RequestCritique);
            values.AddParameter(() => DisplayResolution);
            values.AddParameter(() => Sharing);
            values.AddParameter(() => LicenseCreativeCommons);
            values.AddParameter(() => LicenseComercial);
            values.AddParameter(() => LicenseModify);
            values.AddHashSetParameter(() => GalleryIds);
            values.AddParameter(() => AllowFreeDownload);
            values.AddParameter(() => AddWatermark);
            values.AddParameter(() => ItemId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("stash/publish", values, cancellationToken);
        }
    }
}
