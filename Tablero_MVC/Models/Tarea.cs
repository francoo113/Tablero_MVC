﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablero_MVC.Models
{
    public class Tarea
    {
        /*
        public Tarea(string descripcion, string titulo, Estado estado)
        {

            IDTarea = 0;
            Titulo = titulo;
            Descripcion = descripcion;
            //esto pidio la profe modificar por una lista de Tarea (de si misma)
            // SubTarea = new List<SubTarea>();
            //tareas = new List<Tarea>();
            EstadoTarea = estado;
        }
       */
        //Para indicar que la PK es ID
        [Key]
        //Para que la ID sea autoincrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTarea { get; set; }
        //Este es cambio
        [Display(Name = "Estado")]
        [EnumDataType(typeof(Estado))]
        public Estado EstadoTarea { get; set; }
        //Este es cambio
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        //Este es cambio
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        //esto para no mostrar los enums anteriores
        public IEnumerable<SelectListItem> GetFilteredEstadoSelectList()
        {

            int estadoActualOrdinal = (int)EstadoTarea;


            var filteredStates = Enum.GetValues(typeof(Estado))
                .Cast<Estado>()
                .Where(e => (int)e >= estadoActualOrdinal)
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });

            return filteredStates;
        }

        // public List<Tarea> tareas { get; set; }


        /*
        public void AgregarTarea(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        //Solucionado el tema de devolver un Estado
        private Estado pasoEnteroAEstado(int numero)
        {
            Estado estadoADevolver;
            switch (numero)
            {
                case 1:
                    estadoADevolver = Estado.ANALISIS;
                    break;
                case 2:
                    estadoADevolver = Estado.TO_DO;
                    break;
                case 3:
                    estadoADevolver = Estado.IN_PROGRESS;
                    break;
                default:
                    estadoADevolver = Estado.FINALIZED;
                    break;
            }
            return estadoADevolver;
        }

        public void ModificarTarea(string titulo, string descripcion, int numeroEstado)
        {
            //funcion lambda, t es una tarea y Find busca la tarea por titulo
            //devuelve TRUE o FALSE si coincide con el titulo y, por eso, 
            //advierte que puede ser nulo cuando hago el Find()
            //pero mas abajo controlamos que no sea nulo, sino no aplica
            Tarea tareaAModificar = tareas.Find(t => t.Titulo == titulo);

            if (tareaAModificar != null)
            {

                if (!string.IsNullOrEmpty(descripcion))
                {
                    tareaAModificar.Descripcion = descripcion;
                }

                tareaAModificar.EstadoTarea = pasoEnteroAEstado(numeroEstado);
            }
        }
        */
    }
}
