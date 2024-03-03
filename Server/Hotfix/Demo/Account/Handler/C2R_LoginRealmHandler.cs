using System;

namespace ET
{
    public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {
            if(session.DomainScene().SceneType != SceneType.Realm)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            Scene domainScene = session.DomainScene();

            if(session.GetComponent<SessionLockingComponent>() != null )
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
            }

            string token = domainScene.GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.RealmTokenKey)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }
            
            domainScene.GetComponent<TokenComponent>().Remove(request.AccountId);

            using (session.AddComponent<SessionLockingComponent>())
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginRealm, request.AccountId))
            {
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(domainScene.Zone, request.AccountId);

                G2R_GetLoginGateKey g2RGetLoginGateKey =
                        (G2R_GetLoginGateKey)await MessageHelper.CallActor(gateConfig.InstanceId, new R2G_GetLoginGateKey() { AccountId = request.AccountId, });

                if (g2RGetLoginGateKey.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(g2RGetLoginGateKey.Error.ToString());
                    response.Error = g2RGetLoginGateKey.Error;
                    reply();
                    return;
                }

                response.GateAddress = gateConfig.OuterIPPort.ToString();
                response.GateSessionKey = g2RGetLoginGateKey.GateSessionKey;
                reply();
                
                session?.Disconnect().Coroutine();
            }
        }
    }
}