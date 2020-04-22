using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Graffiti
    {
        public static string[] Logo = new string[] {
                                         @".-- -.         .       ,---.               ",
                                         @" \___  ,-. ,-. | , ,-. |  -'  ,-. ,-,-. ,-.",
                                         @"     \ | | ,-| |<  |-' |  ,-' ,-| | | | |-'",
                                         @" `---' ' ' `-^ ' ` `-' `---|  `-^ ' ' ' `-'",
                                         @"                        ,-.|               ",
                                         @"                        `-+'               "
                                         };

        public static string[] GameOver = {"────────────────────────────────────────────────────────────────────────────────────",

                                 "─██████──────────██████─██████████████─██████████████─██████████████─████████████───",

                                 "─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░████─",

                                 "─██░░██──────────██░░██─██░░██████████─██████░░██████─██░░██████████─██░░████░░░░██─",

                                 "─██░░██──────────██░░██─██░░██─────────────██░░██─────██░░██─────────██░░██──██░░██─",

                                 "─██░░██──██████──██░░██─██░░██████████─────██░░██─────██░░██████████─██░░██──██░░██─",

                                 "─██░░██──██░░██──██░░██─██░░░░░░░░░░██─────██░░██─────██░░░░░░░░░░██─██░░██──██░░██─",

                                 "─██░░██──██░░██──██░░██─██████████░░██─────██░░██─────██░░██████████─██░░██──██░░██─",

                                 "─██░░██████░░██████░░██─────────██░░██─────██░░██─────██░░██─────────██░░██──██░░██─",

                                 "─██░░░░░░░░░░░░░░░░░░██─██████████░░██─────██░░██─────██░░██████████─██░░████░░░░██─",

                                 "─██░░██████░░██████░░██─██░░░░░░░░░░██─────██░░██─────██░░░░░░░░░░██─██░░░░░░░░████─",

                                 "─██████──██████──██████─██████████████─────██████─────██████████████─████████████───",

                                 "────────────────────────────────────────────────────────────────────────────────────" };

        public static string[] Control ={"    U    ",
                                        "    ^    ",
                                        "    |    ",
                                        "L<-- -->R",
                                        "    |    ",
                                        "    v    ", };
        public static string[] Introduction = {"The Snake design dates back to the arcade game Blockade, developed and published by Gremlin in 1976. ",
                                               "It was cloned as Bigfoot Bonkers the same year.",
                                               "In 1977, Atari released two Blockadeinspired titles: the arcade game Dominos and Atari VCS game Surround.",
                                               "Surround was one of the nine Atari VCS (later the Atari 2600) launch titles in the United States.",
                                               "Was also sold by Sears under the name Chase.",
                                               "That same year, a similar game was launched for the Bally Astrocade as Checkmate."};
    }
}