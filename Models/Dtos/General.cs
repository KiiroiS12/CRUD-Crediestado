namespace Models.Dtos
{
    public class General
    {
        public string? title { get; set; }
        public int idError { get; set; } = 0;
        public bool error { get; set; } = false;
        public string? message { get; set; }
        public object data { get; set; } = new { };
    }
}
