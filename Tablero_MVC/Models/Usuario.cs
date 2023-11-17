using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tablero_MVC.Models
{
    public class Usuario
    {
        /*
        public Usuario(string nombre, string apellido, string institucion, string mail)
        {   //La ID no se recibe, cierto?
            IDUsuario = 0;
            Nombre = nombre;
            Apellido = apellido;
            Institucion = institucion;
            Mail = mail;

        }
        */
        
        //Para indicar que la PK es ID
        [Key]
        //Para que la ID sea autoincrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUsuario { get; set; }


        [Required(ErrorMessage ="Carga el nombre")] 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name ="Institución")]
        public string Institucion { get; set; }
        public string Mail { get; set; }


    }
}
