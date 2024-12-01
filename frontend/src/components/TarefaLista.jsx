import { useState } from 'react'
import TarefaFiltro from './TarefaFiltro'
import TarefaItem from './TarefaItem'

export default function TarefaLista({tarefas, iniciaTarefa, concluiTarefa, editaTarefa, excluiTarefa}) {
  const [filtro, setFiltro] = useState("Todos")

  return (
    <div>
      <h1>Lista de Tarefas</h1>
      <TarefaFiltro filtro={filtro} setFiltro={setFiltro} />      
      <div className="tarefa-list">
        {tarefas
          .filter((tarefa) => 
            filtro === "Todos" ? true : filtro === tarefa.status)
          .map((tarefa) => (
            <TarefaItem
              key={tarefa.id} 
              tarefa={tarefa} 
              iniciaTarefa={iniciaTarefa} 
              concluiTarefa={concluiTarefa}
              editaTarefa={editaTarefa}
              excluiTarefa={excluiTarefa} />
        ))}
      </div>
    </div>
  )
}
