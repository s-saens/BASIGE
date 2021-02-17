using UnityEngine;

public class ClientData {
   
   public static string id;
   public static string nickname;
   public static UserType userType;

   /* ----- Singleton Pattern ----- */

   private static ClientData instance;

   public ClientData() {}

   private static class InnerInstanceClazz {
      public static ClientData instance = new ClientData();
   }
   public static ClientData getInstance() {
      return InnerInstanceClazz.instance;
   }

   /* ----------------------------- */


   
}