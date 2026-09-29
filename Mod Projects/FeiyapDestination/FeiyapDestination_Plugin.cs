using System;
using System.Reflection;
using ChronoArkMod.Plugin;
using HarmonyLib;
using UnityEngine;

namespace FeiyapDestination
{
    [PluginConfig("FeiyapDestination", "FeiyapDestination", "0.1.1")]
    public class FeiyapDestination_Plugin : ChronoArkPlugin
    {
        private Harmony harmony;

        public override void Dispose()
        {
            if (this.harmony != null)
            {
                this.harmony.UnpatchSelf();
                this.harmony = null;
            }
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            // 只补丁本程序集，并逐类型处理，避免单个失败导致整模组无法加载时难排查
            Assembly asm = Assembly.GetExecutingAssembly();
            Debug.Log("[FeiyapDestination] PatchAll from " + asm.FullName);
            foreach (Type type in asm.GetTypes())
            {
                try
                {
                    this.harmony.CreateClassProcessor(type).Patch();
                }
                catch (Exception ex)
                {
                    Debug.LogError("[FeiyapDestination] Harmony patch failed on " + type.FullName + ": " + ex);
                }
            }
        }
    }
}
