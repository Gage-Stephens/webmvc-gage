namespace WebMVC_API_Gage.Models
{
    public class Character
    {
        public int? Id { get; set; }
        // Properties
        public string? Name { get; set; }
        public int Health { get; set; }
        public string? Race { get; set; }
        public int Strength { get; set; }

        public Character(int? id, string? name, int health, string? race, int strength)
        {
            Id = id;
            Name = name;
            Health = health;
            Race = race;
            Strength = strength;
        }

        public Character()
        {
            return;
        }

    }
}
