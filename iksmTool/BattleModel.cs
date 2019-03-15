using System;
using System.Collections.Generic;

namespace iksmTool
{
    public class TeamMember
    {
        public Int32 kill_count { get; set; }
        public Int32 assist_count { get; set; }
        public Int32 death_count { get; set; }
        public Int32 special_count { get; set; }
        public Int32 game_paint_point { get; set; }
        public Player player { get; set; }
        public Int32 sort_score { get; set; }
    }

    public class BattleModel
    {
        public String battle_number { get; set; }
        public String type { get; set; }
        public Int32 start_time { get; set; }
        public Int32 elapsed_time { get; set; }
        public GameMode game_mode { get; set; }
        public Rule rule { get; set; }
        public Stage stage { get; set; }
        public Int32 estimate_gachi_power { get; set; }
        public Int32? estimate_x_power { get; set; }
        public Udemae udemae { get; set; }
        public Int32? x_power { get; set; }

        public object rank { get; set; }
        public Int32 player_rank { get; set; }
        public Int32 star_rank { get; set; }

        public PlayerResult player_result { get; set; }
        public List<TeamMember> my_team_members { get; set; }
        public List<TeamMember> other_team_members { get; set; }
        public MyTeamResult my_team_result { get; set; }
        public OtherTeamResult other_team_result { get; set; }
        
        public Int32 my_team_count { get; set; }
        public Int32 other_team_count { get; set; }
        public object crown_players { get; set; }
        public Int32 weapon_paint_point { get; set; }
    }
}
