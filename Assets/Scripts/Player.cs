using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Battle_Entity
{
    // 변수 선언
    private SpriteRenderer spriteRenderer;
    
    // 클릭 공격 범위
    public BoxCollider2D ClickAttackRange;
    
    // 공격 횟수 카운트
    static double ClickCount;
    static double SkillClickCount;
    
    // 카운트 텍스트
    public TMP_Text ClickCountText;
    public TMP_Text SkillClickCountText;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Battle_Entity에 정의 되어 있는 HPMP_Setup() 메소드 호출
        base.HPMP_Setup();
        
        // Battle_Entity에 정의 되어 있는 Damage_Setup() 메소드 호출
        // 플레이어의 능력에 따라 초당 데미지를 가함
        base.Damage_Setup();
    }

    private void Start()
    {
        ClickCount = PlayerPrefs.GetInt("CLICK COUNT", 0);
        SkillClickCount = PlayerPrefs.GetInt("SKILL CLICK COUNT", 0);
    }

    private void Update()
    {
        // 적 박스 정의
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
        

        // 적 2d collider 범위 위에 마우스 커서가 있는지 체크
        // 왼쪽 클릭 시 타겟에 기본 데미지
        // 오른쪽 클릭 시 타겟에 스킬 데미지
        if (rayhit.collider != null)
        {
            if (rayhit.collider == ClickAttackRange && Input.GetMouseButtonDown(0))
            {
                target.TakeDamage(1000);
                target.ClickHit();
                ClickCount += 1;
                ClickCountText.text = "Attack Count : " + ClickCount;
            }

            if (rayhit.collider == ClickAttackRange && Input.GetMouseButtonDown(1))
            {
                MP -= 550;
                target.TakeDamage(5500);
                target.ClickHit();
                SkillClickCount += 1;
                SkillClickCountText.text = "Skill Attack Count : " + SkillClickCount;
            }
        }
        
        
    }
    


    

    // 기본 체력 + 스탯 보너스 + 버프 등과 같이 계산
    public override float MaxHP => MaxHPBasic + MaxHPAttrBonus;

    // 100 + 현재레벨 * 30
    public float MaxHPBasic => 2000 + 1 * 30;

    // 힘 * 10
    public float MaxHPAttrBonus => 10 * 10;


    public override float HPRecovery => 10;
    public override float MaxMP => 2000;
    public override float MPRecovery => 10;



    // 공격 시 데미지 호출
    public override void TakeDamage(float damage)
    {
        HP -= damage;
    }

    // 클릭 시 히트 애니메이션 코루틴 호출
    public override void ClickHit()
    {
        StartCoroutine("HitAnimation");
    }
    
    // 출력 되는 피격 애니메이션
    private IEnumerator HitAnimation()
    {
        Color color = spriteRenderer.color;
        
        color.a = 0.2f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(0.1f);

        color.a = 1;
        spriteRenderer.color = color;
    }

}
