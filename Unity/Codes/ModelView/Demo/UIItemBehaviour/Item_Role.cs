
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Role : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Role BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button EImage_RoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EImage_RoleButton == null )
     				{
		    			this.m_EImage_RoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImage_Role");
     				}
     				return this.m_EImage_RoleButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImage_Role");
     			}
     		}
     	}

		public UnityEngine.UI.Image EImage_RoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EImage_RoleImage == null )
     				{
		    			this.m_EImage_RoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Role");
     				}
     				return this.m_EImage_RoleImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Role");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_RoleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_RoleText == null )
     				{
		    			this.m_ELabel_RoleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Role");
     				}
     				return this.m_ELabel_RoleText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Role");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_RoleButton = null;
			this.m_EImage_RoleImage = null;
			this.m_ELabel_RoleText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_EImage_RoleButton = null;
		private UnityEngine.UI.Image m_EImage_RoleImage = null;
		private UnityEngine.UI.Text m_ELabel_RoleText = null;
		public Transform uiTransform = null;
	}
}
