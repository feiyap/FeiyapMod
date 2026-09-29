using System;
using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace BossPhoenix
{
    /// <summary>
    /// 城镇凤凰：邀请猜谜，选项「是 / 否」。
    /// </summary>
    public class Dia_City
    {
        public static string DialogueTreePath_Phoenix_Ark
        {
            get
            {
                if (Extensions.IsNullOrEmpty(Dia_City._DialogueTreePath_Phoenix_Ark))
                {
                    ModInfo modInfo = ModManager.getModInfo("BossPhoenix");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_City.Phoenix_Ark>();
                    Dia_City._DialogueTreePath_Phoenix_Ark = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_City._DialogueTreePath_Phoenix_Ark;
            }
        }

        public static string _DialogueTreePath_Phoenix_Ark;

        public class Phoenix_Ark : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Phoenix_Ark_Node_1);
                }
            }

            public override DialogueParameter SetDialogueParameter(GameObject gameObject)
            {
                return new DialogueParameter
                {
                    AutoPlay = true,
                    UIOffDialogue = true,
                    StoryDialogue = true
                };
            }
        }

        public class Phoenix_Ark_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("BossPhoenix").localizationInfo.DialogueLocalizeUpdate("Dialogue/Phoenix_Ark/001"),
                    Standing_Path = ""
                };
            }

            public override IEnumerable<Type> OptionCreatorTypes
            {
                get
                {
                    return new List<Type>
                    {
                        typeof(Dia_City.Phoenix_Ark_Yes),
                        typeof(Dia_City.Phoenix_Ark_No)
                    };
                }
            }
        }

        public class Phoenix_Ark_Yes : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("BossPhoenix").localizationInfo.DialogueLocalizeUpdate("Dialogue/Phoenix_Ark/001_Option1")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Phoenix_Ark_Node_2);
                }
            }
        }

        public class Phoenix_Ark_No : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("BossPhoenix").localizationInfo.DialogueLocalizeUpdate("Dialogue/Phoenix_Ark/001_Option2")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Phoenix_Ark_Node_3);
                }
            }
        }

        public class Phoenix_Ark_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("BossPhoenix").localizationInfo.DialogueLocalizeUpdate("Dialogue/Phoenix_Ark/002"),
                    Standing_Path = ""
                };
            }
        }

        public class Phoenix_Ark_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("BossPhoenix").localizationInfo.DialogueLocalizeUpdate("Dialogue/Phoenix_Ark/003"),
                    Standing_Path = ""
                };
            }
        }
    }
}
