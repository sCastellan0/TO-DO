# 📋 Sistema de Gestión de Tareas (TO-DO Kanban) con WPF

[![NET Version](https://img.shields.io/badge/.NET-Framework%204.8%2B%20%2F%20Core-blue.svg)](https://dotnet.microsoft.com/)
[![UI Framework](https://img.shields.io/badge/UI-WPF%20%2F%20XAML-blueviolet)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Pattern](https://img.shields.io/badge/Pattern-MVVM%20Ready-green)](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

Este proyecto es una aplicación de escritorio nativa para Windows desarrollada en **C#** utilizando **WPF (Windows Presentation Foundation)** y **XAML**. Implementa un tablero interactivo para la creación, organización y edición dinámica de tareas pendientes, adaptando conceptos visuales del sistema **Kanban**.

La interfaz destaca por su alto nivel de interactividad reactiva, lograda mediante enlaces de datos bidireccionales y disparadores visuales automáticos.

---

## 🗺️ Arquitectura y Mecanismos de Sincronización

La aplicación aprovecha las características nativas más potentes de WPF para la persistencia en memoria y la actualización automática de la interfaz gráfica:

1. **Notificación de Cambios (`INotifyPropertyChanged`):** La clase modelo `Tarea` implementa esta interfaz en todos sus atributos (`Nombre`, `FechaLimite`, `Prioridad`, `Completada`). Esto asegura que cualquier cambio realizado por el usuario se refleje al instante en el resto de la aplicación sin necesidad de recargar la ventana.
2. **Uso de Expresiones Lambda y CallerMemberName:** Las propiedades utilizan la sintaxis simplificada de C# (`=>`) y el atributo `[CallerMemberName]` para propagar las alertas de modificación de propiedades de manera segura y eficiente, evitando errores de tipado.
3. **Mapeo Automatizado (`ObjectDataProvider`):** Se utiliza un proveedor de datos de objetos directamente en XAML para extraer los valores del enumerado `Prioridad` (`Baja`, `Media`, `Alta`), sirviendo como fuente de datos para los componentes desplegables de forma limpia.

---

## 📁 Estructura de Componentes

```text
Proyecto_TO_DO/
├── App.xaml / App.xaml.cs       # Ciclo de vida y arranque de la aplicación
├── MainWindow.xaml              # Interfaz de usuario declarativa (XAML)
├── MainWindow.xaml.cs           # Lógica de eventos en el Code-Behind (C#)
└── Tarea.cs                     # Clase Modelo con el contrato INotifyPropertyChanged
````

## 🎨 Características de la Interfaz y Estilos Visuales

El diseño visual de la interfaz (`MainWindow.xaml`) ha sido personalizado utilizando recursos globales de XAML y plantillas de control avanzadas para ofrecer una experiencia fluida:

* **Botón Circular Dinámico (`EstiloBotonAgregar`):** El botón de inserción (`+`) utiliza una plantilla de control modificada que reemplaza el rectángulo clásico por una elipse (`Ellipse`) dentro de una rejilla (`Grid`). Además, cuenta con disparadores de plantilla (`ControlTemplate.Triggers`) que automatizan la animación interactiva:
  * Al pasar el cursor por encima (`IsMouseOver`), se reduce la opacidad al **80%** para dar feedback de selección.
  * Al hacer clic (`IsPressed`), se aplica una transformación de escala (`ScaleTransform`) reduciendo su tamaño a un **90%** para simular un efecto de hundimiento físico.
* **Edición en Línea Directa:** Dentro de las tarjetas de la lista, el título de la tarea es un cuadro de texto (`TextBox`) con fondo transparente y sin bordes. Esto permite al usuario editar el texto directamente sobre la marcha sin abrir ventanas secundarias.
* **Selectores Integrados:** Cada tarea expone un menú desplegable (`ComboBox`) enlazado al proveedor de datos del enumerado, lo que permite reconfigurar el nivel de prioridad de cualquier tarea de forma inmediata.
* **Reactividad Visual Automatizada (`DataTemplate.Triggers`):**
  * ⬛ **Atenuación de Tareas Completadas:** Cuando el usuario marca el `CheckBox` de una tarea (`Completada = True`), un disparador de datos reduce la opacidad de todo el contenedor al **50%** (`Opacity="0.5"`) y cambia el borde a un color gris ceniza, indicando visualmente que la actividad ha concluido.
  * 🚨 **Alerta de Prioridad Alta:** Si el estado de la prioridad se cambia a **Alta**, un disparador dinámico intercepta el valor y aplica un borde de color **Rojo** con el doble de grosor estándar (`BorderThickness="2"`), destacando la tarjeta sobre las demás para denotar urgencia.
 
  * ## 🚀 Funcionalidades Soportadas

La aplicación cubre un flujo de trabajo interactivo para la organización de actividades cotidianas a través de los siguientes mecanismos integrados:

* **Creación Parametrizada de Tareas:** El panel superior permite al usuario dar de alta nuevas actividades especificando tres campos clave:
  * **Título:** Entrada de texto libre (`TextBox`) para el nombre de la tarea.
  * **Fecha Límite:** Selector de calendario (`DatePicker`) para establecer la fecha de vencimiento.
  * **Prioridad:** Menú desplegable (`ComboBox`) preprogramado con las opciones del enumerado (`Baja`, `Media`, `Alta`).
* **Sincronización Bidireccional en Tiempo Real (*Data Binding*):** Gracias a la propiedad `UpdateSourceTrigger=PropertyChanged`, cualquier texto introducido o cambio de estado se transmite inmediatamente entre la vista (XAML) y el objeto en memoria (C#), eliminando la necesidad de botones manuales de "Guardar" o "Actualizar".
* **Edición Dinámica Post-Creación:** El usuario puede modificar el nombre de la tarea o alterar su nivel de prioridad directamente desde la tarjeta correspondiente dentro de la lista (`ListBox`), adaptándose al ritmo de un tablero de organización ágil.
* **Control de Finalización:** Al marcar el selector (`CheckBox`), el estado booleano `Completada` conmuta automáticamente, aplicando de inmediato las reglas de estilo visual correspondientes para archivar o atenuar la actividad.
* **Restablecimiento y Limpieza de Campos:** El botón `🗑️ Limpiar` está vinculado a un evento en el controlador (`BtnLimpiar_Click`) diseñado para resetear rápidamente los controles de entrada o purgar los flujos de texto del panel de operaciones.

* 
