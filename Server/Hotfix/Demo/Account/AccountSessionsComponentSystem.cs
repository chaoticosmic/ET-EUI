using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    public class AccountSessionsComponentDestroySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDictionary.Clear();
        }
    }

    [FriendClass(typeof(AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if(!self.AccountSessionDictionary.ContainsKey(accountId))
            {
                return 0;
            }
            return self.AccountSessionDictionary[accountId];
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long instanceId) 
        {
            if (self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary[accountId] = instanceId;
            }
            else
            {
                self.AccountSessionDictionary.Add(accountId, instanceId);
            }
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if(self.AccountSessionDictionary.ContainsKey((accountId)))
            {
                self.AccountSessionDictionary.Remove((accountId));
            }
        }
    }
}
