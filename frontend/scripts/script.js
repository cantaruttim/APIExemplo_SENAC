const gastosList = document.querySelector('.gastos-list');
const apiURL = 'http://localhost:5034/api/gastos';


document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("enviarForm");

  form.addEventListener("submit", async (event) => {
    event.preventDefault();

    const nome = document.getElementById("nome").value.trim();
    const data = document.getElementById("data").value.trim();
    const descricao = document.getElementById("descricao").value.trim();
    const valorStr = document.getElementById("valor").value.trim();

    if (!nome || !data || !descricao || !valorStr) {
      console.log("Todos os campos são obrigatórios!");
      return;
    }

    const valor = parseFloat(valorStr);
    if (isNaN(valor)) {
      console.log("O valor precisa ser um número válido.");
      return;
    }

    const gasto = { nome, data, descricao, valor };
    console.log("Enviando para o backend:", gasto);

    try {
      const response = await fetch(apiURL, 
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(gasto)
        }
    );

      if (!response.ok) {
        const err = await response.json();
        console.error("Erro ao enviar os dados:", response.status, "-", err);
        return;
      }

      const dataResp = await response.json();
      console.log("Gasto criado com sucesso:", dataResp);

      form.reset(); // limpa o formulário
    } catch (error) {
      console.error("Erro de rede ou no backend:", error);
    }
  });
});


// Método Get Implementado
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
        console.log('Dados vindos do backend:', gastos);

        // console.log(gastos);
        gastos.forEach( (gastos) => {
            const newLi = document.createElement('li');
            newLi.innerText = `Nome: ${gastos.nome} | Data: ${gastos.data} Descrição: ${gastos.descricao} | Valor R$ ${gastos.valor}`;
            gastosList.appendChild(newLi);
        })


    } catch (error) {
        console.error(error.message);
    }
}

getGastosList();
createGastos();