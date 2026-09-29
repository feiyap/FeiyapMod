using System;
using System.Collections.Generic;

namespace FeiyapDestination
{
    /// <summary>
    /// 局内存档：缘起盟友列表与偏好职业。
    /// </summary>
    public class CV_FeiyapDestination : CustomValue
    {
        public List<string> YuanqiAllies = new List<string>();
        public int PreferredJob = (int)JobMode.Offense;

        public static CV_FeiyapDestination Instance
        {
            get
            {
                if (PlayData.TSavedata == null)
                {
                    return null;
                }
                CV_FeiyapDestination cv = PlayData.TSavedata.GetCustomValue<CV_FeiyapDestination>();
                if (cv == null)
                {
                    cv = new CV_FeiyapDestination();
                    PlayData.TSavedata.AddCustomValue(cv);
                }
                if (cv.YuanqiAllies == null)
                {
                    cv.YuanqiAllies = new List<string>();
                }
                return cv;
            }
        }

        public JobMode Job
        {
            get { return PreferredJob == (int)JobMode.Defense ? JobMode.Defense : JobMode.Offense; }
            set { PreferredJob = (int)value; }
        }

        public void AddYuanqiAlly(string charKey)
        {
            if (string.IsNullOrEmpty(charKey) || charKey == FeiyapKeys.Destination)
            {
                return;
            }
            if (!YuanqiAllies.Contains(charKey))
            {
                YuanqiAllies.Add(charKey);
            }
        }

        public int YuanqiStacks
        {
            get { return YuanqiAllies == null ? 0 : YuanqiAllies.Count; }
        }
    }

    public static class FriendshipUtil
    {
        /// <summary>金信物 = 好感度 5 级。</summary>
        public static bool HasGoldToken()
        {
            try
            {
                if (SaveManager.NowData == null || SaveManager.NowData.statistics == null)
                {
                    return false;
                }
                Statistics_Character data = SaveManager.NowData.statistics.GetCharData(FeiyapKeys.Destination);
                return data != null && data.FriendshipLV >= 5;
            }
            catch
            {
                return false;
            }
        }
    }
}
