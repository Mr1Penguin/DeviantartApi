namespace DeviantartApi
{
    public struct LoginResult
    {
        public string RefreshToken { get; set; }

        public bool IsLoginError { get; set; }

        public string LoginErrorText { get; set; }

        public string LoginErrorShortText { get; set; }
    }
}
