namespace Todo.Api.Model
{
    public class Navbar
    {
        public int Id { get; set; }
        public string NameOption { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ImageClass { get; set; }
        public string Activeli { get; set; }
        public bool Status { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public bool RighSide { get; set; }
        public string Tooltip { get; set; }

        private bool _antiForgeryKey = true;
        public bool AntiForgeryKey
        {
            get { return _antiForgeryKey; }
            set { _antiForgeryKey = value; }
        }
    }
}
