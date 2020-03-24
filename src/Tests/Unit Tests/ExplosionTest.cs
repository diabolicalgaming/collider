using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// This test is just to check that all of the explosion animations have the correct components.
/// I have chosen one example of an explosion animation to test because I made use of a new feature in
/// Unity called prefab variarents. This allows me to have one parent object where other varients
/// of that parent can be made. All explosion prefab varients derive from the EnemyExplosion parent
/// prefab, which is why I have used it as an example. Each other varient will have the same components attached.
/// </summary>

public class ExplosionTest
{
    GameObject Camera { get; set; }
    GameObject explsoion;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        explsoion = Object.Instantiate(Resources.Load("Test/EnemyExplosion") as GameObject);
    }

    [UnityTest]
    public IEnumerator Explosion_Has_Transform_Component()
    {
        Transform transform = explsoion.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Explosion_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = explsoion.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Explosion_Has_Animator_Component()
    {
        Animator animator = explsoion.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Explosion_Has_Eliminate_Component()
    {
        Eliminate elim = explsoion.GetComponent<Eliminate>();

        if(elim != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(explsoion.gameObject);
    }
}
