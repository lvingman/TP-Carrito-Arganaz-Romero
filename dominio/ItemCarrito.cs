﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ItemCarrito
    {        
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string URLImagen { get; set; }
            
            public decimal Precio { get; set; }

            public int Cantidad { get; set; }

        
    }
}
