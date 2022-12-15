using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Battle_Entity : MonoBehaviour
{
    private Stats stats;    // 캐릭터 정보
    public Battle_Entity target;   // 공격 대상

    
    // 체력 프로퍼티 : 0~ MaxHP 값을 넘지 못하도록 설정
    public float HP
    {
        set => stats.HP = Mathf.Clamp(value, 0, MaxHP);
        get => stats.HP;
    }
    
    
    // 마나 프로퍼티 : 0~ MaxMP 값을 넘지 못하도록 설정
    public float MP
    {
        set => stats.MP = Mathf.Clamp(value, 0, MaxMP);
        get => stats.MP;
    }
    

    
    
    // 프로퍼티 추상 선언
    // 작동하는 내용은 플레이어, 적과 같은 파생 클래스에서 정의
    public abstract float MaxHP       { get; } // 최대체력
    public abstract float HPRecovery  { get; } // 초당 체력 회복량
    public abstract float MaxMP       { get; } // 최대마나
    public abstract float MPRecovery  { get; } // 최대 마나 회복량
    


    // 공격 시 상대방의 TakeDamage(damage) 호출
    // 매개변수 Damage는 공격하는 본인의 공격력
    public abstract void TakeDamage(float damage);
    
    // 공격 시 상대방의 히트 애니메이션 호출
    public abstract void ClickHit();
    
    
    // "리커버리" 초기 HP, MP + 회복 메소드 호출
    protected void HPMP_Setup()
    {
        HP = MaxHP;
        MP = MaxMP;

        StartCoroutine("Recovery");
    }

    
    /// 초당 체력, 마나 회복
    protected IEnumerator Recovery()
    {
        while (true)
        {
            if (HP < MaxHP) HP += HPRecovery;
            if (MP < MaxMP) MP += MPRecovery;

            yield return new WaitForSeconds(1);
        }
    }
    
    
    // 타겟에게 가하는 초당 데미지
    protected void Damage_Setup()
    {
        StartCoroutine("DamagePerSec");
    }

    
    protected IEnumerator DamagePerSec()
    {
        while (true)
        {
            if (target.HP > 0)
            {
                target.TakeDamage(200);
            }
            
            yield return new WaitForSeconds(1);
        }
    }
    
    
 
    
}


[System.Serializable]
public struct Stats
{
    // 이름, 레벨, 직업, 능력치 등 캐릭터 수치
    [HideInInspector] public float HP;
    [HideInInspector] public float MP;

}
