using ChronoArkMod;
namespace RemiliaScarletShinso
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 真祖蕾米莉亚
		/// Passive:
		/// <b>绯夜狂想曲</b> - 真祖蕾米莉亚每次击杀敌人时，获得1点“真法力值”。
		/// 回合开始时，将1点法力值转化为“真法力值”。
		/// “真法力值”可以当做法力值被消耗，且不会因为回合结束重置。真祖蕾米莉亚的部分技能会优先消耗“真法力值”并获得强化。
		/// <b>悲怆第三乐章</b> - 真祖蕾米莉亚每消耗1点“真法力值”时，对随机敌人进行一次追加攻击(33%)，造成痛苦伤害、并超额治疗自己伤害值的100%。
		/// 真祖蕾米莉亚的痛苦伤害可以暴击。
		/// <b>鲜血红雾宛如地狱</b> - 真祖蕾米莉亚受到来自自身的伤害、或是超出体力值的超额治疗时，将伤害值/超出部分的100%记录为“鲜血魔井”。
		/// 每场战斗仅1次，真祖蕾米莉亚在濒死状态下受到伤害前，若“鲜血魔井”超过伤害值，进入“红雾”形态：无敌、隐匿、无法行动。回合结束时，解除“红雾”形态，消耗所有“鲜血魔井”，超额治疗自己等量的体力值，并对所有敌人造成等量的痛苦伤害。
		/// </summary>
        public static string Character_RemiliaScarletShinso = "RemiliaScarletShinso";

    }

    public static class ModLocalization
    {

    }
}