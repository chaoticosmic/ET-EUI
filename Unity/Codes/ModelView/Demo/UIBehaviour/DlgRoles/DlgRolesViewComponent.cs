
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_RoleLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RoleLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RoleLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_Role");
     			}
     			return this.m_ELoopScrollList_RoleLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButton == null )
     			{
		    		this.m_E_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleImage == null )
     			{
		    		this.m_E_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_DeleteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteButton == null )
     			{
		    		this.m_E_DeleteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Delete");
     			}
     			return this.m_E_DeleteButton;
     		}
     	}

		public UnityEngine.UI.Image E_DeleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteImage == null )
     			{
		    		this.m_E_DeleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Delete");
     			}
     			return this.m_E_DeleteImage;
     		}
     	}

		public UnityEngine.UI.InputField E_RoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameInputField == null )
     			{
		    		this.m_E_RoleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameImage == null )
     			{
		    		this.m_E_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_ELoopScrollList_RoleLoopHorizontalScrollRect = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.m_E_CreateRoleButton = null;
			this.m_E_CreateRoleImage = null;
			this.m_E_DeleteButton = null;
			this.m_E_DeleteImage = null;
			this.m_E_RoleNameInputField = null;
			this.m_E_RoleNameImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_RoleLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		private UnityEngine.UI.Button m_E_CreateRoleButton = null;
		private UnityEngine.UI.Image m_E_CreateRoleImage = null;
		private UnityEngine.UI.Button m_E_DeleteButton = null;
		private UnityEngine.UI.Image m_E_DeleteImage = null;
		private UnityEngine.UI.InputField m_E_RoleNameInputField = null;
		private UnityEngine.UI.Image m_E_RoleNameImage = null;
		public Transform uiTransform = null;
	}
}
