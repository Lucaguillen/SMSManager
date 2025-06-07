
# SMSManager

Aplicación de escritorio en C# para el envío masivo de SMS mediante un dispositivo Android utilizando la app Traccar SMS Gateway.

---

## 📄 Descripción general

**SMSManager** surgió como una solución real a una necesidad concreta dentro de una organización estatal: una oficina encargada de los ingresos debía notificar vía SMS a más de 600 personas. Dado que el envío manual era inviable, se decidió desarrollar una herramienta propia que automatizara y optimizara este proceso.

El objetivo fue, desde el principio, construir una solución robusta, reutilizable y escalable que pudiera ser utilizada no solo por esa oficina, sino por cualquier otra dentro de la organización o incluso por terceros que quisieran adaptarla a sus necesidades.

---

## ✨ Características principales

- ✉️ Enío de SMS individuales o masivos.
- 👥 Gestión de contactos: alta, baja, edición e importación masiva desde archivos CSV.
- 📄 Creación y reutilización de formatos/plantillas de mensajes.
- ⚖️ Personalización de mensajes automática por contacto (e.g. nombre, hora, lugar).
- ⚙️ Configuración de conexión a la API Traccar Gateway: IP, puerto y token.
- 🔍 Historial de envíos para auditoría o referencia.
- 📁 Base de datos local SQLite (sin dependencias externas).
- ✨ Interfaz moderna y reutilizable con menú centralizado y formularios modulares.

---

## ⚖️ Arquitectura del sistema

- **Capa de Presentación (UI)**: WinForms con una arquitectura de formularios base (`BaseForm`) y formularios principales reutilizables (`FormPrincipal`).
- **Capa de Lógica**: Servicios y utilidades desacopladas que gestionan la carga, validación y transformación de datos.
- **Capa de Datos**: Acceso a base de datos mediante `SQLite`, con repositorios separados para `Contacto`, `Formato` y `MensajeEnviado`.
- **Capa de Objetos**: Modelos simples que representan las entidades de negocio y estructuras auxiliares.

---

## ⚡ Tecnologías utilizadas

- Lenguaje: **C# (.NET)**
- Interfaz gráfica: **Windows Forms**
- Persistencia: **SQLite** local
- Serialización: **System.Text.Json**
- Mensajería: **Traccar SMS Gateway** (Android)

---

## ⚙️ Requisitos y ejecución

1. Clonar el repositorio:

```bash
git clone https://github.com/Lucaguillen/SMSManager.git
```

2. Abrir la solución `SMSManager.sln` en Visual Studio.
3. Compilar la solución con la configuración `x86` o `Any CPU`.
4. Ejecutar el proyecto `SMSManager.UI`.
5. Configurar la IP, el puerto y el token en el menú **Configuración > Configurar API**.
6. Importar contactos o agregarlos manualmente.
7. Crear un nuevo mensaje usando un formato o redactando libremente.
8. Enviar el mensaje utilizando el dispositivo Android con Traccar Gateway.

---

## 📂 Ejemplo de archivo CSV para importación

```
Nombre,Telefono,Cedula
Juan Pérez,099123456,12345678
Ana López,098654321,23456789
```

> El programa valida automáticamente los números de teléfono y la cédula al importar.

---

## ✋ Limitaciones actuales

- No admite caracteres especiales ni emojis en los mensajes (solo texto plano).
- No tiene soporte para entornos con proxies de red. Esto puede restringir su uso en redes corporativas que requieran autenticación de proxy.

> Estas limitaciones están en la hoja de ruta futura.

---

## 🚀 Futuras mejoras

- ⛓ Soporte para configuración de proxy y autenticación de red.
- ✨ Mejora en el soporte de codificación para permitir acentos y caracteres especiales.
- 🔄 Enlace de envíos con base de datos externa o servicios web para integraciones empresariales.

---

## 👤 Autor

Desarrollado por [Luca Guillén](https://github.com/Lucaguillen) – Programador .NET / Java.

---

## 📅 Estado del proyecto

Activamente mantenido. Utilizado en producción en ambientes reales.

---

## ✨ Licencia

Este proyecto se distribuye bajo la licencia **MIT**. Puedes utilizarlo, modificarlo y redistribuirlo libremente con atribución.
