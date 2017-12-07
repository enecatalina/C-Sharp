namespace ConsoleApplicaton{
    public class Human{
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        // public Human(){
        //     strength = 3;
        //     intelligence = 3;
        //     dexterity = 3;
        //     health = 100;
        // }
        public Human(string nam)
        {
            name = nam;
        }

        public Human(string nam, int strth, int intell, int dex, int hlth){
            name = nam;
            strength = strth;
            intelligence = intell;
            dexterity = dex;
            health = hlth;
        }
        public void Attack(object target)
        {
            Human enemy = target as Human;
            {
                enemy.health -= 5 * strength;
            }
        }
    }
}
