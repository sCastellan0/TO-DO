using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Proyecto_TO_DO
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Tarea> Tareas { get; set; }
        public Tarea NuevaTarea { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Tareas = new ObservableCollection<Tarea>();
            NuevaTarea = new Tarea
            {
                Nombre = "",
                FechaLimite = DateTime.Today.AddDays(1),
                Prioridad = Prioridad.Media,
                Completada = false
            };

            DataContext = this;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NuevaTarea.Nombre) &&
                NuevaTarea.FechaLimite > DateTime.Today)
            {
                var tarea = new Tarea
                {
                    Nombre = NuevaTarea.Nombre,
                    FechaLimite = NuevaTarea.FechaLimite,
                    Prioridad = NuevaTarea.Prioridad,
                    Completada = false
                };

                Tareas.Add(tarea);

                // Limpiar formulario
                NuevaTarea.Nombre = "";
                NuevaTarea.FechaLimite = DateTime.Today.AddDays(1);
                NuevaTarea.Prioridad = Prioridad.Media;
            }
            else
            {
                MessageBox.Show("Nombre o fecha no válida",
                                "Validación",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            var completadas = Tareas.Where(t => t.Completada).ToList();
            foreach (var tarea in completadas)
            {
                Tareas.Remove(tarea);
            }
        }
    }
}
