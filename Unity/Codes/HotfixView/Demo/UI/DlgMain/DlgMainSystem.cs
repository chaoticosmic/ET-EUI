using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgMain))]
	public static  class DlgMainSystem
	{

		public static void RegisterUIEvent(this DlgMain self)
		{
		 
		}

		public static void ShowWindow(this DlgMain self, Entity contextData = null)
		{
			
		}

		public static async ETTask Refresh(this DlgMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
			
			//self.View.E_RoleLevelText.SetText($"Lv.{numericComponent.GetAsInt((int)NumericType.)}");
		}
		 

	}
}
