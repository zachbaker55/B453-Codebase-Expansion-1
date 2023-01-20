using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class SharedData
    {

        public static int Score;

        public static int Level = 1;

        public static bool levelWon;

    public static string TimeRemaining = string.Empty;

        public static List<int> GoalScores = new List<int> { 5, 7, 7, 9, 12, 24 };

        public static List<string> LevelIntros = new List<string> {
            "Welcome to limbo Gumbo!\r\n" +
            "Feed 5 souls in 2 minutes.\r\n" +
            "Each soul orders a hellish or heavenly dish." +
            "Add your ingredients to match the meter on the bottom of the pot!",

            "Some souls have specific requests, so" +
            " remember what you've added to your gumbo!\r\n" +
            "If you need to clear your ingredients, pull the lever to dump your gumbo.\r\n" +
            "You'll have to wait for it to boil again though.  No one likes cold gumbo!",

            "Some souls appreciate complex flavors.\r\n" +
            "They may ask you for many, or few flavors in their gumbo.\r\n" +
            "Remember that you can start fresh gumbo by pulling the lever.",

            "Way to go, chef!\r\n" +
            "Now souls can order whatever they's like.\r\n" +
            "When you get a lot of orders, try to plan your ingredients to make them all happy!",

            "Looks like you're ready for a real dinner rush.\r\n" +
            "See if you can serve up 12 ghosts before time runs out!",

            "You know what to do.  Serve as many lost souls as you can in under 2 minutes.  See how close you can get to all 24!"
        };
    }
