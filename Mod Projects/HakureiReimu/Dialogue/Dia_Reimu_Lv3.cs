using System;
using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace HakureiReimu
{
    public class Dia_Reimu_Lv3
    {
        public static string DialogueTreePath_Reimu_Lv3
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Reimu_Lv3._DialogueTreePath_Reimu_Lv3);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("HakureiReimu");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Reimu_Lv3.Reimu_Lv3>();
                    Dia_Reimu_Lv3._DialogueTreePath_Reimu_Lv3 = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Reimu_Lv3._DialogueTreePath_Reimu_Lv3;
            }
        }

        public static string _DialogueTreePath_Reimu_Lv3;

        public class Reimu_Lv3 : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_1);
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

        public class Reimu_Lv3_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/001"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_2);
                }
            }
        }

        public class Reimu_Lv3_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/002"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_3);
                }
            }
        }

        public class Reimu_Lv3_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/003"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_4);
                }
            }
        }

        public class Reimu_Lv3_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/004"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Smile.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_5);
                }
            }
        }

        public class Reimu_Lv3_Node_5 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/005"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_6);
                }
            }
        }

        public class Reimu_Lv3_Node_6 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/006"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Angry.png")
                };
            }

            public override IEnumerable<Type> OptionCreatorTypes
            {
                get
                {
                    return new List<Type>
                    {
                        typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_6_1),
                        typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_6_2)
                    };
                }
            }
        }

        public class Reimu_Lv3_Node_6_1 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/006_Option1")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_6_1_1);
                }
            }
        }

        public class Reimu_Lv3_Node_6_1_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/006_1_1"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_7);
                }
            }
        }

        public class Reimu_Lv3_Node_6_2 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/006_Option2")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_6_2_1);
                }
            }
        }

        public class Reimu_Lv3_Node_6_2_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/006_2_1"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_7);
                }
            }
        }

        public class Reimu_Lv3_Node_7 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/007"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Smile.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_8);
                }
            }
        }

        public class Reimu_Lv3_Node_8 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/008"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_9);
                }
            }
        }

        public class Reimu_Lv3_Node_9 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/009"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Smile.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_10);
                }
            }
        }

        public class Reimu_Lv3_Node_10 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/010"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_11);
                }
            }
        }

        public class Reimu_Lv3_Node_11 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/011"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Angry.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_12);
                }
            }
        }

        public class Reimu_Lv3_Node_12 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/012"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_13);
                }
            }
        }

        public class Reimu_Lv3_Node_13 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/013"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_SmallAngry.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_14);
                }
            }
        }
        
        public class Reimu_Lv3_Node_14 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/014"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_15);
                }
            }
        }

        public class Reimu_Lv3_Node_15 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/015"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_RedSmallHurt.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_16);
                }
            }
        }

        public class Reimu_Lv3_Node_16 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/016"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_17);
                }
            }
        }

        public class Reimu_Lv3_Node_17 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/017"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Reimu_Lv3.Reimu_Lv3_Node_18);
                }
            }
        }

        public class Reimu_Lv3_Node_18 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Lv3/018"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }
        }
    }
}
