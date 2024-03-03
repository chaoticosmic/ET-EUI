using System;

namespace ET
{
    public class G2M_RequestEnterGameStateHandler : AMActorLocationRpcHandler<Unit, G2M_RequestEnterGameState, M2G_RequestEnterGameStae>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestEnterGameState request, M2G_RequestEnterGameStae response, Action reply)
        {
            reply();

            await ETTask.CompletedTask;
        }
    }
}