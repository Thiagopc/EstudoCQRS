namespace estudo.service.Model
{
    public class OutBox
    {
        public OutBox() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }
    }
}
