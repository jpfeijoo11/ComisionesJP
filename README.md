# ComisionesJP - Sistema de Gestión de Comisiones (Ingeniería Web)

## 📋 Descripción del Proyecto
Este proyecto consiste en la implementación de un **"Mini-Core"** para el cálculo dinámico de comisiones de venta. La aplicación permite filtrar transacciones por rangos de fechas y por vendedor, aplicando reglas de negocio automáticas basadas en el volumen de ventas total alcanzado en el periodo seleccionado.

Este trabajo ha sido desarrollado como una réplica técnica siguiendo los lineamientos de la materia de Ingeniería Web de la **Universidad de las Américas (UDLA)**.

---

## 🚀 Demo y Despliegue
El proyecto se encuentra desplegado y funcional en el siguiente enlace:
🔗 **[Link de tu sitio en Somee aquí]**

---

## 🛠️ Stack Tecnológico
* **Lenguaje:** C# (.NET 8.0)
* **Framework:** ASP.NET Core MVC
* **ORM:** Entity Framework Core
* **Base de Datos:** SQL Server Management Studio (SSMS 21)
* **Frontend:** Razor Views, Bootstrap 5 y CSS3
* **Hosting:** Somee.com (Cloud Hosting & SQL Server)

---

## 🗄️ Arquitectura de Datos
El sistema utiliza una base de datos denominada `ComisionesDB` con tres tablas principales relacionadas:

### 1. Modelo de Negocio (Tablas)
* **Vendedor:** Registro de nombres e identificación de los agentes.
* **Venta:** Detalle de transacciones (Monto, Fecha, VendedorId).
* **CalculadorComision (Reglas):** Define los rangos de aplicación.

### 2. Reglas de Comisión Aplicadas
El sistema evalúa el total vendido y aplica dinámicamente los siguientes porcentajes:

| Rango de Ventas | % Comisión |
| :--- | :--- |
| $0.00 - $1,000.00 | **2%** |
| $1,001.00 - $5,000.00 | **5%** |
| Más de $5,001.00 | **10%** |

---

## 🏗️ Implementación del Patrón MVC
La aplicación sigue estrictamente el patrón **Modelo-Vista-Controlador**:

* **Models:** Representación de las entidades de la base de datos y ViewModels para el transporte de datos procesados.
* **Controllers (`ComisionesController`):** Contiene la lógica de filtrado mediante consultas **LINQ** y el algoritmo de cálculo de tramos de comisión.
* **Views:** Interfaz de usuario responsiva que permite la interacción con los filtros de fecha y vendedor.

---

## ⚙️ Configuración Local

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/ComisionesJP.git](https://github.com/tu-usuario/ComisionesJP.git)
    ```

2.  **Configurar SQL Server:**
    * Ejecutar el script de creación de tablas incluido en la carpeta `/SQL`.
    * Asegurarse de que el servidor sea `(localdb)\mssqllocaldb` o el nombre de su instancia local (ej. `JUAN\SQLEXPRESS`).

3.  **Actualizar `appsettings.json`:**
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=TU_SERVIDOR;Database=ComisionesDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

4.  **Ejecutar:**
    Presionar `F5` en Visual Studio o ejecutar `dotnet run`.

---

## 👤 Autor
* **Juan Feijoo** - Estudiante de Ingeniería de Software (UDLA)

---
*Proyecto desarrollado con fines académicos para la asignatura de Ingeniería Web.*
