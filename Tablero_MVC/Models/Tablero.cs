using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tablero_MVC.Models
{
    public class Tablero
    {
        /*
        public Tablero(Usuario usuario)
        {
            IDTablero = 0;
            Tareas = new List<Tarea>();
            Usuario = usuario;
        }
        public Tablero() 
        {
            Tareas = new List<Tarea>();
        }
        */

        //Para indicar que la PK es ID
        [Key]
        //Para que la ID sea autoincrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTablero { get; set; }

     
        public List<Tarea> Tareas { get; set; }

        //La llave FK se define con el nombre de la PK de la clase Usuario
        [ForeignKey("IDUsuario")]

        public Usuario Usuario { get; set; }

    }
}
