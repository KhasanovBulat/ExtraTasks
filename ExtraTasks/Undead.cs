using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraTasks
{
    class Undead : Character
    {
        
        public List<Stuff> giftList = new List<Stuff>();
        public Stuff undeadMeal; //
        public int lifeTime;
        public Stuff givedGift; //подаренный подарок
        Random rnd = new Random();

        public Undead(string characterType, int lifeTime, Stuff undeadMeal)
        {
            this.characterType = characterType;
            this.lifeTime = lifeTime;
            this.undeadMeal = undeadMeal;
        }

        public bool IsGift()
        {
            int val = rnd.Next(0, 3);
            bool result = val == 0;
            return result;
        }
        Stuff GetGift() //
        {
            Stuff gift = giftList[0];
            giftList.RemoveAt(0);
            return gift;
        }

        public void MakeAction(Human human) // действие, которое совершит нечисть с человеком
        {
            
            if (IsGift()) // если нечисть подарила подарок
            {
                Stuff gift = GetGift(); // отдаем подарок
                givedGift = gift; //сохраняем подранный подарок
                human.TakeGift(gift); // человек принимает
                Console.WriteLine($"{characterType} подарил {human.characterType} подарок {gift.stuffType}");
            }
            else
            {
                //ищем эту пищу у человека
                int index = human.mealList.IndexOf(undeadMeal);
                //если такая пища есть в списке человека
                if (index != -1)
                {
                    //уменьшаем кол-во пищи у человека на то кол-во, которое забрала нечисть
                    human.mealList[index].count -= undeadMeal.count;
                    Console.WriteLine($"{characterType} забрал(а) {human.characterType} еду {undeadMeal.stuffType}");

                    //проверяем, что если нечисть забрала всю кровь или жизнь и человек не бессмертный
                    if ((human.mealList[index].stuffType == "Кровь" || human.mealList[index].stuffType == "Жизнь")
                        && human.mealList[index].count <= 0 && !human.mealList.Contains(new Stuff("Бессмертие", 1)))
                    {
                        Console.WriteLine($"{human.characterType} погиб");
                        human.isAlive = false;
                    }
                    //?? Надо ли удалять объект пищи у человек, если его count стал равен 0
                }
            }
            
        }

        public override string ToString()
        {
            string condition = lifeTime >0 ? "Живой" : "Мертвый"; // тернарный оператор
            string giftCond = givedGift != null ? "Подарил подарок" : "Не дарил подарок"; // тернарный оператор
            string giftInfo = givedGift != null ? givedGift.stuffType : "нет"; // тернарный оператор

            return $"{characterType}, подарок: {giftInfo}, дарил или нет: {giftCond}, состояние: {condition}";
        }
    }
}
