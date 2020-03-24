using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// I have created this class to control the players health points.
/// The player will have a maximum of three lives.
/// There will be text on the canvas that displays the number of lives that the player has.
/// This will be a health bar that displays when the player loses health points (HP).
/// When the players lives is 0 and damage hp is 0, then the player dies.
/// </summary>

public class HealthPoints : MonoBehaviour
{
    const int maxLives = 3;
    public Text livesText;
    public Image healthBar;

    [HideInInspector]
    public int currentLives;
    [HideInInspector]
    public float DamageHP { get; set; }
    [HideInInspector]
    public float MaxHP { get; set; }

    private float hpRatio;

    //Awake to act as a constructor.
    private void Awake()
    {
        this.currentLives = maxLives;
        this.livesText.text = currentLives.ToString();
        this.DamageHP = 100;
        this.MaxHP = 100;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Here I make a call to my UpdateHP function in order to update the UI image for the players health bar. 
        UpdateHP();
    }

    /// <summary>
    /// This is a function I have written which is used to increase the players health points when they pick up the heart collectable. 
    /// It takes a float value, so that I can specify how much I want the player to heal by. If the player picks up a heart collectable, 
    /// increase the player life by the specified float value.
    /// </summary>
    /// <param name="heal"> The number of hp that is added to the players health </param>
    public float IncreaseHP(float heal)
    {
        this.DamageHP += heal;
        if(this.DamageHP >= this.MaxHP)
        {
            if(this.currentLives < maxLives)
            {
                float currentHP = this.MaxHP - this.DamageHP;
                this.DamageHP = -1 * currentHP;
                //If damage hp is equal to 0 when the player gains more hp from the heart collectable, then add 10 hp so that the health bar isn't empty.
                //For examle, if damage hp is 50  (and assuming maxhp is 100) and the player has 2 lives left, when they pick up a heart 
                //collectable (which increases the damage hp by 50) they will now have 0 damage hp with 3 lives. This will cause the health bar
                // to be empty in the UI, to avoid this, just add 10 hp to damage hp.
                if(this.DamageHP == 0)
                {
                    this.DamageHP += 10;
                }
            }
            if(this.currentLives != maxLives)
            {
                //If the player damage hp reaches max hp, then increment the current number of lives that they have as long as it isn't equal to max lives.
                this.currentLives++;
                this.livesText.text = this.currentLives.ToString();
            }
        }
        //Set DamageHP back to MaxHP if player gets over MaxHP. This is to avoid scaling issues.
        if (this.DamageHP > this.MaxHP)
        {
            this.DamageHP = this.MaxHP;
        }
        //Update the GUI image to show that the player is gaining health points.
        UpdateHP();
        return this.DamageHP;
    }

    /// <summary>
    /// Here I have written a function which is used to update the player health bar when the player takes damage.
    /// Enforces a ratio between 0 and 1 because DamageHP cannot be above MaxHP.
    /// The idea is to modify the scaling value on the x-axis to make the health bar move from right to left as the player takes damage.
    /// </summary>
    private void UpdateHP()
    {
        this.hpRatio = this.DamageHP / this.MaxHP;

        this.healthBar.rectTransform.localScale = new Vector2(hpRatio, 1);
    }

    /// <summary>
    /// I have written this function to decrement the players health points when they hit 0. It takes in a float value, so that I can 
    /// specify how much damage I want either the player to take. It is called in my Playership class when the player takes damage from
    /// an incoming enemy ship or enemy missile.
    /// </summary>
    /// <param name="damage"> This is a float value that specifies the amount of damage the player takes to their health points </param>
    public float DecreaseHP(float damage)
    {
        this.DamageHP -= damage;

        //Decrement the players current number of lives by 1 everytime the health bar gets to 0 while the current number of lives is not equal to 0.
        if (this.DamageHP <= 0 && this.currentLives != 0)
        {
            /// <summary>
            /// Update the GUI text that displays the lives to the player.
            /// The health bar should only reset the DamageHP to MaxHP if current lives that the player has is greater than 0.
            /// It wouldn't make sense for the health bar to reset to MaxHP when the players current lives is equal to 0 because
            /// the playership should be destroyed at this point.
            /// </summary>
            this.currentLives--;
            this.livesText.text = this.currentLives.ToString();
            if (currentLives > 0)
            {
                this.DamageHP = this.MaxHP;
            }
        }
        //Set DamageHP to 0 so that I don't get wierd scaling issues.
        if (this.DamageHP < 0)
        {
            this.DamageHP = 0;
        }
        //Update the GUI image to show that the player is losing health points.
        UpdateHP();
        return this.DamageHP;
    }
}
