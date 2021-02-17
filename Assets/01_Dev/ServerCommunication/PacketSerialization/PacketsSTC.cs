using UnityEngine;
using System.Collections.Generic;

public class MATCH_STATUS__STC {
   public int count;
   public int maxCount;
}

public class RENDER__STC {
   public int timer;
   public Block[][] map;
   public Bug[] bugList;
   public Cat cat;
}

public class SKILL_RESULT__STC {
   public SkillResult skillResult;
}

public class REFRESH__STC {

   public int timer;
   public Block[][] map;
   public Dictionary<string, MoveInfo> animationList;
   public int catScore;
   public int bugScore;

   public class MoveInfo {
      public Direction direction;
      public Position position;
   }

}

public class DEAD__STC {
   string[] deadList;
}

public class CHANGE_CAT__STC {
   string id;
}

public class BAN__STC {
   string id;
}

public class GAME_RESULT__STC {
   string winner;
   int catScore;
   int bugScore;
}