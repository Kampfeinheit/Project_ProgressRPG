using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : Battle_Entity
{
    // 변수 선언
    private SpriteRenderer spriteRenderer;

    static double EnemyDeadCount;
    static double EnemyDeadMaxCount;
    
    [SerializeField] private TMP_Text EnemyDeadCountText;




    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Entity에 정의 되어 있는 HPMP_Setup() 메소드 호출
        base.HPMP_Setup();
    }
    
    
    
    private void Start()
    {
        EnemyDeadCount = 0;
        EnemyDeadMaxCount = 5;
        EnemyDeadCountText.text = EnemyDeadCount + " / " + EnemyDeadMaxCount;
    }

    
    
    
    // z키 누르면 상대에게 데미지 
    private void Update()
    {
        if (Input.GetKey("z"))
        {
            int damage = Random.Range(1, 10);
            target.TakeDamage((damage));
            target.ClickHit();
        }

        if (HP == 0)
        {
            EnemyDeadCount += 1;
            EnemyDeadCountText.text = EnemyDeadCount + " / " + EnemyDeadMaxCount;
            HP += MaxHP;
        }

        if (EnemyDeadCount == EnemyDeadMaxCount)
        {
            Debug.Log("Next Stage!");
        }


    }




    public override float MaxHP => 20000;
    public override float HPRecovery => 0;
    public override float MaxMP => 0;
    public override float MPRecovery => 0;
    

    
    
    // 공격 받았을 때 데미지 호출 
    public override void TakeDamage(float damage)
    {
        HP -= damage;
    }
    


    // 공격 받았을 때 및 피격 애니메이션 호출
    public override void ClickHit()
    {
        StartCoroutine(("HitAnimation"));
    }
    

    // 피격 애니메이션
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
