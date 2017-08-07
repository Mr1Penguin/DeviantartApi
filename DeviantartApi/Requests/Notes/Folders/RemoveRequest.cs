namespace DeviantartApi.Requests.Notes.Folders
{
    public class RemoveRequest : Collections.Folders.Remove.FolderRequest
    {
        protected override string FolderPath => "notes";

        public RemoveRequest(string folderId) : base(folderId)
        {
        }
    }
}
