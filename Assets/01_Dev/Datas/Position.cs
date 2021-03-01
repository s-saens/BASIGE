using UnityEngine;

public class Position {
   public int x;
   public int y;
   public Position(int x, int y) {
      this.x = x;
      this.y = y;
   }
   public bool Equals(Position pos) {
      return (this.x == pos.x) && (this.y == pos.y);
   }
}