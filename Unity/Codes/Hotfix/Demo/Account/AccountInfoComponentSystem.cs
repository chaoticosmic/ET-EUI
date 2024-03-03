using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{

    public class AccountInfoComponentDestroySystem : DestroySystem<AccountInfoComponent>
    {
        public override void Destroy(AccountInfoComponent self)
        {
            self.Token = string.Empty;
            self.AccountId = 0;
        }
    }
    public static class AccountInfoComponentSystem
    {
        public static void Test()
        {
            Vector3 t = new Vector3();
        }
    }
}
