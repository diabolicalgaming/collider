using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IStarTest
{
    GameObject Camera { get; set; }
    GameObject star;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        star = Object.Instantiate(Resources.Load("Test/Star") as GameObject);
    }

    [UnityTest]
    public IEnumerator Stars_StarPositionComputation_Moves_Star_Down_Y_Axis()
    {
        var positionBeforeUpdate = star.transform.position.y;

        yield return null;

        var positionAfterUpdate = star.transform.position.y;

        //The value of the y-axis of the new position, should be less than the value for the y-axis of the original position.
        Assert.Less(positionAfterUpdate, positionBeforeUpdate);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(star.gameObject);
    }
}
