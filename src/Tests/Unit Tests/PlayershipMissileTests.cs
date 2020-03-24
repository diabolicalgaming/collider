using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayershipMissileTests
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject playerMissile;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        playerMissile = Object.Instantiate(Resources.Load("Test/PlayerShipMissile") as GameObject);
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Has_Transform_Component()
    {
        Transform transform = playerMissile.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = playerMissile.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Has_PlayershipMissile_Component()
    {
        PlayerShipMissile PM = playerMissile.GetComponent<PlayerShipMissile>();

        if(PM != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = playerMissile.GetComponent<BoxCollider2D>();

        if(box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Has_Rigidbody2D_Component()
    {
        Rigidbody2D rigid = playerMissile.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator PlayershipMissile_Moves_Up_Y_Axis()
    {
        var originalPositon = playerMissile.transform.position;

        var newPosition = playerMissile.GetComponent<PlayerShipMissile>().MissilePositionComputation(originalPositon, 2);

        yield return new WaitForFixedUpdate();

        //If the missile moved up the y-axis, then its new position on the y-axis should be greater than its original position on the y-axis.
        Assert.Greater(newPosition.y,originalPositon.y);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(playerMissile.gameObject);
    }
}
