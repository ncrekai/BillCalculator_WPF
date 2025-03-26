using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp
{
    public class MenuService
    {
        public static IEnumerable<MenuItem> GetAll(string course)
        {
            if (course.Equals("beverage"))
            {
                yield return new MenuItem("Soda", 1.95);
                yield return new MenuItem("Tea", 1.50);
                yield return new MenuItem("Coffee", 1.25);
                yield return new MenuItem("Mineral Water", 2.95);
                yield return new MenuItem("Juice", 2.50);
                yield return new MenuItem("Milk", 1.50);
            }
            else if (course.Equals("appetizer"))
            {
                yield return new MenuItem("Buffalo Wings", 5.95);
                yield return new MenuItem("Buffalo Fingers", 6.95);
                yield return new MenuItem("Potato Skins", 8.95);
                yield return new MenuItem("Nachos", 8.95);
                yield return new MenuItem("Mushroom Caps", 10.95);
                yield return new MenuItem("Shrimp Cocktail", 12.95);
                yield return new MenuItem("Chips and Salsa", 6.95);

            }
            else if (course.Equals("main"))
            {
                yield return new MenuItem("Seafood Alfredo", 15.95);
                yield return new MenuItem("Chicken Alfredo", 13.95);
                yield return new MenuItem("Chicken Picatta", 13.95);
                yield return new MenuItem("Turkey Club", 11.95);
                yield return new MenuItem("Lobster Pie", 19.95);
                yield return new MenuItem("Prime Rib", 20.95);
                yield return new MenuItem("Shrimp Scampi", 18.95);
                yield return new MenuItem("Turkey Dinner", 13.95);
                yield return new MenuItem("Stuffed Chicken", 14.95);
            }
            else if (course.Equals("dessert"))
            {
                yield return new MenuItem("Apple Pie", 5.95);
                yield return new MenuItem("Sundae", 3.95);
                yield return new MenuItem("Carrot Cake", 5.95);
                yield return new MenuItem("Mud Pie", 4.95);
                yield return new MenuItem("Apple Crisp", 5.95);
            }
        }

    }
}
