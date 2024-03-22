document.addEventListener('DOMContentLoaded', () => {
    
     const form = document.querySelector('.required-validation');

     form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const name = form.querySelector('input[name = "name"]').value;
        const lastName = form.querySelector('input[name = "lastName"]').value;
        const email = form.querySelector('input[name = "email"]').value;
        const password = form.querySelector('input[name = "password"]').value;
        const cedula = form.querySelector('input[name = "cedula"]').value;
        const gender = form.querySelector('input[name = "gender"]:checked').value;

        const data = {
            name,
            lastName,
            email,
            password,
            cedula,
            gender
        };

        try{
            const response = await fetch ('url de la api', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                const responseData = await response.json();
                console.log('Respuesta de la Api:', responseData);
                window.location.href='../login-form-14/indexIN.html'
            } else {
                console.error('Error en la solicitud:' , response.status);
            }
        }catch(error){
            console.error('Error:', error);
        }
     });
});