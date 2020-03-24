using NUnit.Framework;
using Puppetry.Puppeteer;
using Puppetry.Puppeteer.Conditions;

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class GameSceneTest
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
        /// The tests below ensure that the menu buttons are active in the Hierarchy
        /// and that each button is interacactable and displays the correct text. 
        /// </summary>
        [Test]
        public void OpenScene_GameSceneComponentsExpectedToBeActiveAreActive()
        {
            GameObject mainCamera = new GameObject().FindByUPath("/Main Camera");
            GameObject spawnManager = new GameObject().FindByUPath("/SpawnManager");
            GameObject playerShipMove = new GameObject().FindByUPath("/PlayershipMove");
            GameObject background = new GameObject().FindByUPath("/Background");
            GameObject starCreatorMove = new GameObject().FindByUPath("/StarCreatorMove");
            GameObject canvas = new GameObject().FindByUPath("/Canvas");
            GameObject eventSystem = new GameObject().FindByUPath("/EventSystem");
            GameObject soundManager = new GameObject().FindByUPath("/SoundManager");
            GameObject gameManager = new GameObject().FindByUPath("/GameManager");
            GameObject movingPosition = new GameObject().FindByUPath("/MovingPosition");

            mainCamera.Should(Be.Present);
            mainCamera.Should(Be.OnScreen);
            mainCamera.Should(Be.ActiveInHierarchy);

            spawnManager.Should(Be.Present);
            spawnManager.Should(Be.OnScreen);
            spawnManager.Should(Be.ActiveInHierarchy);

            playerShipMove.Should(Be.Present);
            playerShipMove.Should(Be.OnScreen);
            playerShipMove.Should(Be.ActiveInHierarchy);

            background.Should(Be.Present);
            background.ShouldNot(Be.OnScreen);
            background.Should(Be.ActiveInHierarchy);

            starCreatorMove.Should(Be.Present);
            starCreatorMove.Should(Be.OnScreen);
            starCreatorMove.Should(Be.ActiveInHierarchy);

            canvas.Should(Be.Present);
            canvas.Should(Be.OnScreen);
            canvas.Should(Be.ActiveInHierarchy);

            eventSystem.Should(Be.Present);
            eventSystem.Should(Be.OnScreen);
            eventSystem.Should(Be.ActiveInHierarchy);

            soundManager.Should(Be.Present);
            soundManager.Should(Be.OnScreen);
            soundManager.Should(Be.ActiveInHierarchy);

            gameManager.Should(Be.Present);
            gameManager.Should(Be.OnScreen);
            gameManager.Should(Be.ActiveInHierarchy);

            movingPosition.Should(Be.Present);
            movingPosition.Should(Be.OnScreen);
            movingPosition.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_PlayerShipChildObjectsAreActiveAndPresent()
        {
            GameObject playerMissileAtPosition1 = new GameObject().FindByUPath("/PlayershipMove//PlayerMissilePosition1");
            GameObject playerMissileAtPosition2 = new GameObject().FindByUPath("/PlayershipMove//PlayerMissilePosition2");
            GameObject thrust_player = new GameObject().FindByUPath("/PlayershipMove//thrust_player");

            playerMissileAtPosition1.Should(Be.Present);
            playerMissileAtPosition1.Should(Be.OnScreen);
            playerMissileAtPosition1.Should(Be.ActiveInHierarchy);

            playerMissileAtPosition2.Should(Be.Present);
            playerMissileAtPosition2.Should(Be.OnScreen);
            playerMissileAtPosition2.Should(Be.ActiveInHierarchy);

            thrust_player.Should(Be.Present);
            thrust_player.Should(Be.OnScreen);
            thrust_player.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_BackgroundChildObjectsAreActiveAndPresent()
        {
            GameObject backgroundObjectsMove = new GameObject().FindByUPath("/Background//BackgroundObjectsMove");

            backgroundObjectsMove.Should(Be.Present);
            backgroundObjectsMove.Should(Be.OnScreen);
            backgroundObjectsMove.Should(Be.Present);
        }

        /// <summary>
        /// Tests with ending "ExpectedToBeActiveAreActive" are tests to ensure that objects that are expected to be active
        /// in the hierarchy are indeed active and objects that are expected to be inactive are indeed inactive.
        /// </summary>

        [Test]
        public void OpenScene_CanvasChildObjectsExpectedToBeActiveAreActive()
        {
            GameObject scoreUI = new GameObject().FindByUPath("/Canvas//ScoreUI");
            GameObject gameMenu = new GameObject().FindByUPath("/Canvas//GameMenu");
            GameObject healthBarBG = new GameObject().FindByUPath("/Canvas//HealthBarBG");
            GameObject gameOver = new GameObject().FindByUPath("/Canvas//Game Over");
            GameObject nameInput = new GameObject().FindByUPath("/Canvas//NameInput");

            scoreUI.Should(Be.Present);
            scoreUI.Should(Be.OnScreen);
            scoreUI.Should(Be.ActiveInHierarchy);

            gameMenu.Should(Be.Present);
            gameMenu.Should(Be.OnScreen);
            gameMenu.ShouldNot(Be.ActiveInHierarchy);

            healthBarBG.Should(Be.Present);
            healthBarBG.Should(Be.OnScreen);
            healthBarBG.Should(Be.ActiveInHierarchy);

            gameOver.Should(Be.Present);
            gameOver.Should(Be.OnScreen);
            gameOver.ShouldNot(Be.ActiveInHierarchy);

            nameInput.Should(Be.Present);
            nameInput.Should(Be.OnScreen);
            nameInput.ShouldNot(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition1IsActiveAndPresent()
        {
            GameObject movingPosition1 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (1)");

            movingPosition1.Should(Be.Present);
            movingPosition1.Should(Be.OnScreen);
            movingPosition1.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition2IsActiveAndPresent()
        {
            GameObject movingPosition2 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (2)");

            movingPosition2.Should(Be.Present);
            movingPosition2.Should(Be.OnScreen);
            movingPosition2.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition3IsActiveAndPresent()
        {
            GameObject movingPosition3 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (3)");

            movingPosition3.Should(Be.Present);
            movingPosition3.Should(Be.OnScreen);
            movingPosition3.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition4IsActiveAndPresent()
        {
            GameObject movingPosition4 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (4)");

            movingPosition4.Should(Be.Present);
            movingPosition4.Should(Be.OnScreen);
            movingPosition4.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition5IsActiveAndPresent()
        {
            GameObject movingPosition5 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (5)");

            movingPosition5.Should(Be.Present);
            movingPosition5.Should(Be.OnScreen);
            movingPosition5.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition6IsActiveAndPresent()
        {
            GameObject movingPosition6 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (6)");

            movingPosition6.Should(Be.Present);
            movingPosition6.Should(Be.OnScreen);
            movingPosition6.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition7IsActiveAndPresent()
        {
            GameObject movingPosition7 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (7)");

            movingPosition7.Should(Be.Present);
            movingPosition7.Should(Be.OnScreen);
            movingPosition7.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition8IsActiveAndPresent()
        {
            GameObject movingPosition8 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (8)");

            movingPosition8.Should(Be.Present);
            movingPosition8.Should(Be.OnScreen);
            movingPosition8.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition9IsActiveAndPresent()
        {
            GameObject movingPosition9 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (9)");

            movingPosition9.Should(Be.Present);
            movingPosition9.Should(Be.OnScreen);
            movingPosition9.Should(Be.ActiveInHierarchy);
        }

        [Test]
        public void OpenScene_MovingPositionChildObjectMovingposition10IsActiveAndPresent()
        {
            GameObject movingPosition10 = new GameObject().FindByUPath("/MovingPosition//MovingPosition (10)");

            movingPosition10.Should(Be.Present);
            movingPosition10.Should(Be.OnScreen);
            movingPosition10.Should(Be.ActiveInHierarchy);
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