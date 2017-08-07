namespace DeviantartApi.Requests.Gallery.Folders
{
    public class CreateRequest : Collections.Folders.CreateRequest
    {
        protected override string FolderPath => "gallery";

        public CreateRequest(string folderName) : base(folderName)
        {
        }
    }
}
