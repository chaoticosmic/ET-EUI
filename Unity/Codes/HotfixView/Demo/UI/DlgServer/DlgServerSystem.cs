
using System;
using UnityEngine;

namespace ET
{
	[FriendClass(typeof(DlgServer))]
	[FriendClass(typeof(ServerInfosComponent))]
	[FriendClass(typeof(ServerInfo))]
	public static  class DlgServerSystem
	{

		public static void RegisterUIEvent(this DlgServer self)
		{
			self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
			self.View.ELoopScrollList_ServerLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) => { self.OnScrollItemRefreshHandler(transform, index); });
		}

		public static async ETTask OnConfirmClickHandler(this DlgServer self)
		{
			bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;

			if (!isSelect)
			{
				Log.Error("请先选择区服");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRoles(self.ZoneScene());

				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
				
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

		public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
		{
			Scroll_Item_Server serverItem = self.ScrollItemServerDict[index].BindTrans(transform);
			ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			serverItem.EImage_ServerImage.color =
					info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.cyan;
			serverItem.ELabel_ServerText.SetText(info.ServerName);
			serverItem.EImage_ServerButton.AddListener(() => { self.OnSelectHandler(info.Id); });
		}

		public static void OnSelectHandler(this DlgServer self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
			Log.Debug($"当前选择的服务器 Id 是：{serverId}");
			self.View.ELoopScrollList_ServerLoopVerticalScrollRect.RefillCells();
		}

		public static void ShowWindow(this DlgServer self, Entity contextData = null)
		{
			int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			self.AddUIScrollItems(ref self.ScrollItemServerDict,count);
			self.View.ELoopScrollList_ServerLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgServer self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemServerDict);
		}


	}
}
