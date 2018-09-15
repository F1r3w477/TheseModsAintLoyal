using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System.Reflection;
using StardewValley.Menus;
using StardewValley.Monsters;
using StardewValley.Locations;
using StardewValley.Characters;
using System.Collections.Generic;
using System.Collections;
using System.Timers;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley.Objects;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace MoodyPlanet
{
    public class ModEntry : Mod
    {
        public static Mod instance;
        public static Random wnd;
        int x, x2, x3, x4, x5, x6;
        int z;
        int alpha = -1;
        List<int> hashofm;
        List<int> blackhash;
        string mood;
        LEModApi api;

    

        public override void Entry(IModHelper helper)
        {
            instance = this;
            wnd = new Random();
            hashofm = new List<int>();
            blackhash = new List<int>();

            TimeEvents.AfterDayStarted += TimeEvents_AfterDayStarted;
            GameEvents.OneSecondTick += GameEvents_OneSecondTick;
            TimeEvents.AfterDayStarted += TimeEvents_AfterDayStarted1;
            GameEvents.FirstUpdateTick += GameEvents_FirstUpdateTick;
            helper.ConsoleCommands.Add("mood", "Tells player world mood.", this.tellMood);






        }

        private void GameEvents_FirstUpdateTick(object sender, EventArgs e)
        {
            if (this.Helper.ModRegistry.IsLoaded("DevinLematty.LevelExtender"))
            {
                api = this.Helper.ModRegistry.GetApi<LEModApi>("DevinLematty.LevelExtender");
            }

        }

        private void tellMood(string command, string[] args)
        {
            this.Monitor.Log(mood);


        }
        private void TimeEvents_AfterDayStarted1(object sender, EventArgs e)
        {
            if (Context.IsWorldReady)
            {
                hashofm.RemoveRange(0, hashofm.Count);
                blackhash.RemoveRange(0, blackhash.Count);
            }
        }

        private void GameEvents_OneSecondTick(object sender, EventArgs e)
        {

            if (Context.IsWorldReady)
            {
                int y = 0;

                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())
                {

                    if (m.IsMonster && !hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        hashofm.Add(m.GetHashCode());
                        y++;
                        //Monitor.Log(m.Name);

                    }



                    //Monitor.Log(m.GetHashCode().ToString());


                }
                if (alpha == -1)
                {
                    alpha = y;
                }
                else
                {
                    if (alpha != y)
                    {
                        alpha = y;
                        rem_mons();
                    }
                    else
                    {

                    }
                }
            }

            /* foreach (int mhash in hashofm)
            {
                Monitor.Log($"--Hashes-->{mhash.ToString()}");
            }
            */
        }
        public void rem_mons()
        {

            if (x == 3 && z > 42) //Angry
            {



                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {


                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);
                        H.Health = H.Health * 2;
                        H.ExperienceGained = (int)(H.ExperienceGained * 1.1);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");
                    }
                }

            }
            if (x == 4 && z > 83) //Enlightened
            {

                Game1.player.health = (int)(Game1.player.health * 1.15);
                Game1.player.Stamina = (int)(Game1.player.Stamina * 1.25);


                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {


                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);
                        H.Health = (int)(H.Health * 0.7);
                        H.ExperienceGained = (int)(H.ExperienceGained * .775);
                        H.resilience.Value = (int)(H.resilience.Value * .8);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");


                    }
                }
            }
            if (x == 6 && z > 73) // Depressed
            {

                Game1.player.Stamina = (int)(Game1.player.Stamina * .5);
                Game1.player.health = (int)(Game1.player.health * .9);

                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {


                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);
                        H.ExperienceGained = (int)(H.ExperienceGained * 1.1);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");

                    }
                }

            }
            if (x == 7 && z > 60) //Mysterious
            {
                double rnd = wnd.Next(0, 13);
                rnd = rnd / 1000.0;
                api.Spawn_Rate(rnd);


                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {


                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);

                        H.Health = (int)(H.Health * x2);
                        H.ExperienceGained = (int)(H.ExperienceGained * x3);
                        H.Slipperiness = (int)(H.Slipperiness * x4);
                        H.resilience.Value = (int)(H.resilience.Value * x5);
                        H.Scale = (int)(H.Scale * x6);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");

                    }
                }

            }
            if (x == 9 && z > 42 && z < 78) //Agressive
            {



                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {


                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);
                        H.Health = (int)(H.Health * 1.4);
                        H.DamageToFarmer = (int)(H.DamageToFarmer * 1.875);
                        H.Speed = (int)(H.Speed * 1.45);
                        H.Scale = (int)(H.Scale * .685);
                        H.ExperienceGained = (int)(H.ExperienceGained * 1.25);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");

                    }
                }
            }


            if (x == 9 && z > 77) //Furious
            {




                foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

                {

                    if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                    {
                        Monster H = (m as Monster);
                        H.Health = (int)(H.Health * 2.4);
                        H.resilience.Value = (int)(H.resilience.Value * 1.3);
                        H.Slipperiness = (int)(H.Slipperiness * 1.4);
                        H.ExperienceGained = (int)(H.ExperienceGained * 1.375);
                        H.Scale = (int)(H.Scale * 1.485);
                        H.Speed = (int)(H.Speed * 1.275);
                        blackhash.Add(m.GetHashCode());
                        hashofm.Remove(m.GetHashCode());
                        Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");

                    }
                }
            }
        }


        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {

            if (Context.IsWorldReady)
            {
                x = wnd.Next(1, 14);
                x2 = wnd.Next(1, 2);
                x3 = wnd.Next(1, 2);
                x4 = wnd.Next(1, 2);
                x5 = wnd.Next(1, 2);
                x6 = wnd.Next(1, 2);
                z = wnd.Next(1, 100);
                // 1 - Happy | 2 - Sad | 3 - Angry | 4 - Enlightened | 5 - Moody | 6 - Depressed | 7 - Elated | 8 - Dying | 9 - Furious
                if (x == 1 && z > 13 && z < 69)
                {
                    mood = "Happy";
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Happy today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);

                }
                else if (x == 1 && z > 68)
                {
                    mood = "Content";
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Satisfied today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);

                }
                else if (x == 1 && z < 14)
                {
                    mood = "Untroubled";
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Satisfied today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);

                }
                else if (x == 2 && z > 17)
                {
                    mood = "sad";
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Sad today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 2 && z < 17)
                {
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Sad today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 3 && z > 42)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Angry today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 4 && z > 83)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Enlightened today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 5 && z > 30)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Moody today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 6 && z > 63)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Depressed today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);


                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 7 && z > 60)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Mysterious today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 8)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Decaying today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 9)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Happy today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 9)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Happy today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 9)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Happy today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 10 && z > 77)
                {

                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Furious today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 10 && z > 42 && z < 78)
                {
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Aggressive today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x == 10 && z < 43)
                {
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Slightly Agitated today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }
                else if (x > 10)
                {
                    Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
                    HUDMessage message = new HUDMessage($"The world is Normal today!");
                    message.color = new Color(218, 165, 32);
                    Game1.addHUDMessage(message);

                    message.timeLeft += 7000.0f;
                    message.noIcon = true;

                    message.update(Game1.currentGameTime);
                }

            }
        }

    }
}
