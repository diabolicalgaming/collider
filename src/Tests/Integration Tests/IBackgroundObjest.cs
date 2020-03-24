using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class IBackgroundObjest
{
    GameObject Camera { get; set; }
    GameObject Background { get; set; }
    GameObject planet;

    /// <summary>
    /// An example of an object in the background would be a planet.
    /// </summary>

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        Background = Object.Instantiate(Resources.Load("Test/Background") as GameObject);
        planet = Object.Instantiate(Resources.Load("Test/BackgroundObject") as GameObject);
    }

    [UnityTest]
    public IEnumerator BackgroundObject_Moves_Down_Y_Axis()
    {
        var originalPosition = planet.transform.position;

        var newPosition = planet.GetComponent<BackgroundObject>().BOPositionComputation(originalPosition, 2);

        yield return new WaitForFixedUpdate();

        //If the planet moves down, then its new position on its y-axis should be less than that of the original position on its y-axis.
        Assert.Less(newPosition.y, originalPosition.y);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(Background.gameObject);
        Object.Destroy(planet.gameObject);
    }
}
