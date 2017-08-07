namespace DeviantartApi.Requests.Gallery.Folders
{
    public class CreateRequest : Collections.Folders.CreateRequest
    {
        protected override string FolderPath { get; set; } = "gallery";

        public CreateRequest(string folderName) : base(folderName)
        {
        }
    }
}
