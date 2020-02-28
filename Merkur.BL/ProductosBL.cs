using Merkur.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merkur.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public BindingList<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new BindingList<Producto>();
                       
        }
        public BindingList<Producto> Obtenerproductos()
        {
            _contexto.Productos.Load();
            ListadeProductos = _contexto.Productos.Local.ToBindingList();

            return ListadeProductos;
        }
        public BindingList<Producto> Obtenerproductos(int buscar)
        {
            var query = _contexto.Productos
                .Where(p => p.Id == buscar).ToList();

            var resultado = new BindingList<Producto>(query);

            return resultado;
        }
        public Resultado GuardarProductos(Producto producto)
        {
            var resultado = Validar(producto); 
            if (resultado.Exitoso == false )
            {

                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;            
            return resultado;
        }
        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();

            ListadeProductos.Add(nuevoProducto);
            
        }
     
        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListadeProductos)
            {
                if (producto.Id == id)
                {
                    ListadeProductos.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
               
            }
            return false;
        }
        private Resultado Validar (Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (producto == null)
            {
                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado; 
            }

            if(string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una Descripcion";
                resultado.Exitoso = false;
            }

            if (producto.Id<0)
            {
                resultado.Mensaje = "el Id debe ser mayor que 0";
                resultado.Exitoso = false;
            }
            if (producto.Precio < 0)
            {
                resultado.Mensaje = "Agregue un precio";
                resultado.Exitoso = false;
            }


            return resultado;
        }

        public void Actualizar(int id, string descripcion)
        {
            var productoExistente = _contexto.Productos.Find(id);

            productoExistente.Descripcion = descripcion;

            _contexto.SaveChanges();
        }
        public List<Producto> Obtener()
        {
            return _contexto.Productos.ToList();
        }

    }
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Destino { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public DateTime FechadeEntrega { get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }
        public string Longitud1 { get; set; }
        public string Longitud2 { get; set; }
        public string Latitud1 { get; set; }
        public string Latitud2 { get; set; }

    }
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }

}
