namespace ApplicationLayer.DTDs
{
    public class ServiceResponce
    {
        public bool Flag { get; }
        public string Message { get; }

        public ServiceResponce(bool flag, string message)
        {
            Flag = flag;
            Message = message;
        }

        public void Deconstruct(out bool flag, out string message)
        {
            flag = Flag;
            message = Message;
        }
    }
}