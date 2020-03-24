using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;

/// <summary>
/// This test is to check that when the player provides input to move the playership, it moves on the x and y axis.
/// </summary>

public class IPlayerControllerTest
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject playerShip;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        playerShip = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator Player_Can_Move_Right_On_Horizonal_Input()
    {
        var player = playerShip.GetComponent<PlayershipController>();
        player.playerSpeed = 1;

        var unityService = Substitute.For<IUnityService>();
        unityService.GetAxisRaw("Horizontal").Returns(1);
        unityService.GetDeltaTime().Returns(1);
        player.unityService = unityService;

        yield return new WaitForSeconds(3);

        Assert.AreEqual(1, player.playerPosition.normalized.x, 0.1f);
    }

    [UnityTest]
    public IEnumerator Player_Can_Move_Left_On_Horizonal_Input()
    {
        var player = playerShip.GetComponent<PlayershipController>();
        player.playerSpeed = 1;

        var unityService = Substitute.For<IUnityService>();
        unityService.GetAxisRaw("Horizontal").Returns(-1);
        unityService.GetDeltaTime().Returns(1);
        player.unityService = unityService;

        yield return new WaitForSeconds(3);

        Assert.AreEqual(-1, player.playerPosition.normalized.x, 0.1f);
    }

    [UnityTest]
    public IEnumerator Player_Can_Move_Up_On_Vertical_Input()
    {
        var player = playerShip.GetComponent<PlayershipController>();
        player.playerSpeed = 1;

        var unityService = Substitute.For<IUnityService>();
        unityService.GetAxisRaw("Vertical").Returns(1);
        unityService.GetDeltaTime().Returns(1);
        player.unityService = unityService;

        yield return new WaitForSeconds(3);

        Assert.AreEqual(1, player.playerPosition.normalized.y, 0.1f);
    }

    [UnityTest]
    public IEnumerator Player_Can_Move_Down_On_Vertical_Input()
    {
        var player = playerShip.GetComponent<PlayershipController>();
        player.playerSpeed = 1;

        var unityService = Substitute.For<IUnityService>();
        unityService.GetAxisRaw("Vertical").Returns(-1);
        unityService.GetDeltaTime().Returns(1);
        player.unityService = unityService;

        yield return new WaitForSeconds(3);

        Assert.AreEqual(-1, player.playerPosition.normalized.y, 0.1f);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(playerShip.gameObject);
    }
}