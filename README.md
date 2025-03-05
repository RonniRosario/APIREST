Para poner en practica nuestra API debemos de hacer lo siguiente:

Correr el proyecto

Una vez dentro de la UI de Swagger, que luce de esta manera: 
![image](https://github.com/user-attachments/assets/003f5576-36ed-44c0-af34-91e48a0256c0)


Hacemos click en el método que deseemos utilizar, empezaremos con el de listar todos los usuarios 
![image](https://github.com/user-attachments/assets/24aacba0-2973-4bd4-a9eb-01ad340cd841)


Presionamos en try out, luego en execute image Aqui nos muestran todos los resultados de los usuarios, en caso de querer solo ver la informacion, nos proporciona la URL, la podemos copiar y pegar en otra pestaña para obtener la informacion
![image](https://github.com/user-attachments/assets/f459756f-f371-4080-9092-def915f6ee57)


Ahora continuaremos con el método de mostrar un solo usuario, para esto debemos de insertar un parámetro, el cual es el id del usuario que queremos buscar, luego hacer click en execute 
![image](https://github.com/user-attachments/assets/7fa887e1-20a8-43a4-a84e-89f0239e261f)

Luego, Tenemos la funcionalidad de crear un usuario, antes de aplicar execute, debemos de introducir todos los datos, menos el id, ya que es auto-incrementable 
![image](https://github.com/user-attachments/assets/e54611f8-2e3a-4f5a-8219-bc03ac7b35e5)

Ya tenemos el usuario creado

Despues está el método de editar un usuario, al igual que el de buscar un usuario y el de eliminar, tenemos que introducir un id, y luego editar. 
![image](https://github.com/user-attachments/assets/71f9843e-47e7-480d-87dc-794d1d139ac4)
En este caso, editamos el usuario con el id 10.

Por último, tenemos la funcionalidad de Eliminar un usuario, simplemente introducimos el id del usuario que queramos eliminar, utilizaremos el mismo id 10. 
![image](https://github.com/user-attachments/assets/bbd1b352-e875-426e-bc6c-edaf3eecc9e6)

Ahora haremos las pruebas de autenticacion,
Para esto, corremos el proyecto

![image](https://github.com/user-attachments/assets/5b344589-c251-40a6-99b3-2269d4d09db4)

Podemos hacerlo registrando un usuario y luego autenticarlo, para esto primero usamos el endpoint de registrar 
![image](https://github.com/user-attachments/assets/6c238b14-e997-4ea8-a5a4-4a376a81acf7)

Ahora podemos proseguir a usar el endpoint de login
![image](https://github.com/user-attachments/assets/e4d0c45a-132b-4394-9aac-970d0f05ab8c)

Ya con el token proporcionado, podemos acceder a los metodos que necesitan de autenticacion
![image](https://github.com/user-attachments/assets/5d5d6d9b-7f10-4869-a065-74ff622298cf)


Nuevas tablas añadidas(Proveedor, Producto, Categorias)

La tabla producto contiene relacion con proveedor y categorias, por lo que primero tenemos que registrar una categoria y un proveedor

En la tabla proveedor tenemos estos registros: 
![image](https://github.com/user-attachments/assets/26cddcb8-8714-4f15-b2e7-cba5553547f9)

En la tabla categoria tenemos estos registros:
![image](https://github.com/user-attachments/assets/0846d874-c51a-4f5d-a645-a31b5eef8dcc)

Entonces, para poder registrar un producto nuevo, ejecutamos el proyecto, y ponemos los datos del producto, y despues presionar execute
![image](https://github.com/user-attachments/assets/d8b30a1d-7934-477e-ac76-3922083913b6)

Una vez hecho esto, Swagger manda el código correspondiente, en este caso fue exitosa
![image](https://github.com/user-attachments/assets/1918b9f7-2e58-45b1-8207-bce7da60c794)

Ahora probaremos los distintos metodos, como el de listar:
![image](https://github.com/user-attachments/assets/8145b449-8850-469a-8a3e-c9bae93ed31d)
despues de haber presionado execute, nos muestra esto, parte de los productos creados
![image](https://github.com/user-attachments/assets/09671d9e-1b5d-4ad6-917b-5af79a8cf945)

Ahora veremos las consultas, la primera que tiene el producto mas alto y bajo, la suma de todos los productos y el precio promedio
![image](https://github.com/user-attachments/assets/2eae427f-2763-4be4-826d-a85e2127afe0)


Productos de una categoría específica
![image](https://github.com/user-attachments/assets/c3457f98-26d8-4b92-9c71-48eec3b84da1)

Productos de un proveedor específico.
![image](https://github.com/user-attachments/assets/ca86f6a6-286b-403e-987b-aaf2427a05c7)

Cantidad total de productos registrados
![image](https://github.com/user-attachments/assets/e3fa3faf-3f69-4966-9ec6-d596fe38bfc0)











