using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// This test is just to check that all of the enemy missiles have the correct components.
/// I have chosen one example of an enemy missile to test because I made use of a new feature in
/// Unity called prefab variarents. This allows me to have one parent object where other varients
/// of that parent can be made. All enemy missiles prefab varients derive from the ChaserMissile parent
/// prefab, which is why I have used it as an example. Each other varient will have the same components attached.
/// </summary>

public class EnemyMissileTest
{
    GameObject Camera { get; set; }
    GameObject missile;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        missile = Object.Instantiate(Resources.Load("Test/ChaserMissile") as GameObject);
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_Transform_Component()
    {
        Transform transform = missile.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = missile.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_Animator_Component()
    {
        Animator animator = missile.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_EnemyMissile_Component()
    {
        EnemyMissile EM = missile.GetComponent<EnemyMissile>();

        if(EM != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_CircleCollider2D_Component()
    {
        Collider2D collider = missile.GetComponent<Collider2D>();

        if(collider != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_RigidBody2D_Component()
    {
        Rigidbody2D rigid = missile.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_MissileCollider_Component()
    {
        MissileCollider MC = missile.GetComponent<MissileCollider>();

        if(MC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator EnemyMissile_Has_DamagePoints_Component()
    {
        DamagePoints DP = missile.GetComponent<DamagePoints>();

        if(DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(missile.gameObject);
    }
}
