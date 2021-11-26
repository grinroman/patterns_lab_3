using System;
using System.Collections.Generic;
using System.Text;

namespace patterns_lab_3
{

    // Originator
    class Player
    {
        private int patrons = 10; // кол-во патронов
        private int lives = 5; // кол-во жизней

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Производим выстрел. Осталось {0} патронов", patrons);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }
        // сохранение состояния
        public PlayerMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", patrons, lives);
            return new PlayerMemento(patrons, lives);
        }

        // восстановление состояния
        public void RestoreState(PlayerMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней", patrons, lives);
        }
    }
    // Memento
    class PlayerMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public PlayerMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<PlayerMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<PlayerMemento>();
        }
    }

}
