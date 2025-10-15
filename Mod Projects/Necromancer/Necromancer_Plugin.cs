using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using ChronoArkMod.ModData;
using HarmonyLib;
using Dialogical;
using UnityEngine.Events;
using Spine.Unity;

namespace Necromancer
{
    [PluginConfig("Necromancer_Plugin", "Necromancer", "1.0.0")]
    public class Necromancer_Plugin: ChronoArkPlugin
    {
        public override void Dispose()
        {
            this.harmony.UnpatchSelf();
        }
        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }
        public override void OnModLoaded()
        {
            base.OnModLoaded();
            this.OnModSettingUpdate();
        }
        public override void OnModSettingUpdate()
        {
            base.OnModSettingUpdate();
            ModInfo modInfo = ModManager.getModInfo(base.ModId);
        }
        private Harmony harmony;

        [HarmonyPatch(typeof(BuffObject))]
        public class BuffObjectPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            public static void UpdatePatch(BuffObject __instance)
            {
                if (__instance.MyBuff != null && __instance.MyBuff.BuffData.Key == "B_Necromancer_3")
                {
                    __instance.StackText.text = __instance.MyBuff.StackInfo[0].RemainTime.ToString();
                }
            }
        }

        [HarmonyPatch(typeof(StageSystem))]
        public static class StageSystem_Plugin
        {

            [HarmonyPostfix]
            [HarmonyPatch("StageStart")]
            public static void StageStartPostfix(StageSystem __instance)
            {
                MapChar_Necromancer.Init(__instance);
            }
        }


        public class NecromancerDef : ModDefinition
        {
        }
        public class NecromancerCharacter : CustomCharacterGDE<Necromancer_Plugin.NecromancerDef>
        {
            public override ModGDEInfo.LoadingType GetLoadingType()
            {
                return 0;
            }
            public override string Key()
            {
                return "Necromancer";
            }
            public override void SetValue()
            {
                base.Dialogue_NomalGiftTalk = ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/非喜爱礼物.asset");
                base.Dialogue_GoodGiftTalks = new List<string>
                {
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/knife.asset"),
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/collar.asset"),
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/SFnovel.asset"),
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/vodka.asset")
                };
                base.Dialogue_FriendShipLVTalks = new List<string>
                {
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/level1.asset"),
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/friendship2.asset"),
                    ModManager.getModInfo("Necromancer").assetInfo.ObjectFromAsset<DialogueTree>("necromancerunityassetbundle", "Assets/ModAssets/ModDialogues/level3.asset")
                };
            }
        }
    }
    public class CharCtrl_Necromancer : MonoBehaviour
    {
        string dialogueTreePath;
        public void TalkNecromancer()
        {
            switch (PlayData.TSavedata.StageNum)
            {
                case 0 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map1.asset");

                        break;
                }
                case 1 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map1.asset");
                        break ;
                }
                case 2 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map2.asset");
                        break;
                }
                case 3 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map2.asset");
                        break ;
                }
                case 4 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map3.asset");
                        break;
                }
                case 5 :
                {
                        dialogueTreePath = ModManager.getModInfo("Necromancer")
        .assetInfo.ObjectFromAsset<DialogueTree>(
            "necromancerunityassetbundle",
            "Assets/ModAssets/ModDialogues/map3.asset");

                        break;
                }
                default:
                {
                        return;
                 }
            }

            DialogueTree tree = AddressableLoadManager.LoadAsyncCompletion<DialogueTree>(
                dialogueTreePath,
                AddressableLoadManager.ManageType.None
            );

            Dialogue dialogue = gameObject.GetComponent<Dialogue>();
            if (dialogue == null)
            {
                dialogue = gameObject.AddComponent<Dialogue>();
            }

            dialogue.tree = tree;
            dialogue.Activate();
            Debug.Log(dialogue.tree.ToString());

        }
    }

    public class MapChar_Necromancer
    {
        public static void Init(StageSystem stageSystem)
        {
            MapTile mapTile = null;
            MapTile[,] mapObject = stageSystem.Map.MapObject;
            int upperBound = mapObject.GetUpperBound(0);
            int upperBound2 = mapObject.GetUpperBound(1);
            System.Random random = new System.Random();
            for (int i = mapObject.GetLowerBound(0); i <= upperBound; i++)
            {
                for (int j = mapObject.GetLowerBound(1); j <= upperBound2; j++)
                {
                    MapTile mapTile2 = mapObject[i, j];
                    bool flag = mapTile2.Info.Type.SpriteType == TILESPRITE.EVENT && random.Next(0, 10) < 4;
                    flag = ((mapTile2.Info.Type.SpriteType == TILESPRITE.STORE) && (random.Next(0, 10) < 4)) || flag;
                    if (flag)
                    {
                        mapTile = mapTile2;
                        Debug.Log("成功生成");
                        goto IL_84;
                    }
                }
            }
        IL_84:
            bool flag2 = mapTile == null;
            if (!flag2)
            {
                GameObject gameObject = MapCharCtrl.CreateSkeletonObj(MapCharEnum.NECROMANCER);
                CharCtrl_Necromancer charCtrl_BFRBShopKeeper = gameObject.AddComponent<CharCtrl_Necromancer>();
                gameObject.GetComponent<EventObject>().TargetEvent.AddListener(delegate ()
                {
                    charCtrl_BFRBShopKeeper.TalkNecromancer();
                });
                gameObject.transform.parent = mapTile.HexTileComponent.transform;
                gameObject.transform.localPosition = new Vector3(1f, -3f, 0f);
                gameObject.transform.localScale = new Vector3(-0.45f, 0.45f, 1f);
                gameObject.SetActive(true);
            }
        }
    }

    public class MapCharCtrl
    {
        public static GameObject GetSkeletonCharPrefab()
        {
            GameObject gameObject = AddressableLoadManager.Instantiate("FieldObject/Shard/Door", AddressableLoadManager.ManageType.Stage);
            Dorchi_Quest componentInChildren = gameObject.transform.GetComponentInChildren<Dorchi_Quest>(true);
            GameObject gameObject2 = componentInChildren.gameObject;
            gameObject2.SetActive(false);
            return gameObject2;
        }

        public static void InitSkeletonCharObj(GameObject skeletonCharObj)
        {
            skeletonCharObj.GetComponent<EventObject>().TargetEvent = new UnityEvent();
            Dorchi_Quest componentInChildren = skeletonCharObj.transform.GetComponentInChildren<Dorchi_Quest>(true);
            UnityEngine.Object.Destroy(componentInChildren);
            foreach (Dialogue obj in skeletonCharObj.GetComponentsInChildren<Dialogue>())
            {
                UnityEngine.Object.Destroy(obj);
            }
            for (int j = 0; j < 100; j++)
            {
                Transform transform = skeletonCharObj.transform.Find("Dialogue");
                bool flag = transform == null;
                if (flag)
                {
                    break;
                }
                UnityEngine.Object.Destroy(transform.gameObject);
            }
        }

        public static GameObject CreateSkeletonObj(MapCharEnum mapCharEnum)
        {
            GameObject skeletonCharPrefab = MapCharCtrl.GetSkeletonCharPrefab();
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(skeletonCharPrefab);
            MapCharCtrl.InitSkeletonCharObj(gameObject);
            bool flag = mapCharEnum == MapCharEnum.DEFAULT;
            GameObject result;
            if (flag)
            {
                result = gameObject;
            }
            else
            {
                MapCharCtrl.MapCharData mapCharData = MapCharCtrl.mapCharDataDic[mapCharEnum];
                gameObject.name = mapCharData.keyName;
                ModInfo modInfo = ModManager.getModInfo("Necromancer");
                AssetBundle assetBundle = modInfo.assetInfo.GetAssetBundle("nec_sd");
                Debug.Log(mapCharData.skeletonPath);
                SkeletonDataAsset skeletonDataAsset = assetBundle.LoadAsset<SkeletonDataAsset>(mapCharData.skeletonPath);
                gameObject.GetComponentInChildren<SkeletonAnimation>().skeletonDataAsset = skeletonDataAsset;
                string name = skeletonDataAsset.GetSkeletonData(false).Skins.Items[0].Name;
                gameObject.GetComponentInChildren<SkeletonAnimation>().initialSkinName = name;
                gameObject.GetComponentInChildren<SkeletonAnimation>().Initialize(true);
                gameObject.GetComponentInChildren<SkeletonAnimation>().loop = true;
                gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = mapCharData.skeletonIdleName;
                UnityEngine.Object.Destroy(skeletonCharPrefab);
                result = gameObject;
            }
            return result;
        }

        public static Dictionary<MapCharEnum, MapCharCtrl.MapCharData> mapCharDataDic = new Dictionary<MapCharEnum, MapCharCtrl.MapCharData>
        {
            {
                MapCharEnum.NECROMANCER,
                new MapCharCtrl.MapCharData
                {
                    keyName = "Necromancer",
                    name = "死灵法师",
                    skeletonPath = "Assets/ModAssets/nec_SD/\u6B7B\u7075\u6CD5\u5E08\u57CE\u9547_SkeletonData.asset",
                    skeletonIdleName = "default"
                }
            }
        };

        public struct MapCharData
        {
            public string keyName;
            public string name;
            public string skeletonPath;
            public string skeletonIdleName;
        }
    }

    public enum MapCharEnum
    {
        DEFAULT,
        NECROMANCER
    }

}