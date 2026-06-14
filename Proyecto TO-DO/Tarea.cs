using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Proyecto_TO_DO
{
    public class Tarea : INotifyPropertyChanged
    {
        private string _nombre;
        private DateTime _fechaLimite;
        private Prioridad _prioridad;
        private bool _completada;

        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(); }
        }

        public DateTime FechaLimite
        {
            get => _fechaLimite;
            set { _fechaLimite = value; OnPropertyChanged(); }
        }

        public Prioridad Prioridad
        {
            get => _prioridad;
            set { _prioridad = value; OnPropertyChanged(); }
        }

        public bool Completada
        {
            get => _completada;
            set { _completada = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}
