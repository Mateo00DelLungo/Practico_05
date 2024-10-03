
# Proyecto[Practica_05]

#### Ejercicio Práctico sobre WebApi utilizando Entity Framework CORE.

La actividad práctica N° 05 propone el desarrollo completo del problema 2.7 de la guía de estudios correspondiente a la unidad 2.Para ello se pide:

- Refactorizar la solución WebApi desarrollada en la Actividad Práctica 04 agregando los siguientes componentes:

  	
        ++ Un controlador llamado TurnosController (carpeta Controllers).

        ++ Modificar el proyecto de tipo librería (DLL) para que exponga las funcionalidades de: registrar, consultar (con filtros), editar y registrar la baja de turnos (cancelación).

        ++ Mediante Entity Framework Core (EF) y utilizando una ingeniería inversa refactorizar las entidades a partir de la base datos.

        ++ Desarrollar una implementación de un patrón Repository para Turnos utilizando el ORM EF. 

        ++ Tener presente las reglas de negocio planteadas por enunciado e implementarlas debidamente en la capa que considere más oportuna.

- Adicionalmente deberá probar la WebApi mediante la herramienta POSTMAN.
## Utils

```c#
 public class MapperBase<Input, Output> : IMapper<Input, Output>
        where Input : new()
        where Output : new()
```
La Clase Mapper utiliza [Tipos Genéricos](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/generics) para mapear un tipo de objeto *INPUT* en uno *OUTPUT* y visceversa.

Para implementar su funcionalidad se debe hacer una clase que herede de MapperBase, ésta clase hija debe utilizar los métodos de la clase base, indicando/definiendo los tipos que va a utilizar. El Mapper tiene métodos tanto de **GET** (para obtener el *INPUT*) como de **SET** (para obtener el *OUTPUT*).

**Importante:** 
     Los tipos utilizados por el mapper deben compartir el mismo nombre en sus propiedades, ya que es así como busca y encuentra la propiedad que tiene que mapear desde el objeto A al objeto B
```c#
private void TransferProperty(PropertyInfo property, object fromValue, object whereToValue)
{   
    string propName = property.Name;
    var propValue = property.GetValue(fromValue);
    //las propiedades de ambas clases deben tener el mismo nombre
    whereToValue.GetType().GetProperty(propName).SetValue(whereToValue, propValue);
}
```

   Tener en cuenta que se intentarán transferir/mapear todas las propiedades que sean accesibles por el propio Mapper.
    
## Estadísticas

![GitHub commit activity](https://img.shields.io/github/commit-activity/t/Mateo00DelLungo/Practico_05)
[![wakatime](https://wakatime.com/badge/user/ecb456c5-1b67-4281-9da9-456ba4d60a8e/project/ce3b253c-ffdf-450e-a964-c717188cec51.svg)](https://wakatime.com/badge/user/ecb456c5-1b67-4281-9da9-456ba4d60a8e/project/ce3b253c-ffdf-450e-a964-c717188cec51)
![GitHub top language](https://img.shields.io/github/languages/top/Mateo00DelLungo/Practico_05)


## Autor

- [@Mateo del lungo](https://github.com/Mudo0)🤓

