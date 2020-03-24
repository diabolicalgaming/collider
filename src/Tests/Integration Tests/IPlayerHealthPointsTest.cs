using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IPlayerHealthPointsTest
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject player;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator Player_Starts_With_3_Lives()
    {
        float currentLives = player.GetComponent<HealthPoints>().currentLives;

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(3, currentLives);
    }

    [UnityTest]
    public IEnumerator Player_Starts_With_100_HealthPoints()
    {
        float damageHP = player.GetComponent<HealthPoints>().DamageHP;

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(100, damageHP);
    }

    [UnityTest]
    public IEnumerator Player_Takes_Damage_To_HealthPoints()
    {
        float originalHP = player.GetComponent<HealthPoints>().DamageHP;

        yield return new WaitForFixedUpdate();

        float newHP = player.GetComponent<HealthPoints>().DecreaseHP(20);

        Assert.Less(newHP, originalHP);
    }

    [UnityTest]
    public IEnumerator Player_Can_Regain_HealthPoints()
    {
        float damagedHP = player.GetComponent<HealthPoints>().DecreaseHP(50);

        yield return new WaitForFixedUpdate();

        float gainHP = player.GetComponent<HealthPoints>().IncreaseHP(30);

        Assert.Greater(gainHP, damagedHP);
    }

    [UnityTest]
    public IEnumerator Player_Current_Lives_Should_Increase_By_1_When_HP_Is_Regained_and_Damage_HP_Is_More_Than_100()
    {
        player.GetComponent<HealthPoints>().DecreaseHP(120);

        yield return new WaitForFixedUpdate();

        float newLives = player.GetComponent<HealthPoints>().currentLives;

        yield return new WaitForFixedUpdate();

        player.GetComponent<HealthPoints>().IncreaseHP(50);

        float gainedLife = player.GetComponent<HealthPoints>().currentLives;

        //Now gaineLife should be greater than newLives (which is the current number of lives you have after losing more than 100HP).
        //Note that current lives is just the number to the right of the health bar.
        Assert.Greater(gainedLife, newLives);
    }


    [UnityTest]
    public IEnumerator Player_Current_Lives_Should_Decrease_By_1_When_Damaged_By_More_Than_100()
    {
        float currentLives = player.GetComponent<HealthPoints>().currentLives;

        player.GetComponent<HealthPoints>().DecreaseHP(120);

        yield return new WaitForFixedUpdate();

        float newLives = player.GetComponent<HealthPoints>().currentLives;

        Assert.Less(newLives, currentLives);
    }

    [UnityTest]
    public IEnumerator Player_Can_Only_Have_A_Maximum_Of_MaxLives()
    {
        //The maximum number of lives the player can have is 3.
        //At run time currentLives is equal to maxlives in the HealthPoints class.
        player.GetComponent<HealthPoints>().IncreaseHP(120);

        yield return new WaitForFixedUpdate();

        float newLives = player.GetComponent<HealthPoints>().currentLives;

        Assert.AreEqual(3, newLives);
    }

    [UnityTest]
    public IEnumerator Player_Cannot_Have_Less_Than_0_Lives()
    {
        //Note that there are 3 lives.
        //I'll call DecreaseHP one at a time (once for each number of lives and 
        //call it again one more time to ensure that it doesn't go less than 0).
        player.GetComponent<HealthPoints>().DecreaseHP(100);
        player.GetComponent<HealthPoints>().DecreaseHP(100);
        player.GetComponent<HealthPoints>().DecreaseHP(100);
        player.GetComponent<HealthPoints>().DecreaseHP(100);

        yield return new WaitForFixedUpdate();

        float newLives = player.GetComponent<HealthPoints>().currentLives;

        Assert.Zero(newLives);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(player.gameObject);
    }
}
