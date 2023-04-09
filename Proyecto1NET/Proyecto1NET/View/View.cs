using System;
using Proyecto1NET.Controller;
using Proyecto1NET.Model;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace View
{
    class View

    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la máquina dispensadora");

            Controller controller = new Controller(new string[4] { " "," ", " ", " " });
            Consumable Consumableview = new Consumable("",0,0);
            Moneda moneda = new Moneda();
           
            var productosactivos = new List<Consumable> {
                new Consumable("Producto uno",1000,80),
                new Consumable("Producto dos",1000,80),
                new Consumable("Producto tres",1000,20)
            };

            string imprimirproductos = string.Join("\n", productosactivos);

            bool menu = false;
            do
            {
                Console.WriteLine("Seleccione una de las siguientes opciones:\n1. Cliente.\n2. Proveedor.");

                    int input_client_type = Int32.Parse(Console.ReadLine());

                switch (input_client_type)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("|      \u001b[1mMÁQUINA EXPENDEDORA   |\u001b[0m ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("| \u001b[1mProducto  | Cantidad | Precio |\u001b[0m ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        foreach (Consumable i in productosactivos)
                        {
                            Console.WriteLine("|" + i.Name + "| " + i.StockQuantity + " | " + i.Price + "| \n------------------------------");
                        }

                        Console.ResetColor();
                        Console.WriteLine("Escribe el nombre del producto que deseas como ves en la máquina expendedora \n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        string selecionproducto = Console.ReadLine();
                        Console.ResetColor();
                        try
                        {
                            if (productosactivos.Any(a => a.Name == selecionproducto))
                            {
                                var querybusquedaproducto = (from p in productosactivos
                                                             where p.Name == selecionproducto
                                                             select p).First();
                                

                                Console.WriteLine("\n El producto cuesta \u001b[1m" + querybusquedaproducto.Price + "\u001b[0m \n");
                                var plata = 0;      
                                while (plata < querybusquedaproducto.Price)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Por favor, inserta una moneda (\u001b[1m 50, 100, 200, 500, 1000) o billete (2000, 5000, 10000, 20000, 50000, 100000) \u001b[0m \n");
                                    Console.ResetColor();
                                    int coin = int.Parse(Console.ReadLine());

                                    if (coin == 50 || coin == 100 || coin == 200 || coin == 500 || coin == 1000 || coin == 2000 || coin == 5000 || coin == 10000 || coin == 20000 || coin == 50000 || coin == 100000) //ACA AGREGAS LOS OTROS BILLETES
                                    {
                                        plata += coin;
                                        Console.WriteLine($"Total: \u001b[1m  {plata}\u001b[0m pesos");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Lo siento, esta máquina solo acepta monedas de 50, 100, 200, 500 o 1000 pesos o billetes de 2000, 5000, 10000, 20000, 50000, 100000");
                                    }
                                }
                                int change = plata - querybusquedaproducto.Price;
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine(moneda.cambio(change));
                                Console.ResetColor();
                                querybusquedaproducto.StockQuantity -= Consumableview.QuitarCantidadConsumable();


                            }

                        }
                        catch (Exception)
                        {
                            break;
                        }

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("|      \u001b[1mMÁQUINA EXPENDEDORA   |\u001b[0m ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("| \u001b[1mProducto  | Cantidad | Precio |\u001b[0m ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------");
                        foreach (Consumable i in productosactivos)
                        {
                            Console.WriteLine("|" + i.Name + "| " + i.StockQuantity + " | " + i.Price + "| \n------------------------------");
                        }

                        
                        bool menuprovedor = false;
                        do
                        {
                            Console.ResetColor();
                            Console.WriteLine("\n Por favor, seleccione \n 1. Agregar producto ya existente.\n2. Nuevo producto. \n 0. Para volver. \n");
                            int input_client_type_provedor = Int32.Parse(Console.ReadLine());
                            switch (input_client_type_provedor)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    Console.WriteLine("|      \u001b[1mMÁQUINA EXPENDEDORA   |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("| \u001b[1mProducto  | Cantidad | Precio |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    foreach (Consumable i in productosactivos)
                                    {
                                        Console.WriteLine(productosactivos.IndexOf(i) + " |  " + i.Name + " | " + i.StockQuantity + "\n---------------------------");
                                    }
                                    Console.ResetColor();
                                    productosactivos[Consumableview.EscogerProducto()].StockQuantity += Consumableview.AgregarCantidadConsumable();
                                    
                                    Console.WriteLine("Cantidad agregada, exitosa! \n");

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    Console.WriteLine("|      \u001b[1mMÁQUINA EXPENDEDORA   |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("| \u001b[1mProducto  | Cantidad | Precio |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    foreach (Consumable i in productosactivos)
                                    {
                                      Console.WriteLine(productosactivos.IndexOf(i) + " |  " + i.Name + " | " + i.StockQuantity + "\n--------------------------");
                                    }
                                    Console.ResetColor();

                                    break;

                                case 2:
                                    productosactivos.Add(Consumableview.AgregarConsumable());
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Nuevo producto agregado \n");
                                    Console.WriteLine("------------------------------");
                                    Console.WriteLine("|      \u001b[1mMÁQUINA EXPENDEDORA   |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("| \u001b[1mProducto  | Cantidad | Precio |\u001b[0m ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("------------------------------");
                                    foreach (Consumable i in productosactivos)
                                    {
                                        Console.WriteLine(i.Name + " | " + i.StockQuantity + "\n---------------------");
                                    }
                                    Console.ResetColor();
                                    break;
                                case 0:
                                    menuprovedor = true;
                                    break;
                            

                            }
                         } while (!menuprovedor);
                        
                    break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Por favor, ingrese una opción válida.\n");
                        break;

                }
            } while (!menu);

        }
    }
}