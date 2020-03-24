using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuPlayButtonTest : UITest
    {
        /// <summary>
        /// This is just a simple UI test, to check that when the "Play" button is clicked, the Game scene is opened.
        /// </summary>
        [UnityTest]
        public IEnumerator Clicking_Play_Button_Opens_Game_Scene_In_UI()
        {
            yield return LoadScene("Menu");
            yield return Press("Menu/play_button");
            yield return new WaitForSeconds(1.0f);
            yield return WaitFor(new SceneLoaded("Game"));
        }
    }
}
