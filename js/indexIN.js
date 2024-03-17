document.addEventListener('DOMContentLoaded', () => {
  const formulario = document.getElementById('loginForm');

  formulario.addEventListener('submit', async (event) => {
  event.preventDefault();

  const username = document.getElementById('username').value;
  const password = document.getElementById('password').value;

  const datos = 
  {
     username,
     password
   };

   try {
      const resuesta = await fetch('url de la api', {
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