document.addEventListener('DOMContentLoaded', () => {
  const formulario = document.getElementById('loginForm');

  formulario.addEventListener('submit', async (event) => {
  event.preventDefault();

  const email = document.getElementById('username').value;
  const password = document.getElementById('password').value;

  const datos = 
  {
     email,
     password
   };

   try {
      const resuesta = await fetch('https://localhost:7076/api/Auth/login', {
         method: 'POST',
         headers:{
             'Content-Type': 'application/json'
           }
       });
       if (resuesta.ok){
          const respuestaJson = await resuesta.json();
          console.log('Respuesta de la Api:', respuestaJson);
          window.location.href='../html/indexR.html'
         }
        else{
         console.error('Error en la solicitud:', resuesta.status);
       }
    }catch(error){
      console.error('Error', error);
   }
}); 

});