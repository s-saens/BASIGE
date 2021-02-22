using UnityEngine;

public class MyClientData {
   
   public static string id;
   public static string nickname;
   public static UserType userType;
   public static GameObject myObject;

   /* ----- Singleton Pattern ----- */

   private static MyClientData instance;

   public MyClientData() {}

   private static class InnerInstanceClazz {
      public static MyClientData instance = new MyClientData();
   }
   public static MyClientData getInstance() {
      return InnerInstanceClazz.instance;
   }

   /* ----------------------------- */

   
}