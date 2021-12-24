using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Undead> undeadList = new List<Undead>();
            Undead undead1 = new Undead("Вампир", 10, new Stuff("Кровь", 2));// имя, время жизни, пища нечисти
            undead1.giftList.Add(new Stuff("Бессмертие", 1)); //подарки нечисти
            undeadList.Add(undead1);

            undead1 = new Undead("Ведьма", 5, new Stuff("Кровь", 1));
            undead1.giftList.Add(new Stuff("Конфета", 5)); //подарки нечисти
            undeadList.Add(undead1);

            Undead undead3 = new Undead("Оборотень", 5, new Stuff("жизнь", 1));
            undead3.giftList.Add(null);
            undeadList.Add(undead3);

            Undead undead4 = new Undead("Призрак", 5, new Stuff("жизнь", 1));
            undead4.giftList.Add(null);
            undeadList.Add(undead4);

            Undead undead5 = new Undead("Демон", 10, new Stuff("жизнь", 1));
            undead5.giftList.Add(new Stuff("Восстановление крови", 1));
            undeadList.Add(undead5);

            Undead undead6 = new Undead("Зомби", 5, new Stuff("кровь", 1.5));
            undead6.giftList.Add(null);
            undeadList.Add(undead6);

            Undead undead7 = new Undead("Черная вдова", 10, new Stuff("Конфета", 3));
            undead7.giftList.Add(new Stuff("Восстановление крови", 1.5));

            List<Human> humanList = new List<Human>();
            Human human1 = new Human("Взрослый", null);
            human1.mealList.Add(new Stuff("Конфеты", 5)); //пища, которая есть у человека
            human1.mealList.Add(new Stuff("кровь", 1)); //пища, которая есть у человека
            human1.mealList.Add(new Stuff("жизнь", 1)); //пища, которая есть у человека
            humanList.Add(human1);

            Human human2 = new Human("Ребенок", null);
            human2.mealList.Add(new Stuff("Конфеты", 5)); //пища, которая есть у человека
            human2.mealList.Add(new Stuff("кровь", 0.5)); //пища, которая есть у человека
            human2.mealList.Add(new Stuff("жизнь", 1)); //пища, которая есть у человека
            humanList.Add(human1);

            Human human3 = new Human("Ведьмак", "Может убить нечисть");

            //Human human4 = new Human("Бабуля", null);
            //human4.mealList.Add(new Stuff("Пирожки", 1));
            //human4.mealList.Add(new Stuff("кровь", 0.5));

            //Human human5 = new Human("Дедуля", null);
            //human5.mealList.Add(new Stuff("жизнь", 1));

            //Human human6 = new Human("Подросток", null);
            //human5.mealList.Add(new Stuff("Конфеты", 2));

            //Human human7 = new Human("Младенец", null);
            //human5.mealList.Add(new Stuff("жизнь", 1));


            int i = 0;
            foreach (Undead undead in undeadList)
            {
                Human human = humanList[i++];
                    if (human.isAlive && undead.lifeTime > 0)
                    {
                        if (human.characterType == "Ведьмак")
                        {
                            undead.lifeTime = 0;
                            Console.WriteLine($"{human.characterType} убил {undead.characterType}");
                        }
                        else
                        {
                            undead.MakeAction(human);
                        }
                    }              
            }

            Console.WriteLine("Информация о нечисти:");
            foreach (Undead undead in undeadList)
            {
                Console.WriteLine(undead);
            }

            Console.WriteLine("Информация о людях:");
            foreach (Human human in humanList)
            {
                Console.WriteLine(human);
            }
        }
    }
}
