﻿using System;
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
        int x; //becomes random 
        int z; //becomes random variable
        int a; //becomes random variable
        int b; //becomes random variable
        int alpha = -1;
        List<int> hashofm;
        List<int> blackhash;
        string mood;
        LEModApi api;
        public double[] CMS;

    

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




           /* H.Health
            H.resilience.Value
            H.Slipperiness
            H.ExperienceGained 
            H.Scale
            H.Speed */

        }

        public double[] MoodMultis
        {
            get
            {
                double he = 1.0;
                double res = 1.0;
                double sl = 1.0;
                double exp = 1.0;
                double sc = 1.0;
                double sp = 1.0;
                if (mood == "Happy")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.1;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Content")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.2;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Untroubled")
                {
                    he = 0.85;
                    res = 0.9;
                    sl = 1.0;
                    exp = 1.25;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Sad")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 0.9;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Gloomy")
                {
                    he = 1.0;
                    res = 0.8;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Depressed")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 0.65;
                    sc = 0.85;
                    sp = 0.8;
                }
                else if (mood == "Annoyed")
                {
                    he = 1.8;
                    res = 2.0;
                    sl = 1.85;
                    exp = 2.2;
                    sc = 1.0;
                    sp = 1.25;
                }
                else if (mood == "Angry")
                {
                    he = 2.0;
                    res = 3.0;
                    sl = 2.0;
                    exp = 2.45;
                    sc = 1.25;
                    sp = 1.75;
                }
                else if (mood == "Furious")
                {
                    he = 2.5;
                    res = 4.25;
                    sl = 2.0;
                    exp = 2.75;
                    sc = 1.5;
                    sp = 2.0;
                }
                else if (mood == "Mellow")
                {
                    he = 1.0;
                    res = 0.9;
                    sl = 1.0;
                    exp = 1.15;
                    sc = 1.0;
                    sp = 0.9;
                }
                else if (mood == "Serene")
                {
                    he = 0.95;
                    res = 0.8;
                    sl = 1.0;
                    exp = 1.25;
                    sc = 1.68;
                    sp = 1.8;
                }
                else if (mood == "Enlightened")
                {
                    he = 0.85;
                    res = 0.75;
                    sl = 0.9;
                    exp = 1.45;
                    sc = 1.0;
                    sp = 0.9;
                }
                else if (mood == "Indifferent")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Uncaring")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 1.25;
                    sp = 1.25;
                }
                else if (mood == "Uninterested")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 2.0;
                    sp = 2.0;
                }
                else if (mood == "Tired")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 1.0;
                    sp = 0.85;
                }
                else if (mood == "Restless")
                {
                    he = 1.0;
                    res = 1.0;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 1.0;
                    sp = 0.6;
                }
                else if (mood == "Anxious")
                {
                    he = 0.9;
                    res = 0.9;
                    sl = 1.0;
                    exp = 1.0;
                    sc = 0.9;
                    sp = 0.5;
                }
                else if (mood == "Loved")
                {
                    he = 1.0;
                    res = 0.9;
                    sl = 1.0;
                    exp = 1.35;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Cherished")
                {
                    he = 1.0;
                    res = 0.75;
                    sl = 1.0;
                    exp = 1.65;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Adored")
                {
                    he = 1.0;
                    res = 0.2;
                    sl = 1.0;
                    exp = 1.95;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Mysterious")
                {
                    he = wnd.Next(1, 2);
                    res = wnd.Next(1, 2);
                    sl = wnd.Next(1, 2);
                    exp = wnd.Next(1, 2);
                    sc = wnd.Next(1, 2);
                    sp = wnd.Next(1, 2);
                }
                else if (mood == "Cryptic")
                {
                    he = wnd.Next(1, 4);
                    res = wnd.Next(1, 4);
                    sl = wnd.Next(1, 4);
                    exp = wnd.Next(1, 4);
                    sc = wnd.Next(1, 4);
                    sp = wnd.Next(1, 4);
                }
                else if (mood == "Unexplainable")
                {
                    he = wnd.Next(1, 6);
                    res = wnd.Next(1, 6);
                    sl = wnd.Next(1, 6);
                    exp = wnd.Next(1, 6);
                    sc = wnd.Next(1, 6);
                    sp = wnd.Next(1, 6);
                }
                else if (mood == "Arrogant")
                {
                    he = 4.0;
                    res = 0.9;
                    sl = 1.0;
                    exp = 2.3;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Narcissistic")
                {
                    he = 6.0;
                    res = 0.7;
                    sl = 1.0;
                    exp = 2.6;
                    sc = 1.0;
                    sp = 1.0;
                }
                else if (mood == "Egotistical")
                {
                    he = 9.0;
                    res = 0.6;
                    sl = 1.0;
                    exp = 3.0;
                    sc = 1.15;
                    sp = 1.15;
                }
                else if (mood == "Crazy")
                {
                    he = 3.5;
                    res = 1.85;
                    sl = 1.5;
                    exp = 3.3;
                    sc = 1.0;
                    sp = 1.8;
                }
                else if (mood == "Irrational")
                {
                    he = 5.0;
                    res = 2.9;
                    sl = 2.0;
                    exp = 4.65;
                    sc = 1.65;
                    sp = 2.3;
                }
                else if (mood == "Insane")
                {
                    he = 6.0;
                    res = 4.0;
                    sl = 2.0;
                    exp = 6.0;
                    sc = 2.0;
                    sp = 2.6;
                }
                else if (mood == "Holy shit just sleep again.")
                {
                    he = 15.0;
                    res = 10.0;
                    sl = 4.0;
                    exp = 40.0;
                    sc = 3.0;
                    sp = 3.0;
                }
                double[] nutty = { he, res, sl, exp, sc, sp };
                return nutty;
            }
        }

        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {

            if (Context.IsWorldReady)
            {
                x = wnd.Next(1, 14);
                z = wnd.Next(1, 100);
                a = wnd.Next(1, 100);
                b = wnd.Next(1, 100);
                // 1 - Happy | 2 - Sad | 3 - Angry | 4 - Enlightened | 5 - Moody | 6 - Depressed | 7 - Elated | 8 - Dying | 9 - Furious
                if(x == 1 && z == 1 && b == 1 && a == 1)
                {
                    mood = "Holy shit just sleep again.";
                }
                if (x == 1 && z > 13 && z < 69)
                {
                    mood = "Happy";
                }
                else if (x == 1 && z > 68)
                {
                    mood = "Content";

                }
                else if (x == 1 && z < 14)
                {
                    mood = "Untroubled";
                }
                else if (x == 2 && z > 17)
                {
                    mood = "Sad";
                }
                else if (x == 2 && z < 17)
                {
                    mood = "Depressed";
                }

                else if (x == 3 && z > 42)
                {
                    mood = "Depressed";
                    Game1.player.Stamina = (int)(Game1.player.Stamina * .5);
                    Game1.player.health = (int)(Game1.player.health * .9);
                }
                else if (x == 4 && z > 83)
                {
                    mood = "Depressed";
                }
                else if (x == 5 && z > 30)
                {
                    mood = "Depressed";
                }
                else if (x == 6 && z > 63)
                {
                    mood = "Depressed";
                }
                else if (x == 7 && z > 60)
                {
                    mood = "Depressed";
                }
                else if (x == 8)
                {
                    mood = "Depressed";
                }
                else if (x == 9)
                {
                    mood = "Enlightened";
                    Game1.player.health = (int)(Game1.player.health * 1.15);
                    Game1.player.Stamina = (int)(Game1.player.Stamina * 1.25);
                }
                else if (x == 9)
                {
                    mood = "Depressed";
                }
                else if (x == 9)
                {
                    mood = "Depressed";
                }
                else if (x == 10 && z > 77)
                {
                    mood = "Depressed";
                }
                else if (x == 10 && z > 42 && z < 78)
                {
                    mood = "Depressed";
                }
                else if (x == 10 && z < 43)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Mysterious";
                    double rnd = wnd.Next(0, 13);
                    rnd = rnd / 1000.0;
                    api.Spawn_Rate(rnd);
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                    
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                else if (x > 10)
                {
                    mood = "Depressed";
                }
                CMS = MoodMultis;
                DisplayMood();
            }
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

            foreach (NPC m in Game1.player.currentLocation.characters.OfType<NPC>())

            {


                if (m.IsMonster && hashofm.Contains(m.GetHashCode()) && !blackhash.Contains(m.GetHashCode()))
                {
                    Monster H = (m as Monster);
                    H.Health = (int)(H.Health * CMS[0]);
                    H.resilience.Value = (int)(H.resilience.Value * CMS[1]);
                    H.Slipperiness = (int)(H.Slipperiness * CMS[2]);
                    H.ExperienceGained = (int)(H.ExperienceGained * CMS[3]);
                    H.Scale = (int)(H.Scale * CMS[4]);
                    H.Speed = (int)(H.Speed * CMS[5]);
                    blackhash.Add(m.GetHashCode());
                    hashofm.Remove(m.GetHashCode());
                    //Monitor.Log("-MOODY--PLANET-> Applied status changes to monsters in this location. <--DEBUG--");
                }
            }
           
            
        }

        public void DisplayMood()
        {
            Monitor.Log($"-MOODY--PLANET-> World Mood : {mood} <--DEBUG--");
            HUDMessage message = new HUDMessage($"The world is {mood} today!");
            message.color = new Color(218, 165, 32);
            Game1.addHUDMessage(message);


            message.timeLeft += 7000.0f;
            message.noIcon = true;

            message.update(Game1.currentGameTime);
        }

    }

}
