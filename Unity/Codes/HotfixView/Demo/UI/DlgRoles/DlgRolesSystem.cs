using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	
	[FriendClass(typeof(RoleInfo))]
	[FriendClass(typeof(RoleInfosComponent))]
	[FriendClass(typeof(DlgRoles))]
	public static  class DlgRolesSystem
	{

		public static void RegisterUIEvent(this DlgRoles self)
		{
		 self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
		 self.View.E_CreateRoleButton.AddListenerAsync((() => { return self.OnCreateRoleHandler();}));
		 self.View.E_DeleteButton.AddListenerAsync(() => { return self.OnDeleteRoleHandler(); });
		 self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) => { self.OnScrollItemRefreshHandler(transform, index);});
		 
		}

		public static void ShowWindow(this DlgRoles self, Entity contextData = null)
		{
			self.RefreshRoleItems();
		}
		public static void RefreshRoleItems(this DlgRoles self)
		{
			int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
			self.AddUIScrollItems(ref self.ScrollRolesDict, count);
			self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.SetVisible(true, count);
		}

		public static void OnRoleItemClickHandler(this DlgRoles self, long roleId)
		{
			self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleId;
			self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.RefillCells();
		}
		public static void OnScrollItemRefreshHandler(this DlgRoles self, Transform transform, int index)
		{
			Scroll_Item_Role roleItem = self.ScrollRolesDict[index].BindTrans(transform);
			RoleInfo info = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
			roleItem.EImage_RoleImage.color =
					info.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId? Color.red : Color.cyan;
			roleItem.ELabel_RoleText.SetText(info.Name);
			roleItem.EImage_RoleButton.AddListener(() => { self.OnSelectHandler(info.Id); });
		}
		
		public static void OnSelectHandler(this DlgRoles self, long roleId)
		{
			self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleId;
			Log.Debug($"当前选择的角色 Id 是：{roleId}:");
			self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.RefillCells();
		}

		public static async ETTask OnConfirmClickHandler(this DlgRoles self)
		{
			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("请选择角色");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());

				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}

				errorCode = await LoginHelper.EnterGame(self.ZoneScene());

				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Roles);

			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			
			
			await ETTask.CompletedTask;

		}
		public static async ETTask OnCreateRoleHandler(this DlgRoles self)
		{
			string roleName = self.View.E_RoleNameInputField.text;

			if (string.IsNullOrEmpty(roleName))
			{
				Log.Error("name is null");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), roleName);

				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				self.RefreshRoleItems();
				
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				
			}
		}

		public static async ETTask OnDeleteRoleHandler(this DlgRoles self)
		{
			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("请选择需要删除的角色");
				return;
			}   

			try
			{
				int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				self.RefreshRoleItems();
				
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}



	}
}
