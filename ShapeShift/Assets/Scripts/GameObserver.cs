using System.Collections;
using System.Collections.Generic;

public static class GameObserver
{
    public delegate void DelegatePause();
    public static event DelegatePause OnGamePaused;

    public static void GamePause()
    {
        if(OnGamePaused != null)
        {
            OnGamePaused();
        }
    }

    public delegate void DelegateContinue();
    public static event DelegateContinue OnGameContinue;

    public static void GameContinue()
    {
        if(OnGameContinue != null)
        {
            OnGameContinue();
        }
    }
}
