using ChronoArkMod;
namespace saber
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 阿尔托莉雅
		/// Passive:
		/// 阿尔托莉雅，拥有龙的血脉，这般强大的力量使其魔力异常充沛，一呼一吸间皆能汲取庞大的魔力。每回合开始时，阿尔托莉雅回复5点生命值并获得1点魔力
		/// </summary>
        public static string Character_Saber = "Saber";
		/// <summary>
		/// 龙之炉心
		/// 每回合开始时，阿尔托莉雅回复4点生命值
		/// </summary>
        public static string Buff_SaberBuff = "SaberBuff";
		/// <summary>
		/// 石中之剑
		/// 获得「必胜黄金之剑」
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_Saber_bajian = "Saber_bajian";
		/// <summary>
		/// 庇佑
		/// 对自身造成（&a）点痛苦伤害并为其他友军生成（&b）点护盾
		/// <color=green>魔力填充</color>
		/// </summary>
        public static string Skill_Saber_bihu = "Saber_bihu";
		/// <summary>
		/// 庇护
		/// 被攻击概率大幅增加
		/// </summary>
        public static string Buff_Saber_bihu_B = "Saber_bihu_B";
        public static string SkillExtended_Saber_bihu_ex = "Saber_bihu_ex";
        public static string Buff_Saber_bihu_hudun = "Saber_bihu_hudun";
		/// <summary>
		/// 必胜黄金之剑
		/// 阿尔托莉雅装备时，速度+1，防御穿透+15%
		/// <color=#808080>拔出此剑者，即为英格兰之王!</color>
		/// </summary>
        public static string Item_Equip_Saber_Calibur = "Saber_Calibur";
		/// <summary>
		/// 挑战
		/// 优先攻击&target。
		/// 攻击目标时解除。
		/// <color=#808080>受到了王的挑战，现在就看有没有胆子应邀了......</color>
		/// </summary>
        public static string Buff_Saber_challenge = "Saber_challenge";
		/// <summary>
		/// 挑战
		/// 优先攻击阿尔托莉雅。
		/// 攻击目标时解除。
		/// </summary>
        public static string SkillKeyword_Saber_challenge_D = "Saber_challenge_D";
		/// <summary>
		/// 决斗
		///  无法攻击&target以外的目标，并每回合受到伤害。
		/// 攻击目标时解除。
		/// 无法减少体力极限。
		/// <color=#808080>与王决斗？这便从内心感到了战栗！</color>
		/// </summary>
        public static string Buff_Saber_challenge_plus = "Saber_challenge_plus";
		/// <summary>
		/// 决斗
		///  无法攻击阿尔托莉雅以外的目标，并每回合受到伤害。
		/// 攻击目标时解除。
		/// 无法减少体力极限
		/// </summary>
        public static string SkillKeyword_Saber_challenge_plus_D = "Saber_challenge_plus_D";
		/// <summary>
		/// 重整架势
		/// 清除过载并施加「整备」
		/// <color=#ED5C26>剑技</color>：获得50%最大生命值的保护罩并抽取一个技能
		/// 不计入<color=#ED5C26>剑技</color>
		/// </summary>
        public static string Skill_Saber_chongzheng = "Saber_chongzheng";
        public static string SkillExtended_Saber_chongzheng_ex = "Saber_chongzheng_ex";
		/// <summary>
		/// 魔力装填
		/// 获得2点「<color=blue>魔力</color>」
		/// </summary>
        public static string Skill_Saber_cunxu = "Saber_cunxu";
		/// <summary>
		/// 断钢斩
		/// 无视50%防御
		/// <color=#ED5C26>剑技</color>:击杀时重复释放1次并获得1点法力值
		/// </summary>
        public static string Skill_Saber_duangang = "Saber_duangang";
        public static string SkillExtended_Saber_duangang_ex = "Saber_duangang_ex";
		/// <summary>
		/// <color=#F0BC1F>誓约胜利之剑</color>
		/// 阿尔托莉雅装备时：
		/// 速度+2
		/// 防御穿透+30%
		/// 战斗开始时，赋予自身「<color=red>英雄作成</color>」
		/// <color=#808080>“那把剑正是从过去未来消逝在战场上的所有士兵，在临终之际怀抱的虽悲伤但尊贵的梦想，那样的意志值得夸耀，那样的信义必须贯彻，常胜之王高声的念出手上奇迹的真名，那正是------誓约胜利之剑（Excalibur）”</color>
		/// </summary>
        public static string Item_Equip_Saber_ExCalibur = "Saber_ExCalibur";
        public static string SkillExtended_Saber_EXCalibur_EX = "Saber_EXCalibur_EX";
		/// <summary>
		/// <color=#F0BC1F>宝具解放·誓约胜利之剑</color>
		/// 倒计时期间获得50%减伤且无法行动，
		/// 释放时赋予「无敌」
		/// 无视目标的防御并施加「断钢」
		/// <color=green>魔力放出</color>(5)：能够释放
		/// <color=#F0BCAF>孤独な巡礼</color>：获得30%最大生命值的防护墙
		/// <color=#808080>风王结界</color>：施加4层「<color=#A0AC8F>风蚀</color>」
		/// <color=#ED5C26>剑技</color>：进入倒计时后，抽取2个技能
		/// 不计入<color=#ED5C26>剑技
		/// <color=#808080>阶级：A++　种类：对城宝具
		/// <color=yellow>Excalibur
		/// </color>这并非人造的武器，而是由星锻造而成神造兵器。立于圣剑顶点的宝具。拥有真正强大力量的应是剑鞘，而不是剑本身，但剑鞘据说已永远遗失了。</color>
		/// </summary>
        public static string Skill_Saber_Excalicur = "Saber_Excalicur";
		/// <summary>
		/// <color=blue><color=green><color=green>魔力放出</color></color>
		/// </color>消耗积攒的<color=blue>魔力</color></color>，使攻击获得额外效果
		/// </summary>
        public static string SkillKeyword_Saber_fangchu = "Saber_fangchu";
		/// <summary>
		/// <color=#A0AC8F>风蚀</color>
		/// 正在遭受风压的侵蚀！
		/// </summary>
        public static string Buff_Saber_fengshi = "Saber_fengshi";
		/// <summary>
		/// 风王铁锤
		/// 施加「挑战」
		/// <color=green>魔力放出</color>(3):施加「决斗」
		/// <color=#808080>风王结界</color>:施加1层「<color=#A0AC8F>风蚀</color>」
		/// <color=#808080><color=green>
		/// </summary>
        public static string Skill_Saber_fengwang = "Saber_fengwang";
        public static string SkillExtended_saber_fengwang_moli2 = "saber_fengwang_moli2";
		/// <summary>
		/// 风压
		/// <color=green>魔力放出</color>(2)：获得自身最大生命值20%的防护墙
		/// <color=#808080>风王结界</color>:额外施加1层「<color=#A0AC8F>风蚀</color>」
		/// </summary>
        public static string Skill_Saber_fengya = "Saber_fengya";
        public static string SkillExtended_Saber_fengya_ex = "Saber_fengya_ex";
		/// <summary>
		///  <color=#F0BCAF>孤独な巡礼</color>
		/// 赋予全体「无敌」
		/// 赋予自身「 <color=#F0BCAF>孤独な巡礼</color>」
		/// </summary>
        public static string Skill_Saber_gudu = "Saber_gudu";
		/// <summary>
		/// <color=#ED5C26>剑技</color>
		/// 打出时不会增加<color=blue>魔力</color>，但如果上一次使用了<color=#ED5C26>剑技</color></color></color>,则获得额外的效果;若施展后<color=blue>魔力</color>为0，则会获得1点<color=blue>魔力
		/// </summary>
        public static string SkillKeyword_Saber_jianji_D = "Saber_jianji_D";
		/// <summary>
		/// 剑势
		/// 阿尔托莉雅打出了<color=#ED5C26>剑技</color>
		/// </summary>
        public static string Buff_Saber_jianshi = "Saber_jianshi";
		/// <summary>
		/// <color=#808080>风王结界</color>
		/// 战斗开始时，放在牌库最上方
		/// 赋予自身「<color=#808080>风王结界·散</color>」,若自身拥有2层及以上的</color>「<color=red>英雄作成</color>」<color=#ED5C26><color=red></color></color>则改为「<color=#808080>风王结界</color>」
		/// <color=#808080>此宝具是被强力魔术守护着，而并非剑本体是透明的。缠住剑身的风改变了光的折射率，从而使得剑的形状变得看不见。</color>
		/// </summary>
        public static string Skill_Saber_jiejie = "Saber_jiejie";
		/// <summary>
		/// <color=#808080>风王结界</color>
		/// <color=white>造成伤害时施加1层</color>「<color=#A0AC8F>风蚀</color>」
		/// 无视</color>「嘲讽</color>」
		/// <color=#808080>此宝具是被强力魔术守护着，而并非剑本体是透明的。
		/// 缠住剑身的风改变了光的折射率，从而使得剑的形状变得看不见。
		/// 即使并没有到达真空状态，包裹着剑身的风也是非常致命的，能够增加斩击的破坏力。</color>
		/// </summary>
        public static string Buff_Saber_jiejie_A = "Saber_jiejie_A";
		/// <summary>
		/// <color=#808080>风王结界</color>
		/// 攻击力+25%
		/// 暴击率+20%
		/// 暴击伤害+50%
		/// 闪避率+10%
		/// 造成伤害时附加一层<color=#A0AC8F></color>「<color=#A0AC8F>风蚀</color>」
		/// 被攻击概率小幅减少
		/// </summary>
        public static string SkillKeyword_Saber_jiejie_A_D = "Saber_jiejie_A_D";
		/// <summary>
		/// <color=#808080>风王结界·散</color>
		/// 被攻击时对目标施加1层「<color=#A0AC8F>风蚀</color>」
		/// 每回合获得8点护盾
		/// <color=#808080>作为风王结界的别种应用，比起之前锋锐的形态，现在这一形态更适合守护，这或许亦是吾王守护他人的意愿取得具象的证明吧。</color>
		/// </summary>
        public static string Buff_Saber_jiejie_B = "Saber_jiejie_B";
		/// <summary>
		/// <color=#808080>风王结界·散</color>
		/// 保护体力极限
		/// 攻击力-50%
		/// 暴击率-50%
		/// 暴击伤害-50%
		/// 受到伤害-30%
		/// 闪避+10%
		/// 每回合获得8点保护罩
		/// 受到伤害时对其施加1层<color=#A0AC8F></color>「<color=#A0AC8F>风蚀</color>」
		/// 被攻击概率大幅提升
		/// </summary>
        public static string SkillKeyword_Saber_jiejie_B_D = "Saber_jiejie_B_D";
		/// <summary>
		/// <color=#808080>风王结界</color>
		/// 自身有<color=#808080>风王结界</color>或<color=#808080>风王结界·散</color>时，获得额外效果
		/// </summary>
        public static string SkillKeyword_Saber_jiejie_D = "Saber_jiejie_D";
        public static string SkillExtended_Saber_jiejie_ex = "Saber_jiejie_ex";
		/// <summary>
		/// 晋升
		/// <color=#808080>正在踏上闪耀之路</color>
		/// </summary>
        public static string Buff_Saber_jinsheng = "Saber_jinsheng";
        public static string SkillExtended_Saber_jinsheng_ex = "Saber_jinsheng_ex";
		/// <summary>
		/// 断钢
		/// 全部的护甲已被击碎！
		/// <color=#808080>此乃，断钢之剑！
		/// </summary>
        public static string Buff_Saber_jisui = "Saber_jisui";
		/// <summary>
		/// 风王连斩
		/// <color=green>魔力放出</color>(4):使法力消耗变为0
		/// <color=#808080>风王结界</color>:再次抽取此技能
		/// <color=#ED5C26>剑技</color>：根据目标身上「<color=#A0AC8F>风蚀</color>」的数量追击，每次造成（&a）点伤害
		/// <color=#A0AC8F></color><color=#808080><color=green>
		/// </summary>
        public static string Skill_Saber_lianzhan = "Saber_lianzhan";
        public static string SkillExtended_Saber_lianzhan_ex = "Saber_lianzhan_ex";
        public static string Skill_Saber_lianzhan_plus = "Saber_lianzhan_plus";
		/// <summary>
		/// 王之领导
		/// <color=green></color>赋予其他友方「无畏」，赋予自身「<color=red>英雄作成</color>」</color>
		/// <color=green>魔力放出</color>(3):抽取2个技能
		/// <color=#F0BCAF>孤独な巡礼</color>:将「<color=red>英雄作成</color>」改为20点防护墙
		/// <color=#808080>吾王!
		///  阿尔托莉雅，具有指挥军团的天生才能。贯彻清廉正直，大公无私的王。 其公正令骑士们愿意守护于她的身旁，令民众们在对贫困的忍耐中看到了希望。她的王者之路并不是为了统帅少数强者，而是为了领导更多无力之人而存在的。</color>
		/// </summary>
        public static string Skill_Saber_lingdao = "Saber_lingdao";
		/// <summary>
		/// 无畏
		/// <color=#808080>吾王剑之所指，吾等心之所向！</color>
		/// </summary>
        public static string Buff_Saber_lingdao_B = "Saber_lingdao_B";
		/// <summary>
		/// 阻止自身获得无畏
		/// </summary>
        public static string SkillExtended_Saber_lingdao_ex = "Saber_lingdao_ex";
		/// <summary>
		/// <color=#A02C1F>令咒</color>
		/// 抽到时，抽取1个技能
		/// 一场战斗只能使用3次
		/// 释放后，从3个效果中进行选择
		/// <color=#808080>我以令咒之名，命令你——</color>
		/// </summary>
        public static string Skill_Saber_lingzhou = "Saber_lingzhou";
		/// <summary>
		/// <color=#A02C1F>令咒</color>
		/// 获得2点法力值
		/// </summary>
        public static string Skill_Saber_lingzhou_1 = "Saber_lingzhou_1";
        public static string SkillExtended_Saber_lingzhou_1_ex = "Saber_lingzhou_1_ex";
		/// <summary>
		/// <color=#A02C1F>令咒</color>
		/// 超额恢复目标30点生命值
		/// </summary>
        public static string Skill_Saber_lingzhou_2 = "Saber_lingzhou_2";
        public static string SkillExtended_Saber_lingzhou_2_ex = "Saber_lingzhou_2_ex";
		/// <summary>
		/// <color=#A02C1F>令咒</color>
		/// 抽取2个技能
		/// </summary>
        public static string Skill_Saber_lingzhou_3 = "Saber_lingzhou_3";
        public static string SkillExtended_Saber_lingzhou_3_ex = "Saber_lingzhou_3_ex";
        public static string SkillExtended_Saber_lingzhou_ex = "Saber_lingzhou_ex";
		/// <summary>
		/// 龙之炉心
		/// 每回合回复4点生命值并获得1点魔力；此外，在释放技能时，会获得1点魔力。
		/// </summary>
        public static string Buff_Saber_luxin = "Saber_luxin";
		/// <summary>
		/// <color=blue>魔力</color>
		/// <color=#808080>阿尔托莉雅积攒的</color><color=blue>魔力</color>
		/// 每点<color=blue>魔力</color>能够增加5%的攻击力和2%的暴击率
		/// </summary>
        public static string Buff_Saber_moli = "Saber_moli";
		/// <summary>
		/// <color=blue>魔力</color>
		/// </color>阿尔托莉雅所积攒的<color=blue>魔力</color>
		/// </summary>
        public static string SkillKeyword_Saber_moli_D = "Saber_moli_D";
		/// <summary>
		/// 弱点战破
		/// 根据目标持有的减益，对目标造成每回合减益伤害量乘以剩余回合数的2倍的额外伤害。对方生命值在50%以下时，无视对方防御。
		/// <color=#ED5C26>剑技</color>：以暴击形式命中
		/// </summary>
        public static string Skill_Saber_ruodian = "Saber_ruodian";
        public static string SkillExtended_Saber_ruodian_ex = "Saber_ruodian_ex";
		/// <summary>
		/// <color=#F0BC1F>闪耀之路</color>
		/// 无法打出
		/// 战斗开始时，放在牌库最上方
		/// 根据所自身拥有的技能类型对其施加额外效果
		/// 抽到这个技能时，额外抽取一个技能
		/// 每打出一个技能获得一层「晋升」标记，累计10层时，此技能可以打出。
		/// 打出时，生成「<color=#F0BC1F>擢升宝具·闪耀于终焉之枪</color>」
		/// </summary>
        public static string Skill_Saber_shanyao = "Saber_shanyao";
        public static string SkillExtended_Saber_shanyao_base = "Saber_shanyao_base";
        public static string SkillExtended_Saber_shanyao_ex = "Saber_shanyao_ex";
        public static string SkillExtended_Saber_shanyao_ex2 = "Saber_shanyao_ex2";
		/// <summary>
		/// 星耀
		/// 施加「星光」
		/// </summary>
        public static string SkillExtended_Saber_shanyao_ex_ally = "Saber_shanyao_ex_ally";
		/// <summary>
		/// 暗耀
		/// 对目标施加「星蚀」
		/// </summary>
        public static string SkillExtended_Saber_shanyao_ex_enemy = "Saber_shanyao_ex_enemy";
		/// <summary>
		/// <color=#F00C6F>圣剑解放</color>
		/// 打出时弃置手中所有的攻击技能，每弃置一张，额外造成10点伤害。
		/// 若击杀目标，则再次生成此技能。
		/// <color=green>魔力填充</color>
		/// <color=#ED5C26>剑技</color>：抽取弃置技能数量一半的数量的技能（向下取整）
		/// </summary>
        public static string Skill_Saber_shengjian = "Saber_shengjian";
        public static string SkillExtended_Saber_shengjian_ex = "Saber_shengjian_ex";
		/// <summary>
		/// <color=#F0BC1F>擢升宝具·闪耀于终焉之枪</color>
		/// 不可闪避，一击必杀！
		/// 面对Boss时，斩杀低于40%最大生命值的目标
		/// </summary>
        public static string Skill_Saber_shengqiang = "Saber_shengqiang";
        public static string SkillExtended_Saber_shengqiang_ex = "Saber_shengqiang_ex";
		/// <summary>
		/// <color=green>魔力填充</color>
		/// 将自身的<color=blue>魔力</color>全部填充，每填充1点魔力，降低1点法力消耗
		/// </summary>
        public static string SkillKeyword_Saber_tianchong = "Saber_tianchong";
		/// <summary>
		/// 突进斩
		/// 抽取1个技能
		/// <color=#ED5C26>剑技</color>：赋予「嘲讽」
		/// </summary>
        public static string Skill_Saber_tujin = "Saber_tujin";
		/// <summary>
		/// 无敌
		/// 免疫一回合伤害
		/// </summary>
        public static string Buff_Saber_wudi = "Saber_wudi";
		/// <summary>
		/// 星光
		/// <color=#808080>她是星的宠儿
		/// </summary>
        public static string Buff_Saber_xingguang_A = "Saber_xingguang_A";
		/// <summary>
		/// 星蚀
		/// <color=#808080>直视闪耀的星光，必会付出代价。</color>
		/// </summary>
        public static string Buff_Saber_xingguang_B = "Saber_xingguang_B";
		/// <summary>
		/// 星光
		/// 攻击力+10%
		/// 防御力+5%
		/// <color=#808080>她是星的宠儿</color>
		/// </summary>
        public static string SkillKeyword_Saber_xingguang_D = "Saber_xingguang_D";
        public static string SkillExtended_Saber_xingguang_ex = "Saber_xingguang_ex";
		/// <summary>
		/// 星陨斩
		/// 赋予「断钢」
		/// <color=#ED5C26>剑技</color>：以暴击形式命中
		/// </summary>
        public static string Skill_Saber_xingyun = "Saber_xingyun";
        public static string SkillExtended_Saber_xingyun_ex = "Saber_xingyun_ex";
		/// <summary>
		/// 炫目
		/// 攻击力-10%
		/// 闪避率-5%
		/// <color=#808080>直视强烈的星光，必会付出代价。</color></color>
		/// </summary>
        public static string SkillKeyword_Saber_xuanmu_D = "Saber_xuanmu_D";
		/// <summary>
		/// <color=#F0BC1F>吟唱中</color>
		/// 无法行动
		/// <color=#808080>
		/// 这光辉乃是星辰的希望，照亮大地的生命之证！见证吧，誓约胜利之剑——！</color>
		/// </summary>
        public static string Buff_Saber_xuli = "Saber_xuli";
		/// <summary>
		/// <color=#F0BCAF>孤独な巡礼</color>
		/// 不与「<color=red>英雄作成</color>」</color>共存
		/// 每回合获得1点<color=blue>魔力</color>
		/// <color=#808080>孤独，亦是成王的代价
		/// 遥想那个风光明媚的午后
		/// 那位清纯娇俏的少女，是否会后悔拔出了那把剑呢?
		/// 或许，她从未后悔......</color>
		/// </summary>
        public static string Buff_Saber_xunli = "Saber_xunli";
		/// <summary>
		/// <color=#F0BCAF>孤独な巡礼</color>
		/// 自身拥有「<color=#F0BCAF>孤独な巡礼</color>」时，获得额外效果
		/// </summary>
        public static string SkillKeyword_Saber_xunli_D = "Saber_xunli_D";
        public static string SkillExtended_Saber_xunli_ex = "Saber_xunli_ex";
		/// <summary>
		/// <color=red>英雄作成</color>
		/// 不与「 <color=#F0BCAF>孤独な巡礼</color>」共存
		/// <color=#808080>成为王的理由，非是拔出了圣剑
		/// 倒不如说，正因为是王
		/// 所以才能拔出圣剑......</color>
		/// </summary>
        public static string Buff_Saber_yingxiong_B = "Saber_yingxiong_B";
		/// <summary>
		/// 招架
		/// <color=#ED5C26>剑技</color>：对自己也施加「招架」
		/// </summary>
        public static string Skill_Saber_zhaojia = "Saber_zhaojia";
		/// <summary>
		/// 招架
		/// 受到攻击时对其造成自身30%最大生命值（&a）点伤害
		/// <color=#808080>如此羸弱的攻击！</color>
		/// </summary>
        public static string Buff_Saber_zhaojia_B = "Saber_zhaojia_B";
        public static string SkillExtended_Saber_zhaojia_ex = "Saber_zhaojia_ex";
        public static string Skill_Saber_zhaojia_fanji = "Saber_zhaojia_fanji";
        public static string SkillExtended_Saber_zhaojia_fanji_ex = "Saber_zhaojia_fanji_ex";
		/// <summary>
		/// 整备
		/// 无法行动。
		/// 弃置自身技能时解除。
		/// </summary>
        public static string Buff_Saber_zhengbei = "Saber_zhengbei";
        public static string Buff_Saber_zhengbei_huzhao = "Saber_zhengbei_huzhao";
		/// <summary>
		/// <color=red>英雄作成</color>
		/// 赋予自身「<color=red>英雄作成</color>」并提升1点最大法力值
		/// <color=#808080>成为王的理由，非是拔出了圣剑
		/// 倒不如说，正因为是王
		/// 所以才能拔出圣剑......</color>
		/// </summary>
        public static string Skill_Saber_zuocheng = "Saber_zuocheng";
        public static string SkillExtended_Saber_zuocheng_ex = "Saber_zuocheng_ex";
        public static string SkillEffect_SE_S_Saber_bihu = "SE_S_Saber_bihu";
        public static string SkillEffect_SE_S_Saber_chongzheng = "SE_S_Saber_chongzheng";
        public static string SkillEffect_SE_S_Saber_cunxu = "SE_S_Saber_cunxu";
        public static string SkillEffect_SE_S_Saber_duangang = "SE_S_Saber_duangang";
        public static string SkillEffect_SE_S_Saber_Excalicur = "SE_S_Saber_Excalicur";
        public static string SkillEffect_SE_S_Saber_fengwang = "SE_S_Saber_fengwang";
        public static string SkillEffect_SE_S_Saber_fengya = "SE_S_Saber_fengya";
        public static string SkillEffect_SE_S_Saber_gudu = "SE_S_Saber_gudu";
        public static string SkillEffect_SE_S_Saber_jiejie = "SE_S_Saber_jiejie";
        public static string SkillEffect_SE_S_Saber_lianzhan = "SE_S_Saber_lianzhan";
        public static string SkillEffect_SE_S_Saber_lingdao = "SE_S_Saber_lingdao";
        public static string SkillEffect_SE_S_Saber_ruodian = "SE_S_Saber_ruodian";
        public static string SkillEffect_SE_S_Saber_shengjian = "SE_S_Saber_shengjian";
        public static string SkillEffect_SE_S_Saber_tujin = "SE_S_Saber_tujin";
        public static string SkillEffect_SE_S_Saber_xingguang = "SE_S_Saber_xingguang";
        public static string SkillEffect_SE_S_Saber_xingyun = "SE_S_Saber_xingyun";
        public static string SkillEffect_SE_S_Saber_zuocheng = "SE_S_Saber_zuocheng";
        public static string SkillEffect_SE_Tick_SaberBuff = "SE_Tick_SaberBuff";
        public static string SkillEffect_SE_Tick_Saber_challenge_plus = "SE_Tick_Saber_challenge_plus";
        public static string SkillEffect_SE_Tick_Saber_fengshi = "SE_Tick_Saber_fengshi";
        public static string SkillEffect_SE_Tick_Saber_luxin = "SE_Tick_Saber_luxin";
        public static string SkillEffect_SE_T_Saber_cunxu = "SE_T_Saber_cunxu";
        public static string SkillEffect_SE_T_Saber_duangang = "SE_T_Saber_duangang";
        public static string SkillEffect_SE_T_Saber_Excalicur = "SE_T_Saber_Excalicur";
        public static string SkillEffect_SE_T_Saber_fengwang = "SE_T_Saber_fengwang";
        public static string SkillEffect_SE_T_Saber_fengya = "SE_T_Saber_fengya";
        public static string SkillEffect_SE_T_Saber_gudu = "SE_T_Saber_gudu";
        public static string SkillEffect_SE_T_Saber_lianzhan = "SE_T_Saber_lianzhan";
        public static string SkillEffect_SE_T_Saber_lianzhan_plus = "SE_T_Saber_lianzhan_plus";
        public static string SkillEffect_SE_T_Saber_lingzhou_2 = "SE_T_Saber_lingzhou_2";
        public static string SkillEffect_SE_T_Saber_ruodian = "SE_T_Saber_ruodian";
        public static string SkillEffect_SE_T_Saber_shengjian = "SE_T_Saber_shengjian";
        public static string SkillEffect_SE_T_Saber_shengqiang = "SE_T_Saber_shengqiang";
        public static string SkillEffect_SE_T_Saber_tujin = "SE_T_Saber_tujin";
        public static string SkillEffect_SE_T_Saber_xingguang = "SE_T_Saber_xingguang";
        public static string SkillEffect_SE_T_Saber_xingyun = "SE_T_Saber_xingyun";
        public static string SkillEffect_SE_T_Saber_zhaojia = "SE_T_Saber_zhaojia";
        public static string SkillEffect_SE_T_Saber_zhaojia_fanji = "SE_T_Saber_zhaojia_fanji";

    }

    public static class ModLocalization
    {

    }
}