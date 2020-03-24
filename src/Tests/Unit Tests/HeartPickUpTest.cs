using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class HeartPickUpTest
{
    GameObject Camera { get; set; }
    GameObject heart;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        heart = Object.Instantiate(Resources.Load("Test/HeartPickUp") as GameObject);
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_Transform_Component()
    {
        Transform transform = heart.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = heart.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_Animator_Component()
    {
        Animator animator = heart.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = heart.GetComponent<BoxCollider2D>();

        if(box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_Rigidbody2D_Component()
    {
        Rigidbody2D rigid = heart.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_ObjectGravity_Component()
    {
        ObjectGravity OG = heart.GetComponent<ObjectGravity>();

        if (OG != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_HeartCollider_Component()
    {
        HeartCollider HC = heart.GetComponent<HeartCollider>();

        if(HC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_SpawnPoints_Component()
    {
        SpawnPoints SP = heart.GetComponent<SpawnPoints>();

        if (SP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_DamagePoints_Component()
    {
        DamagePoints DP = heart.GetComponent<DamagePoints>();

        if (DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator HeartPickUp_Has_OutOfBounds_Component()
    {
        OutOfBounds OOB = heart.GetComponent<OutOfBounds>();

        if (OOB != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(heart.gameObject);
    }
}
