using System;
using System.Collections.Generic;
using System.Text;

namespace WorldAbstractFactory
{
    
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Спроектируйте приложение, 
             используя паттерн «абстрактная фабрика», 
             который будет симулировать животную жизнь на разных континентах земного шара.
            */

            AnimalWorld animalWorld = new AnimalWorld();

            animalWorld.MealsHerbivores();
            animalWorld.NutritionCarnivores();

            Console.ReadKey();
        }
    }

    public class AnimalWorld
    {
        //Всеми процессами в программе будет управлять класс «мир животных» (клиент)

        public AnimalWorld()
        {
        }
        //Питание травоядных(Meals herbivores) -метод клиента, 
        //который инициирует всех травоядных приступить к кормежке
        public void MealsHerbivores()
        {
            List<Herbivore> herbivoresList = new List<Herbivore>();
            herbivoresList.Add(new Wildebeest());
            herbivoresList.Add(new Bison());
            herbivoresList.Add(new Elk());

            List<Herbivore> createdHerbivoresList = new List<Herbivore>();

            Random r = new Random();
            int randomInt;

            for (int i = 0; i < 5; i++)
            {
                randomInt = r.Next(0, herbivoresList.Count);

                Herbivore CreatedHerbivore = herbivoresList[randomInt];
                CreatedHerbivore.Life = true;
                createdHerbivoresList.Add(CreatedHerbivore);
            }

            foreach (var item in createdHerbivoresList)
            {
                item.Walk();
            }
        }

        //Питание плотоядных (Nutrition carnivores) - метод клиента, 
        //который заставит всех плотоядных охотится на травоядных
        public void NutritionCarnivores()
        {
            List<Carnivore> carnivoresList = new List<Carnivore>();
            carnivoresList.Add(new Lion());
            carnivoresList.Add(new Wolf());

            List<Carnivore> createdCarnivoresList = new List<Carnivore>();

            Random r = new Random();
            int randomInt;

            for (int i = 0; i < 5; i++)
            {
                randomInt = r.Next(0, carnivoresList.Count);

                Carnivore CreatedCarnivore = carnivoresList[randomInt];
                CreatedCarnivore.Life = true;
                createdCarnivoresList.Add(CreatedCarnivore);
            }

            foreach (var item in createdCarnivoresList)
            {
                item.Walk();
            }
        }
    }

    public abstract class Continent : AnimalWorld
    {
        //Континент (Continent) - абстрактная фабрика
        public int Area { get; set; }
    }

    public class Africa : Continent
    {
        //Африка (Africa) - конкретная фабрика

        public Africa()
        {
            Area = 100;
        }
    }

    public class NorthAmerica : Continent
    {
        //Северная Америка(North America) - конкретная фабрика
        public NorthAmerica()
        {
            Area = 80;
        }
    }

    public abstract class Herbivore : IAnimal
    {
        //Травоядное животное(Herbivore) - абстрактный продукт

        //Вес (Weight) - свойство травоядного животного
        public int Weight { get; set; }

        //Кушать траву (Eat grass) - метод конкретного продукта
        abstract public void EatGrass();

        //Жизнь (Life) - свойство животного (характеризует живое ли существо)
        public bool Life { get; set; }

        public void Walk ()
        {
            string str = this.ToString();
            Console.WriteLine(str + " Created Herbivore");
        }
    }

    class HerbivoreCreater
    {
        
    }

    public class Wildebeest : Herbivore //Антилопа Гну : Травоядное животное
    {
        public Wildebeest()
        {
            Walk();
            Console.WriteLine("Wildebeest Created");
        }
        override public void EatGrass()
        {
            Weight = +10;
            Console.WriteLine("Wildebeest Weight +" + 10);
        }
    }

    public class Bison : Herbivore //Бизон :  Травоядное животное
    {
        public Bison()
        {
            Walk();
            Console.WriteLine("Bison Created");
        }
        override public void EatGrass()
        {
            Weight = +10;
            Console.WriteLine("Bison Weight +" + 10);
        }
    }

    public abstract class Carnivore : IAnimal
    {
        //Плотоядное животное (Carnivore) - абстрактный продукт

        //Сила (Power) - свойство плотоядного животного
        public int Power { get; set; }

        //Кушать травоядное животное (Eat) - метод конкретного продукта, 
        //при выполнении которого проверяется, 
        //является ли сила плотоядного животного больше, 
        //чем вес травоядного, которого он съедает.
        //Если является, то хищник получает +10 к силе, иначе, 
        //если сила меньше, чем вес травоядного животного, 
        //то сила плотоядного уменьшаются на -10
        abstract public void Eat(Herbivore herbivore);

        //Жизнь (Life) - свойство животного (характеризует живое ли существо)
        public bool Life { get; set; }

        public void Walk()
        {
            string str = this.ToString();
            Console.WriteLine(str + " Created Carnivore");
        }
    }

    public class Lion : Carnivore
    {
        public Lion()
        {
            Walk();
            Console.WriteLine("Lion Created");
        }
        public override void Eat(Herbivore herbivore)
        {
            //Кушать травоядное животное (Eat) - метод конкретного продукта, 
            //при выполнении которого проверяется, 
            //является ли сила плотоядного животного больше, 
            //чем вес травоядного, которого он съедает.
            //Если является, то хищник получает +10 к силе, иначе, 
            //если сила меньше, чем вес травоядного животного, 
            //то сила плотоядного уменьшаются на -10
            if (Power > herbivore.Weight)
            {
                Power += 10;
                Console.WriteLine("Lion Power +" + 10);
            }
            else
            {
                Power += 10;
                Console.WriteLine("Lion Power -" + 10);
            }
        }
    }

    public class Wolf : Carnivore
    {
        public Wolf()
        {
            Walk();
            Console.WriteLine("Wolf Created");
        }
        public override void Eat(Herbivore herbivore)
        {
            //Кушать травоядное животное (Eat) - метод конкретного продукта, 
            //при выполнении которого проверяется, 
            //является ли сила плотоядного животного больше, 
            //чем вес травоядного, которого он съедает.
            //Если является, то хищник получает +10 к силе, иначе, 
            //если сила меньше, чем вес травоядного животного, 
            //то сила плотоядного уменьшаются на -10
            if (Power > herbivore.Weight)
            {
                Power += 10;
                Console.WriteLine("Wolf Power +" + 10);
            }
            else
            {
                Power += 10;
                Console.WriteLine("Wolf Power -" + 10);
            }
        }
    }


    /*
    public abstract class PredatorsAnimals
    {
        abstract public void Eat(Herbivores animal);
    }

    public abstract class Predators : PredatorsAnimals//хищники
    {
        public override void Eat(Herbivores animal)
        {

        }
    }

    public abstract class Herbivores//травоядные
    {
        //public override void Eat(Animals animal)
        //{

        //}
    }
    */
    public interface IAnimal
    {
        void Walk();

        //void Creat();
    }

    public interface IAnimalType
    {
        
    }


    public class Eurasia : Continent
    {
        //новый континент «Евразия»
        Elk elk;
        Tiger tiger;

        public Eurasia()
        {
            Area = 120;
        }
    }

    public abstract class Elk : Herbivore //Лось : Травоядное животное
    {
        public Elk()
        {
            Walk();
            Console.WriteLine("Elk Created");
        }
        override public void EatGrass()
        {
            Weight = +11;
            Console.WriteLine("Elk Weight +" + 11);
        }
    }

    public abstract class Tiger : Carnivore //Тигр : Хищники
    {
        public override void Eat(Herbivore herbivore)
        {
            if (Power > herbivore.Weight)
            {
                Power += 11;
                Console.WriteLine("Tiger Power +" + 11);
            }
            else
            {
                Power += 11;
                Console.WriteLine("Tiger Power -" + 11);
            }
        }
    }
}
