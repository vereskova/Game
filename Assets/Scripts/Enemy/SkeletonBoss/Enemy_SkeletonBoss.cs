using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Босс наследуется от обычного скелета, чтобы переиспользовать всю ту же логику
public class Enemy_SkeletonBoss : Enemy_Skeleton
{
    [Header("Boss Stats")]
    // При желании можно переопределить какие-то характеристики
      public float bossExtraHP = 100;
    // public float bossExtraDamage = 10;

    protected override void Awake()
    {
        // Вызываем базовый Awake из Enemy_Skeleton (там создаются idleState, moveState и т.д.)
        base.Awake();
        
        // Можем при необходимости менять параметры (moveSpeed, attackDistance, etc.)
        // moveSpeed = 2.5f;
        // attackDistance = 2f;
    }

    protected override void Start()
    {
        base.Start();
        // По умолчанию идёт в idleState (точно как обычный скелет)
    }

    // Если нужно, переопределяем Die(), CanBeStunned() и т.п.
    //public override void Die()
    //{
    //    base.Die();
    //    // Дополнительные эффекты
    //}
}
