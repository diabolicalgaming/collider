using NUnit.Framework;
using Puppetry.Puppeteer;
using Puppetry.Puppeteer.Conditions;

namespace Tests
{
    /// <summary>
    /// These tests are run in Editor Mode.
    /// </summary>

    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class MenuSceneTest
    {
        [OneTimeSetUp]
        public void TestRunInit()
        {
            PuppetryDriver.ReleaseAllSessions();
            Configuration.Set(Settings.TimeoutMs, 45000);
            Configuration.Set(Settings.StartPlayModeTimeoutMs, 45000);
        }

        [SetUp]
        public void Init()
        {
            Editor.StartPlayMode();
        }

        /// <summary>
        /// This Test is to ensure that when the Menu scene is loaded, that all the Menu components that are expected to be active
        /// in the hierarchy are indeed active and components that are expected to be inactive are indeed inactive.
        /// </summary>
        [Test]
        public void OpenScene_MenuSceneComponentsExpectedToBeActiveAreActive()
        {
            GameObject mainCamera = new GameObject().FindByUPath("/Main Camera");
            GameObject canvas = new GameObject().FindByUPath("/Canvas");
            GameObject background = new GameObject().FindByUPath("/Canvas//Background");
            GameObject rawImage = new GameObject().FindByUPath("/Canvas//Background//RawImage");
            GameObject videoPlayer = new GameObject().FindByUPath("/Canvas//Background//Video Player");
            GameObject menu = new GameObject().FindByUPath("/Canvas//Background//Menu");
            GameObject ranking = new GameObject().FindByUPath("/Canvas//Background//Ranking");
            GameObject controlsMenu = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu");

            mainCamera.Should(Be.Present);
            mainCamera.Should(Be.OnScreen);
            mainCamera.Should(Be.ActiveInHierarchy);

            canvas.Should(Be.Present);
            canvas.Should(Be.OnScreen);
            canvas.Should(Be.ActiveInHierarchy);

            background.Should(Be.Present);
            background.Should(Be.OnScreen);
            background.Should(Be.ActiveInHierarchy);

            rawImage.Should(Be.Present);
            rawImage.Should(Be.OnScreen);
            rawImage.Should(Be.ActiveInHierarchy);

            videoPlayer.Should(Be.Present);
            videoPlayer.Should(Be.OnScreen);
            videoPlayer.Should(Be.ActiveInHierarchy);

            menu.Should(Be.Present);
            menu.Should(Be.OnScreen);
            menu.Should(Be.ActiveInHierarchy);

            ranking.Should(Be.Present);
            ranking.Should(Be.OnScreen);
            ranking.ShouldNot(Be.ActiveInHierarchy);

            controlsMenu.Should(Be.Present);
            controlsMenu.Should(Be.OnScreen);
            controlsMenu.ShouldNot(Be.ActiveInHierarchy);
        }

        /// <summary>
        /// The tests below ensure that the menu buttons are active in the Hierarchy
        /// and that each button is interacactable and displays the correct text. 
        /// </summary>
        [Test]
        public void OpenMenu_PlayButtonShouldBeActiveAndInteractable()
        {
            GameObject playButton = new GameObject().FindByUPath("/Canvas//Background//Menu//play_button");
            GameObject playButtonText = new GameObject().FindByUPath("/Canvas//Background//Menu//play_button//play_text");

            playButton.Should(Be.Present);
            playButton.Should(Be.OnScreen);
            playButton.Should(Have.ComponentWithPropertyAndValue("Button", "m_Interactable", "true"));
            playButton.Should(Be.ActiveInHierarchy);

            playButtonText.Should(Be.Present);
            playButtonText.Should(Be.OnScreen);
            playButtonText.Should(Have.Component("TextMeshProUGUI"));
            string text = playButtonText.GetComponent("TextMeshProUGUI");
            Assert.IsTrue(text.Contains("PLAY"));
        }

        [Test]
        public void OpenMenu_RankingButtonShouldBeActiveAndInteractable()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            GameObject rankingButtonText = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button//ranking_text");

            rankingButton.Should(Be.Present);
            rankingButton.Should(Be.OnScreen);
            rankingButton.Should(Have.ComponentWithPropertyAndValue("Button", "m_Interactable", "true"));
            rankingButton.Should(Be.ActiveInHierarchy);

            rankingButtonText.Should(Be.Present);
            rankingButton.Should(Be.OnScreen);
            rankingButtonText.Should(Have.Component("TextMeshProUGUI"));
            string text = rankingButtonText.GetComponent("TextMeshProUGUI");
            Assert.IsTrue(text.Contains("RANKING"));
        }

        [Test]
        public void OpenMenu_ControlsButtonShouldBeActiveAndInteractable()
        {
            GameObject controlsButton = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button");
            GameObject controlsButtonText = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button//controls_text");

            controlsButton.Should(Be.Present);
            controlsButton.Should(Be.OnScreen);
            controlsButton.Should(Have.ComponentWithPropertyAndValue("Button", "m_Interactable", "true"));
            controlsButton.Should(Be.ActiveInHierarchy);

            controlsButtonText.Should(Be.Present);
            controlsButtonText.Should(Be.OnScreen);
            controlsButtonText.Should(Have.Component("TextMeshProUGUI"));
            string text = controlsButtonText.GetComponent("TextMeshProUGUI");
            Assert.IsTrue(text.Contains("CONTROLS"));
        }

        [Test]
        public void OpenMenu_ExitButtonShouldBeActiveAndInteractable()
        {
            GameObject exitButton = new GameObject().FindByUPath("/Canvas//Background//Menu//exit_button");
            GameObject exitButtonText = new GameObject().FindByUPath("/Canvas//Background//Menu//exit_button//exit_text");

            exitButton.Should(Be.Present);
            exitButton.Should(Be.OnScreen);
            exitButton.Should(Have.ComponentWithPropertyAndValue("Button", "m_Interactable", "true"));
            exitButton.Should(Be.ActiveInHierarchy);

            exitButtonText.Should(Be.Present);
            exitButtonText.Should(Be.OnScreen);
            exitButtonText.Should(Have.Component("TextMeshProUGUI"));
            string text = exitButtonText.GetComponent("TextMeshProUGUI");
            Assert.IsTrue(text.Contains("EXIT"));
        }
        /// <summary>
        /// End of Menu button tests.
        /// </summary>

        [Test]
        public void ClickingRankingButtonShouldSetOtherMenusToInactive()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject menu = new GameObject().FindByUPath("/Canvas//Background//Menu");
            menu.ShouldNot(Be.ActiveInHierarchy);

            GameObject controlsMenu = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu");
            controlsMenu.ShouldNot(Be.ActiveInHierarchy);
        }

        [Test]
        public void ClickingRankingButtonShouldOpenRankings()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject ranking = new GameObject().FindByUPath("/Canvas//Background//Ranking");
            GameObject rankingBackground = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground");
            GameObject rankingBackButton = new GameObject().FindByUPath("/Canvas//Background//Ranking//back_button");

            ranking.Should(Be.ActiveInHierarchy);

            rankingBackground.Should(Be.Present);
            rankingBackground.Should(Be.ActiveInHierarchy);

            rankingBackButton.Should(Be.Present);
            rankingBackButton.Should(Be.OnScreen);
            rankingBackButton.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_RankingBackgroundObjectsArePresentAndActive()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject rankingBackground = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground");
            rankingBackground.Should(Be.OnScreen);
            rankingBackground.Should(Be.ActiveInHierarchy);

            GameObject leaderBoardText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//LeaderBoardText");
            GameObject rankText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//RankText");
            GameObject playerText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//PlayerText");
            GameObject scoreText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//ScoreText");
            GameObject entryContainer = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer");

            leaderBoardText.Should(Be.Present);
            leaderBoardText.Should(Be.OnScreen);
            leaderBoardText.Should(Be.ActiveInHierarchy);

            rankText.Should(Be.Present);
            rankText.Should(Be.OnScreen);
            rankText.Should(Be.ActiveInHierarchy);

            playerText.Should(Be.Present);
            playerText.Should(Be.OnScreen);
            playerText.Should(Be.ActiveInHierarchy);

            scoreText.Should(Be.Present);
            scoreText.Should(Be.OnScreen);
            scoreText.Should(Be.ActiveInHierarchy);

            entryContainer.Should(Be.Present);
            entryContainer.Should(Be.OnScreen);
            entryContainer.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_LeaderBoardTextShouldHaveCorrectText()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject leaderBoardText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//LeaderBoardText");

            string text = leaderBoardText.GetComponent("Text");
            Assert.IsTrue(text.Contains("leaderboard"));
        }

        [Test]
        public void OpenRanking_RankTextShouldHaveCorrectText()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject rankText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//RankText");

            string text = rankText.GetComponent("Text");
            Assert.IsTrue(text.Contains("RANK"));
        }

        [Test]
        public void OpenRanking_PlayerTextShouldHaveCorrectText()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject playerText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//PlayerText");

            string text = playerText.GetComponent("Text");
            Assert.IsTrue(text.Contains("PLAYER"));
        }

        [Test]
        public void OpenRanking_ScoreTextShouldHaveCorrectText()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject scoreText = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//ScoreText");

            string text = scoreText.GetComponent("Text");
            Assert.IsTrue(text.Contains("SCORE"));
        }

        [Test]
        public void OpenRanking_EntryContainerOneIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate1 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 1");
            entryTemplate1.Should(Be.Present);
            entryTemplate1.Should(Be.OnScreen);
            entryTemplate1.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 1//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 1//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 1//PlayerScore");
            GameObject firstPlaceCrown = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 1//FirstPlaceCrown");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);

            firstPlaceCrown.Should(Be.Present);
            firstPlaceCrown.Should(Be.OnScreen);
            firstPlaceCrown.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerTwoIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate2 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 2");
            entryTemplate2.Should(Be.Present);
            entryTemplate2.Should(Be.OnScreen);
            entryTemplate2.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 2//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 2//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 2//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerThreeIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate3 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 3");
            entryTemplate3.Should(Be.Present);
            entryTemplate3.Should(Be.OnScreen);
            entryTemplate3.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 3//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 3//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 3//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerFourIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate4 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 4");
            entryTemplate4.Should(Be.Present);
            entryTemplate4.Should(Be.OnScreen);
            entryTemplate4.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 4//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 4//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 4//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerFiveIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate5 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 5");
            entryTemplate5.Should(Be.Present);
            entryTemplate5.Should(Be.OnScreen);
            entryTemplate5.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 5//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 5//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 5//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerSixIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate6 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 6");
            entryTemplate6.Should(Be.Present);
            entryTemplate6.Should(Be.OnScreen);
            entryTemplate6.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 6//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 6//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 6//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerSevenIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate7 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 7");
            entryTemplate7.Should(Be.Present);
            entryTemplate7.Should(Be.OnScreen);
            entryTemplate7.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 7//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 7//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 7//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerEightIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate8 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 8");
            entryTemplate8.Should(Be.Present);
            entryTemplate8.Should(Be.OnScreen);
            entryTemplate8.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 8//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 8//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 8//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerNineIsPresentAndActiveWithCorrecChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate9 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 9");
            entryTemplate9.Should(Be.Present);
            entryTemplate9.Should(Be.OnScreen);
            entryTemplate9.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 9//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 9//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 9//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenRanking_EntryContainerTenIsPresentAndActiveWithCorrectChildObjects()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject entryTemplate10 = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 10");
            entryTemplate10.Should(Be.Present);
            entryTemplate10.Should(Be.OnScreen);
            entryTemplate10.Should(Be.ActiveInHierarchy);

            GameObject playerRank = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 10//PlayerRank");
            GameObject playerName = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 10//PlayerName");
            GameObject playerScore = new GameObject().FindByUPath("/Canvas//Background//Ranking//RankingBackground//EntryContainer//EntryTemplate 10//PlayerScore");

            playerRank.Should(Be.Present);
            playerRank.Should(Be.OnScreen);
            playerRank.Should(Be.ActiveInHierarchy);

            playerName.Should(Be.Present);
            playerName.Should(Be.OnScreen);
            playerName.Should(Be.ActiveInHierarchy);

            playerScore.Should(Be.Present);
            playerScore.Should(Be.OnScreen);
            playerScore.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void ClickingRankingBackButtonReturnsPlayerToMenu()
        {
            GameObject rankingButton = new GameObject().FindByUPath("/Canvas//Background//Menu//ranking_button");
            rankingButton.Click();

            GameObject ranking = new GameObject().FindByUPath("/Canvas//Background//Ranking");
            GameObject rankingBackButton = new GameObject().FindByUPath("/Canvas//Background//Ranking//back_button");

            rankingBackButton.Click();
            ranking.ShouldNot(Be.ActiveInHierarchy);

            GameObject menu = new GameObject().FindByUPath("/Canvas//Background//Menu");
            menu.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void ClickingControlsButtonShouldSetOtherMenusToInactive()
        {
            GameObject controlsButton = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button");
            controlsButton.Click();

            GameObject menu = new GameObject().FindByUPath("/Canvas//Background//Menu");
            menu.ShouldNot(Be.ActiveInHierarchy);

            GameObject ranking = new GameObject().FindByUPath("/Canvas//Background//Ranking");
            ranking.ShouldNot(Be.ActiveInHierarchy);
        }

        [Test]
        public void ClickingControlsButtonShouldOpenControlsMenu()
        {
            GameObject controlsButton = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button");
            controlsButton.Click();

            GameObject controlsMenu = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu");
            GameObject controlsMenuBackButton = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//back_button");
            GameObject controlsMenuKeyboardImage = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//Keyboard");
            GameObject controlsMenuMouseImage = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//Mouse");

            controlsMenu.Should(Be.ActiveInHierarchy);

            controlsMenuBackButton.Should(Be.Present);
            controlsMenuBackButton.Should(Be.OnScreen);
            controlsMenuBackButton.Should(Be.ActiveInHierarchy);

            controlsMenuKeyboardImage.Should(Be.Present);
            controlsMenuKeyboardImage.Should(Be.OnScreen);
            controlsMenuKeyboardImage.Should(Be.ActiveInHierarchy);

            controlsMenuMouseImage.Should(Be.Present);
            controlsMenuMouseImage.Should(Be.OnScreen);
            controlsMenuMouseImage.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void ControlsMenuBackButtonIsInteractable()
        {
            GameObject controlsButton = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button");
            controlsButton.Click();

            GameObject backButton = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//back_button");
            GameObject backButtonText = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//back_button//back_text");

            backButton.Should(Have.ComponentWithPropertyAndValue("Button", "m_Interactable", "true"));

            string text = backButtonText.GetComponent("TextMeshProUGUI");
            Assert.IsTrue(text.Contains("BACK"));
        }

        [Test]
        public void ClickingControlsMenuBackButtonReturnsPlayerToMenu()
        {
            GameObject controlsButton = new GameObject().FindByUPath("/Canvas//Background//Menu//controls_button");
            controlsButton.Click();

            GameObject controlsMenu = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu");
            GameObject controlsMenuBackButton = new GameObject().FindByUPath("/Canvas//Background//ControlsMenu//back_button");

            controlsMenuBackButton.Click();
            controlsMenu.ShouldNot(Be.ActiveInHierarchy);

            GameObject menu = new GameObject().FindByUPath("/Canvas//Background//Menu");
            menu.Should(Be.ActiveInHierarchy);
        }

        [TearDown]
        public void CleanUp()
        {
            Editor.StopPlayMode();
        }

        [OneTimeTearDown]
        public void TestRunCleanUp()
        {
            PuppetryDriver.ReleaseAllSessions();
        }
    }
}