using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
namespace FeiyapTank
{
    /// <summary>
    /// 神速
    /// 其他调查员受到攻击时，自身代为承受。
    /// 触发时减少 1 层。
    /// </summary>
    public class B_FeiyapTank_7 : Buff, IP_TargetedAlly
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            bool flag = false;
            for (int i = 0 ; i < SaveTargets.Count ; i++)
            {
                if (SaveTargets[i] == base.BChar)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int j = 0 ; j < SaveTargets.Count ; j++)
                {
                    if (SaveTargets[j] != this.BChar)
                    {
                        CopyCharImageWithFade(SaveTargets[j].GetPos());

                        SaveTargets[j] = base.BChar;
                        EffectView.TextOutSimple(this.BChar, this.BuffData.Name);

                        this.SelfStackDestroy();
                        return null;
                    }
                }
            }
            return null;
        }

        public UIComponent UI;
        
        public void CopyCharImageWithFade(Vector3 offsetPosition, float delayBeforeFade = 1f, float fadeDuration = 0.5f)
        {
            if (this.BChar.UI == null || this.BChar.UI.CharImage == null)
            {
                Debug.LogWarning("CharImage reference is missing!");
                return;
            }

            UI = this.BChar.UI;
            
            GameObject copiedImage = BattleSystem.Instantiate(UI.CharImage, UI.CharImage.transform.parent);
            
            copiedImage.transform.localPosition = UI.CharImage.transform.localPosition + offsetPosition;
            copiedImage.SetActive(true);
            BattleSystem.instance.StartCoroutine(FadeOutAndDestroy(copiedImage, delayBeforeFade, fadeDuration));
        }

        private IEnumerator FadeOutAndDestroy(GameObject targetObject, float delay, float fadeDuration)
        {
            yield return new WaitForSeconds(delay);
            
            Image image = targetObject.GetComponent<Image>();
            SpriteRenderer spriteRenderer = null;
            
            if (image == null)
            {
                spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            }
            
            float elapsedTime = 0f;
            Color originalColor = image != null ? image.color : spriteRenderer.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

                if (image != null)
                {
                    Color newColor = image.color;
                    newColor.a = alpha;
                    image.color = newColor;
                }
                else if (spriteRenderer != null)
                {
                    Color newColor = spriteRenderer.color;
                    newColor.a = alpha;
                    spriteRenderer.color = newColor;
                }

                yield return null;
            }
            
            BattleSystem.Destroy(targetObject);
        }
    }
}