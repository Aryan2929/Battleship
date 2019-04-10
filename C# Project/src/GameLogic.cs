using SwinGameSDK;
using static GameResources;
using static GameController;

//Loads the game
static class GameLogic {
    public static void Main() {
        // Opens a new Graphics Window
        SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

        // Load Resources
        LoadResources();
        SwinGame.PlayMusic(GameMusic("Background"));

        // Game Loop
		while (!SwinGame.WindowCloseRequested() &&
			   CurrentState != GameState.Quitting)
		{
            HandleUserInput();
            DrawScreen();
		}

        // Free Resources and Close Audio, to end the program.
		SwinGame.StopMusic();
        FreeResources();
    }
}
