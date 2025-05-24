namespace chi_task
{
    public class Program
    {
        public static List<Product> products = new() { new("Cheeseburger", 6.99m), new("Hamburger", 5.99m), new("Fries", 1.99m), new("Coke", 0.99m) };
        public static Cart userCart = new();

        static void Main(string[] args)
        {
            //Intro for ~~pizzazz~~ 
            Console.WriteLine("Made by Alex K.");
            Thread.Sleep(1000);
            //Exit flag for the loop
            bool exit = false;
            // Initial main menu
            MainMenu();
            //Main app loop
            while (!exit)
            {
                //Reading input from the user
                Console.Write("\nInput command: ");
                string? input = Console.ReadLine();
                Console.Write("\n");
                int choice;
                //Checking that input is indeed an int, pretty self-explanatory
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Error: input must be an int value!");
                    continue;
                }
                //Selecting the appropriate command based on user input
                switch (choice)
                {
                    case 0:
                        MainMenu();
                        break;
                    case 1:
                        GetProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        GetCartItems();
                        break;
                    case 5:
                        AddCartItem();
                        break;
                    case 6:
                        Checkout();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine($"Error: {choice} is unknown command.");
                        break;

                }
            }

        }

        /// <summary>
        /// Displays main menu with the available commands
        /// </summary>
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Hello, {Environment.MachineName}");
            Console.WriteLine(@"Available commands:
                                0. List commands
                                1. List available products
                                2. Add product
                                3. Delete product
                                4. List Cart items
                                5. Add Cart item
                                6. Checkout
                                7. Exit
                               ");
        }

        /// <summary>
        /// Lists all available products
        /// </summary>
        static void GetProducts()
        {
            Console.WriteLine("Listing products");
            Console.WriteLine("Available products:");
            //Formatting for a table-like look (gotta keep it pretty)
            string formatting = "{0, -25} {1,6:c}";
            Console.WriteLine(format: formatting, "Name", "Price");
            foreach (Product product in products)
            {
                Console.WriteLine(format: formatting, product.Name, product.Price);

            }
        }
        /// <summary>
        /// Let's the user add a new product to the products tab
        /// </summary>
        static void AddProduct()
        {
            Console.WriteLine("Adding new product");
            Console.WriteLine("Input new product's name: ");
            string? inputName = Console.ReadLine();
            Console.Write("\n");
            if (inputName == null)
            {
                Console.WriteLine("Error: Name can't be null, this error shouldn't happen!");
                return;
            }
            if (inputName.Length == 0)
            {
                Console.WriteLine("Error: Name cannot be empty!");
                return;
            }

            Console.WriteLine("Input new product's price: ");
            string? inputPrice = Console.ReadLine();
            decimal priceResult;
            if (!decimal.TryParse(inputPrice, out priceResult))
            {
                Console.WriteLine($"Error: {inputPrice} is not a number!");
                return;
            }
            Console.Write("\n");
            Product newProduct = new(inputName, priceResult);
            products.Add(newProduct);
            Console.WriteLine("New product created.");
        }

        /// <summary>
        /// Let's the user delete any product
        /// </summary>
        static void DeleteProduct()
        {
            Console.WriteLine("Deleting product:");
            Console.WriteLine("Input product's name: ");
            string? inputName = Console.ReadLine();
            Console.Write("\n");
            if (inputName == null)
            {
                Console.WriteLine("Error: Name can't be null, this error shouldn't happen!");
                return;
            }
            if (inputName.Length == 0)
            {
                Console.WriteLine("Error: Name cannot be empty!");
                return;
            }
            Product product = products.Find(x => x.Name.ToLower().Trim() == inputName.ToLower().Trim());
            if (product == null)
            {
                Console.WriteLine($"Error: No product with {inputName} name found");
                return;
            }
            products.Remove(product);
            Console.WriteLine("Product removed.");
        }

        /// <summary>
        /// Lists all items that the user added to the cart
        /// </summary>
        static void GetCartItems()
        {
            Console.WriteLine("Showing cart items");
            Console.WriteLine("Items in the cart:");
            List<Product> items = userCart.GetProducts();
            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty");
                return;
            }
            string formatting = "{0, -25} {1,6:c}";
            Console.WriteLine(format: formatting, "Name", "Price");
            foreach (Product item in items)
            {
                Console.WriteLine(format: formatting, item.Name, item.Price);
            }
            decimal total = userCart.GetTotalAmount();
            Console.WriteLine($"Total price: {total:c}");
        }

        /// <summary>
        /// Adds a product to the cart
        /// </summary>
        static void AddCartItem()
        {
            Console.WriteLine("Adding cart item");
            Console.WriteLine("Input product's name: ");
            string? inputName = Console.ReadLine();
            Console.Write("\n");
            if (inputName == null)
            {
                Console.WriteLine("Error: Name can't be null, this error shouldn't happen!");
                return;
            }
            if (inputName.Length == 0)
            {
                Console.WriteLine("Error: Name cannot be empty!");
                return;
            }
            Product product = products.Find(x => x.Name.ToLower().Trim() == inputName.ToLower().Trim());
            if (product == null)
            {
                Console.WriteLine($"Error: No product with {inputName} name found");
                return;
            }
            userCart.AddProduct(product);
            Console.WriteLine($"Added {product.Name} to cart.");
        }

        /// <summary>
        /// Shows the checkout and lets the user input budget
        /// </summary>
        static void Checkout()
        {
            Console.WriteLine("Checkout");
            List<Product> products = userCart.GetProducts();
            if(products.Count == 0)
            {
                Console.WriteLine("No items in the cart, go add some!");
                return;
            }
            Console.WriteLine("You are purchasing:");
            string formatting = "{0, -25} {1,6:c}";
            Console.WriteLine(format: formatting, "Name", "Price");
            foreach (Product item in products)
            {
                Console.WriteLine(format: formatting, item.Name, item.Price);

            }
            decimal total = userCart.GetTotalAmount();
            Console.WriteLine($"Total price: {total:c}");
            Console.WriteLine("Input your budget: ");
            string? inputPrice = Console.ReadLine();
            decimal priceResult;
            if (!decimal.TryParse(inputPrice, out priceResult))
            {
                Console.WriteLine($"Error: {inputPrice} is not a number!");
                return;
            }
            Console.Write("\n");

            if(priceResult >= total)
            {
                Console.WriteLine("Success");
                Console.WriteLine($"Your change: {priceResult - total}");
                userCart.ClearProducts();
            }
            else
            {
                Console.WriteLine("Failure: not enough funds");
            }
        }

    }
}
