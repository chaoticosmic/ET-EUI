

using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(ServerInfo))]
    [ComponentOf(typeof(Scene))]
    public class ServerInfosComponent : Entity, IAwake, IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();
        public int CurrentServerId = 0;
    }
}
