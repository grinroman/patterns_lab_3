using System;
using System.Collections.Generic;
using System.Text;

namespace patterns_lab_3
{
    interface IObserver//сам наблюдатель
    {
        void Update(Object ob);
    }

    interface IObservable//наблюдаемый объект
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class DataStorage : IObservable
    {
        StorageInfo sInfo; // информация о торгах

        List<IObserver> observers;
        public DataStorage()
        {
            observers = new List<IObserver>();
            sInfo = new StorageInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Market()//торги
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StorageInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable dataStor;
        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            dataStor = obs;
            dataStor.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StorageInfo sInfo = (StorageInfo)ob;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }
        public void StopTrade()
        {
            dataStor.RemoveObserver(this);
            dataStor = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable dataStor;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            dataStor = obs;
            dataStor.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StorageInfo sInfo = (StorageInfo)ob;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }
    }
}
