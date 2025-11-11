const apiURL = 'http:localhost:5034/api/gastos';

const getGastosList = async () => {
    try {
        // que vamos implementar o método GET
        const response = await fetch(
            apiURL,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        );

        if (!response.ok) {
            throw new Error('Erro enquanto buscava lista de gastos');
        }

        const gastos = await response.json();
        console.log(gastos);

    } catch (error) {
        console.error(error.message);
    }
}