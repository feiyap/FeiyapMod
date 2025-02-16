using ChronoArkMod;
namespace Yuyuko
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 半灵
		/// </summary>
        public static string Enemy_Boss_Ghost = "Boss_Ghost";
		/// <summary>
		/// 魂魄妖梦·半灵
		/// </summary>
        public static string Enemy_Boss_Ghost_Youmu = "Boss_Ghost_Youmu";
		/// <summary>
		/// 魂魄妖梦
		/// </summary>
        public static string Enemy_Boss_Youmu = "Boss_Youmu";
		/// <summary>
		/// 引导攻击
		/// 受到妖梦的伤害+1。
		/// </summary>
        public static string Buff_B_GhostF_1 = "B_GhostF_1";
		/// <summary>
		/// 空观剑「六根清净斩」
		/// 受到攻击时以&a点伤害反击。
		/// </summary>
        public static string Buff_B_GhostF_2 = "B_GhostF_2";
		/// <summary>
		/// 半人半灵
		/// 受到的伤害转化为痛苦伤害。
		/// 死亡后，清空“魂魄妖梦”的“符卡能量”和“符卡层数”，移除“半分幻的庭师”增益，并立即释放“魂魄「幽明求闻持聪明之法」”。
		/// </summary>
        public static string Buff_B_GhostF_P_0 = "B_GhostF_P_0";
		/// <summary>
		/// 生命二刀流·楼观剑
		/// 与“魂魄妖梦”共享体力值。
		/// 以倒计时+1复制所有“魂魄妖梦”的额外行动（除“人鬼「未来永劫斩」”外）。
		/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
		/// “符卡层数”到达5层后释放“空观剑「六根清净斩」”。
		/// </summary>
        public static string Buff_B_GhostF_P_1 = "B_GhostF_P_1";
		/// <summary>
		/// 凭依之缚
		/// 成为“半灵冲撞”优先攻击的目标。
		/// </summary>
        public static string Buff_B_YoumuF_1 = "B_YoumuF_1";
		/// <summary>
		/// 「待宵反射卫星斩」
		/// 受到下一次伤害时以等额伤害反击，触发时移除1层。
		/// </summary>
        public static string Buff_B_YoumuF_2 = "B_YoumuF_2";
		/// <summary>
		/// 半分幻的庭师
		/// 减少的伤害量会传递给“半灵”。
		/// 自身每行动2次，释放1次“半灵冲撞”。
		/// 剩余行动次数：&a
		/// 每行动3次，释放1次“拔刀术”。
		/// 剩余行动次数：&b
		/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
		/// “符卡层数”到达5层后释放“人鬼「未来永劫斩」”。
		/// </summary>
        public static string Buff_B_YoumuF_P_0 = "B_YoumuF_P_0";
		/// <summary>
		/// 生命二刀流·白楼剑
		/// 与“魂魄妖梦·半灵”共享体力值。
		/// 每行动3次，释放1次“拔刀术”。
		/// 剩余行动次数：&b
		/// 每次行动或受到伤害会叠加1层“符卡能量”，“符卡能量”叠加至4层时获得1层“符卡层数”。
		/// “符卡层数”到达5层后释放“人鬼「未来永劫斩」”。
		/// </summary>
        public static string Buff_B_YoumuF_P_1 = "B_YoumuF_P_1";
		/// <summary>
		/// 符卡能量
		/// 叠加至4层时获得1层“符卡层数”。
		/// </summary>
        public static string Buff_B_YoumuF_Spell = "B_YoumuF_Spell";
		/// <summary>
		/// 符卡等级
		/// 到达5层后释放“人鬼「未来永劫斩」”。
		/// </summary>
        public static string Buff_B_YoumuF_Spell2 = "B_YoumuF_Spell2";
		/// <summary>
		/// 渡魂蝶
		/// </summary>
        public static string Buff_B_YuyukoF_0 = "B_YuyukoF_0";
		/// <summary>
		/// 轮回蝶
		/// 结算时降低&a最大体力值<color=#FF7A33>(&user的攻击力的54%)</color>。
		/// </summary>
        public static string Buff_B_YuyukoF_1 = "B_YuyukoF_1";
		/// <summary>
		/// 死欲蝶
		/// </summary>
        public static string Buff_B_YuyukoF_5 = "B_YuyukoF_5";
		/// <summary>
		/// 妄死蝶
		/// 结算时降低&a最大体力值<color=#FF7A33>(&user攻击力的33%/每层)</color>。
		/// </summary>
        public static string Buff_B_YuyukoF_6 = "B_YuyukoF_6";
		/// <summary>
		/// 醉梦蝶
		/// 受到的伤害降低为0，但&user增加等量于伤害值的<color=#FFB6C1>返魂值</color>。
		/// &user陷入<color=#8B008B>永眠</color>时立即解除。
		/// </summary>
        public static string Buff_B_YuyukoF_8 = "B_YuyukoF_8";
		/// <summary>
		/// 樱散蝶
		/// 体力值不会降低至1以下。
		/// </summary>
        public static string Buff_B_YuyukoF_9 = "B_YuyukoF_9";
		/// <summary>
		/// <color=#4876FF>幽冥蝶</color>
		/// &effect
		/// </summary>
        public static string Buff_B_YuyukoF_Butterfly_M = "B_YuyukoF_Butterfly_M";
		/// <summary>
		/// <color=#FF69B4>人魂蝶</color>
		/// &effect
		/// </summary>
        public static string Buff_B_YuyukoF_Butterfly_R = "B_YuyukoF_Butterfly_R";
		/// <summary>
		/// 死亡的边界
		/// </summary>
        public static string Buff_B_YuyukoF_Die = "B_YuyukoF_Die";
		/// <summary>
		/// <color=#E066FF>唤魂</color>
		/// 当前有<color=#E066FF>&a</color>点<color=#E066FF>亡魂</color>。
		/// </summary>
        public static string Buff_B_YuyukoF_Ghost = "B_YuyukoF_Ghost";
		/// <summary>
		/// 通常
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_1 = "B_YuyukoF_P_1";
		/// <summary>
		/// <color=#FF1493>华胥</color>
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_2 = "B_YuyukoF_P_2";
		/// <summary>
		/// <color=#8B008B>永眠</color>
		/// 当前<color=#FFB6C1>返魂值</color>为：<color=#FFB6C1>&a</color>
		/// </summary>
        public static string Buff_B_YuyukoF_P_3 = "B_YuyukoF_P_3";
		/// <summary>
		/// 黄泉蝶
		/// 每次有敌人死亡时，对所有敌人造成&a伤害<color=#FF7A33>(攻击力的135%)</color>。
		/// </summary>
        public static string Buff_B_YuyukoF_Rare_2 = "B_YuyukoF_Rare_2";
		/// <summary>
		/// 明光蝶
		/// 每个回合第一次触发<color=#E066FF><color=#E066FF>唤魂</color>X</color>时，获得X点<color=#E066FF><color=#E066FF>亡魂</color></color>，并回复X点法力值（无法超过法力值上限）。
		/// </summary>
        public static string Buff_B_YuyukoF_Rare_3 = "B_YuyukoF_Rare_3";
		/// <summary>
		/// 浮月蝶
		/// 所有造成的伤害额外增加&a点<color=#FF7A33>(攻击力的47%)</color>，最多触发 10 次。
		/// 当前触发次数：&b
		/// </summary>
        public static string Buff_B_YuyukoF_Rare_3_1 = "B_YuyukoF_Rare_3_1";
		/// <summary>
		/// <color=#4876FF>幽冥蝶</color>
		/// 可以被转化为<color=#4876FF>幽冥蝶</color>施加在敌人身上。
		/// </summary>
        public static string SkillKeyword_Keyword_ButterflyM = "Keyword_ButterflyM";
		/// <summary>
		/// <color=#FF69B4>人魂蝶</color>
		/// 可以被转化为<color=#FF69B4>人魂蝶</color>施加在敌人身上。
		/// </summary>
        public static string SkillKeyword_Keyword_ButterflyR = "Keyword_ButterflyR";
		/// <summary>
		/// <b><color=#CAE1FF>亡者召还X</color></b>
		/// 从放逐牌库中、费用不超过X的技能中，将随机1个费用最高的技能拿回手中（持有者不为自己的一次性技能除外）。
		/// </summary>
        public static string SkillKeyword_Keyword_DeadRevive = "Keyword_DeadRevive";
		/// <summary>
		/// <b><color=#E066FF>唤魂X</color></b>
		/// 打出技能时，消耗X点<color=#E066FF>亡魂</color>，能够触发额外效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Ghost = "Keyword_Ghost";
		/// <summary>
		/// <color=#FF1493>华胥</color>
		/// 在<color=#FF1493>华胥</color>状态下，部分技能获得强化。
		/// </summary>
        public static string SkillKeyword_Keyword_Huaxu = "Keyword_Huaxu";
		/// <summary>
		/// <b><color=#AB82FF>葬送</color></b>
		/// 当附带此词条的技能被<b>放逐</b>时触发效果。
		/// </summary>
        public static string SkillKeyword_Keyword_Ruin = "Keyword_Ruin";
        public static string SkillEffect_SE_S_S_YoumuF_2 = "SE_S_S_YoumuF_2";
        public static string SkillEffect_SE_S_S_YuyukoF_Rare_2 = "SE_S_S_YuyukoF_Rare_2";
        public static string SkillEffect_SE_S_S_YuyukoF_Rare_3 = "SE_S_S_YuyukoF_Rare_3";
        public static string SkillEffect_SE_T_S_GhostF_0 = "SE_T_S_GhostF_0";
        public static string SkillEffect_SE_T_S_GhostF_2 = "SE_T_S_GhostF_2";
        public static string SkillEffect_SE_T_S_GhostF_2_0 = "SE_T_S_GhostF_2_0";
        public static string SkillEffect_SE_T_S_YoumuF_0 = "SE_T_S_YoumuF_0";
        public static string SkillEffect_SE_T_S_YoumuF_1 = "SE_T_S_YoumuF_1";
        public static string SkillEffect_SE_T_S_YoumuF_4 = "SE_T_S_YoumuF_4";
        public static string SkillEffect_SE_T_S_YoumuF_5 = "SE_T_S_YoumuF_5";
        public static string SkillEffect_SE_T_S_YoumuF_6 = "SE_T_S_YoumuF_6";
        public static string SkillEffect_SE_T_S_YoumuF_6_1 = "SE_T_S_YoumuF_6_1";
        public static string SkillEffect_SE_T_S_YoumuF_6_2 = "SE_T_S_YoumuF_6_2";
        public static string SkillEffect_SE_T_S_YoumuF_6_3 = "SE_T_S_YoumuF_6_3";
        public static string SkillEffect_SE_T_S_YuyukoF_0 = "SE_T_S_YuyukoF_0";
        public static string SkillEffect_SE_T_S_YuyukoF_1 = "SE_T_S_YuyukoF_1";
        public static string SkillEffect_SE_T_S_YuyukoF_2 = "SE_T_S_YuyukoF_2";
        public static string SkillEffect_SE_T_S_YuyukoF_3 = "SE_T_S_YuyukoF_3";
        public static string SkillEffect_SE_T_S_YuyukoF_4 = "SE_T_S_YuyukoF_4";
        public static string SkillEffect_SE_T_S_YuyukoF_5 = "SE_T_S_YuyukoF_5";
        public static string SkillEffect_SE_T_S_YuyukoF_6 = "SE_T_S_YuyukoF_6";
        public static string SkillEffect_SE_T_S_YuyukoF_8 = "SE_T_S_YuyukoF_8";
        public static string SkillEffect_SE_T_S_YuyukoF_9 = "SE_T_S_YuyukoF_9";
        public static string SkillEffect_SE_T_S_YuyukoF_P_2 = "SE_T_S_YuyukoF_P_2";
        public static string SkillEffect_SE_T_S_YuyukoF_Rare_1 = "SE_T_S_YuyukoF_Rare_1";
        public static string SkillEffect_SE_T_S_YuyukoF_Rare_1_0 = "SE_T_S_YuyukoF_Rare_1_0";
        public static string SkillEffect_SE_T_S_YuyukoF_Rare_2 = "SE_T_S_YuyukoF_Rare_2";
        public static string SkillEffect_SE_T_S_YuyukoF_Rare_2_0 = "SE_T_S_YuyukoF_Rare_2_0";
        public static string SkillEffect_SE_T_S_YuyukoF_Rare_3 = "SE_T_S_YuyukoF_Rare_3";
        public static string EnemyQueue_SR_Boss_Youmu = "SR_Boss_Youmu";
		/// <summary>
		/// 半灵冲撞
		/// 优先攻击拥有“凭依之缚”的敌人。
		/// </summary>
        public static string Skill_S_GhostF_0 = "S_GhostF_0";
		/// <summary>
		/// 魂魄「幽明求闻持聪明之法」
		/// 在场上生成1个“魂魄妖梦·半灵”，与本体共享体力值。
		/// 为“魂魄妖梦”赋予“生命二刀流·白楼剑”增益。
		/// </summary>
        public static string Skill_S_GhostF_1 = "S_GhostF_1";
		/// <summary>
		/// 空观剑「六根清净斩」
		/// </summary>
        public static string Skill_S_GhostF_2 = "S_GhostF_2";
		/// <summary>
		/// 空观剑「六根清净斩」
		/// </summary>
        public static string Skill_S_GhostF_2_0 = "S_GhostF_2_0";
		/// <summary>
		/// 柄击
		/// 释放2次“柄击”后，追加1次“拔刀术”。
		/// </summary>
        public static string Skill_S_YoumuF_0 = "S_YoumuF_0";
		/// <summary>
		/// 凭依之缚
		/// </summary>
        public static string Skill_S_YoumuF_1 = "S_YoumuF_1";
		/// <summary>
		/// 「待宵反射卫星斩」
		/// </summary>
        public static string Skill_S_YoumuF_2 = "S_YoumuF_2";
		/// <summary>
		/// 狱神剑「业风神闪斩」
		/// 随机追加3次行动（“狱神剑「业风神闪斩」”除外）。
		/// </summary>
        public static string Skill_S_YoumuF_3 = "S_YoumuF_3";
		/// <summary>
		/// 奥义「西行春风斩」
		/// 重复释放本技能1次。
		/// 同时攻击除该目标外1个随机目标。
		/// 如果只攻击1个目标，本次攻击必定暴击。
		/// </summary>
        public static string Skill_S_YoumuF_4 = "S_YoumuF_4";
		/// <summary>
		/// 拔刀术
		/// 减少1次等待次数。
		/// </summary>
        public static string Skill_S_YoumuF_5 = "S_YoumuF_5";
		/// <summary>
		/// 人鬼「未来永劫斩」
		/// 无视防御。
		/// 先造成1次&a伤害(攻击力的60%)，再造成16次&b伤害(攻击力的29%)，最后造成一次&c伤害(攻击力的500%)。
		/// 若目标陷入濒死状态，且场上存在非濒死状态的调查员，则攻击对象转移至其他非濒死状态的调查员。
		/// </summary>
        public static string Skill_S_YoumuF_6 = "S_YoumuF_6";
		/// <summary>
		/// 人鬼「未来永劫斩」-一式
		/// </summary>
        public static string Skill_S_YoumuF_6_1 = "S_YoumuF_6_1";
		/// <summary>
		/// 人鬼「未来永劫斩」-二式
		/// </summary>
        public static string Skill_S_YoumuF_6_2 = "S_YoumuF_6_2";
		/// <summary>
		/// 人鬼「未来永劫斩」-终式
		/// </summary>
        public static string Skill_S_YoumuF_6_3 = "S_YoumuF_6_3";
		/// <summary>
		/// 亡乡「亡我乡 -宿罪-」
		/// 增加20<color=#FFB6C1>返魂值</color>。
		/// <color=#FF1493>华胥</color> - 超额治疗自己等量于“目标已损失的最大体力值的25%”的体力。
		/// <color=#AB82FF>葬送</color> - <color=#CAE1FF>亡者召还3</color>。
		/// <color=#4876FF>幽冥蝶</color> - 结算时降低10%最大体力值<color=#FF7A33>(不超过自身攻击力的200%)</color>。
		/// <color=#FF69B4>人魂蝶</color> - 可以无视嘲讽状态被选中。
		/// </summary>
        public static string Skill_S_YuyukoF_0 = "S_YuyukoF_0";
		/// <summary>
		/// 死蝶「华胥之永眠」
		/// 增加20<color=#FFB6C1>返魂值</color>。
		/// <color=#FF1493>华胥</color> - 若指向目标拥有冥魂蝶，以暴击形式命中；若指向目标拥有<color=#FF69B4>人魂蝶</color>，额外造成&a伤害<color=#FF7A33>(攻击力的54%)</color>。
		/// <color=#E066FF>唤魂5</color> - 以倒计时2重复释放1次。
		/// <color=#4876FF>幽冥蝶</color> - 受到的非<color=purple>痛苦伤害</color>转化为降低等量的最大体力值。
		/// <color=#FF69B4>人魂蝶</color> - 受到的<color=purple>痛苦伤害</color>转化为降低等量的最大体力值。
		/// </summary>
        public static string Skill_S_YuyukoF_1 = "S_YuyukoF_1";
		/// <summary>
		/// 幽雅「通向黄泉的诱蛾灯」
		/// 仅能指定同时拥有<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>的敌人。
		/// <color=#8B008B>回引</color>目标的<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>。
		/// <color=#E066FF>唤魂10</color> - 额外造成&a伤害<color=#FF7A33>(攻击力的300%)</color>。
		/// <color=#FF1493>华胥</color> - 额外造成&a伤害<color=#FF7A33>(攻击力的300%)</color>。
		/// <color=#4876FF>幽冥蝶</color> - 施加时，触发一次<color=#CAE1FF>亡者召还1</color>。<color=#8B008B>回引</color>时，触发一次<color=#CAE1FF>亡者召还1</color>。
		/// <color=#FF69B4>人魂蝶</color> - 施加时，获得8点<color=#E066FF>亡魂</color>。<color=#8B008B>回引</color>时，获得8点<color=#E066FF>亡魂</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_2 = "S_YuyukoF_2";
		/// <summary>
		/// 亡舞「生者必灭之理」
		/// 减少20<color=#FFB6C1>返魂值</color>。
		/// 展示牌库中的技能。选择其中1个放逐，抽取1个技能。
		/// <color=#AB82FF>葬送</color> - 展示弃牌库中的技能。选择其中1个放逐，抽取1个技能。
		/// <color=#4876FF>幽冥蝶</color> - 施加时，选择手中1个技能放逐，抽取1个技能。
		/// <color=#FF69B4>人魂蝶</color> - 施加时，选择手中1个技能放逐，抽取1个技能。
		/// </summary>
        public static string Skill_S_YuyukoF_3 = "S_YuyukoF_3";
		/// <summary>
		/// 冥符「黄泉平坂行路」
		/// 增加20<color=#FFB6C1>返魂值</color>。
		/// 使所有敌人获得与目标相同的“已损失最大体力值”的值。
		/// <color=#AB82FF>葬送</color> - 使所有敌人失去&a最大体力值<color=#FF7A33>(攻击力的121%)</color>。
		/// <color=#4876FF>幽冥蝶</color> - <color=#8B008B>回引</color>时，造成&a伤害<color=#FF7A33>(攻击力的121%)</color>。
		/// <color=#FF69B4>人魂蝶</color> - 施加时，使所有调查员的固定能力变为可用状态。
		/// </summary>
        public static string Skill_S_YuyukoF_4 = "S_YuyukoF_4";
		/// <summary>
		/// 蝶符「凤蝶纹的死枪」
		/// <color=#E066FF>唤魂4</color> - 额外使敌人降低25%最大体力值<color=#FF7A33>(不超过自身攻击力的500%)</color>。
		/// <color=#AB82FF>葬送</color> - 对随机敌人释放这个技能。
		/// <color=#4876FF>幽冥蝶</color> - 施加时，触发1次<color=#CAE1FF>亡者召还2</color>。
		/// <color=#FF69B4>人魂蝶</color> - <color=#8B008B>回引</color>时，抽取2个技能。
		/// </summary>
        public static string Skill_S_YuyukoF_5 = "S_YuyukoF_5";
		/// <summary>
		/// 樱符「完全墨染的樱花」
		/// 增加20<color=#FFB6C1>返魂值</color>。
		/// <color=#E066FF>唤魂4</color> - <color=#CAE1FF>亡者召还0</color>。
		/// <color=#FF1493>华胥</color> - 改为减少20<color=#FFB6C1>返魂值</color>。
		/// <color=#4876FF>幽冥蝶</color> - <color=#8B008B>回引</color>时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// <color=#FF69B4>人魂蝶</color> - <color=#8B008B>回引</color>时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// </summary>
        public static string Skill_S_YuyukoF_6 = "S_YuyukoF_6";
		/// <summary>
		/// 灵蝶「蝶之羽风暂留此世」
		/// 仅能在无法行动时、或处于<color=#8B008B>永眠</color>状态时使用。
		/// 解除所有干扰减益和<color=#8B008B>永眠</color>状态，抽取2个技能，恢复2点法力值。
		/// 将<color=#FFB6C1>返魂值</color>设置为50，并进入<color=#FF1493>华胥</color>状态。
		/// 立即获得10点<color=#E066FF>亡魂</color>。
		/// <color=#AB82FF>葬送</color> - 降低100<color=#FFB6C1>返魂值</color>。
		/// <color=#4876FF>幽冥蝶</color> - 施加时，抽取1个技能，恢复1点法力值。
		/// <color=#FF69B4>人魂蝶</color> - 施加时，眩晕（<sprite=2>100%）1回合。
		/// </summary>
        public static string Skill_S_YuyukoF_7 = "S_YuyukoF_7";
		/// <summary>
		/// 死符「醉人之生，死的梦幻」
		/// 仅能在<color=#FF1493>华胥</color>状态下使用。
		/// <color=#FF1493>华胥</color> - 减少20<color=#FFB6C1>返魂值</color>。
		/// <color=#AB82FF>葬送</color> - 选择手中1个技能放逐，<color=#CAE1FF>亡者召还1</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_8 = "S_YuyukoF_8";
		/// <summary>
		/// 樱花「依恋未酌宴」
		/// 选择 - 增加40<color=#FFB6C1>返魂值</color>；
		/// 减少40<color=#FFB6C1>返魂值</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_9 = "S_YuyukoF_9";
		/// <summary>
		/// 樱花「依恋未酌宴」
		/// 增加40<color=#FFB6C1>返魂值</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_9_0 = "S_YuyukoF_9_0";
		/// <summary>
		/// 樱花「依恋未酌宴」
		/// 减少40<color=#FFB6C1>返魂值</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_9_1 = "S_YuyukoF_9_1";
		/// <summary>
		/// 寿命「通向无寿国的期票」
		/// 放逐目标技能，抽取3个技能。
		/// </summary>
        public static string Skill_S_YuyukoF_LucyD = "S_YuyukoF_LucyD";
		/// <summary>
		/// <color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>
		/// 仅能选择拥有<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>关键词的技能。
		/// 放逐目标技能，将其转化为1个技能对应的减益效果施加在任意敌人身上。
		/// <color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>各只能存在1只，在<color=#8B008B>回引</color>之前无法再次施加。
		/// </summary>
        public static string Skill_S_YuyukoF_P_1 = "S_YuyukoF_P_1";
		/// <summary>
		/// 转化<color=#4876FF>幽冥蝶</color>
		/// 将目标技能转化为<color=#4876FF>幽冥蝶</color>施加在任意敌人身上。&a
		/// </summary>
        public static string Skill_S_YuyukoF_P_1_1 = "S_YuyukoF_P_1_1";
		/// <summary>
		/// 转化<color=#FF69B4>人魂蝶</color>
		/// 将目标技能转化为<color=#FF69B4>人魂蝶</color>施加在任意敌人身上。&a
		/// </summary>
        public static string Skill_S_YuyukoF_P_1_2 = "S_YuyukoF_P_1_2";
		/// <summary>
		/// <color=#4876FF>亡乡「亡我乡 -自尽-」</color>
		/// 立即获得100<color=#FFB6C1>返魂值</color>，并进入<color=#8B008B>永眠</color>状态。
		/// </summary>
        public static string Skill_S_YuyukoF_P_2 = "S_YuyukoF_P_2";
		/// <summary>
		/// <color=#8B008B>亡乡「亡我乡 -无道之路-」</color>
		/// 放逐目标技能，减少100<color=#FFB6C1>返魂值</color>。
		/// </summary>
        public static string Skill_S_YuyukoF_P_3 = "S_YuyukoF_P_3";
		/// <summary>
		/// 「反魂蝶」
		/// 握在手中时，自身每次进入<color=#8B008B>永眠</color>状态时，使这个技能获得：打出时，重复释放1次。
		/// 这个技能最多能重复释放10次。
		/// <color=#AB82FF>葬送</color> - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
		/// <color=#4876FF>幽冥蝶</color> - 无效果。
		/// <color=#FF69B4>人魂蝶</color> - 无效果。
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_1 = "S_YuyukoF_Rare_1";
		/// <summary>
		/// 「反魂蝶 - 十分咲」
		/// 重复释放 10 次。
		/// 握在手中时，自身每次进入<color=#8B008B>永眠</color>状态时，使这个技能获得：打出时，重复释放1次。
		/// 这个技能最多能重复释放10次。
		/// <color=#AB82FF>葬送</color> - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_1_0 = "S_YuyukoF_Rare_1_0";
		/// <summary>
		/// 再迷「幻想乡的黄泉归」
		/// 握在手中时，每次有技能被放逐，使这个技能费用降低1点。
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_2 = "S_YuyukoF_Rare_2";
        public static string Skill_S_YuyukoF_Rare_2_0 = "S_YuyukoF_Rare_2_0";
		/// <summary>
		/// 「死蝶浮月」
		/// </summary>
        public static string Skill_S_YuyukoF_Rare_3 = "S_YuyukoF_Rare_3";
		/// <summary>
		/// 西行寺幽幽子
		/// Passive:
		/// <b>操纵死亡程度的能力</b> - 西行寺幽幽子模糊了生与死的界限，部分技能会增加或减少<color=#FFB6C1>返魂值</color>。
		/// 西行寺幽幽子的攻击不再造成伤害，而是降低目标等量的最大体力值。
		/// <b><color=#FF1493>幽雅地绽放吧</color>，<color=#8B008B>墨染之樱</color></b> - 固定技能被替换为<color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>。
		/// 当<color=#FFB6C1>返魂值</color>的进度超过50时，西行寺幽幽子进入<color=#FF1493>华胥</color>状态，并从放逐牌库将1个自己的技能拿回手中；
		/// 在<color=#FF1493>华胥</color>状态下，获得攻击力提升，部分技能获得增强。
		/// 当场上同时存在<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>时，固定技能被替换为<color=#4876FF>亡乡「亡我乡 -自尽-」</color>。
		/// 当<color=#FFB6C1>返魂值</color>的进度超过100时，西行寺幽幽子进入<color=#8B008B>永眠</color>状态，并使所有敌人失去10%最大体力值、并<color=#8B008B>回引</color>所有<color=#4876FF>幽冥蝶</color>和<color=#FF69B4>人魂蝶</color>；
		/// 在<color=#8B008B>永眠</color>状态下，固定技能被替换为<color=#8B008B>亡乡「亡我乡 -无道之路-」</color>。
		/// <b><color=#E066FF>唤魂X</color></b> - 每有1个技能被放逐，西行寺幽幽子获得1点<color=#E066FF>亡魂</color>。打出技能时，消耗X点<color=#E066FF>亡魂</color>，能够触发额外效果。
		/// <b><color=#AB82FF>葬送</color></b> - 当附带此词条的技能被<b>放逐</b>时触发效果。
		/// <b><color=#CAE1FF>亡者召还</color>X</b> - 从放逐牌库将1个费用不超过X的技能拿回手中。
		/// </summary>
        public static string Character_YuyukoF = "YuyukoF";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 结算时降低10%最大体力值<color=#FF7A33>(不超过&user攻击力的200%)</color>。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_0_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_0_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 可以无视嘲讽状态被选中。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_0_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_0_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 受到的非<color=purple>痛苦伤害</color>转化为降低等量的最大体力值。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_1_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_1_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 受到的<color=purple>痛苦伤害</color>转化为降低等量的最大体力值。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_1_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_1_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，触发1次<color=#CAE1FF>亡者召还1</color>。<color=#8B008B>回引</color>时，触发1次<color=#CAE1FF>亡者召还1</color>。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_2_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_2_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，获得8点<color=#E066FF>亡魂</color>。<color=#8B008B>回引</color>时，获得8点<color=#E066FF>亡魂</color>。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_2_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_2_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，选择手中1个技能放逐，抽取1个技能。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_3_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_3_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，选择手中1个技能放逐，抽取1个技能。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_3_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_3_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <color=#8B008B>回引</color>时，造成&a的伤害(&user攻击力的135%)。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_4_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_4_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，使所有调查员的固定能力变为可用状态。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_4_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_4_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，触发1次<color=#CAE1FF>亡者召还2</color>。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_5_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_5_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <color=#8B008B>回引</color>时，抽取2个技能。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_5_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_5_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <color=#8B008B>回引</color>时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_6_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_6_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <color=#8B008B>回引</color>时，在手中生成1个“樱符「完全墨染的樱花」”。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_6_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_6_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，抽取1个技能，恢复1点法力值。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_7_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_7_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 施加时，眩晕（<sprite=2>100%）1回合。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_7_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_7_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=red>场上已经有<color=#4876FF>幽冥蝶</color>了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_P_1_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_P_1_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// <i><color=red>场上已经有<color=#FF69B4>人魂蝶</color>了。</color></i>
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_P_1_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_P_1_2/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 「反魂蝶 - 
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_Rare_1 => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 分咲」
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_Rare_1_0 => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1_0");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 无效果。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_Rare_1_1Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1_1/Text");
		/// <summary>
		/// Korean:
		/// English:
		/// Japanese:
		/// Chinese:
		/// 无效果。
		/// Chinese-TW:
		/// </summary>
        public static string S_YuyukoF_Rare_1_2Text => ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1_2/Text");

    }
}