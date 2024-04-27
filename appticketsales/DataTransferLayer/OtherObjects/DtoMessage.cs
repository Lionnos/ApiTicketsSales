namespace DataTransferLayer.OtherObjects
{
    public class DtoMessage
    {
        public List<string> listMessage { get; set; }
        public string type { get; set; }

        public DtoMessage()
        {
            listMessage = new List<string>();
            //type = "error";
        }

        public bool ExistsMessage()
        {
            return listMessage.Count > 0;
        }

        public void AddMessage(string message)
        {
            listMessage.Add(message);
        }

        public void Success()
        {
            type = "success";
        }

        public void Warning()
        {
            type = "warning";
        }

        public void Error()
        {
            type = "error";
        }

        public void Exception()
        {
            type = "exception";
        }
    }
}
