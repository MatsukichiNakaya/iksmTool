using System.Collections.Generic;

namespace iksmTool
{
    public class Rule
    {
        public string key { get; set; }
        public string name { get; set; }
        public string multiline_name { get; set; }
    }

    public class Stage
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class GameMode
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    public class MyTeamResult
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    public class OtherTeamResult
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    public class Udemae
    {
        public int number { get; set; }
        public string name { get; set; }
        public bool is_number_reached { get; set; }
        public bool is_x { get; set; }
        public int? s_plus_number { get; set; }
    }

    public class Brand
    {
        public string id { get; set; }
        public string name { get; set; }
        public FrequentSkill frequent_skill { get; set; }
        public string image { get; set; }
    }

    public class FrequentSkill
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class Main
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class Skills
    {
        public Main main { get; set; }
        public List<Sub> subs { get; set; }
    }

    public class Gear
    {
        public string id { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public Brand brand { get; set; }
        public int rarity { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
    }

    public class Weapon
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public Special special { get; set; }
        public Sub2 sub { get; set; }
    }

    public class Sub
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class Sub2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image_a { get; set; }
        public string image_b { get; set; }
    }

    public class Special
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image_a { get; set; }
        public string image_b { get; set; }
    }

    public class PlayerType
    {
        public string style { get; set; }
        public string species { get; set; }
    }

    public class Player
    {
        public string principal_id { get; set; }
        public PlayerType player_type { get; set; }
        public string nickname { get; set; }
        public int player_rank { get; set; }
        public int star_rank { get; set; }
        public Udemae udemae { get; set; }
        public Gear head { get; set; }
        public Gear clothes { get; set; }
        public Gear shoes { get; set; }
        public Skills head_skills { get; set; }
        public Skills clothes_skills { get; set; }
        public Skills shoes_skills { get; set; }
        public Weapon weapon { get; set; }
    }

    public class PlayerResult
    {
        public int kill_count { get; set; }
        public int assist_count { get; set; }
        public int death_count { get; set; }
        public int special_count { get; set; }
        public int game_paint_point { get; set; }
        public Player player { get; set; }
        public int sort_score { get; set; }
    }

    public class Result
    {
        public string battle_number { get; set; }
        public string type { get; set; }
        public int start_time { get; set; }
        public int elapsed_time { get; set; }
        public GameMode game_mode { get; set; }
        public Rule rule { get; set; }
        public Stage stage { get; set; }
        public int estimate_gachi_power { get; set; }
        public object estimate_x_power { get; set; }
        public Udemae udemae { get; set; }
        public object x_power { get; set; }

        public object rank { get; set; }
        public int player_rank { get; set; }
        public int star_rank { get; set; }

        public PlayerResult player_result { get; set; }
        public MyTeamResult my_team_result { get; set; }
        public double? my_team_percentage { get; set; }
        public OtherTeamResult other_team_result { get; set; }
        public double? other_team_percentage { get; set; }
        public int my_team_count { get; set; }
        public int other_team_count { get; set; }
        public object crown_players { get; set; }
        public int weapon_paint_point { get; set; }

        public double? win_meter { get; set; }
    }

    public class Summary
    {
        public int count { get; set; }
        public double kill_count_average { get; set; }
        public double assist_count_average { get; set; }
        public double death_count_average { get; set; }
        public double special_count_average { get; set; }
        public int victory_count { get; set; }
        public int defeat_count { get; set; }
        public double victory_rate { get; set; }
    }

    public class ResultModel
    {
        public string unique_id { get; set; }
        public Summary summary { get; set; }
        public List<Result> results { get; set; }
    }
}
