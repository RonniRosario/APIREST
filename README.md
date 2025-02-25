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
