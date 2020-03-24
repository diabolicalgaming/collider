using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IHeartPickUp
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
    public IEnumerator HeartPickUp_Moves_Down_Y_Axis()
    {
        var positionBeforeUpdate = heart.transform.position.y;

        yield return null;

        var positionAfterUpdate = heart.transform.position.y;

        //Its position on the y-axis should be less if it moved down the y-axis after update.
        Assert.Less(positionAfterUpdate, positionBeforeUpdate);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(heart.gameObject);
    }
}
