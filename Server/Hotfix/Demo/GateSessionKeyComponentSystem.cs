namespace ET
{
    [FriendClass(typeof(GateSessionKeyComponent))]
    public static class GateSessionKeyComponentSystem
    {
        public static void Add(this GateSessionKeyComponent self, long accountId, string key)
        {
            self.sessionKey.Add(accountId, key);
            self.TimeoutRemoveKey(accountId).Coroutine();
        }

        public static string Get(this GateSessionKeyComponent self, long key)
        {
            string account = null;
            self.sessionKey.TryGetValue(key, out account);
            return account;
        }

        public static void Remove(this GateSessionKeyComponent self, long key)
        {
            self.sessionKey.Remove(key);
        }

        private static async ETTask TimeoutRemoveKey(this GateSessionKeyComponent self, long key)
        {
            await TimerComponent.Instance.WaitAsync(20000);
            self.sessionKey.Remove(key);
        }
    }
}