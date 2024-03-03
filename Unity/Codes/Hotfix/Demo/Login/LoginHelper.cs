using System;

using UnityEngine;

namespace ET
{
    [FriendClass(typeof(ServerInfosComponent))]
    [FriendClass(typeof(RoleInfosComponent))]
    [FriendClass(typeof(AccountInfoComponent))]
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {

            A2C_LoginAccount a2CLoginAccount = null;
            Session accountSession = null;

            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password       = MD5Helper.StringMD5(password);
                a2CLoginAccount = (A2C_LoginAccount) await accountSession.Call(new C2A_LoginAccount() { AccountName = account, Password = password }); 
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2CLoginAccount.Error;
            }
            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().Token = a2CLoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId= a2CLoginAccount.AccountId;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos a2C_GetServerInfos = null;

            try
            {
                a2C_GetServerInfos = (A2C_GetServerInfos)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetServerInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2C_GetServerInfos.Error != ErrorCode.ERR_Success)
            {
                return a2C_GetServerInfos.Error;
            }

            foreach (var serverInfoProto in a2C_GetServerInfos.ServerInfosList)
            {
                ServerInfo serverInfo = zoneScene.GetComponent<ServerInfosComponent>().AddChild<ServerInfo>();
                serverInfo.FromMessage(serverInfoProto);
                zoneScene.GetComponent<ServerInfosComponent>().Add(serverInfo);
            }

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene zoneScene, string name)
        {
            A2C_CreateRole a2C_CreateRole = null;

            try
            {
                a2C_CreateRole = (A2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,

                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2C_CreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_CreateRole.Error.ToString());
                return a2C_CreateRole.Error;
            }

            RoleInfo roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
            roleInfo.FromMessage(a2C_CreateRole.RoleInfo);
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(roleInfo);


            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRole(Scene zoneScene)
        {
            A2C_DeleteRole a2CDeleteRole = null;
            try
            {
                a2CDeleteRole = (A2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_DeleteRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    RoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
                
                if (a2CDeleteRole.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(a2CDeleteRole.Error.ToString());
                    return a2CDeleteRole.Error;
                }

                int index = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.FindIndex(r => r.Id == a2CDeleteRole.DeletedRoleId);
                zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.RemoveAt(index);

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                
            }
            
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRoles a2CGetRoles = null;

            try
            {
                a2CGetRoles = (A2C_GetRoles)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRoles()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CGetRoles.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CGetRoles.Error.ToString());
                return a2CGetRoles.Error;
            }
            
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Clear();
            foreach (RoleInfoProto infoProto in a2CGetRoles.RoleInfo)
            {
                RoleInfo roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
                roleInfo.FromMessage(infoProto);
                zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(roleInfo);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2CGetRealmKey = null;
            try
            {
                a2CGetRealmKey = (A2C_GetRealmKey)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            
            if (a2CGetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CGetRealmKey.Error.ToString());
                return a2CGetRealmKey.Error;
            }

            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2CGetRealmKey.RealmAddress;
            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2CGetRealmKey.RealmKey;
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;

            R2C_LoginRealm r2CLoginRealm;

            Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));
            try
            {
                r2CLoginRealm = (R2C_LoginRealm)await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RealmTokenKey = zoneScene.GetComponent<AccountInfoComponent>().RealmKey,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            session?.Dispose();

            if (r2CLoginRealm.Error != ErrorCode.ERR_Success)
            {
                return r2CLoginRealm.Error;
            }
            
            Log.Warning($"GateAddrsss : {r2CLoginRealm.GateAddress}");
            Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLoginRealm.GateAddress));
            gateSession.AddComponent<PingComponent>();
            zoneScene.GetComponent<SessionComponent>().Session = gateSession;
            
            // 2. 开始连接Gate
            long currentRoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId;
            G2C_LoginGameGate g2CLoginGameGate = null;
            try
            {
                long accountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId;
                g2CLoginGameGate = (G2C_LoginGameGate)await gateSession.Call(new C2G_LoginGameGate()
                {
                    Account = accountId, Key = r2CLoginRealm.GateSessionKey, RoleId = currentRoleId,
                });
            }
            catch (Exception e)
            {
             Log.Error(e.ToString());
             zoneScene.GetComponent<SessionComponent>().Session.Dispose();
             return ErrorCode.ERR_NetWorkError;
            }

            if (g2CLoginGameGate.Error != ErrorCode.ERR_Success)
            {
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return g2CLoginGameGate.Error;
            }
            Log.Debug("登录Gate成功!");
            
            //3.角色正式进入游戏逻辑服
            G2C_EnterGame g2CEnterGame = null;
            try
            {
                g2CEnterGame = (G2C_EnterGame)await gateSession.Call(new C2G_EnterGame() { });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2CEnterGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2CEnterGame.Error.ToString());
                return g2CEnterGame.Error;
            }

            Log.Debug("角色进入游戏");
            zoneScene.GetComponent<PlayerComponent>().MyId = g2CEnterGame.MyId;
            return ErrorCode.ERR_Success;
        }
    }
}