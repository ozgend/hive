using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L4D2Launcher.Model
{
    public class Parameters
    {

        //valve documentation:
        //https://developer.valvesoftware.com/wiki/Command_Line_Options
        //https://developer.valvesoftware.com/wiki/Category:Console_Variables


        public const string TargetName = "left4dead2.exe";


        //parameters
        [CommandAlias("-steam", false)]
        public bool Steam { get; set; }

        [CommandAlias("-console", false)]
        public bool Console { get; set; }

        [CommandAlias("-insecure", false)]
        public bool Insecure { get; set; }


        //cl variables
        [CommandAlias("+maxplayers", true)]
        public int MaxPlayers { get; set; }

        [CommandAlias("+sv_cheats", true)]
        public bool Cheats { get; set; }

        [CommandAlias("+physcannon_mega_enabled", true)]
        public bool Physcannon { get; set; }

        [CommandAlias("+sv_allow_lobby_connect_only", true)]
        public bool LobbyOnly { get; set; }

        [CommandAlias("+sv_lan", true)]
        public bool Lan { get; set; }

        [CommandAlias("+z_difficulty", true)]
        public int Difficulty { get; set; }

        [CommandAlias("+map", true)]
        public string Map { get; set; }


        /*
         
         left4dead2.exe 
         -steam 
         -console 
         -insecure 
         +sv_allow_lobby_connect_only 0 
         +sv_lan 0 
         +z_difficulty 1
         +map c4m1_milltown_a

         
         */


    }
}
