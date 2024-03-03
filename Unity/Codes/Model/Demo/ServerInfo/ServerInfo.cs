

namespace ET
{
    public enum ServerStatus
    {
        Normal,
        Stop,
    }


    public class ServerInfo : Entity, IAwake
    {
        public int Status;
        public string ServerName;
    }
}
