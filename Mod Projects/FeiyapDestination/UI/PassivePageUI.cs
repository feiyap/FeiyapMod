using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace FeiyapDestination
{
    /// <summary>
    /// 被动悬停预览（PassivePreview → PassiveUnlock）内左键翻页。
    /// 该界面移开鼠标即消失，故不使用翻页按钮。
    /// </summary>
    public static class PassivePageUI
    {
        private const string HintLine = "点击鼠标左键翻到下一页";

        private static int _page;
        private static TextMeshProUGUI _boundDesc;
        private static PassiveUnlock _boundUnlock;

        /// <summary>清理角色界面上误挂的旧翻页/描述物体。</summary>
        public static void CleanupCharStatLeftovers(CharStatV4 ui)
        {
            if (ui == null)
            {
                return;
            }
            Transform[] all = ui.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < all.Length; i++)
            {
                Transform t = all[i];
                if (t == null)
                {
                    continue;
                }
                string n = t.name;
                if (n == "FeiyapDestination_PassiveDes"
                    || n == "FeiyapDestination_PassivePager"
                    || n == "FeiyapDestination_UnlockPager")
                {
                    Object.Destroy(t.gameObject);
                }
            }
        }

        public static void BindUnlock(PassiveUnlock unlock)
        {
            if (unlock == null || unlock.Desc == null)
            {
                return;
            }
            // 清掉旧版翻页按钮残留
            DestroyPagerResidue(unlock);
            _boundUnlock = unlock;
            _boundDesc = unlock.Desc;
            _page = 0;
            Refresh();
        }

        public static void ClearUnlock()
        {
            _boundDesc = null;
            _boundUnlock = null;
        }

        /// <summary>转职后若悬停描述仍打开，按新职业重绘当前页（置灰状态）。</summary>
        public static void RefreshIfBound()
        {
            if (_boundDesc == null || _boundUnlock == null || _boundUnlock.Destoryed)
            {
                return;
            }
            Refresh();
        }

        public static void TickInput()
        {
            if (_boundDesc == null || _boundUnlock == null)
            {
                return;
            }
            // Unity 已销毁对象
            if (_boundUnlock.Destoryed)
            {
                ClearUnlock();
                return;
            }
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            List<string> pages = PassivePages.BuildPages();
            if (pages == null || pages.Count == 0)
            {
                return;
            }
            _page = (_page + 1) % pages.Count;
            Refresh();
        }

        private static void DestroyPagerResidue(PassiveUnlock unlock)
        {
            if (unlock == null)
            {
                return;
            }
            Transform[] all = unlock.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < all.Length; i++)
            {
                Transform t = all[i];
                if (t != null && t.name == "FeiyapDestination_UnlockPager")
                {
                    Object.Destroy(t.gameObject);
                }
            }
        }

        private static void Refresh()
        {
            List<string> pages = PassivePages.BuildPages();
            if (pages == null || pages.Count == 0 || _boundDesc == null)
            {
                return;
            }
            if (_page < 0)
            {
                _page = 0;
            }
            if (_page >= pages.Count)
            {
                _page = pages.Count - 1;
            }
            // 描述正文 + 底行翻页提示（含页码）
            _boundDesc.text = pages[_page] + "\n\n" + HintLine + "（" + (_page + 1) + "/" + pages.Count + "）";
            _boundDesc.ForceMeshUpdate();
        }
    }

    [HarmonyPatch(typeof(PassiveUnlock))]
    public static class PassiveUnlock_Page_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Init")]
        public static void Init_Postfix(PassiveUnlock __instance, Character info, bool ConfirmOn)
        {
            try
            {
                if (info == null || info.KeyData != FeiyapKeys.Destination)
                {
                    PassivePageUI.ClearUnlock();
                    return;
                }
                PassivePageUI.BindUnlock(__instance);
            }
            catch
            {
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Update_Postfix(PassiveUnlock __instance)
        {
            try
            {
                PassivePageUI.TickInput();
            }
            catch
            {
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("SelfDestroy")]
        public static void SelfDestroy_Postfix()
        {
            PassivePageUI.ClearUnlock();
        }
    }
}
