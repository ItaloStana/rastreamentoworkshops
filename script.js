const tbodyWorkshops = document.querySelector('#workshopsSection tbody');
const tbodyColaboradores = document.querySelector('#colaboradoresSection tbody');
const btnWorkshops = document.querySelector('#btnWorkshops');
const btnColaboradores = document.querySelector('#btnColaboradores');
const workshopDetails = document.getElementById('workshopDetails');
const detailsContent = document.getElementById('detailsContent');

const API_WORKSHOPS_URL = 'http://localhost:5050/api/workshops';  
const API_COLABORADORES_URL = 'http://localhost:5050/api/colaboradores';  

let workshops = [];
let colaboradores = [];


btnWorkshops.onclick = () => {
  document.getElementById('workshopsSection').style.display = 'block';
  document.getElementById('colaboradoresSection').style.display = 'none';
  workshopDetails.style.display = 'none'; 
  loadWorkshops();  
};

btnColaboradores.onclick = () => {
  document.getElementById('colaboradoresSection').style.display = 'block';
  document.getElementById('workshopsSection').style.display = 'none';
  workshopDetails.style.display = 'none';  
  loadColaboradores();  
};


function loadWorkshops() {
  
  if (workshops.length > 0) {
    return;  
  }

  fetch(API_WORKSHOPS_URL)
    .then(response => response.json())  
    .then(data => {
      workshops = data;
      tbodyWorkshops.innerHTML = '';  
      workshops.forEach(workshop => {
        insertWorkshop(workshop);  
      });
    })
    .catch(error => {
      console.error('Erro ao carregar workshops:', error);
      document.getElementById('workshopsSection').innerHTML = 'Erro ao carregar workshops. Tente novamente mais tarde.';
    });
}


function loadColaboradores() {
  fetch(API_COLABORADORES_URL)
    .then(response => response.json()) 
    .then(data => {
      colaboradores = data;
      tbodyColaboradores.innerHTML = ''; 
      colaboradores.forEach(colaborador => {
        insertColaborador(colaborador);  
      });
    })
    .catch(error => {
      console.error('Erro ao carregar colaboradores:', error);
      document.getElementById('colaboradoresSection').innerHTML = 'Erro ao carregar colaboradores. Tente novamente mais tarde.';
    });
}


function insertWorkshop(workshop) {
  let tr = document.createElement('tr');
  tr.innerHTML = `
    <td>${workshop.id}</td>
    <td><a href="#" onclick="showWorkshopDetails(${workshop.id})">${workshop.nome}</a></td>
    <td>${workshop.dataRealizacao}</td>
    <td>${workshop.descricao}</td>
    <td>${workshop.participantes ? workshop.participantes.join(', ') : 'Nenhum participante'}</td> <!-- Lista de participantes -->
  `;
  tbodyWorkshops.appendChild(tr);
}


function insertColaborador(colaborador) {
  let tr = document.createElement('tr');
  
  
  const workshopsParticipados = workshops.filter(workshop => 
    workshop.participantes && workshop.participantes.includes(colaborador.nome)
  );
  
 
  const workshopsList = workshopsParticipados.length > 0 
    ? workshopsParticipados.map(workshop => workshop.nome).join(', ') 
    : 'Nenhum workshop';

  tr.innerHTML = `
    <td>${colaborador.id}</td>
    <td>${colaborador.nome}</td>
    <td>${colaborador.email}</td>
    <td>${workshopsList}</td> <!-- Lista de workshops que o colaborador participou -->
  `;
  
  tbodyColaboradores.appendChild(tr);
}


function showWorkshopDetails(workshopId) {
  const workshop = workshops.find(w => w.id === workshopId);

  workshopDetails.style.display = 'block';

  detailsContent.innerHTML = `
    <h3>${workshop.nome}</h3>
    <p><strong>Data de Realização:</strong> ${workshop.dataRealizacao}</p>
    <p><strong>Descrição:</strong> ${workshop.descricao}</p>
    <p><strong>Participantes:</strong> ${workshop.participantes ? workshop.participantes.join(', ') : 'Nenhum participante'}</p>
    <h4>Colaboradores Presentes:</h4>
    <ul>
      ${workshop.colaboradores.length > 0 ? workshop.colaboradores.map(colabId => {
        const colaborador = colaboradores.find(col => col.id === colabId);
        return colaborador ? `<li>${colaborador.nome} (${colaborador.email})</li>` : '';
      }).join('') : '<li>Nenhum colaborador presente</li>'}
    </ul>
  `;

  generateParticipationCharts(workshop);
}


function generateParticipationCharts(workshop) {
  const participantsCount = workshop.participantes.length;
  

  Highcharts.chart('barChart', {
    chart: {
      type: 'column'
    },
    title: {
      text: 'Participantes por Workshop'
    },
    xAxis: {
      categories: [workshop.nome]
    },
    yAxis: {
      min: 0,
      title: {
        text: 'Número de Participantes'
      }
    },
    series: [{
      name: 'Participantes',
      data: [participantsCount],
      color: '#75c9c9'
    }]
  });

  Highcharts.chart('pieChart', {
    chart: {
      type: 'pie'
    },
    title: {
      text: 'Participantes no Workshop'
    },
    series: [{
      name: 'Participantes',
      data: [
        { name: 'Participantes', y: participantsCount },
        { name: 'Não Participantes', y: 100 - participantsCount }
      ],
      colorByPoint: true
    }]
  });
}
