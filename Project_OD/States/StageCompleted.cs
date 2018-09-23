using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD.States
{
    public static class StageCompleted
    {
        public enum LevelState
        {
            notCompleted,
            completed
        }

        private static LevelState lvlstate = LevelState.notCompleted;
        public static LevelState getLevelstateState() { return lvlstate; }
        public static void SetLevelState(LevelState state) { lvlstate = state; }

        public static void isCompleted()
        {
            StageCompleted.SetLevelState(LevelState.notCompleted);
            if (lvlstate == LevelState.notCompleted)
            {
                StageCompleted.SetLevelState(LevelState.completed);
                OD.setState(gameStates.StageCompletedScreen);
            }
        }
    }
}
