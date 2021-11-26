using System;
using System.Collections.Generic;
using System.Text;


namespace patterns_lab_3
{


    interface IHero
    {
        int Hp { get; set; }
        Hero Next { get; set; }
        void MustWin(Orc enemy);
    }


    class Hero : IHero
    {
        public int Hp { get; set; }
        public Hero Next { get; set; }

        public string Name => this.GetType().Name;

        public Hero(int hp, Hero hero)
        {
            this.Hp = hp;
            Next = hero;
        }

        public void MustWin(Orc enemy)
        {
            if (this.Hp > enemy.Hp)
            {
                Console.WriteLine($"{Name} смог");
            }
            else
            {
                if (Next != null)
                {
                    Console.WriteLine($"{Name} не смог. Попробует {(Next.GetType().Name)}");
                    Next.MustWin(enemy);
                    return;
                }
                Console.WriteLine($"{Name} Не смог. Враг победил");
            }
        }

        
    }

    class Orc
    {
        public Orc(int hp = 30) => Hp = hp;

        public int Hp { get; set; }
    }

    class Gendalf : Hero
    {
        public Gendalf(int hp = 110, Hero next = null) : base(hp, next) { }
    }

    class Sam : Hero
    {
        public Sam(int hp = 70, Hero next = null) : base(hp, next) { }
    }

    class Aragorn : Hero
    {
        public Aragorn(int hp = 50, Hero next = null) : base(hp, next) { }
    }

}
