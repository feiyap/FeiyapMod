using System;
using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace KirisameMarisa
{
    public class Dia_Marisa_Lv3
    {
        public static string DialogueTreePath_Marisa_Lv3
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Marisa_Lv3._DialogueTreePath_Marisa_Lv3);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("KirisameMarisa");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Marisa_Lv3.Marisa_Lv3>();
                    Dia_Marisa_Lv3._DialogueTreePath_Marisa_Lv3 = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Marisa_Lv3._DialogueTreePath_Marisa_Lv3;
            }
        }

        public static string _DialogueTreePath_Marisa_Lv3;

        public class Marisa_Lv3 : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_1);
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

        public class Marisa_Lv3_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/001"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedSad.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_2);
                }
            }
        }

        public class Marisa_Lv3_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/002"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_3);
                }
            }
        }

        public class Marisa_Lv3_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/003"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedSmallCry.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_4);
                }
            }
        }

        public class Marisa_Lv3_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/004"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_5);
                }
            }
        }

        public class Marisa_Lv3_Node_5 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/005"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Mairsa_Sad.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_6);
                }
            }
        }

        public class Marisa_Lv3_Node_6 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/006"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Bad.png")
                };
            }

            public override IEnumerable<Type> OptionCreatorTypes
            {
                get
                {
                    return new List<Type>
                    {
                        typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_6_1),
                        typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_6_2)
                    };
                }
            }
        }

        public class Marisa_Lv3_Node_6_1 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/006_Option1")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_6_1_1);
                }
            }
        }

        public class Marisa_Lv3_Node_6_1_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/006_1_1"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Angry.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_7);
                }
            }
        }

        public class Marisa_Lv3_Node_6_2 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/006_Option2")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_6_2_1);
                }
            }
        }

        public class Marisa_Lv3_Node_6_2_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/006_2_1"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_SmallCry.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_7);
                }
            }
        }

        public class Marisa_Lv3_Node_7 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/007"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_8);
                }
            }
        }

        public class Marisa_Lv3_Node_8 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/008"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_9);
                }
            }
        }

        public class Marisa_Lv3_Node_9 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/009"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Han.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_10);
                }
            }
        }

        public class Marisa_Lv3_Node_10 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/010"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_11);
                }
            }
        }

        public class Marisa_Lv3_Node_11 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/011"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_12);
                }
            }
        }

        public class Marisa_Lv3_Node_12 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/012"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_13);
                }
            }
        }

        public class Marisa_Lv3_Node_13 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/013"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_14);
                }
            }
        }
        
        public class Marisa_Lv3_Node_14 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/014"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_15);
                }
            }
        }

        public class Marisa_Lv3_Node_15 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/015"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedNormal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_16);
                }
            }
        }

        public class Marisa_Lv3_Node_16 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/016"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Mairsa_Sad.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_17);
                }
            }
        }

        public class Marisa_Lv3_Node_17 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/017"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_18);
                }
            }
        }

        public class Marisa_Lv3_Node_18 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/018"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_19);
                }
            }
        }

        public class Marisa_Lv3_Node_19 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/019"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_20);
                }
            }
        }

        public class Marisa_Lv3_Node_20 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/020"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_21);
                }
            }
        }

        public class Marisa_Lv3_Node_21 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/021"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_22);
                }
            }
        }

        public class Marisa_Lv3_Node_22 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/022"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv3.Marisa_Lv3_Node_23);
                }
            }
        }

        public class Marisa_Lv3_Node_23 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv3/023"),
                    Standing_Path = ""
                };
            }
        }
    }
}
