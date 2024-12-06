
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Brass Trumpet",
        Price = 94.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Violet Bent Backwards Over the Grass",
        Price = 24.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "The Iliad & The odyssey",
        Price = 32.49M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Brass Snare Drum",
        Price = 69.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Brass Clarinet",
        Price = 47.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "The Divine Comedy",
        Price = 55.69M,
        ProductTypeId = 2
    }
    
};


List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poem",
        Id = 2
    }
};

Console.WriteLine(@"
Welcome to Brass & Poem!
Where you will find only the finest of brass and poems.");

string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
        Console.WriteLine("All available products:");
        DisplayAllProducts(products, productTypes);
        break;

        case "2":
        DeleteProduct(products, productTypes);
        break;

        case "3":
        AddProduct(products, productTypes);
        break;

        case "4":
        UpdateProduct(products, productTypes);
        break;

        case "5":
        Console.WriteLine("5. Fairwell!");
        break;

        default:
        Console.WriteLine("Please select valid option");
        break;
    }
}

void DisplayMenu()
{
   Console.WriteLine(@"
   1. Display all products
   2. Delete a product
   3. Add a new product
   4. Update a product
   5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
   for (int i = 0; i < products.Count; i++)
   {
    ProductType matchedProductType = productTypes.First(p => p.Id == products[i].ProductTypeId);
    Console.WriteLine($"{i + 1}. {products[i].Name} costs ${products[i].Price} and is in the {matchedProductType.Title} category.");
   }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Delete a Product");
    
    while (true)
    {
        DisplayAllProducts(products, productTypes);
        Console.WriteLine("Choose a product to delete.");

        if (int.TryParse(Console.ReadLine().Trim(), out int choice))
        {
            if (choice >= 1 && choice <= products.Count)
            {
                Console.WriteLine($"{products[choice - 1].Name} successfully deleted.");
                products.RemoveAt(choice - 1);
                break;
            }
            else
            {
                Console.WriteLine("Please select a valid option.");
            }
        }
        else
        {
            Console.WriteLine("Please select an integer of an available choice.");
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes) 
{
    Console.WriteLine("Add a new product:");
    
    Console.WriteLine("Enter product name:");
    string newProductName = Console.ReadLine().Trim();

    decimal newProductPrice = 0;
    try
    {
        Console.WriteLine("Enter product price:");
         newProductPrice = Decimal.Parse(Console.ReadLine().Trim());
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid price.");
        AddProduct(products, productTypes);
    }

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }

    int newProductType;
    while (true)
    {
        Console.WriteLine("Choose product type:");
        if (int.TryParse(Console.ReadLine(), out newProductType))
        {
            if (newProductType >= 1 && newProductType <= productTypes.Count)
            {
                break;
            }
            else 
            {
                Console.WriteLine("Please enter a valid choice.");
            }
        }
        else
        {
            Console.WriteLine("Please ensure selection is an integer and is of a valid choice.");
        }
    }

    products.Add(
        new Product()
    {
        Name = newProductName,
        Price = newProductPrice,
        ProductTypeId = newProductType
    });

    Console.WriteLine($"{newProductName} successfully created!");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    while (true)
    {
    Console.WriteLine("Update  a product.");
    Console.WriteLine("");
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("");
    Console.WriteLine("Select a product to update:");

    if (int.TryParse(Console.ReadLine().Trim(), out int productUpdateChoice))
    {
        if (productUpdateChoice >= 1 && productUpdateChoice <= products.Count)
        {
            Product productToUpdate = products[productUpdateChoice - 1];

            Console.WriteLine($"Updating {productToUpdate.Name}");
            Console.WriteLine("");
            Console.WriteLine("Update name:");
            string updatedProductName = Console.ReadLine().Trim();
            if (updatedProductName != "")
            {
                productToUpdate.Name = updatedProductName;
            }

            Console.WriteLine("Update price:");
            try
            {
                string updatedProductPrice = Console.ReadLine();
                if (updatedProductPrice != "")
                {
                    productToUpdate.Price = Decimal.Parse(updatedProductPrice);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid price");
                UpdateProduct(products, productTypes);
            }
            

            Console.WriteLine("Update product type:");
            for (int i = 0; i < productTypes.Count; i ++)
            {
                Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
            }
            string updatedProductType = Console.ReadLine().Trim();
             if (int.Parse(updatedProductType) >= 1 && int.Parse(updatedProductType) <= productTypes.Count)
             {
                 if (updatedProductType != "")
                productToUpdate.ProductTypeId = int.Parse(updatedProductType);
             }
             else
             {
                Console.WriteLine("Please choose a valid type.");
                UpdateProduct(products, productTypes);
             }
            Console.WriteLine($"{productToUpdate.Name} successfully updated!");

            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid choice");
        }
    }
    else
    {
        Console.WriteLine("Ensure selection is an integer and is of a valid choice.");
    }
    }
}

// don't move or change this!
public partial class Program { }