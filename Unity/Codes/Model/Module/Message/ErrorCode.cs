namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_NetWorkError               = 200002; //网络错误
        public const int ERR_LoginInfoIsNull            = 200003; //登录信息错误
        public const int ERR_AccountNameFormError       = 200004; //登录账号格式错误
        public const int ERR_PasswordFormError          = 200005; //登录密码格式错误
        public const int ERR_AccountInBlackListError    = 200006; //账号处于黑名单中
        public const int ERR_LoginPasswordError         = 200007; //登录密码错误
        public const int ERR_RequestRepeatedly          = 200008; //请求重复
        public const int ERR_TokenError                 = 200009; //令牌Token错误
        public const int ERR_RoleNameIsNull             = 200010; //游戏角色名称为空
        public const int ERR_RoleNameSame               = 200011; //游戏角色名称已存在
        public const int ERR_RoleNotExist               = 200012; //游戏角色不存在
        public const int ERR_RequestSceneTypeError      = 200013; //请求场景错误
        public const int ERR_ConnectGateKeyError        = 200014; //网关令牌错误
        public const int ERR_OtherAccountLogin          = 200015; //账号在其他地方登录
        public const int ERR_SessionPlayerError         = 200016; //玩家会话错误
        public const int ERR_NonePlayerError            = 200017; //没有玩家错误
        public const int ERR_SessionStateError          = 200018; //会话状态错误
        public const int ERR_ReEnterGame2               = 200019; //二次登录错误2
        public const int ERR_ReEnterGame                = 200020; //二次登录错误
        public const int ERR_EnterGame                  = 200021; //进入游戏错误
        
        
        

    }
}