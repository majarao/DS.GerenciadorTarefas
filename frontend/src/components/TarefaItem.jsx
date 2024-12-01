export default function TarefaItem({tarefa, iniciaTarefa, concluiTarefa, editaTarefa, excluiTarefa}) {
  return (
    <div>
      <div className="tarefa">
        <div className="content">
          <p>{tarefa.titulo} - {tarefa.status}</p>
          <p className='descricao'>{tarefa.descricao}</p>
        </div>
        <div>
          <button className="iniciar" onClick={() => iniciaTarefa(tarefa.id)}>Iniciar</button>
          <button className="concluir" onClick={() => concluiTarefa(tarefa.id)}>Concluir</button>
          <button className="editar" onClick={() => editaTarefa(tarefa.id, tarefa.titulo, tarefa.descricao)}>Editar</button>
          <button className="excluir" onClick={() => excluiTarefa(tarefa.id)}>Excluir</button>
        </div>
      </div>
    </div>
  )
}
