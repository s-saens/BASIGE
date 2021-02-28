using UnityEngine;

public class Block
{

   public Position position;

   public string owner;
   public string[] userList;

   public Block(string ownerType, string[] userList)
   {
      this.owner = ownerType;
      this.userList = userList;
   }

   public Color GetColor()
   {
      Debug.Log(userList[0]); // TODO : 이거 맞냐?
      return ServerData.users[userList[0]].GetColor();
   }

}