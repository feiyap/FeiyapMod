using ChronoArkMod;
namespace BossPhoenix
{
    public static class ModItemKeys
    {
		/// <summary>
		/// 凤凰
		/// </summary>
        public static string Enemy_Boss_Phoenix = "Boss_Phoenix";
		/// <summary>
		/// 耍赖皮
		/// 凤凰就算被打至1血也会耍性子赖着不死……
		/// 聪明的露西有没有办法哄好它呢？
		/// </summary>
        public static string Buff_B_BossPhoenix_P = "B_BossPhoenix_P";
		/// <summary>
		/// 好疼…
		/// 受到痛苦伤害增加100%。
		/// </summary>
        public static string Buff_B_BossPhoenix_Pain = "B_BossPhoenix_Pain";
        public static string EnemyQueue_Queue_BossPhoenix = "Queue_BossPhoenix";
		/// <summary>
		/// 拦路的凤凰
		/// 好无聊啊！
		/// 正因如此，我们来玩猜谜游戏吧？
		/// 赢了的话有奖励，输了的话有惩罚！
		/// 「不知从何处出现的凤凰拦住了你们……」
		/// Button
		/// ButtonToolTip
		/// </summary>
        public static string RandomEvent_RE_BossPhoenix = "RE_BossPhoenix";
        public static string SkillEffect_SE_T_S_BossPhoenix_0 = "SE_T_S_BossPhoenix_0";
        public static string SkillEffect_SE_T_S_BossPhoenix_1 = "SE_T_S_BossPhoenix_1";
        public static string SkillEffect_SE_T_S_BossPhoenix_2 = "SE_T_S_BossPhoenix_2";
        public static string SkillEffect_SE_T_S_BossPhoenix_FindBread = "SE_T_S_BossPhoenix_FindBread";
        public static string SkillEffect_SE_T_S_BossPhoenix_SmallWorld = "SE_T_S_BossPhoenix_SmallWorld";
        public static string SkillEffect_SE_T_S_BossPhoenix_ThrowBread = "SE_T_S_BossPhoenix_ThrowBread";
		/// <summary>
		/// 猜谜游戏
		/// 伟大的凤凰大人在心中想象一个技能！请在8次机会之内猜中凤凰大人想的那个技能。
		/// 若是猜错，则全队受到当前猜错次数的痛苦伤害；
		/// 但是，仁慈的凤凰大人会仁慈地告诉你一些有关的信息。
		/// 若是成功猜对，仁慈的凤凰大人会仁慈地将这个技能送给你（若没有对应持有者，则随机选择持有者）。
		/// 若是输掉3局猜谜游戏，凤凰大人会觉得你在敷衍它，立刻结束战斗并把你打回床上！
		/// </summary>
        public static string Skill_S_BossPhoenix_0 = "S_BossPhoenix_0";
		/// <summary>
		/// 啄
		/// 施加“眩晕”：100%干扰成功率。
		/// </summary>
        public static string Skill_S_BossPhoenix_1 = "S_BossPhoenix_1";
		/// <summary>
		/// 发脾气
		/// 施加“好疼…”：80%弱化成功率；2回合；受到痛苦伤害增加100%。
		/// </summary>
        public static string Skill_S_BossPhoenix_2 = "S_BossPhoenix_2";
		/// <summary>
		/// 找面包（很急！）
		/// 获得1个面包。
		/// </summary>
        public static string Skill_S_BossPhoenix_FindBread = "S_BossPhoenix_FindBread";
		/// <summary>
		/// 小世界现象
		/// 放逐目标技能。
		/// 那之后，展示牌堆和弃牌堆中、满足以下条件的技能。选择并放逐其中 1 个技能（此时，条件中被放逐的技能改变），那之后，再次展示牌库中、满足以下条件的技能。选择并将其中 1 个技能拿到手中：
		/// 在“费用”、“指向”、“持有者”、“倍率”中仅有一项与被放逐的技能相同。
		/// </summary>
        public static string Skill_S_BossPhoenix_SmallWorld = "S_BossPhoenix_SmallWorld";
		/// <summary>
		/// 扔面包（很急！）
		/// 消耗1个面包。
		/// </summary>
        public static string Skill_S_BossPhoenix_ThrowBread = "S_BossPhoenix_ThrowBread";

    }

    public static class ModLocalization
    {
		/// <summary>
		/// Korean:
		/// 맞혔어! 이 스킬 줄게.
		/// English:
		/// You got it! I'll give you this skill.
		/// Japanese:
		/// 当たった！このスキルあげる。
		/// Chinese:
		/// 猜对了！这个技能就送给你吧。
		/// Chinese-TW:
		/// 猜對了！這個技能就送給你吧。
		/// </summary>
        public static string BattleDiaBoss_PhoenixCorrect => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Correct");
		/// <summary>
		/// Korean:
		/// 대충 하는 거지?
		/// English:
		/// You're just brushing me off?
		/// Japanese:
		/// 適当にしてるでしょ？
		/// Chinese:
		/// 你这是在敷衍我吧？
		/// Chinese-TW:
		/// 你這是在敷衍我吧？
		/// </summary>
        public static string BattleDiaBoss_PhoenixFail => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Fail");
		/// <summary>
		/// Korean:
		/// 빵이다! 흥… 이번엔 봐줄게.
		/// English:
		/// Bread! Hmph... I'll let you win this time.
		/// Japanese:
		/// パンだ！ふん…今回は特別に許してあげる。
		/// Chinese:
		/// 是面包！哼……这次就特别饶了你们吧。
		/// Chinese-TW:
		/// 是麵包！哼……這次就特別饒了你們吧。
		/// </summary>
        public static string BattleDiaBoss_PhoenixSoothe => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Soothe");
		/// <summary>
		/// Korean:
		/// 1 남았다고 죽지 않아! 
		/// English:
		/// I won't die at 1 HP! 
		/// Japanese:
		/// 1残っても死なないよ！
		/// Chinese:
		/// 才1血我才不倒下呢！
		/// Chinese-TW:
		/// 才1血我才不倒下呢！
		/// </summary>
        public static string BattleDiaBoss_PhoenixStubborn => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Stubborn");
		/// <summary>
		/// Korean:
		/// 심심해!
		/// English:
		/// I'm so bored!
		/// Japanese:
		/// つまんない!
		/// Chinese:
		/// 好无聊啊！
		/// Chinese-TW:
		/// 好無聊啊！
		/// </summary>
        public static string BattleDiaBoss_PhoenixText1 => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Text1");
		/// <summary>
		/// Korean:
		/// 그러니까 수수께끼 놀이 하자! 이기면 보상
		/// English:
		///  So let's play a riddle game! Win and get a reward!
		/// Japanese:
		/// だからクイズしよう！勝てばご褒美
		/// Chinese:
		/// 正因如此，我们来玩猜谜游戏吧？赢了有奖励！
		/// Chinese-TW:
		/// 正因如此，我們來玩猜謎遊戲吧？贏了有獎勵！
		/// </summary>
        public static string BattleDiaBoss_PhoenixText2 => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Text2");
		/// <summary>
		/// Korean:
		/// 지면 벌이야!
		/// English:
		/// Lose and get a punishment!
		/// Japanese:
		/// 負けたら罰ゲーム!
		/// Chinese:
		/// 输了的话有惩罚！
		/// Chinese-TW:
		/// 輸了的話有懲罰！
		/// </summary>
        public static string BattleDiaBoss_PhoenixText3 => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Phoenix/Text3");
		/// <summary>
		/// Korean:
		/// 없음
		/// English:
		/// No
		/// Japanese:
		/// なし
		/// Chinese:
		/// 无
		/// Chinese-TW:
		/// 無
		/// </summary>
        public static string RiddleBuffNone => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/BuffNone");
		/// <summary>
		/// Korean:
		/// 있음({0})
		/// English:
		/// Yes({0})
		/// Japanese:
		/// あり({0})
		/// Chinese:
		/// 有({0})
		/// Chinese-TW:
		/// 有({0})
		/// </summary>
        public static string RiddleBuffYes => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/BuffYes");
		/// <summary>
		/// Korean:
		/// 부가버프
		/// English:
		/// Extra Buff
		/// Japanese:
		/// 追加バフ
		/// Chinese:
		/// 附加BUFF
		/// Chinese-TW:
		/// 附加BUFF
		/// </summary>
        public static string RiddleColBuff => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColBuff");
		/// <summary>
		/// Korean:
		/// 코스트
		/// English:
		/// Cost
		/// Japanese:
		/// コスト
		/// Chinese:
		/// 费用
		/// Chinese-TW:
		/// 費用
		/// </summary>
        public static string RiddleColCost => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColCost");
		/// <summary>
		/// Korean:
		/// 배율
		/// English:
		/// Multiplier
		/// Japanese:
		/// 倍率
		/// Chinese:
		/// 倍率
		/// Chinese-TW:
		/// 倍率
		/// </summary>
        public static string RiddleColMult => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColMult");
		/// <summary>
		/// Korean:
		/// 스킬명
		/// English:
		/// Name
		/// Japanese:
		/// スキル名
		/// Chinese:
		/// 技能名
		/// Chinese-TW:
		/// 技能名
		/// </summary>
        public static string RiddleColName => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColName");
		/// <summary>
		/// Korean:
		/// 소유자
		/// English:
		/// Owner
		/// Japanese:
		/// 所有者
		/// Chinese:
		/// 持有者
		/// Chinese-TW:
		/// 持有者
		/// </summary>
        public static string RiddleColOwner => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColOwner");
		/// <summary>
		/// Korean:
		/// 대상
		/// English:
		/// Target
		/// Japanese:
		/// 対象
		/// Chinese:
		/// 目标
		/// Chinese-TW:
		/// 目標
		/// </summary>
        public static string RiddleColTarget => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColTarget");
		/// <summary>
		/// Korean:
		/// 유형
		/// English:
		/// Type
		/// Japanese:
		/// タイプ
		/// Chinese:
		/// 技能类型
		/// Chinese-TW:
		/// 技能類型
		/// </summary>
        public static string RiddleColType => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/ColType");
		/// <summary>
		/// Korean:
		/// 확인
		/// English:
		/// OK
		/// Japanese:
		/// 決定
		/// Chinese:
		/// 确定
		/// Chinese-TW:
		/// 確定
		/// </summary>
        public static string RiddleConfirm => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Confirm");
		/// <summary>
		/// Korean:
		/// 다름
		/// English:
		/// Different
		/// Japanese:
		/// 違う
		/// Chinese:
		/// 不同
		/// Chinese-TW:
		/// 不同
		/// </summary>
        public static string RiddleDifferent => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Different");
		/// <summary>
		/// Korean:
		/// 포기
		/// English:
		/// Give Up
		/// Japanese:
		/// 諦める
		/// Chinese:
		/// 放弃
		/// Chinese-TW:
		/// 放棄
		/// </summary>
        public static string RiddleGiveUp => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/GiveUp");
		/// <summary>
		/// Korean:
		/// 틀렸어! ({0}번째)
		/// 코스트: {1}
		/// 대상: {2}
		/// 소유자: {3}
		/// 배율: {4}
		/// English:
		/// Wrong! (Guess {0})
		/// Cost: {1}
		/// Target: {2}
		/// Owner: {3}
		/// Multiplier: {4}
		/// Japanese:
		/// はずれ！（{0}回目）
		/// コスト：{1}
		/// 対象：{2}
		/// 所有者：{3}
		/// 倍率：{4}
		/// Chinese:
		/// 猜错了！（第 {0} 次）
		/// 费用：{1}
		/// 指向：{2}
		/// 持有者：{3}
		/// 倍率：{4}
		/// Chinese-TW:
		/// 猜錯了！（第 {0} 次）
		/// 費用：{1}
		/// 指向：{2}
		/// 持有者：{3}
		/// 倍率：{4}
		/// </summary>
        public static string RiddleHint => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Hint");
		/// <summary>
		/// Korean:
		/// 정규식으로 스킬을 검색한 뒤 확인을 누르세요.
		/// English:
		/// Search a skill with regex
		/// Japanese:
		///  then press OK.
		/// Chinese:
		/// 正規表現でスキルを検索して決定。
		/// Chinese-TW:
		/// 用正则搜索技能，然后按回车或点确定。
		/// </summary>
        public static string RiddleInputHint => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/InputHint");
		/// <summary>
		/// Korean:
		/// 검색 결과 없음
		/// English:
		/// No matches
		/// Japanese:
		/// 一致なし
		/// Chinese:
		/// 无匹配结果
		/// Chinese-TW:
		/// 無匹配結果
		/// </summary>
        public static string RiddleNoMatch => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/NoMatch");
		/// <summary>
		/// Korean:
		/// 해당하는 스킬이 없습니다. 다시 입력하세요.
		/// English:
		/// No such skill. Try again.
		/// Japanese:
		/// 該当スキルがありません。再入力して。
		/// Chinese:
		/// 没有找到对应技能，请重新输入。
		/// Chinese-TW:
		/// 沒有找到對應技能，請重新輸入。
		/// </summary>
        public static string RiddleNotExist => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/NotExist");
		/// <summary>
		/// Korean:
		/// {0}개가 검색되었습니다. 더 구체적으로 입력하세요.
		/// English:
		/// {0} skills matched. Be more specific.
		/// Japanese:
		/// {0}件ヒット。もっと具体的に入力して。
		/// Chinese:
		/// 匹配到 {0} 个技能，请输入更精确的条件。
		/// Chinese-TW:
		/// 匹配到 {0} 個技能，請輸入更精確的條件。
		/// </summary>
        public static string RiddleNotUnique => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/NotUnique");
		/// <summary>
		/// Korean:
		/// 루시
		/// English:
		/// Lucy
		/// Japanese:
		/// ルーシー
		/// Chinese:
		/// 露西
		/// Chinese-TW:
		/// 露西
		/// </summary>
        public static string RiddleOwnerLucy => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/OwnerLucy");
		/// <summary>
		/// Korean:
		/// 스킬 이름 / 정규식
		/// English:
		/// Skill name / regex
		/// Japanese:
		/// スキル名 / 正規表現
		/// Chinese:
		/// 技能名 / 正则表达式
		/// Chinese-TW:
		/// 技能名 / 正則表達式
		/// </summary>
        public static string RiddlePlaceholder => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Placeholder");
		/// <summary>
		/// Korean:
		/// 이번 퀴즈는 패배. ({0}/{1})
		/// English:
		/// You lost this riddle. ({0}/{1})
		/// Japanese:
		/// このクイズは負け。({0}/{1})
		/// Chinese:
		/// 这局猜谜你输了。（{0}/{1}）
		/// Chinese-TW:
		/// 這局猜謎你輸了。（{0}/{1}）
		/// </summary>
        public static string RiddleRoundLost => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/RoundLost");
		/// <summary>
		/// Korean:
		/// 같음
		/// English:
		/// Same
		/// Japanese:
		/// 同じ
		/// Chinese:
		/// 相同
		/// Chinese-TW:
		/// 相同
		/// </summary>
        public static string RiddleSame => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Same");
		/// <summary>
		/// Korean:
		/// 봉황이 상상한 스킬을 고르세요.
		/// English:
		/// Pick the skill Phoenix imagined.
		/// Japanese:
		/// 鳳凰が思い浮かべたスキルを選んで。
		/// Chinese:
		/// 请选择凤凰大人想象中的那个技能。
		/// Chinese-TW:
		/// 請選擇鳳凰大人想像中的那個技能。
		/// </summary>
        public static string RiddleSelectTitle => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/SelectTitle");
		/// <summary>
		/// Korean:
		/// 무대상
		/// English:
		/// No Target
		/// Japanese:
		/// 対象なし
		/// Chinese:
		/// 无指向
		/// Chinese-TW:
		/// 無指向
		/// </summary>
        public static string RiddleTargetMisc => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/Misc");
		/// <summary>
		/// Korean:
		/// 아군 전체
		/// English:
		/// All Allies
		/// Japanese:
		/// 味方全体
		/// Chinese:
		/// 全体友军
		/// Chinese-TW:
		/// 全體友軍
		/// </summary>
        public static string RiddleTargetall_ally => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/all_ally");
		/// <summary>
		/// Korean:
		/// 적 전체
		/// English:
		/// All Enemies
		/// Japanese:
		/// 敵全体
		/// Chinese:
		/// 全体敌人
		/// Chinese-TW:
		/// 全體敵人
		/// </summary>
        public static string RiddleTargetall_enemy => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/all_enemy");
		/// <summary>
		/// Korean:
		/// 모든 스킬
		/// English:
		/// All Skills
		/// Japanese:
		/// 全スキル
		/// Chinese:
		/// 全体技能
		/// Chinese-TW:
		/// 全體技能
		/// </summary>
        public static string RiddleTargetallskill => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/allskill");
		/// <summary>
		/// Korean:
		/// 아군 하나
		/// English:
		/// Single Ally
		/// Japanese:
		/// 味方単体
		/// Chinese:
		/// 指向友军
		/// Chinese-TW:
		/// 指向友軍
		/// </summary>
        public static string RiddleTargetally => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/ally");
		/// <summary>
		/// Korean:
		/// 전투불능 아군
		/// English:
		/// Downed Ally
		/// Japanese:
		/// 戦闘不能の味方
		/// Chinese:
		/// 无法战斗的友军
		/// Chinese-TW:
		/// 無法戰鬥的友軍
		/// </summary>
        public static string RiddleTargetdeathally => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/deathally");
		/// <summary>
		/// Korean:
		/// 적 하나
		/// English:
		/// Single Enemy
		/// Japanese:
		/// 敵単体
		/// Chinese:
		/// 指向敌人
		/// Chinese-TW:
		/// 指向敵人
		/// </summary>
        public static string RiddleTargetenemy => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/enemy");
		/// <summary>
		/// Korean:
		/// 다른 아군
		/// English:
		/// Other Ally
		/// Japanese:
		/// 他の味方
		/// Chinese:
		/// 其他友军
		/// Chinese-TW:
		/// 其他友軍
		/// </summary>
        public static string RiddleTargetotherally => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/otherally");
		/// <summary>
		/// Korean:
		/// 무작위 적
		/// English:
		/// Random Enemy
		/// Japanese:
		/// ランダムな敵
		/// Chinese:
		/// 随机敌人
		/// Chinese-TW:
		/// 隨機敵人
		/// </summary>
        public static string RiddleTargetrandom_enemy => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/random_enemy");
		/// <summary>
		/// Korean:
		/// 자신
		/// English:
		/// Self
		/// Japanese:
		/// 自身
		/// Chinese:
		/// 自身
		/// Chinese-TW:
		/// 自身
		/// </summary>
        public static string RiddleTargetself => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/self");
		/// <summary>
		/// Korean:
		/// 스킬
		/// English:
		/// Skill
		/// Japanese:
		/// スキル
		/// Chinese:
		/// 指向技能
		/// Chinese-TW:
		/// 指向技能
		/// </summary>
        public static string RiddleTargetskill => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Target/skill");
		/// <summary>
		/// Korean:
		/// 공격
		/// English:
		/// Attack
		/// Japanese:
		/// 攻撃
		/// Chinese:
		/// 攻击
		/// Chinese-TW:
		/// 攻擊
		/// </summary>
        public static string RiddleTypeAttack => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Type/Attack");
		/// <summary>
		/// Korean:
		/// 회복
		/// English:
		/// Heal
		/// Japanese:
		/// 回復
		/// Chinese:
		/// 治疗
		/// Chinese-TW:
		/// 治療
		/// </summary>
        public static string RiddleTypeHeal => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Type/Heal");
		/// <summary>
		/// Korean:
		/// 루시
		/// English:
		/// Lucy
		/// Japanese:
		/// ルーシー
		/// Chinese:
		/// 露西
		/// Chinese-TW:
		/// 露西
		/// </summary>
        public static string RiddleTypeLucy => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Type/Lucy");
		/// <summary>
		/// Korean:
		/// 지원
		/// English:
		/// Support
		/// Japanese:
		/// 支援
		/// Chinese:
		/// 辅助
		/// Chinese-TW:
		/// 輔助
		/// </summary>
        public static string RiddleTypeSupport => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/Type/Support");
		/// <summary>
		/// Korean:
		/// 수수께끼 놀이
		/// English:
		/// Riddle Game
		/// Japanese:
		/// クイズ遊び
		/// Chinese:
		/// 猜谜游戏
		/// Chinese-TW:
		/// 猜謎遊戲
		/// </summary>
        public static string RiddleUiTitle => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/UiTitle");
		/// <summary>
		/// Korean:
		/// 오답 {0}/{1}
		/// English:
		/// Wrong {0}/{1}
		/// Japanese:
		/// 不正解 {0}/{1}
		/// Chinese:
		/// 猜错 {0}/{1}
		/// Chinese-TW:
		/// 猜錯 {0}/{1}
		/// </summary>
        public static string RiddleWrongCount => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("Riddle/WrongCount");
		/// <summary>
		/// Korean:
		/// 조건에 맞는 스킬 1장을 손으로.
		/// English:
		/// Add 1 matching skill to your hand.
		/// Japanese:
		/// 条件に合うスキルを1枚手札へ。
		/// Chinese:
		/// 选择 1 个满足条件的技能拿到手中。
		/// Chinese-TW:
		/// 選擇 1 個滿足條件的技能拿到手中。
		/// </summary>
        public static string SmallWorldDrawSelect => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("SmallWorld/DrawSelect");
		/// <summary>
		/// Korean:
		/// 조건에 맞는 스킬 1개를 추방하세요.
		/// English:
		/// Exile 1 skill that matches the condition.
		/// Japanese:
		/// 条件に合うスキルを1つ除外して。
		/// Chinese:
		/// 选择并放逐 1 个满足条件的技能。
		/// Chinese-TW:
		/// 選擇並放逐 1 個滿足條件的技能。
		/// </summary>
        public static string SmallWorldExileSelect => ModManager.getModInfo("BossPhoenix").localizationInfo.SystemLocalizationUpdate("SmallWorld/ExileSelect");

    }
}