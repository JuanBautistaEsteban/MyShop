using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Web
{
    public class Constants
    {
        public const string IMAGEN_LOGO = "~/img/logo/logo.jpg";
        public const string DESTINO_IMAGENES_PRODUCTOS = @"\img\products\";
        public const string RUTA_RELATIVA_CARGA_IMAGENES_PRODUCTOS = "~/img/products/";
        public const string RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS = @"\img\tmp\";

        public const string ERROR_NOMBRE_PRODUCTO_VACIO = "El nombre del producto no puede quedarse vacío.";

    }
}