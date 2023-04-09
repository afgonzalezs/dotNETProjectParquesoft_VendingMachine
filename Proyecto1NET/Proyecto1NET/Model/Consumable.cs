using System;
namespace Proyecto1NET.Model
{
	// Modelos de nuestro proyecto
	public class Consumable : InterfaceConsumable
	{
		public string Name { get; set;}

		public int Price { get; set; }

		public int StockQuantity { get; set; }


        public override string ToString()
        {
            return $" {Name} | {Price} | {StockQuantity}";
        }

        public Consumable(string name, int price, int stockQuantity)
		{
			Name = name;

			Price = price;

			StockQuantity = stockQuantity;
		}


        public int QuitarCantidadConsumable()
        {
            return 1;
        }

        public int EscogerProducto()
        {

            Console.WriteLine("\n Por favor, escoge el numero del producto al que deseas agregarle cantidad \n");
            int indice = Int32.Parse(Console.ReadLine());

            return indice;
        }

        public Consumable AgregarConsumable()
        {
            Console.WriteLine("Por favor, ingrese nombre, precio y cantidad del producto");
            Console.WriteLine("Por favor, ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese cantidad: ");
            int cantidad = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Por favor, ingrese precio: ");
            int precio = Int32.Parse(Console.ReadLine());
            Consumable producto = new Consumable(nombre, precio, cantidad);

            return producto;
        }


        public int AgregarCantidadConsumable()
        {

            Console.WriteLine("\n Por favor, inserta cuánta cantidad vas a agregar \n");
            int valorSumer = Int32.Parse(Console.ReadLine());
            return valorSumer;
        }

        

    }
}

