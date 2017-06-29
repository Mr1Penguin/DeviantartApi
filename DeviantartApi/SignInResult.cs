namespace DeviantartApi
{
    public struct SignInResult
    {
        public string Code { get; set; }

        public bool IsSignInError { get; set; }

        public string SignInErrorText { get; set; }

        public string SignInErrorShortText { get; set; }
    }
}
