using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_HPMP : MonoBehaviour
{
    [SerializeField] private Battle_Entity entity;
    [SerializeField] private Image FillHP;
    [SerializeField] private Image FillBackHP;
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private Image FillMP;
    [SerializeField] private Image FillBackMP;
    [SerializeField] private TextMeshProUGUI textMP;

    private void Update()
    {
        // 현재 체력 바 UI
        if (FillHP != null) FillHP.fillAmount = Utils.Percent(entity.HP, entity.MaxHP);
        // 체력 바 깎임 연출 UI
        if (FillBackHP != null) FillBackHP.fillAmount = Mathf.Lerp(FillBackHP.fillAmount, FillHP.fillAmount, Time.deltaTime * 2f);
        // 체력 Text
        if (textHP != null) textHP.text = $"{entity.HP:F0}/{entity.MaxHP:F0}";
        // 현재 마나 바 UI
        if (FillMP != null) FillMP.fillAmount = Utils.Percent(entity.MP, entity.MaxMP);
        // 마나 바 깎임 연출 UI
        if (FillBackMP != null) FillBackMP.fillAmount = Mathf.Lerp(FillBackMP.fillAmount, FillMP.fillAmount, Time.deltaTime * 2f);
        // 마나 Text
        if (textMP != null) textMP.text = $"{entity.MP:F0}/{entity.MaxMP:F0}";
    }
}
