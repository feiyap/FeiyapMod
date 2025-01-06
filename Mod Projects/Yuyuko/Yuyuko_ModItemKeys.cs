using ChronoArkMod;
namespace Yuyuko
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 西行寺幽幽子
		/// Passive:
		/// <b>操纵死亡程度的能力</b> - 西行寺幽幽子模糊了生与死的界限，部分技能会增加或减少<color=#FFB6C1>返魂值</color>。
		/// 每个回合开始时，西行寺幽幽子减少20<color=#FFB6C1>返魂值</color>。
		/// <b><color=#FF1493>幽雅地绽放吧</color>，<color=#8B008B>墨染之樱</color></b> - 当<color=#FFB6C1>返魂值</color>的进度超过50时，西行寺幽幽子进入<color=#FF1493>华胥</color>状态：
		/// 攻击力提升10%，部分技能获得加强；
		/// 进入<color=#FF1493>华胥</color>状态时，从放逐牌库将1个自己的技能放回牌库最上方；
		/// 在<color=#FF1493>华胥</color>状态下，固定技能被替换为<color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>：选择1个拥有<color=#436EEE>幽冥蝶</color>或<color=#00688B>人魂蝶</color>关键词的技能，放逐这个技能，将其转化为1个技能对应的减益效果施加在任意敌人身上。<color=#436EEE>幽冥蝶</color>和<color=#00688B>人魂蝶</color>只能存在1只，在<color=#8B008B>引爆</color>之前无法再次施加。
		/// 当<color=#FFB6C1>返魂值</color>的进度超过100时，西行寺幽幽子进入<color=#8B008B>永眠</color>状态：
		/// 无法使用手中的技能，防御力提升50%，直到<color=#FFB6C1>返魂值</color>降低为0；
		/// 进入<color=#8B008B>永眠</color>状态时，使所有敌人失去10%最大体力值，并<color=#8B008B>引爆</color>所有<color=#436EEE>幽冥蝶</color>和<color=#00688B>人魂蝶</color>；
		/// 在<color=#8B008B>永眠</color>状态下，固定技能被替换为<color=#8B008B>亡乡「亡我乡 -无道之路-」</color>：选择1个技能，放逐这个技能，并依据放逐技能的费用，减少40x费用的<color=#FFB6C1>返魂值</color>。
		/// </summary>
        public static string Character_YuyukoF = "YuyukoF";

    }

    public static class ModLocalization
    {

    }
}