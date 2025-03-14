﻿using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace HakureiReimu
{
    public class Dia_Mugwort
    {
        public static string DialogueTreePath_Gift_Mugwort
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Mugwort._DialogueTreePath_Mugwort);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("HakureiReimu");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Mugwort.Gift_Mugwort>();
                    Dia_Mugwort._DialogueTreePath_Mugwort = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Mugwort._DialogueTreePath_Mugwort;
            }
        }

        public static string _DialogueTreePath_Mugwort;

        public class Gift_Mugwort : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Mugwort.Gift_Mugwort_Node_1);
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

        public class Gift_Mugwort_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Mugwort/001"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Mugwort.Gift_Mugwort_Node_2);
                }
            }
        }

        public class Gift_Mugwort_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Mugwort/002"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_RedHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Mugwort.Gift_Mugwort_Node_3);
                }
            }
        }

        public class Gift_Mugwort_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Mugwort/003"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_RedSmallHappy.png")
                };
            }
        }
    }
}
