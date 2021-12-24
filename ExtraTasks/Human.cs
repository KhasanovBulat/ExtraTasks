using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraTasks
{
    class Human : Character
    {
        
        public string action; //ответное действие
        public bool isAlive;
        public List<Stuff> mealList = new List<Stuff>(); //у человека это будет пища, у нечести - список подарков или еда, которую нечесть забирает

        public Human(string characterType, string action)
        {
            isAlive = true;
            this.characterType = characterType;
            this.action = action;
        }

        public void TakeGift(Stuff gift) //принимаем подарок
        {
            int index = mealList.IndexOf(gift);
            if (index != -1)
            {
                //Если такой подарок уже есть, то просто увеличиваем его кол-во
                mealList[index].count += gift.count;
            }
            else
            {
                //если подарка такого еще нет, то просто добавляем его в список
                mealList.Add(gift);
            }
        }

        public override string ToString()
        {
            string condition = isAlive ? "Живой" : "Мертвый"; //тернарный оператор
            return $"{characterType}, сотояние: {condition}, кол-во подарков: {mealList.Count}";
        }

    }
}
