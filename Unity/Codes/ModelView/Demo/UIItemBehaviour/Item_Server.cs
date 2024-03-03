
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Server : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Server BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button EImage_ServerButton
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
     				if( this.m_EImage_ServerButton == null )
     				{
		    			this.m_EImage_ServerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImage_Server");
     				}
     				return this.m_EImage_ServerButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImage_Server");
     			}
     		}
     	}

		public UnityEngine.UI.Image EImage_ServerImage
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
     				if( this.m_EImage_ServerImage == null )
     				{
		    			this.m_EImage_ServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Server");
     				}
     				return this.m_EImage_ServerImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Server");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_ServerText
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
     				if( this.m_ELabel_ServerText == null )
     				{
		    			this.m_ELabel_ServerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Server");
     				}
     				return this.m_ELabel_ServerText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Server");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_ServerButton = null;
			this.m_EImage_ServerImage = null;
			this.m_ELabel_ServerText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_EImage_ServerButton = null;
		private UnityEngine.UI.Image m_EImage_ServerImage = null;
		private UnityEngine.UI.Text m_ELabel_ServerText = null;
		public Transform uiTransform = null;
	}
}
