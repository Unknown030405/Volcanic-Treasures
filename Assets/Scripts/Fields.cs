public static class Fields
{
     public static class Tags
     {
          public const string Player = "Player";
          public const string Canvas = "Canvas";
          public const string ChestKey = "ChestKey";
          public const string Chest = "Chest";
          public const string DoorKey = "DoorKey";
     }

     public static class AnimationState
     {
          public const string Door = "Door";
          public const string Chest = "Chest";
     }

     public static class Paths
     {
          public const string Blocks = "Blocks";
          public const string StartBlocks = "StartBlocks";
     }

     public static class Generation
     {
          public const float BlockSize = 20;
          public const float BlockBaseSpeed = 1;
          public const float BlockSpeedIncrease = 0.1f;
          public const float LavaPosition = -20;
          public const float LavaOffset = 9;
     }

     public static class Buffs
     {
          public const float BootsAcceleration = 1.6f;
          public const float UsingTime = 10f; 
          public const float DirtSlowdown = 0.5f;
     }

     public static class UIBehaviour
     {
          public const float MaxDelay = 10f;
          public const int Shift = 1;
          public const int Space = 150;
          public const int PointX = 50;
          public const int PointY = 50;
     }

     public static class Coins
     {
          public const int Min = 1;
          public const int Max = 5;
     }

     public static class Key
     {
          public const double Epsilon = 1e-9;
          public const float Speed = 9;
     }

     public static class Player
     {
          public const float ClimbSpeed = 10;
          public const float GroundCheckRadius = 0.4f;
          public const float LadderCheckRadius = 0.3f;
          public const float SlopeCheckRadius = 0.4f;
     }

     public const int DiamondsAmount = 1;
     public const float DoorOpenTime = 0.8f;
}
