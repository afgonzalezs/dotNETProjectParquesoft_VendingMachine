using System;
namespace Proyecto1NET.Model
{
	public interface InterfaceConsumable
	{
        public int QuitarCantidadConsumable();
        public int EscogerProducto();
        public Consumable AgregarConsumable();
        public int AgregarCantidadConsumable();
    }
}

